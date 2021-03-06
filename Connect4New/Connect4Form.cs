using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Connect4New
{
    public partial class Connect4Form : Form
    {
        #region Private Fields

        private readonly bool _isHost;

        private Game _game;

        private TcpClient _client;

        private Image _colorChosenp1;

        private Image _colorChosenp2;

        private int _currentColumnIndex;

        private bool _imAwaiting = false;

        private bool _isAwaiting = false;

        private BackgroundWorker _messageReceiver = new BackgroundWorker();

        private Socket _socket;

        private List<List<PictureBoxWithLocation>> _pictureBoxGrid;

        #endregion Private Fields

        #region Public Constructors

        public Connect4Form(bool isHost)
        {
            InitializeComponent();
            _game = new Game();
            this._isHost = isHost;
            CheckForIllegalCrossThreadCalls = false;
            pictureBoxTurn.Image = Images.White;
            textBoxMessage.Text = "Add a player and select a color";
            _messageReceiver.DoWork += MessageReceiver_DoWork;
            _messageReceiver.WorkerSupportsCancellation = true;
        }

        #endregion Public Constructors 


        #region Public Delegates

        public delegate void BoardUpdate();

        #endregion Public Delegates


        #region Private Properties

        private string _cbChosenp1
        {
            get
            {
                return cbCuloarePlayer1.GetItemText(cbCuloarePlayer1.SelectedItem);
            }
        }

        private string _cbChosenp2
        {
            get
            {
                return cbCuloarePlayer2.GetItemText(cbCuloarePlayer2.SelectedItem);
            }
        }

        private bool _isMyTurn
        {
            get
            {
                return _isHost ? this._game.Turn == 1 : this._game.Turn != 1;
            }
        }

        private string _player1
        {
            get
            {
                return listBoxPlayer1.GetItemText(listBoxPlayer1.SelectedItem);
            }
        }

        private string _player2
        {
            get
            {
                return listBoxPlayer2.GetItemText(listBoxPlayer2.SelectedItem);
            }
        }

        #endregion Private Properties

        #region Public Methods

        public void StartGame(string p1, string p2)
        {
            _game.InitGame(_game.GetOrAddPlayer(p1), _game.GetOrAddPlayer(p2));
        }
        public void StartConnection(string adressIp, string port)
        {
            TcpListener server = null;

            if (_isHost)
            {
                server = new TcpListener(IPAddress.Parse(adressIp), Convert.ToInt32(port));
                server.Start();
                _socket = server.AcceptSocket();
                label6.Text = "HOST";
                buttonAddPlayer2.Enabled = false;
                cbCuloarePlayer2.Enabled = false;
                listBoxPlayer2.Enabled = false;
                textBoxPlayer2NewName.Enabled = false;
            }
            else
            {
                label6.Text = "CLIENT";
                buttonAddPlayer1.Enabled = false;
                cbCuloarePlayer1.Enabled = false;
                listBoxPlayer1.Enabled = false;
                textBoxPlayer1NewName.Enabled = false;
                try
                {
                    _client = new TcpClient();
                    _client.Connect(IPAddress.Parse(adressIp), Convert.ToInt32(port));
                    _socket = _client.Client;
                    _messageReceiver.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void buttonAddPlayerToFirstList_Click(object sender, EventArgs e)  //Adauga un jucator in lista de afisare din stanga
        {
            string nameToFind = textBoxPlayer1NewName.Text;
            nameToFind = _game.GetOrAddPlayer(nameToFind).Name;
            if (!listBoxPlayer1.Items.Contains(nameToFind))
            {
                listBoxPlayer1.Items.Add(nameToFind);
            }
        }

        private void buttonAddPlayerToSecondList_Click_1(object sender, EventArgs e)  //Adauga un jucator in lista de afisare din dreapta
        {
            string nameToFind = textBoxPlayer2NewName.Text;
            nameToFind = _game.GetOrAddPlayer(nameToFind).Name;
            if (!listBoxPlayer2.Items.Contains(nameToFind))
            {
                listBoxPlayer2.Items.Add(nameToFind);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)//Porneste jocul
        {
            if (_isHost)
            {
                Send($"iStarted:{_player1}-{_cbChosenp1}");
            }
            else
            {
                Send($"iStarted:{_player2}-{_cbChosenp2}");
            }

            _imAwaiting = true;
            // freeze form
            textBoxMessage.Text = "Waiting for the other player to start";
            if (_isAwaiting)
            {
                StartGame(_player1, _player2);
                DrawBoard();
            }

            buttonStart.Enabled = false;
        }

        private void cbCuloarePlayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var colorChosen = GetChosenColor(_cbChosenp1);

            if (colorChosen == _colorChosenp2)
            {
                MessageBox.Show("The other player already chose that color, please choose another.");
                return;
            }

            _colorChosenp1 = colorChosen;
            if (listBoxPlayer1.SelectedItem != null)
            {
                buttonStart.Enabled = true;
            }
        }

        private void cbCuloarePlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var colorChosen = GetChosenColor(_cbChosenp2);

            if (colorChosen == _colorChosenp1)
            {
                MessageBox.Show("The other player already chose that color, please choose another.");
                return;
            }

            _colorChosenp2 = colorChosen;
            if (listBoxPlayer2.SelectedItem != null)
            {
                buttonStart.Enabled = true;
            }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            _currentColumnIndex = ((PictureBoxWithLocation)sender).ColumnIndex;

            if (ValidateMove(_currentColumnIndex) == true)
            {
                MakeMove(_currentColumnIndex);
                FreezeBoard();
                Send($"move:{_currentColumnIndex}");
            }
        }

        private void Connect4Form_Load(object sender, EventArgs e)
        {
            buttonStart.Enabled = false;
        }

        private void DrawBoard()//Deseneaza tabla de joc
        {
            panelGrid.Enabled = true;
            panelGrid.Controls.Clear();

            var lineLenght = _game.Grid[0].Count;
            var columnLenght = _game.Grid.Count;
            var pictureHeight = panelGrid.Size.Height / lineLenght;
            var pictureWidth = panelGrid.Size.Width / columnLenght;
            _pictureBoxGrid = new List<List<PictureBoxWithLocation>>();

            //Construim tabla de joc folosind o lista de coloane de clasa PictureBoxWithState
            for (int columnIndex = 0; columnIndex < columnLenght; columnIndex++)
            {
                var pictureBoxColumn = new List<PictureBoxWithLocation>();//Cream o lista de pictureBox-uri care va fi o coloana din grila

                for (int lineIndex = 0; lineIndex < lineLenght; lineIndex++)
                {
                    //Initializam un obiect de tip PictureBoxWithState cu atributele corespunzatoare
                    var pictureBoxWithLocation = new PictureBoxWithLocation() { LineIndex = lineIndex, ColumnIndex = columnIndex };
                    pictureBoxWithLocation.Image = Images.White;
                    pictureBoxWithLocation.Size = new Size(pictureHeight, pictureWidth);
                    pictureBoxWithLocation.Location = new Point(columnIndex * pictureHeight, lineIndex * pictureWidth);
                    pictureBoxWithLocation.Click += Cell_Click;

                    //Adaugam PictureBoxul la panel
                    panelGrid.Controls.Add(pictureBoxWithLocation);

                    //Adaugam pictureBox-ul la coloana
                    pictureBoxColumn.Add(pictureBoxWithLocation);
                }
                //Adaugam coloana de pictureBox-uri la grila
                _pictureBoxGrid.Add(pictureBoxColumn);
            }

            WritePlayersData();
            textBoxMessage.Text = _game.Player1.Name;
            pictureBoxTurn.Image = _colorChosenp1;

            if (!IsExistingPlayer(_game.Player1.Name))
            {
                listBoxPlayer1.Items.Add(_game.Player1.Name);
            }
            if (!IsExistingPlayer(_game.Player2.Name))
            {
                listBoxPlayer2.Items.Add(_game.Player2.Name);
            }
        }

        private Image GetChosenColor(string color)
        {
            switch (color)
            {
                case "red":
                    {
                        return Images.Red;
                    }
                case "blue":
                    {
                        return Images.Blue;
                    }
                case "green":
                    {
                        return Images.Green;
                    }
                case "orange":
                    {
                        return Images.Orange;
                    }
                case "yellow":
                    {
                        return Images.Yellow;
                    }
                case "violet":
                    {
                        return Images.Violet;
                    }
                case "grey":
                    {
                        return Images.Grey;
                    }
                case "pink":
                    {
                        return Images.Pink;
                    }
            }

            return Images.White;
        }

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
                        _isAwaiting = true;
                        var playerAndColor = splittedString[1].Split('-');
                        if (_isHost)
                        {
                            if (!listBoxPlayer2.Items.Contains(playerAndColor))
                            {
                                listBoxPlayer2.Items.Insert(0, playerAndColor[0]);
                            }
                            this.listBoxPlayer2.SelectedItem = listBoxPlayer2.Items[0];
                            _colorChosenp2 = GetChosenColor(playerAndColor[1]);
                        }
                        else
                        {
                            if (!listBoxPlayer1.Items.Contains(playerAndColor))
                            {
                                listBoxPlayer1.Items.Insert(0, playerAndColor[0]);
                            }
                            this.listBoxPlayer1.SelectedItem = listBoxPlayer1.Items[0];
                            _colorChosenp1 = GetChosenColor(playerAndColor[1]);
                        }

                        if (_imAwaiting)
                        {
                            StartGame(_player1, _player2);
                            if (this.panelGrid.InvokeRequired)
                            {
                                BoardUpdate d = new BoardUpdate(DrawBoard);
                                this.Invoke(d);
                            }
                            else
                            {
                                DrawBoard();
                            }
                        }

                        break;
                    }
                default:
                    break;
            }
        }

        private bool IsExistingPlayer(string playerName)
        {
            return listBoxPlayer1.Items.Contains(playerName) || listBoxPlayer2.Items.Contains(playerName);
        }

        private void ListBoxPlayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCuloarePlayer1.SelectedItem != null)
            {
                buttonStart.Enabled = true;
            }
        }

        private void ListBoxPlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCuloarePlayer2.SelectedItem != null)
            {
                buttonStart.Enabled = true;
            }
        }

        private bool ValidateMove(int currentColumnIndex)
        {
            if (!_isMyTurn)
            {
                MessageBox.Show("Not your turn.");
                return false;
            }

            int currentLineIndex = _game.FindCorrectLine(currentColumnIndex);

            if (currentLineIndex == -1)
            {
                MessageBox.Show(GameStatusMessage.GetInvalidMoveMessage(), "That column is full!");
                return false;
            }
            else
            {
                return true;
            }

        }

        private void MakeMove(int currentColumnIndex)
        {
            int currentLineIndex = _game.UpdateGrid(currentColumnIndex);
            var gameState = _game.GetNextState(_game.Grid[currentColumnIndex][currentLineIndex]);
            UpdateGame(gameState, _game.Grid[currentColumnIndex][currentLineIndex]);
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {

                try
                {
                    ReceiveMessage();
                    UnfreezeBoard();
                }

                catch (System.IO.IOException ex)
                {
                    SocketException socketex = (SocketException)ex.InnerException;
                    switch (socketex.ErrorCode)
                    {
                        case 10054:
                            // server disconnected
                            MessageBox.Show(socketex.Message, "Server disappeared");
                            return;
                        case 10060:
                            // timeout
                            break;
                        default:
                            MessageBox.Show(socketex.Message, "Socket error " + socketex.ErrorCode);
                            return;
                    }
                }
            }
        }

        private void ReceiveMessage()
        {
            byte[] buffer = new byte[_socket.ReceiveBufferSize];
            int bytesRead = _socket.Receive(buffer, _socket.ReceiveBufferSize, SocketFlags.None);
            string opponentsMove = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);
            InterpretMessage(opponentsMove);
        }

        private void Send(string msg)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(msg);
            _socket.Send(buffer, buffer.Length, SocketFlags.None);

            if (!_messageReceiver.IsBusy)      // ASTA FACE SA NU MAI APARA EXCEPTIA 
            {
                _messageReceiver.RunWorkerAsync();

            }
        }

        private void FreezeBoard()
        {
            panelGrid.Enabled = false;
        }

        private void UnfreezeBoard()
        {
            panelGrid.Enabled = true;
        }

        private void AfterGameReset()
        {
            _imAwaiting = false;
            _isAwaiting = false;
            buttonStart.Enabled = true;
        }

        private void UpdateDraw(Connect4Cell cell)
        {
            _pictureBoxGrid[cell.ColumnIndex][cell.LineIndex].Image = cell.State == 1 ? _colorChosenp1 : _colorChosenp2;
        }

        private void UpdateGame(State state, Connect4Cell cell)
        {
            switch (state)
            {
                case State.TurnPlayer1:
                    {
                        UpdateDraw(cell);
                        textBoxMessage.Text = _game.Player1.Name;
                        pictureBoxTurn.Image = _colorChosenp1;
                        break;
                    }
                case State.TurnPlayer2:
                    {
                        UpdateDraw(cell);
                        textBoxMessage.Text = _game.Player2.Name;
                        pictureBoxTurn.Image = _colorChosenp2;
                        break;
                    }
                case State.WinPlayer1:
                    {
                        UpdateDraw(cell);
                        textBoxMessage.Text = GameStatusMessage.GetWin(_game.Player1.Name);
                        WritePlayersData();
                        FreezeBoard();
                        if (_isHost)
                        {
                            MessageBox.Show($"Congratulations, you won {_game.Player1.Name}", "WINNER");
                        }
                        else
                        {
                            MessageBox.Show($"Aww no, you lost {_game.Player2.Name}", "LOSER");
                        }
                        AfterGameReset();
                        break;
                    }
                case State.WinPlayer2:
                    {
                        UpdateDraw(cell);
                        textBoxMessage.Text = GameStatusMessage.GetWin(_game.Player2.Name);
                        WritePlayersData();
                        FreezeBoard();
                        if (_isHost)
                        {
                            MessageBox.Show($"Aww no, you lost {_game.Player1.Name}", "LOSER");
                        }
                        else
                        {
                            MessageBox.Show($"Congratulations, you won {_game.Player2.Name}", "WINNER");
                        }
                        AfterGameReset();
                        break;
                    }
                case State.Draw:
                    {
                        UpdateDraw(cell);
                        WritePlayersData();
                        MessageBox.Show(GameStatusMessage.GetDraw());
                        FreezeBoard();
                        AfterGameReset();
                        break;
                    }
            }
        }

        private void WritePlayersData()
        {
            textBoxPlayer1Name.Text = _game.Player1.Name;
            textBoxPlayer2Name.Text = _game.Player2.Name;
            textBoxPlayer1Matches.Text = Convert.ToString(_game.Player1.Statistics.Matches);
            textBoxPlayer1Victories.Text = Convert.ToString(_game.Player1.Statistics.Victories);
            textBoxPlayer2Matches.Text = Convert.ToString(_game.Player2.Statistics.Matches);
            textBoxPlayer2Victories.Text = Convert.ToString(_game.Player2.Statistics.Victories);
        }


        #endregion Private Methods

    }
}