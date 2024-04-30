namespace E14Hockey
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lvPlayers = new ListView();
            btnCheck = new Button();
            btnShot = new Button();
            btnGoal = new Button();
            btnAssist = new Button();
            BtnEnd = new Button();
            SuspendLayout();
            // 
            // lvPlayers
            // 
            lvPlayers.Location = new Point(12, 12);
            lvPlayers.Name = "lvPlayers";
            lvPlayers.Size = new Size(659, 721);
            lvPlayers.TabIndex = 0;
            lvPlayers.UseCompatibleStateImageBehavior = false;
            // 
            // btnCheck
            // 
            btnCheck.Location = new Point(742, 49);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(94, 29);
            btnCheck.TabIndex = 1;
            btnCheck.Text = "Check";
            btnCheck.UseVisualStyleBackColor = true;
            btnCheck.Click += btnCheck_Click;
            // 
            // btnShot
            // 
            btnShot.Location = new Point(742, 109);
            btnShot.Name = "btnShot";
            btnShot.Size = new Size(94, 29);
            btnShot.TabIndex = 2;
            btnShot.Text = "Shot";
            btnShot.UseVisualStyleBackColor = true;
            btnShot.Click += btnShot_Click;
            // 
            // btnGoal
            // 
            btnGoal.Location = new Point(742, 180);
            btnGoal.Name = "btnGoal";
            btnGoal.Size = new Size(94, 29);
            btnGoal.TabIndex = 3;
            btnGoal.Text = "Goal";
            btnGoal.UseVisualStyleBackColor = true;
            btnGoal.Click += btnGoal_Click;
            // 
            // btnAssist
            // 
            btnAssist.Location = new Point(742, 248);
            btnAssist.Name = "btnAssist";
            btnAssist.Size = new Size(94, 29);
            btnAssist.TabIndex = 4;
            btnAssist.Text = "Assist";
            btnAssist.UseVisualStyleBackColor = true;
            btnAssist.Click += btnAssist_Click;
            // 
            // BtnEnd
            // 
            BtnEnd.Location = new Point(704, 679);
            BtnEnd.Name = "BtnEnd";
            BtnEnd.Size = new Size(169, 54);
            BtnEnd.TabIndex = 5;
            BtnEnd.Text = "Game Ends";
            BtnEnd.UseVisualStyleBackColor = true;
            BtnEnd.Click += BtnEnd_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 0, 64);
            ClientSize = new Size(902, 745);
            Controls.Add(BtnEnd);
            Controls.Add(btnAssist);
            Controls.Add(btnGoal);
            Controls.Add(btnShot);
            Controls.Add(btnCheck);
            Controls.Add(lvPlayers);
            Font = new Font("Calibri", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView lvPlayers;
        private Button btnCheck;
        private Button btnShot;
        private Button btnGoal;
        private Button btnAssist;
        private Button BtnEnd;
    }
}
