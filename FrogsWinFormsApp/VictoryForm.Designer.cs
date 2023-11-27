namespace FrogsWinFormsApp
{
    partial class VictoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VictoryForm));
            VictoryPictureBox = new PictureBox();
            VictoryLabel = new Label();
            buttonYes = new Button();
            buttonNo = new Button();
            ((System.ComponentModel.ISupportInitialize)VictoryPictureBox).BeginInit();
            SuspendLayout();
            // 
            // VictoryPictureBox
            // 
            VictoryPictureBox.Image = Properties.Resources.victoryImage;
            VictoryPictureBox.Location = new Point(214, 12);
            VictoryPictureBox.Name = "VictoryPictureBox";
            VictoryPictureBox.Size = new Size(202, 167);
            VictoryPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            VictoryPictureBox.TabIndex = 0;
            VictoryPictureBox.TabStop = false;
            // 
            // VictoryLabel
            // 
            VictoryLabel.AutoSize = true;
            VictoryLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            VictoryLabel.Location = new Point(44, 214);
            VictoryLabel.Name = "VictoryLabel";
            VictoryLabel.Size = new Size(542, 21);
            VictoryLabel.TabIndex = 1;
            VictoryLabel.Text = "Вы выиграли за не минимальное количество шагов! Попробуйте еще раз!";
            // 
            // buttonYes
            // 
            buttonYes.Location = new Point(174, 258);
            buttonYes.Name = "buttonYes";
            buttonYes.Size = new Size(128, 43);
            buttonYes.TabIndex = 2;
            buttonYes.Text = "Сыграть еще раз";
            buttonYes.UseVisualStyleBackColor = true;
            buttonYes.Click += buttonYes_Click;
            // 
            // buttonNo
            // 
            buttonNo.Location = new Point(308, 258);
            buttonNo.Name = "buttonNo";
            buttonNo.Size = new Size(128, 43);
            buttonNo.TabIndex = 3;
            buttonNo.Text = "Выйти";
            buttonNo.UseVisualStyleBackColor = true;
            buttonNo.Click += buttonNo_Click;
            // 
            // VictoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 313);
            Controls.Add(buttonNo);
            Controls.Add(buttonYes);
            Controls.Add(VictoryLabel);
            Controls.Add(VictoryPictureBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VictoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Лягушки";
            Load += VictoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)VictoryPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox VictoryPictureBox;
        private Label VictoryLabel;
        private Button buttonYes;
        private Button buttonNo;
    }
}