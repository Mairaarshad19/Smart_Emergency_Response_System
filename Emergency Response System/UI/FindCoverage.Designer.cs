namespace Emergency_Response_System.UI
{
    partial class FindCoverage
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
            this.btnCoverage = new System.Windows.Forms.Button();
            this.gridCoverage = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxStations = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridCoverage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCoverage
            // 
            this.btnCoverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCoverage.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCoverage.Location = new System.Drawing.Point(457, 198);
            this.btnCoverage.Name = "btnCoverage";
            this.btnCoverage.Size = new System.Drawing.Size(266, 50);
            this.btnCoverage.TabIndex = 37;
            this.btnCoverage.Text = "Calculate Coverage ";
            this.btnCoverage.UseVisualStyleBackColor = true;
            this.btnCoverage.Click += new System.EventHandler(this.btnCoverage_Click_1);
            // 
            // gridCoverage
            // 
            this.gridCoverage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCoverage.Location = new System.Drawing.Point(99, 355);
            this.gridCoverage.Name = "gridCoverage";
            this.gridCoverage.RowHeadersWidth = 51;
            this.gridCoverage.RowTemplate.Height = 24;
            this.gridCoverage.Size = new System.Drawing.Size(993, 246);
            this.gridCoverage.TabIndex = 38;
            this.gridCoverage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCoverage_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(214, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 25);
            this.label4.TabIndex = 39;
            this.label4.Text = "Station ID";
            // 
            // comboBoxStations
            // 
            this.comboBoxStations.FormattingEnabled = true;
            this.comboBoxStations.Location = new System.Drawing.Point(362, 145);
            this.comboBoxStations.Name = "comboBoxStations";
            this.comboBoxStations.Size = new System.Drawing.Size(465, 24);
            this.comboBoxStations.TabIndex = 40;
            this.comboBoxStations.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.button1.Location = new System.Drawing.Point(457, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 50);
            this.button1.TabIndex = 41;
            this.button1.Text = "Back to Dashboard ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FindCoverage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1219, 844);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxStations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gridCoverage);
            this.Controls.Add(this.btnCoverage);
            this.Name = "FindCoverage";
            this.Text = "FindCoverage";
            this.Load += new System.EventHandler(this.FindCoverage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCoverage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCoverage;
        private System.Windows.Forms.DataGridView gridCoverage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxStations;
        private System.Windows.Forms.Button button1;
    }
}