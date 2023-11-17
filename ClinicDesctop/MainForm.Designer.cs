namespace ClinicDesctop
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
            listViewClients = new ListView();
            columnHeaderId = new ColumnHeader();
            columnHeaderSurName = new ColumnHeader();
            columnHeaderFirstName = new ColumnHeader();
            columnHeaderPatronymic = new ColumnHeader();
            columnHeaderDocument = new ColumnHeader();
            buttonLoadClients = new Button();
            SuspendLayout();
            // 
            // listViewClients
            // 
            listViewClients.Columns.AddRange(new ColumnHeader[] { columnHeaderId, columnHeaderSurName, columnHeaderFirstName, columnHeaderPatronymic, columnHeaderDocument });
            listViewClients.FullRowSelect = true;
            listViewClients.GridLines = true;
            listViewClients.Location = new Point(12, 12);
            listViewClients.MultiSelect = false;
            listViewClients.Name = "listViewClients";
            listViewClients.Size = new Size(1063, 428);
            listViewClients.TabIndex = 0;
            listViewClients.UseCompatibleStateImageBehavior = false;
            listViewClients.View = View.Details;
            // 
            // columnHeaderId
            // 
            columnHeaderId.Text = "#";
            // 
            // columnHeaderSurName
            // 
            columnHeaderSurName.Text = "Фамилия";
            columnHeaderSurName.Width = 120;
            // 
            // columnHeaderFirstName
            // 
            columnHeaderFirstName.Text = "Имя";
            columnHeaderFirstName.Width = 120;
            // 
            // columnHeaderPatronymic
            // 
            columnHeaderPatronymic.Text = "Очество";
            columnHeaderPatronymic.Width = 120;
            // 
            // columnHeaderDocument
            // 
            columnHeaderDocument.Text = "Документ";
            columnHeaderDocument.Width = 120;
            // 
            // buttonLoadClients
            // 
            buttonLoadClients.BackColor = SystemColors.InactiveCaption;
            buttonLoadClients.Font = new Font("Sitka Banner", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLoadClients.Location = new Point(955, 446);
            buttonLoadClients.Name = "buttonLoadClients";
            buttonLoadClients.Size = new Size(120, 52);
            buttonLoadClients.TabIndex = 1;
            buttonLoadClients.Text = "Загрузить";
            buttonLoadClients.UseVisualStyleBackColor = false;
            buttonLoadClients.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 531);
            Controls.Add(buttonLoadClients);
            Controls.Add(listViewClients);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Моя клиника";
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewClients;
        private ColumnHeader columnHeaderId;
        private ColumnHeader columnHeaderSurName;
        private ColumnHeader columnHeaderFirstName;
        private ColumnHeader columnHeaderPatronymic;
        private ColumnHeader columnHeaderDocument;
        private Button buttonLoadClients;
    }
}
