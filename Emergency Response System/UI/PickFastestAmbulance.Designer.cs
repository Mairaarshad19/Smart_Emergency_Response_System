namespace Emergency_Response_System.UI
{
    partial class PickFastestAmbulance
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
            this.cmbSeverity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFindFastestAmbulance = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvDispatches = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispatches)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbId
            // 
            this.cmbId.FormattingEnabled = true;
            this.cmbId.Location = new System.Drawing.Point(464, 123);
            this.cmbId.Name = "cmbId";
            this.cmbId.Size = new System.Drawing.Size(485, 24);
            this.cmbId.TabIndex = 45;
            // 
            // cmbSeverity
            // 
            this.cmbSeverity.FormattingEnabled = true;
            this.cmbSeverity.Location = new System.Drawing.Point(464, 183);
            this.cmbSeverity.Name = "cmbSeverity";
            this.cmbSeverity.Size = new System.Drawing.Size(485, 24);
            this.cmbSeverity.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(164, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 25);
            this.label2.TabIndex = 49;
            this.label2.Text = "Choose Intersection Id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(164, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 50;
            this.label1.Text = "Choose Severity";
            // 
            // btnFindFastestAmbulance
            // 
            this.btnFindFastestAmbulance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindFastestAmbulance.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnFindFastestAmbulance.Location = new System.Drawing.Point(528, 228);
            this.btnFindFastestAmbulance.Name = "btnFindFastestAmbulance";
            this.btnFindFastestAmbulance.Size = new System.Drawing.Size(340, 50);
            this.btnFindFastestAmbulance.TabIndex = 51;
            this.btnFindFastestAmbulance.Text = "Pick Fastest Ambulance ";
            this.btnFindFastestAmbulance.UseVisualStyleBackColor = true;
            this.btnFindFastestAmbulance.Click += new System.EventHandler(this.btnFindFastestAmbulance_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.SteelBlue;
            this.button1.Location = new System.Drawing.Point(528, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(340, 50);
            this.button1.TabIndex = 63;
            this.button1.Text = "Undo ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvDispatches
            // 
            this.dgvDispatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDispatches.Location = new System.Drawing.Point(196, 450);
            this.dgvDispatches.Name = "dgvDispatches";
            this.dgvDispatches.RowHeadersWidth = 51;
            this.dgvDispatches.RowTemplate.Height = 24;
            this.dgvDispatches.Size = new System.Drawing.Size(939, 305);
            this.dgvDispatches.TabIndex = 64;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.SteelBlue;
            this.button2.Location = new System.Drawing.Point(528, 367);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(340, 51);
            this.button2.TabIndex = 65;
            this.button2.Text = "Back to Dashboard";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PickFastestAmbulance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1322, 853);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvDispatches);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFindFastestAmbulance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSeverity);
            this.Controls.Add(this.cmbId);
            this.Name = "PickFastestAmbulance";
            this.Text = "PickFastestAmbulance";
            this.Load += new System.EventHandler(this.PickFastestAmbulance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispatches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbId;
        private System.Windows.Forms.ComboBox cmbSeverity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFindFastestAmbulance;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvDispatches;
        private System.Windows.Forms.Button button2;
    }
}