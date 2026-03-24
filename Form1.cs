using System;
using System.IO;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.Web.WebView2.WinForms;

namespace PdfArchiveViewer
{
    public partial class Form1 : Form
    {
        // Update these two strings to match your specific setup
        private readonly string _connectionString = "Server=127.0.0.1,1434;Database=KennyTest;User ID=sa;Password=L0ck3d.D0wn!;TrustServerCertificate=True;";
        private readonly string _processedFolderPath = @"C:\PdfProject\processed";

        public Form1()
        {
            InitializeComponent();

            // Wire up the events manually if you haven't done it in the Designer
            this.Load += Form1_Load;
            btnSearch.Click += btnSearch_Click;
            listBoxFiles.SelectedIndexChanged += listBoxFiles_SelectedIndexChanged;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await InitializeWebViewAsync();
        }

        private async Task InitializeWebViewAsync()
        {
            try
            {
                // Waits for the Edge browser engine to initialize
                await pdfViewer.EnsureCoreWebView2Async(null);
                pdfViewer.CoreWebView2.Navigate("about:blank");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not initialize PDF Viewer: {ex.Message}", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listBoxFiles.Items.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    // Query the database we created in the previous steps
                    string sql = "SELECT FileName FROM PdfProcessingLog WHERE FileName LIKE @search AND Status = 'Merged' ORDER BY Timestamp DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // The % signs are wildcards for the SQL LIKE operator
                        cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listBoxFiles.Items.Add(reader["FileName"].ToString());
                            }
                        }
                    }
                }

                if (listBoxFiles.Items.Count == 0)
                {
                    MessageBox.Show("No matching PDFs found in the database.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}\n\nMake sure your SSH tunnel is open!", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Only proceed if an item is actually selected
            if (listBoxFiles.SelectedItem == null) return;

            string selectedFileName = listBoxFiles.SelectedItem.ToString();
            string fullFilePath = Path.Combine(_processedFolderPath, selectedFileName);

            if (File.Exists(fullFilePath))
            {
                // This command tells the WebView2 control to load and display the PDF
                pdfViewer.CoreWebView2.Navigate(fullFilePath);
            }
            else
            {
                MessageBox.Show($"The file '{selectedFileName}' exists in the database record, but was not found in the physical folder: {_processedFolderPath}", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}