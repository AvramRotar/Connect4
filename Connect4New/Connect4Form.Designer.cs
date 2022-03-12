namespace Connect4New
{
    partial class Connect4Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelGrid = new System.Windows.Forms.Panel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.pictureBoxTurn = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPlayer1NewName = new System.Windows.Forms.TextBox();
            this.textBoxPlayer1Matches = new System.Windows.Forms.TextBox();
            this.textBoxPlayer1Victories = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2Victories = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2Matches = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2NewName = new System.Windows.Forms.TextBox();
            this.listBoxPlayer1 = new System.Windows.Forms.ListBox();
            this.listBoxPlayer2 = new System.Windows.Forms.ListBox();
            this.buttonAddPlayer1 = new System.Windows.Forms.Button();
            this.buttonAddPlayer2 = new System.Windows.Forms.Button();
            this.textBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.textBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.cbCuloarePlayer1 = new System.Windows.Forms.ComboBox();
            this.cbCuloarePlayer2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxDebugMode = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTurn)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGrid
            // 
            this.panelGrid.Location = new System.Drawing.Point(186, 91);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(437, 355);
            this.panelGrid.TabIndex = 0;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(335, 45);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(143, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start New Game";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Bold);
            this.textBoxMessage.Location = new System.Drawing.Point(186, 447);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ReadOnly = true;
            this.textBoxMessage.Size = new System.Drawing.Size(437, 35);
            this.textBoxMessage.TabIndex = 6;
            // 
            // pictureBoxTurn
            // 
            this.pictureBoxTurn.Location = new System.Drawing.Point(384, 492);
            this.pictureBoxTurn.Name = "pictureBoxTurn";
            this.pictureBoxTurn.Size = new System.Drawing.Size(51, 50);
            this.pictureBoxTurn.TabIndex = 7;
            this.pictureBoxTurn.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(28, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Matches";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(27, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Victories";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(638, 376);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Victories";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(639, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 19);
            this.label9.TabIndex = 14;
            this.label9.Text = "Matches";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(639, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 19);
            this.label10.TabIndex = 13;
            this.label10.Text = "Name";
            // 
            // textBoxPlayer1NewName
            // 
            this.textBoxPlayer1NewName.Location = new System.Drawing.Point(186, 65);
            this.textBoxPlayer1NewName.Name = "textBoxPlayer1NewName";
            this.textBoxPlayer1NewName.Size = new System.Drawing.Size(75, 20);
            this.textBoxPlayer1NewName.TabIndex = 18;
            // 
            // textBoxPlayer1Matches
            // 
            this.textBoxPlayer1Matches.Location = new System.Drawing.Point(105, 349);
            this.textBoxPlayer1Matches.Name = "textBoxPlayer1Matches";
            this.textBoxPlayer1Matches.ReadOnly = true;
            this.textBoxPlayer1Matches.Size = new System.Drawing.Size(65, 20);
            this.textBoxPlayer1Matches.TabIndex = 20;
            // 
            // textBoxPlayer1Victories
            // 
            this.textBoxPlayer1Victories.Location = new System.Drawing.Point(105, 375);
            this.textBoxPlayer1Victories.Name = "textBoxPlayer1Victories";
            this.textBoxPlayer1Victories.ReadOnly = true;
            this.textBoxPlayer1Victories.Size = new System.Drawing.Size(65, 20);
            this.textBoxPlayer1Victories.TabIndex = 21;
            // 
            // textBoxPlayer2Victories
            // 
            this.textBoxPlayer2Victories.Location = new System.Drawing.Point(717, 375);
            this.textBoxPlayer2Victories.Name = "textBoxPlayer2Victories";
            this.textBoxPlayer2Victories.ReadOnly = true;
            this.textBoxPlayer2Victories.Size = new System.Drawing.Size(65, 20);
            this.textBoxPlayer2Victories.TabIndex = 26;
            // 
            // textBoxPlayer2Matches
            // 
            this.textBoxPlayer2Matches.Location = new System.Drawing.Point(717, 349);
            this.textBoxPlayer2Matches.Name = "textBoxPlayer2Matches";
            this.textBoxPlayer2Matches.ReadOnly = true;
            this.textBoxPlayer2Matches.Size = new System.Drawing.Size(65, 20);
            this.textBoxPlayer2Matches.TabIndex = 25;
            // 
            // textBoxPlayer2NewName
            // 
            this.textBoxPlayer2NewName.Location = new System.Drawing.Point(548, 65);
            this.textBoxPlayer2NewName.Name = "textBoxPlayer2NewName";
            this.textBoxPlayer2NewName.Size = new System.Drawing.Size(75, 20);
            this.textBoxPlayer2NewName.TabIndex = 23;
            // 
            // listBoxPlayer1
            // 
            this.listBoxPlayer1.BackColor = System.Drawing.Color.White;
            this.listBoxPlayer1.FormattingEnabled = true;
            this.listBoxPlayer1.Location = new System.Drawing.Point(41, 32);
            this.listBoxPlayer1.Name = "listBoxPlayer1";
            this.listBoxPlayer1.Size = new System.Drawing.Size(129, 95);
            this.listBoxPlayer1.TabIndex = 27;
            this.listBoxPlayer1.SelectedIndexChanged += new System.EventHandler(this.ListBoxPlayer1_SelectedIndexChanged);
            // 
            // listBoxPlayer2
            // 
            this.listBoxPlayer2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listBoxPlayer2.FormattingEnabled = true;
            this.listBoxPlayer2.Location = new System.Drawing.Point(643, 32);
            this.listBoxPlayer2.Name = "listBoxPlayer2";
            this.listBoxPlayer2.Size = new System.Drawing.Size(139, 95);
            this.listBoxPlayer2.TabIndex = 28;
            this.listBoxPlayer2.SelectedIndexChanged += new System.EventHandler(this.ListBoxPlayer2_SelectedIndexChanged);
            // 
            // buttonAddPlayer1
            // 
            this.buttonAddPlayer1.Location = new System.Drawing.Point(186, 36);
            this.buttonAddPlayer1.Name = "buttonAddPlayer1";
            this.buttonAddPlayer1.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPlayer1.TabIndex = 29;
            this.buttonAddPlayer1.Text = "Add player";
            this.buttonAddPlayer1.UseVisualStyleBackColor = true;
            this.buttonAddPlayer1.Click += new System.EventHandler(this.buttonAddPlayerToFirstList_Click);
            // 
            // buttonAddPlayer2
            // 
            this.buttonAddPlayer2.Location = new System.Drawing.Point(548, 36);
            this.buttonAddPlayer2.Name = "buttonAddPlayer2";
            this.buttonAddPlayer2.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPlayer2.TabIndex = 30;
            this.buttonAddPlayer2.Text = "Add player";
            this.buttonAddPlayer2.UseVisualStyleBackColor = true;
            this.buttonAddPlayer2.Click += new System.EventHandler(this.buttonAddPlayerToSecondList_Click_1);
            // 
            // textBoxPlayer1Name
            // 
            this.textBoxPlayer1Name.Location = new System.Drawing.Point(105, 323);
            this.textBoxPlayer1Name.Name = "textBoxPlayer1Name";
            this.textBoxPlayer1Name.ReadOnly = true;
            this.textBoxPlayer1Name.Size = new System.Drawing.Size(65, 20);
            this.textBoxPlayer1Name.TabIndex = 31;
            // 
            // textBoxPlayer2Name
            // 
            this.textBoxPlayer2Name.Location = new System.Drawing.Point(717, 323);
            this.textBoxPlayer2Name.Name = "textBoxPlayer2Name";
            this.textBoxPlayer2Name.ReadOnly = true;
            this.textBoxPlayer2Name.Size = new System.Drawing.Size(65, 20);
            this.textBoxPlayer2Name.TabIndex = 32;
            // 
            // cbCuloarePlayer1
            // 
            this.cbCuloarePlayer1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbCuloarePlayer1.FormattingEnabled = true;
            this.cbCuloarePlayer1.Items.AddRange(new object[] {
            "blue",
            "red",
            "green",
            "grey",
            "orange",
            "yellow",
            "violet",
            "pink"});
            this.cbCuloarePlayer1.Location = new System.Drawing.Point(41, 192);
            this.cbCuloarePlayer1.Name = "cbCuloarePlayer1";
            this.cbCuloarePlayer1.Size = new System.Drawing.Size(120, 21);
            this.cbCuloarePlayer1.TabIndex = 33;
            this.cbCuloarePlayer1.SelectedIndexChanged += new System.EventHandler(this.cbCuloarePlayer1_SelectedIndexChanged);
            // 
            // cbCuloarePlayer2
            // 
            this.cbCuloarePlayer2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbCuloarePlayer2.FormattingEnabled = true;
            this.cbCuloarePlayer2.Items.AddRange(new object[] {
            "blue",
            "red",
            "green",
            "grey",
            "orange",
            "yellow",
            "violet",
            "pink"});
            this.cbCuloarePlayer2.Location = new System.Drawing.Point(654, 192);
            this.cbCuloarePlayer2.Name = "cbCuloarePlayer2";
            this.cbCuloarePlayer2.Size = new System.Drawing.Size(120, 21);
            this.cbCuloarePlayer2.TabIndex = 34;
            this.cbCuloarePlayer2.SelectedIndexChanged += new System.EventHandler(this.cbCuloarePlayer2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Choose your Color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(669, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Choose your Color";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "label6";
            // 
            // checkBoxDebugMode
            // 
            this.checkBoxDebugMode.AutoSize = true;
            this.checkBoxDebugMode.Location = new System.Drawing.Point(357, 10);
            this.checkBoxDebugMode.Name = "checkBoxDebugMode";
            this.checkBoxDebugMode.Size = new System.Drawing.Size(88, 17);
            this.checkBoxDebugMode.TabIndex = 39;
            this.checkBoxDebugMode.Text = "Debug Mode";
            this.checkBoxDebugMode.UseVisualStyleBackColor = true;
            // 
            // Connect4Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 554);
            this.Controls.Add(this.checkBoxDebugMode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCuloarePlayer2);
            this.Controls.Add(this.cbCuloarePlayer1);
            this.Controls.Add(this.textBoxPlayer2Name);
            this.Controls.Add(this.textBoxPlayer1Name);
            this.Controls.Add(this.buttonAddPlayer2);
            this.Controls.Add(this.buttonAddPlayer1);
            this.Controls.Add(this.listBoxPlayer2);
            this.Controls.Add(this.listBoxPlayer1);
            this.Controls.Add(this.textBoxPlayer2Victories);
            this.Controls.Add(this.textBoxPlayer1Victories);
            this.Controls.Add(this.textBoxPlayer2Matches);
            this.Controls.Add(this.textBoxPlayer1Matches);
            this.Controls.Add(this.textBoxPlayer2NewName);
            this.Controls.Add(this.textBoxPlayer1NewName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxTurn);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.panelGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Connect4Form";
            this.Text = "CONNECT 4  ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Connect4Form_FormClosing);
            this.Load += new System.EventHandler(this.Connect4Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTurn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.PictureBox pictureBoxTurn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPlayer1NewName;
        private System.Windows.Forms.TextBox textBoxPlayer1Matches;
        private System.Windows.Forms.TextBox textBoxPlayer1Victories;
        private System.Windows.Forms.TextBox textBoxPlayer2Victories;
        private System.Windows.Forms.TextBox textBoxPlayer2Matches;
        private System.Windows.Forms.TextBox textBoxPlayer2NewName;
        private System.Windows.Forms.ListBox listBoxPlayer1;
        private System.Windows.Forms.ListBox listBoxPlayer2;
        private System.Windows.Forms.Button buttonAddPlayer1;
        private System.Windows.Forms.Button buttonAddPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer1Name;
        private System.Windows.Forms.TextBox textBoxPlayer2Name;
        private System.Windows.Forms.ComboBox cbCuloarePlayer1;
        private System.Windows.Forms.ComboBox cbCuloarePlayer2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxDebugMode;
    }
}

