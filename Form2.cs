using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using EchoPlayManager.Models;

namespace EchoPlayManager
{
    public partial class SongsForm : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private string baseUrl = "https://downloaded-warranty-skill-common.trycloudflare.com"; // Cambiar si tu servidor es otro

        public SongsForm()
        {
            InitializeComponent();
            LoadSongsAsync();
        }

        private async Task LoadSongsAsync()
        {
            try
            {
                statusTextBox.Text = "Cargando canciones...";
                HttpResponseMessage response = await client.GetAsync($"{baseUrl}/songs");
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                // Deserializamos la respuesta en una lista de objetos
                var songs = JsonConvert.DeserializeObject<List<Song>>(json);

                // Limpiamos y llenamos el DataGridView
                songsDataGridView.Rows.Clear();
                foreach (var song in songs)
                {
                    songsDataGridView.Rows.Add(song.Id, song.Name, song.Artist, song.Cover, song.File);
                }

                statusTextBox.Text = $"Se cargaron {songs.Count} canciones correctamente.";
            }
            catch (Exception ex)
            {
                statusTextBox.Text = "Error al cargar canciones: " + ex.Message;
            }
        }
    }
}