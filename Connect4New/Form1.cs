using System;
using System.Windows.Forms;

namespace Connect4New
{
    public partial class Form1 : Form
    {
        #region Public Constructors

        public Form1()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Private Methods

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Connect4Form newForm = new Connect4Form(isHostCheckBox.Checked);
            newForm.StartConnection(textBox2.Text, textBox3.Text);
            newForm.ShowDialog();
        }

        #endregion Private Methods
    }
}