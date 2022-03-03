using System;
using System.Windows.Forms;

namespace Connect4New
{
    public partial class StartupForm : Form
    {
        #region Public Constructors

        public StartupForm()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        private void connectbtn_Click(object sender, EventArgs e)
        {
            Hide();
            Connect4Form newForm = new Connect4Form(isHostCheckBox.Checked);
            newForm.StartConnection(textBoxIP.Text, textBoxPort.Text);
            newForm.ShowDialog();   ///// catch exception cand nu reuseste sa se conecteze
        }

        #endregion Private Methods
    }
}