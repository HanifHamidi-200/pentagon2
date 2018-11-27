namespace RYDX
{
    partial class Form1
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
            this.lstRoomsOutput = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstEventsList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnQNext = new System.Windows.Forms.Button();
            this.lblYou = new System.Windows.Forms.Label();
            this.btnGoto1 = new System.Windows.Forms.Button();
            this.btnGoto2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstRoomsOutput
            // 
            this.lstRoomsOutput.FormattingEnabled = true;
            this.lstRoomsOutput.Location = new System.Drawing.Point(116, 83);
            this.lstRoomsOutput.Name = "lstRoomsOutput";
            this.lstRoomsOutput.Size = new System.Drawing.Size(333, 277);
            this.lstRoomsOutput.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(116, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "RoomsOutput";
            // 
            // lstEventsList
            // 
            this.lstEventsList.FormattingEnabled = true;
            this.lstEventsList.Location = new System.Drawing.Point(30, 83);
            this.lstEventsList.Name = "lstEventsList";
            this.lstEventsList.Size = new System.Drawing.Size(69, 277);
            this.lstEventsList.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(30, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "EventsList";
            // 
            // btnQNext
            // 
            this.btnQNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnQNext.Location = new System.Drawing.Point(689, 70);
            this.btnQNext.Name = "btnQNext";
            this.btnQNext.Size = new System.Drawing.Size(99, 90);
            this.btnQNext.TabIndex = 6;
            this.btnQNext.Text = "&QNext";
            this.btnQNext.UseVisualStyleBackColor = false;
            this.btnQNext.Click += new System.EventHandler(this.btnQNext_Click);
            // 
            // lblYou
            // 
            this.lblYou.AutoSize = true;
            this.lblYou.BackColor = System.Drawing.Color.Yellow;
            this.lblYou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblYou.Location = new System.Drawing.Point(490, 83);
            this.lblYou.Name = "lblYou";
            this.lblYou.Size = new System.Drawing.Size(70, 15);
            this.lblYou.TabIndex = 7;
            this.lblYou.Text = "You are on []";
            // 
            // btnGoto1
            // 
            this.btnGoto1.BackColor = System.Drawing.Color.Lime;
            this.btnGoto1.Location = new System.Drawing.Point(490, 110);
            this.btnGoto1.Name = "btnGoto1";
            this.btnGoto1.Size = new System.Drawing.Size(161, 36);
            this.btnGoto1.TabIndex = 8;
            this.btnGoto1.Text = "goto 1";
            this.btnGoto1.UseVisualStyleBackColor = false;
            this.btnGoto1.Click += new System.EventHandler(this.btnGoto1_Click);
            // 
            // btnGoto2
            // 
            this.btnGoto2.BackColor = System.Drawing.Color.Lime;
            this.btnGoto2.Location = new System.Drawing.Point(490, 152);
            this.btnGoto2.Name = "btnGoto2";
            this.btnGoto2.Size = new System.Drawing.Size(161, 36);
            this.btnGoto2.TabIndex = 9;
            this.btnGoto2.Text = "goto 2";
            this.btnGoto2.UseVisualStyleBackColor = false;
            this.btnGoto2.Click += new System.EventHandler(this.btnGoto2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGoto2);
            this.Controls.Add(this.btnGoto1);
            this.Controls.Add(this.lblYou);
            this.Controls.Add(this.btnQNext);
            this.Controls.Add(this.lstEventsList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstRoomsOutput);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "RYDX";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstRoomsOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstEventsList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnQNext;
        private System.Windows.Forms.Label lblYou;
        private System.Windows.Forms.Button btnGoto1;
        private System.Windows.Forms.Button btnGoto2;
    }
}

