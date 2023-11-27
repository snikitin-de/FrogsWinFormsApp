namespace FrogsWinFormsApp
{
    public partial class MainForm : Form
    {
        public static int JumpCount = 0;
        private string leftSideText = "left";
        private string rightSideText = "right";
        private string centerSideText = "center";
        private int startPictureBoxX;
        private int pictureBoxMenuSpaceY;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var mediaPlayer = new MediaPlayer(Properties.Resources.riverSunrise, true);
            mediaPlayer.Play();

            startPictureBoxX = leftFrog1PictureBox.Size.Width;
            pictureBoxMenuSpaceY = mainMenuStrip.Size.Height;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (SwapFrog((PictureBox)sender))
            {
                var mediaPlayer = new MediaPlayer(Properties.Resources.frogJump);
                mediaPlayer.Play();
            }

            if (CheckFrogSide(leftFrog1PictureBox) == rightSideText &&
                CheckFrogSide(leftFrog2PictureBox) == rightSideText &&
                CheckFrogSide(leftFrog3PictureBox) == rightSideText &&
                CheckFrogSide(leftFrog4PictureBox) == rightSideText &&
                CheckFrogSide(emptyWaterLilyPictureBox) == centerSideText)
            {
                var victoryForm = new VictoryForm();
                Hide();
                victoryForm.ShowDialog();
            }
        }

        private bool SwapFrog(PictureBox frog)
        {
            var isSwapped = false;
            var distance = Math.Abs(frog.Location.X - emptyWaterLilyPictureBox.Location.X) / frog.Width;

            if (distance > 2)
            {
                MessageBox.Show("Так двигаться нельзя!");
            }
            else
            {
                var emptyWaterLilyLocation = emptyWaterLilyPictureBox.Location;

                emptyWaterLilyPictureBox.Location = frog.Location;
                frog.Location = emptyWaterLilyLocation;
                isSwapped = true;
                JumpCount++;

                jumpCountLabel.Text = $"Количество прыжков: {JumpCount.ToString()}";
            }

            return isSwapped;
        }

        private string CheckFrogSide(PictureBox frog)
        {
            if (frog.Location.X < frog.Width * 4)
            {
                return leftSideText;
            }
            else if (frog.Location.X > frog.Width * 4)
            {
                return rightSideText;
            }
            else
            {
                return centerSideText;
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leftFrog1PictureBox.Location = new Point(0, pictureBoxMenuSpaceY);
            leftFrog2PictureBox.Location = new Point(startPictureBoxX, pictureBoxMenuSpaceY);
            leftFrog3PictureBox.Location = new Point(startPictureBoxX * 2, pictureBoxMenuSpaceY);
            leftFrog4PictureBox.Location = new Point(startPictureBoxX * 3, pictureBoxMenuSpaceY);
            emptyWaterLilyPictureBox.Location = new Point(startPictureBoxX * 4, pictureBoxMenuSpaceY);
            rightFrog1PictureBox.Location = new Point(startPictureBoxX * 5, pictureBoxMenuSpaceY);
            rightFrog2PictureBox.Location = new Point(startPictureBoxX * 6, pictureBoxMenuSpaceY);
            rightFrog3PictureBox.Location = new Point(startPictureBoxX * 7, pictureBoxMenuSpaceY);
            rightFrog4PictureBox.Location = new Point(startPictureBoxX * 8, pictureBoxMenuSpaceY);

            JumpCount = 0;
            jumpCountLabel.Text = $"Количество прыжков: {JumpCount}";
        }

        private void showRulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Цель игры — расположить лягушек, которые смотрят влево, в левую часть, а остальных - " +
                "в правую часть за минимальное количество перепрыгиваний.\n\nПрыгать можно на листок, если он находится рядом или через 1 лягушку", "Правила");
        }
    }
}