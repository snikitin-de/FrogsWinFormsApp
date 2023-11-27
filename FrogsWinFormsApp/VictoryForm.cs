namespace FrogsWinFormsApp
{
    public partial class VictoryForm : Form
    {
        public VictoryForm()
        {
            InitializeComponent();
        }

        private void VictoryForm_Load(object sender, EventArgs e)
        {
            if (MainForm.JumpCount == 24)
            {
                VictoryLabel.Text = "Вы выиграли за минимальное количество шагов!";
            }
            else
            {
                VictoryLabel.Text = "Вы выиграли за не минимальное количество шагов! Попробуйте еще раз!";
            }
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
