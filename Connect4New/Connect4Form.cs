using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using SimpleTCP;
using System.Net.NetworkInformation;

namespace Connect4New
{
    public partial class Connect4Form : Form
    {
        #region globals
        private Image white = Image.FromFile("WHITE.png");
        private Image green = Image.FromFile("GREEN.png");
        private Image blue = Image.FromFile("BLUE.png");
        private Image orange = Image.FromFile("ORANGE.png");
        private Image pink = Image.FromFile("PINK.png");
        private Image yellow = Image.FromFile("YELLOW.png");
        private Image red = Image.FromFile("RED.png");
        private Image grey = Image.FromFile("GREY.png");
        private Image violet = Image.FromFile("VIOLET.png");
        string cbChosenp1;
        string cbChosenp2;
        Image colorChosenp1;
        Image colorChosenp2;
        private int currentColumnIndex;

        private GameBoard board;
        private List<List<PictureBoxWithLocation>> pictureBoxGrid;
        private readonly bool isHost;
        private bool isMyTurn { get { return isHost ? this.board?.Game.Turn == 1 : this.board?.Game.Turn != 1; } }

        // Playerii selectati
        private string p1;
        private string p2;

        private bool imAwaiting = false;
        private bool isAwaiting = false;

        //connection globals
        private TcpClient client;

        BackgroundWorker MessageReceiver = new BackgroundWorker();

        #endregion

        public Connect4Form(bool isHost)   //Initializari la crearea form-ului
        {
            InitializeComponent();
            board = new GameBoard();
            this.isHost = isHost;
            CheckForIllegalCrossThreadCalls = false;
            pictureBoxTurn.Image = white;
            textBoxMessage.Text = "Add a player and select a color";
            MessageReceiver.DoWork += MessageReceiver_DoWork;
        }


        public void StartConnection(string adressIp, string port)
        {
            TcpListener server = null;
            

            if (isHost)
            {
                server = new TcpListener(IPAddress.Parse(adressIp), Convert.ToInt32(port));
                server.Start();
                client = server.AcceptTcpClient();
                label6.Text = "HOST";
                button1.Enabled = false;
                cbCuloarePlayer2.Enabled = false;
                listBoxPlayer2.Enabled = false;
                textBoxPlayer2NewName.Enabled = false;
                MessageReceiver.RunWorkerAsync();
            }
            else
            {
                label6.Text = "CLIENT";
                buttonAddPlayer.Enabled = false;
                cbCuloarePlayer1.Enabled = false;
                listBoxPlayer1.Enabled = false;
                textBoxPlayer1NewName.Enabled = false;
                try
                {
                    client = new TcpClient();
                    client.Connect(IPAddress.Parse(adressIp), Convert.ToInt32(port));
                    MessageReceiver.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            ReceiveMessage();
            UnfreezeBoard();
        }

        private void FreezeBoard()
        {
            panelGrid.Enabled = false;
        }

        private void UnfreezeBoard()
        {
            panelGrid.Enabled = true;
        }

        public delegate void BoardUpdate();

        private void InterpretMessage(string message)
        {
            var splittedString = message.Split(':');
            switch (splittedString[0])
            {
                case "move":
                    {
                        var columnIndex = Convert.ToInt32(splittedString[1]);
                        MakeMove(columnIndex);
                        UnfreezeBoard();
                        break;
                    }

                case "iStarted":
                    {
                        isAwaiting = true;
                        var playerAndColor = splittedString[1].Split('-');
                        if (isHost)
                        {
                            p2 = playerAndColor[0];
                            listBoxPlayer2.Items.Add(p2);
                            this.listBoxPlayer2.SelectedItem = listBoxPlayer2.Items[0];
                            cbChosenp2 = playerAndColor[1];  /// do all the operations
                            colorChosenp2 = GetChosenColor(cbChosenp2);
                        }
                        else
                        {
                            p1 = playerAndColor[0];
                            listBoxPlayer1.Items.Add(p1);
                            this.listBoxPlayer1.SelectedItem = listBoxPlayer1.Items[0];
                            cbChosenp1 = playerAndColor[1];
                            colorChosenp1 = GetChosenColor(cbChosenp1);
                        }

                        if (imAwaiting)
                        {
                           // board.StartGame(p1, p2);
                            if (this.panelGrid.InvokeRequired)
                            {
                                BoardUpdate d = new BoardUpdate(DrawBoard);
                                this.Invoke(d);
                            }
                            else
                            {
                                board.StartGame(p1, p2);
                                DrawBoard();
                            }
                        }
                        break;
                    }
                default:
                break;
            }
        }

        private void ReceiveMessage()
        {
            NetworkStream networkStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];
            int bytesRead = networkStream.Read(buffer, 0, client.ReceiveBufferSize);
            string opponentsMove = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);
            InterpretMessage(opponentsMove);
        }

        void Send(string msg)  
        {
                NetworkStream networkStream = client.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes(msg);
                networkStream.Write(buffer, 0, buffer.Length);
                networkStream.Flush();
        }

        private void buttonAddPlayerToFirstList_Click(object sender, EventArgs e)  //Adauga un jucator in lista de afisare din stanga
        {
            string nameToFind = textBoxPlayer1NewName.Text;
            nameToFind = board.GetOrAddPlayer(nameToFind).Name;
            if (!listBoxPlayer1.Items.Contains(nameToFind))
            {
                listBoxPlayer1.Items.Add(nameToFind);
            }
        }

        private void buttonAddPlayerToSecondList_Click_1(object sender, EventArgs e)  //Adauga un jucator in lista de afisare din dreapta
        {
            string nameToFind = textBoxPlayer2NewName.Text;
            nameToFind = board.GetOrAddPlayer(nameToFind).Name;
            if (!listBoxPlayer2.Items.Contains(nameToFind))
            {
                listBoxPlayer2.Items.Add(nameToFind);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)//Porneste jocul
        {
            if (isHost)
            {
                Send($"iStarted:{p1}-{cbChosenp1}");
            }
            else 
            {
                Send($"iStarted:{p2}-{cbChosenp2}");
            } 

            imAwaiting = true;
            // freeze form 
            textBoxMessage.Text ="Waiting for the other player to start";            
            if(isAwaiting) 
            {
                board.StartGame(p1,p2);
                DrawBoard(); 
            }
            
        }

        private bool IsExistingPlayer(string playerName)
        {
            return listBoxPlayer1.Items.Contains(playerName) || listBoxPlayer2.Items.Contains(playerName);
        }

        private void DrawBoard()//Deseneaza tabla de joc
        {
            panelGrid.Enabled = true;
            panelGrid.Controls.Clear();

            #region initialize values for grid

            int lineLenght = board.Game.Grid[0].Count;
            int columnLenght = board.Game.Grid.Count;
            int pictureHeight = panelGrid.Size.Height / lineLenght;
            int pictureWidth = panelGrid.Size.Width / columnLenght;
            pictureBoxGrid = new List<List<PictureBoxWithLocation>>();

            #endregion

            //Construim tabla de joc folosind o lista de coloane de clasa PictureBoxWithState
            for (int columnIndex = 0; columnIndex < columnLenght; columnIndex++)
            {
                var pictureBoxColumn = new List<PictureBoxWithLocation>();//Cream o lista de pictureBox-uri care va fi o coloana din grila

                for (int lineIndex = 0; lineIndex < lineLenght; lineIndex++)
                {
                    PictureBoxWithLocation pictureBoxWithLocation;

                    //Initializam un obiect de tip PictureBoxWithState cu atributele corespunzatoare
                    pictureBoxWithLocation = new PictureBoxWithLocation() { LineIndex = lineIndex, ColumnIndex = columnIndex };
                    pictureBoxWithLocation.Image = white;
                    pictureBoxWithLocation.Size = new Size(pictureHeight, pictureWidth);
                    pictureBoxWithLocation.Location = new Point(columnIndex * pictureHeight, lineIndex * pictureWidth);  //??? PH e 59 pw e 62 
                    pictureBoxWithLocation.Click += Cell_Click;

                    //Adaugam PictureBoxul la panel
                    panelGrid.Controls.Add(pictureBoxWithLocation);

                    //Adaugam pictureBox-ul la coloana
                    pictureBoxColumn.Add(pictureBoxWithLocation);
                }
                //Adaugam coloana de pictureBox-uri la grila
                pictureBoxGrid.Add(pictureBoxColumn);
            }
            WritePlayersData();
            textBoxMessage.Text = board.Game.player1.Name;
            pictureBoxTurn.Image = colorChosenp1;

            if (!IsExistingPlayer(board.Game.player1.Name))
            {
                listBoxPlayer1.Items.Add(board.Game.player1.Name);
            }
            if (!IsExistingPlayer(board.Game.player2.Name))
            {
                listBoxPlayer2.Items.Add(board.Game.player2.Name);
            }
        }

        private void WritePlayersData()//Scrie datele jucatorilor in casutele corespunzatoare
        {
            textBoxPlayer1Name.Text = board.Game.player1.Name;
            textBoxPlayer2Name.Text = board.Game.player2.Name;
            textBoxPlayer1Matches.Text = Convert.ToString(board.Game.player1.Matches);
            textBoxPlayer1Victories.Text = Convert.ToString(board.Game.player1.Victories);
            textBoxPlayer2Matches.Text = Convert.ToString(board.Game.player2.Matches);
            textBoxPlayer2Victories.Text = Convert.ToString(board.Game.player2.Victories);
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (!isMyTurn)  //trebuie facut un check corect cu Turn.
            {
                MessageBox.Show("Not my turn");
                return;
            }

            currentColumnIndex = ((PictureBoxWithLocation)sender).ColumnIndex;
            FreezeBoard();
            Send($"move:{currentColumnIndex}");
            MakeMove(currentColumnIndex);
            MessageReceiver.RunWorkerAsync();
        }

        private void MakeMove(int currentColumnIndex)
        {
            int currentLineIndex = board.Game.UpdateGrid(currentColumnIndex);
            if (currentLineIndex == -1)
            {
                MessageBox.Show(GameStatusMessage.GetInvalidMoveMessage(), "That column is full!");
            }
            else
            {
                State gameState = board.Game.GetNextState(board.Game.Grid[currentColumnIndex][currentLineIndex]);
                UpdateGame(gameState, board.Game.Grid[currentColumnIndex][currentLineIndex]);
            }
        }

        private void UpdateGame(State state, Cell cell)
        {
            switch (state)
            {
                case State.turnPlayer1:
                    {
                        UpdateDraw(cell);
                        textBoxMessage.Text = board.Game.player1.Name;
                        pictureBoxTurn.Image = colorChosenp1;
                        break;
                    }
                case State.turnPlayer2:
                    {
                        UpdateDraw(cell);
                        textBoxMessage.Text = board.Game.player2.Name;
                        pictureBoxTurn.Image = colorChosenp2;
                        break;
                    }
                case State.winPlayer1:
                    {
                        UpdateDraw(cell);
                        textBoxMessage.Text = GameStatusMessage.GetWin(board.Game.player1.Name);
                        WritePlayersData();
                        panelGrid.Enabled = false;
                        MessageBox.Show("Congratulations, you won " + board.Game.player1.Name, "WINNER");
                        break;
                    }
                case State.winPlayer2:
                    {
                        UpdateDraw(cell);
                        textBoxMessage.Text = GameStatusMessage.GetWin(board.Game.player2.Name);
                        WritePlayersData();
                        panelGrid.Enabled = false;
                        MessageBox.Show("Congratulations, you won " + board.Game.player2.Name, "WINNER");
                        break;
                    }
                case State.draw:
                    {
                        UpdateDraw(cell);
                        WritePlayersData();
                        MessageBox.Show(GameStatusMessage.GetDraw());
                        panelGrid.Enabled = false;
                        break;
                    }
            }
        }

        private void UpdateDraw(Cell cell)//Modifica imaginea din celula curenta in functie de state-ul acesteia
        {
            pictureBoxGrid[cell.ColumnIndex][cell.LineIndex].Image = cell.State == 1 ? colorChosenp1 : colorChosenp2;
        }

        private void Connect4Form_Load(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
        }

        private void cbCuloarePlayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbChosenp1 = cbCuloarePlayer1.SelectedItem.ToString();
            var colorChosen = GetChosenColor(cbChosenp1);

            if (colorChosen == colorChosenp2)
            {
                MessageBox.Show("The other player already chose that color, please choose another.");
                return;
            }

            colorChosenp1 = GetChosenColor(cbChosenp1);

            if (listBoxPlayer1.SelectedItem != null)
            {
                buttonStart.Enabled = true;
            }
        }

        public void cbCuloarePlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbChosenp2 = cbCuloarePlayer2.SelectedItem.ToString();
            var colorChosen = GetChosenColor(cbChosenp2);

            if (colorChosen == colorChosenp1)
            {
                MessageBox.Show("The other player already chose that color, please choose another.");
                return;
            }

            colorChosenp2 = GetChosenColor(cbChosenp2);

            if (listBoxPlayer2.SelectedItem != null)
            {
                buttonStart.Enabled = true;
            }
        }

        private Image GetChosenColor(string culoare)
        {
            switch (culoare)
            {
                case "red":
                    {
                        return red;
                    }
                case "blue":
                    {
                        return blue;
                    }
                case "green":
                    {
                        return green;
                    }
                case "orange":
                    {
                        return orange;
                    }
                case "yellow":
                    {
                        return yellow;
                    }
                case "violet":
                    {
                        return violet;
                    }
                case "grey":
                    {
                        return grey;
                    }
                case "pink":
                    {
                        return pink;
                    }
            }

            MessageBox.Show("You didnt select the right color"); // useless line?
            return white;
        }

        public static void DisplayIPAddresses()
        {
            StringBuilder sb = new StringBuilder();

            // Get a list of all network interfaces (usually one per network card, dialup, and VPN connection)
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface network in networkInterfaces)
            {
                // Read the IP configuration for each network
                IPInterfaceProperties properties = network.GetIPProperties();

                // Each network interface may have multiple IP addresses
                foreach (IPAddressInformation address in properties.UnicastAddresses)
                {
                    // We're only interested in IPv4 addresses for now
                    if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;

                    // Ignore loopback addresses (e.g., 127.0.0.1)
                    if (IPAddress.IsLoopback(address.Address))
                        continue;

                    sb.AppendLine(address.Address.ToString() + " (" + network.Name + ")");
                }
            }
            MessageBox.Show(sb.ToString());
        }

        private void listBoxPlayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1 = listBoxPlayer1.GetItemText(listBoxPlayer1.SelectedItem);
            if (cbCuloarePlayer1.SelectedItem != null)
            {
                buttonStart.Enabled = true;
            }
        }  

        private void listBoxPlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
           p2 = listBoxPlayer2.GetItemText(listBoxPlayer2.SelectedItem);
            if (cbCuloarePlayer2.SelectedItem != null)
            {
                buttonStart.Enabled = true;
            }

        }

    }
}