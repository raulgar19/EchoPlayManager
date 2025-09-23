using EchoPlayManager.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoPlayManager
{
    public partial class ApksForm : Form
    {
        private readonly string host = "http://192.168.1.35:3000";
        private readonly HttpClient client = new HttpClient();
        private string selectedApkPath = "";

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
                var apks = JsonConvert.DeserializeObject<Apk[]>(json);

                foreach (var apk in apks)
                {
                    dataGridView1.Rows.Add(apk.name, "Descargar");
                }
                UpdateStatus($"Se cargaron {apks.Length} APKs correctamente.");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error al obtener APKs: {ex.Message}");
            }
        }

        private async void DownloadApk(string apkName)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.FileName = apkName;
                    sfd.Filter = "APK Files|*.apk";
                    sfd.Title = "Guardar APK en Descargas";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        UpdateStatus($"Descargando {apkName}...");
                        var url = $"{host}/apk/download/{apkName}";
                        var data = await client.GetByteArrayAsync(url);
                        File.WriteAllBytes(sfd.FileName, data);
                        UpdateStatus($"APK {apkName} descargada correctamente.");
                    }
                    else
                    {
                        UpdateStatus("Descarga cancelada por el usuario.");
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error al descargar APK: {ex.Message}");
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
                    content.Add(new StreamContent(fileStream), "apk", Path.GetFileName(selectedApkPath));
                    content.Add(new StringContent(version), "version");

                    var response = await client.PostAsync($"{host}/apk/upload", content);
                    response.EnsureSuccessStatusCode();

                    UpdateStatus($"APK subida y renombrada a echoplay-{version}.apk correctamente.");
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
                string apkName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                DownloadApk(apkName);
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