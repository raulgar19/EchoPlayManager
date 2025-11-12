using EchoPlayManager.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoPlayManager
{
    public partial class ApksForm : Form
    {
        private readonly string host = "https://echoplaybackend.onrender.com";
        private readonly HttpClient client = new HttpClient();
        private string selectedApkPath = "";
        private Apk[] apksList; // Guardamos la lista completa para poder acceder por índice

        public ApksForm()
        {
            InitializeComponent();
            LoadApksFromServer();
        }

        private void UpdateStatus(string message)
        {
            statusTxtBox.Text = message;
        }

        private async void LoadApksFromServer()
        {
            dataGridView1.Rows.Clear();
            try
            {
                UpdateStatus("Cargando lista de APKs...");
                var response = await client.GetAsync($"{host}/apk/list");
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                apksList = JsonConvert.DeserializeObject<Apk[]>(json);

                foreach (var apk in apksList)
                {
                    dataGridView1.Rows.Add(apk.Version, "Descargar");
                }
                UpdateStatus($"Se cargaron {apksList.Length} APKs correctamente.");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error al obtener APKs: {ex.Message}");
            }
        }

        private void DownloadApk(int rowIndex)
        {
            try
            {
                if (rowIndex < 0 || rowIndex >= apksList.Length)
                {
                    UpdateStatus("Error: índice de fila inválido.");
                    return;
                }

                var selectedApk = apksList[rowIndex];
                
                if (selectedApk != null && !string.IsNullOrEmpty(selectedApk.Url))
                {
                    UpdateStatus($"Abriendo enlace de descarga para APK versión {selectedApk.Version}...");
                    
                    // Abrir la URL en el navegador predeterminado
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = selectedApk.Url,
                        UseShellExecute = true
                    });
                    
                    UpdateStatus($"Enlace de descarga abierto. Descarga el APK desde tu navegador.");
                }
                else
                {
                    UpdateStatus("No se encontró la URL de descarga para este APK.");
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error al obtener información del APK: {ex.Message}");
            }
        }

        private async void UploadApk(string version)
        {
            if (string.IsNullOrEmpty(selectedApkPath))
            {
                UpdateStatus("Debes seleccionar un archivo APK antes de subirlo.");
                return;
            }

            if (!Regex.IsMatch(version, @"^\d+(\.\d+){2,}$"))
            {
                UpdateStatus("El formato de la versión no es válido. Debe ser x.x.x (los números pueden tener uno o más dígitos).");
                return;
            }

            try
            {
                UpdateStatus($"Subiendo {Path.GetFileName(selectedApkPath)}...");
                using (var content = new MultipartFormDataContent())
                {
                    var fileStream = File.OpenRead(selectedApkPath);

                    // 🔧 Forzamos el tipo MIME correcto
                    var fileContent = new StreamContent(fileStream);
                    fileContent.Headers.ContentType =
                        new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.android.package-archive");

                    // 🔧 Mandamos ya con el nombre correcto
                    var newFileName = $"echoplay-{version}.apk";
                    content.Add(fileContent, "apk", newFileName);

                    // Mandamos también la versión como campo de texto si quieres
                    content.Add(new StringContent(version), "version");

                    var response = await client.PostAsync($"{host}/apk/upload", content);
                    response.EnsureSuccessStatusCode();

                    UpdateStatus($"APK subida y renombrada a {newFileName} correctamente.");
                    LoadApksFromServer();
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error al subir APK: {ex.Message}");
            }
        }

        private void selectFileBttn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "APK Files|*.apk";
                ofd.Title = "Selecciona un APK para subir";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedApkPath = ofd.FileName;
                    fileLbl.Text = selectedApkPath;
                    UpdateStatus($"Archivo seleccionado: {Path.GetFileName(selectedApkPath)}");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1) // Columna "Descargar"
            {
                DownloadApk(e.RowIndex);
            }
        }

        private void uploadBttn_Click(object sender, EventArgs e)
        {
            string version = versionTxtBox.Text.Trim();
            UploadApk(version);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string version = versionTxtBox.Text.Trim();
            UploadApk(version);
        }
    }
}