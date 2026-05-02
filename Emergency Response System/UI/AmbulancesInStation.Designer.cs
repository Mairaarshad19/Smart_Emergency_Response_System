namespace Emergency_Response_System.UI
{
    partial class AmbulancesInStation
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
            this.noofamb = new System.Windows.Forms.Button();
            this.gridCount = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCount)).BeginInit();
            this.SuspendLayout();
            // 
            // noofamb
            // 
            this.noofamb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noofamb.ForeColor = System.Drawing.Color.SteelBlue;
            this.noofamb.Location = new System.Drawing.Point(507, 414);
            this.noofamb.Name = "noofamb";
            this.noofamb.Size = new System.Drawing.Size(405, 50);
            this.noofamb.TabIndex = 34;
            this.noofamb.Text = "Show no of ambulances in each station";
            this.noofamb.UseVisualStyleBackColor = true;
            this.noofamb.Click += new System.EventHandler(this.noofamb_Click);
            // 
            // gridCount
            // 
            this.gridCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.gridCount.Location = new System.Drawing.Point(189, 55);
            this.gridCount.Name = "gridCount";
            this.gridCount.RowHeadersWidth = 51;
            this.gridCount.RowTemplate.Height = 24;
            this.gridCount.Size = new System.Drawing.Size(993, 330);
            this.gridCount.TabIndex = 35;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Station Id";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ambulances Count";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // AmbulancesInStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1393, 847);
            this.Controls.Add(this.gridCount);
            this.Controls.Add(this.noofamb);
            this.Name = "AmbulancesInStation";
            this.Text = "AmbulancesInStation";
            ((System.ComponentModel.ISupportInitialize)(this.gridCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button noofamb;
        private System.Windows.Forms.DataGridView gridCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}