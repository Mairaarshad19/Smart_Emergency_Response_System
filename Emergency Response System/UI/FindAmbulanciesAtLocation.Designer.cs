namespace Emergency_Response_System.UI
{
    partial class FindAmbulanciesAtLocation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvEmergencies = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmergencies)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbId
            // 
            this.cmbId.FormattingEnabled = true;
            this.cmbId.Location = new System.Drawing.Point(423, 240);
            this.cmbId.Name = "cmbId";
            this.cmbId.Size = new System.Drawing.Size(485, 24);
            this.cmbId.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(177, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 25);
            this.label2.TabIndex = 47;
            this.label2.Text = "Choose Intersection Id";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.button1.Location = new System.Drawing.Point(451, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(425, 45);
            this.button1.TabIndex = 48;
            this.button1.Text = "Find All Ambulances at this Location";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvEmergencies
            // 
            this.dgvEmergencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmergencies.Location = new System.Drawing.Point(199, 425);
            this.dgvEmergencies.Name = "dgvEmergencies";
            this.dgvEmergencies.RowHeadersWidth = 51;
            this.dgvEmergencies.RowTemplate.Height = 24;
            this.dgvEmergencies.Size = new System.Drawing.Size(839, 310);
            this.dgvEmergencies.TabIndex = 49;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.SteelBlue;
            this.button2.Location = new System.Drawing.Point(451, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(425, 45);
            this.button2.TabIndex = 50;
            this.button2.Text = "Back to Dashboard";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FindAmbulanciesAtLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1179, 878);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvEmergencies);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbId);
            this.Name = "FindAmbulanciesAtLocation";
            this.Text = "FindAmbulanciesAtLocation";
            this.Load += new System.EventHandler(this.FindAmbulanciesAtLocation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmergencies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvEmergencies;
        private System.Windows.Forms.Button button2;
    }
}