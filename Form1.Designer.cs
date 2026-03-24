namespace PdfArchiveViewer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtSearch = new TextBox();
            btnSearch = new Button();
            listBoxFiles = new ListBox();
            pdfViewer = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)pdfViewer).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(37, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(172, 23);
            txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(126, 41);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // listBoxFiles
            // 
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.ItemHeight = 15;
            listBoxFiles.Location = new Point(12, 91);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(145, 184);
            listBoxFiles.TabIndex = 2;
            listBoxFiles.SelectedIndexChanged += listBoxFiles_SelectedIndexChanged;
            // 
            // pdfViewer
            // 
            pdfViewer.AllowExternalDrop = true;
            pdfViewer.CreationProperties = null;
            pdfViewer.DefaultBackgroundColor = Color.White;
            pdfViewer.Location = new Point(226, 12);
            pdfViewer.Name = "pdfViewer";
            pdfViewer.Size = new Size(551, 627);
            pdfViewer.TabIndex = 3;
            pdfViewer.ZoomFactor = 1D;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 651);
            Controls.Add(pdfViewer);
            Controls.Add(listBoxFiles);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pdfViewer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Button btnSearch;
        private ListBox listBoxFiles;
        private Microsoft.Web.WebView2.WinForms.WebView2 pdfViewer;
    }
}
