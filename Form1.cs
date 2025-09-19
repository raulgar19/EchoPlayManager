namespace EchoPlayManager
{
    public partial class MainForm : Form
    {
        private SongsForm songsForm;
        private UsersForm usersForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void songsManageBttn_Click(object sender, EventArgs e)
        {
            if (songsForm == null || songsForm.IsDisposed) // si no existe o ya fue cerrada
            {
                songsForm = new SongsForm();
                songsForm.Show();
            }
            else
            {
                songsForm.BringToFront(); // si ya está abierta, traerla al frente
            }
        }

        private void usersManageBttn_Click(object sender, EventArgs e)
        {
            if (usersForm == null || usersForm.IsDisposed) // si no existe o ya fue cerrada
            {
                usersForm = new UsersForm();
                usersForm.Show();
            }
            else
            {
                usersForm.BringToFront(); // si ya está abierta, traerla al frente
            }
        }
    }
}