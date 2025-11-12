using EchoPlayManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoPlayManager
{
    public partial class UsersForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private string baseUrl = "https://echoplaybackend.onrender.com";
        private string selectedImagePath = null; // Para la modificación

        public UsersForm()
        {
            InitializeComponent();
            LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                statusTextBox.Text = "Cargando usuarios...";
                HttpResponseMessage response = await client.GetAsync($"{baseUrl}/users");
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(json);

                usersDataGridView.Rows.Clear();
                foreach (var user in users)
                {
                    usersDataGridView.Rows.Add(user.Id, user.Name, user.Image);
                }

                statusTextBox.Text = $"Se cargaron {users.Count} usuarios correctamente.";
            }
            catch (Exception ex)
            {
                statusTextBox.Text = "Error al cargar usuarios: " + ex.Message;
            }
        }
        private async void UsersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (usersDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = usersDataGridView.SelectedRows[0];

                // Asignar ID y nombre
                idTextBox.Text = selectedRow.Cells["Id"].Value.ToString();
                nameTextBox.Text = selectedRow.Cells["Name"].Value.ToString();

                // Cargar imagen desde URL
                string imageUrl = selectedRow.Cells["Image"].Value.ToString(); // Asegúrate de que tu columna se llama "Image"
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    try
                    {
                        using (var client = new System.Net.Http.HttpClient())
                        {
                            var imageBytes = await client.GetByteArrayAsync(imageUrl);
                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
                                userPictureBox.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    catch
                    {
                        userPictureBox.Image = null; // Si falla, limpiar la imagen
                    }
                }
                else
                {
                    userPictureBox.Image = null;
                }
            }
        }

        private async void addUserBttn_Click(object sender, EventArgs e)
        {
            // Crear diálogo modal
            using (Form dialog = new Form())
            {
                dialog.Text = "Añadir Usuario";
                dialog.Size = new Size(400, 300);
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.MinimizeBox = false;
                dialog.MaximizeBox = false;

                // Nombre
                Label nameLabel = new Label() { Text = "Nombre:", Location = new Point(20, 20), AutoSize = true };
                TextBox nameBox = new TextBox() { Location = new Point(120, 20), Width = 190 };

                // Imagen
                Label imageLabel = new Label() { Text = "Imagen:", Location = new Point(20, 60) };
                PictureBox imageBox = new PictureBox() { Location = new Point(120, 60), Size = new Size(100, 100), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.StretchImage };
                Button browseBtn = new Button() { Text = "Seleccionar...", Location = new Point(230, 100) };

                string selectedImagePath = null;

                browseBtn.Click += (s, ev) =>
                {
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        ofd.Filter = "Imágenes (*.jpg;*.png)|*.jpg;*.png";
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            selectedImagePath = ofd.FileName;
                            imageBox.Image = Image.FromFile(selectedImagePath);
                        }
                    }
                };

                // Botones Aceptar y Cancelar
                Button okBtn = new Button() { Text = "Aceptar", Location = new Point(100, 200), DialogResult = DialogResult.OK };
                Button cancelBtn = new Button() { Text = "Cancelar", Location = new Point(200, 200), DialogResult = DialogResult.Cancel };

                dialog.Controls.Add(nameLabel);
                dialog.Controls.Add(nameBox);
                dialog.Controls.Add(imageLabel);
                dialog.Controls.Add(imageBox);
                dialog.Controls.Add(browseBtn);
                dialog.Controls.Add(okBtn);
                dialog.Controls.Add(cancelBtn);

                dialog.AcceptButton = okBtn;
                dialog.CancelButton = cancelBtn;

                // Mostrar diálogo
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(nameBox.Text) || string.IsNullOrEmpty(selectedImagePath))
                    {
                        MessageBox.Show("Debes ingresar un nombre y seleccionar una imagen.");
                        return;
                    }

                    try
                    {
                        // Preparar contenido multipart
                        using (var form = new MultipartFormDataContent())
                        {
                            form.Add(new StringContent(nameBox.Text.Trim()), "name");

                            var imageContent = new ByteArrayContent(File.ReadAllBytes(selectedImagePath));
                            imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                            form.Add(imageContent, "image", Path.GetFileName(selectedImagePath));

                            HttpResponseMessage response = await client.PostAsync($"{baseUrl}/users", form);
                            response.EnsureSuccessStatusCode();

                            statusTextBox.Text = "Usuario añadido correctamente.";
                            await LoadUsersAsync(); // refrescar la lista
                        }
                    }
                    catch (Exception ex)
                    {
                        statusTextBox.Text = "Error al añadir usuario: " + ex.Message;
                    }
                }
            }
        }
        private async void deleteBttn_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un usuario para eliminar.");
                return;
            }

            var selectedRow = usersDataGridView.SelectedRows[0];
            string userId = selectedRow.Cells["Id"].Value.ToString();

            var confirm = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar este usuario y todos sus datos relacionados?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    statusTextBox.Text = "Eliminando usuario...";

                    HttpResponseMessage response = await client.DeleteAsync($"{baseUrl}/users/{userId}");
                    response.EnsureSuccessStatusCode();

                    statusTextBox.Text = "Usuario eliminado correctamente.";

                    // Limpiar los controles de la interfaz
                    idTextBox.Clear();
                    nameTextBox.Clear();
                    userPictureBox.Image = null;
                    selectedImagePath = null;

                    // Refrescar la lista
                    await LoadUsersAsync();
                }
                catch (Exception ex)
                {
                    statusTextBox.Text = "Error al eliminar usuario: " + ex.Message;
                }
            }
        }

        private async void modifyBttn_Click(object sender, EventArgs e)
        {
            if (usersDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario para modificar.");
                return;
            }

            var selectedRow = usersDataGridView.SelectedRows[0];
            int userId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string newName = nameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("El nombre no puede estar vacío.");
                return;
            }

            try
            {
                using (var form = new MultipartFormDataContent())
                {
                    form.Add(new StringContent(newName), "name");

                    // Si se cambió la imagen
                    if (userPictureBox.Image != null && !string.IsNullOrEmpty(selectedImagePath))
                    {
                        var imageContent = new ByteArrayContent(File.ReadAllBytes(selectedImagePath));
                        imageContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                        form.Add(imageContent, "image", Path.GetFileName(selectedImagePath));
                    }

                    HttpResponseMessage response = await client.PutAsync($"{baseUrl}/users/{userId}", form);
                    response.EnsureSuccessStatusCode();

                    statusTextBox.Text = "Usuario modificado correctamente.";
                    await LoadUsersAsync(); // refrescar lista
                }
            }
            catch (Exception ex)
            {
                statusTextBox.Text = "Error al modificar usuario: " + ex.Message;
            }
        }
    }
}
