namespace Module5A
{
    partial class MakeReports
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
            this.cbx_ffli = new System.Windows.Forms.CheckBox();
            this.cbx_fday = new System.Windows.Forms.CheckBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnMakeRP = new System.Windows.Forms.Button();
            this.dgvTotalAmenity = new System.Windows.Forms.DataGridView();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.titledgv = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalAmenity)).BeginInit();
            this.SuspendLayout();
            // 
            // cbx_ffli
            // 
            this.cbx_ffli.AutoSize = true;
            this.cbx_ffli.Location = new System.Drawing.Point(12, 12);
            this.cbx_ffli.Name = "cbx_ffli";
            this.cbx_ffli.Size = new System.Drawing.Size(101, 17);
            this.cbx_ffli.TabIndex = 0;
            this.cbx_ffli.Text = "Report for Flight";
            this.cbx_ffli.UseVisualStyleBackColor = true;
            this.cbx_ffli.CheckedChanged += new System.EventHandler(this.cbx_ffli_CheckedChanged);
            // 
            // cbx_fday
            // 
            this.cbx_fday.AutoSize = true;
            this.cbx_fday.Location = new System.Drawing.Point(12, 35);
            this.cbx_fday.Name = "cbx_fday";
            this.cbx_fday.Size = new System.Drawing.Size(95, 17);
            this.cbx_fday.TabIndex = 1;
            this.cbx_fday.Text = "Report for Day";
            this.cbx_fday.UseVisualStyleBackColor = true;
            this.cbx_fday.CheckedChanged += new System.EventHandler(this.cbx_fday_CheckedChanged);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(119, 9);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(141, 20);
            this.txtInput.TabIndex = 2;
            this.txtInput.Click += new System.EventHandler(this.txtInput_Click);
            // 
            // btnMakeRP
            // 
            this.btnMakeRP.Location = new System.Drawing.Point(266, 7);
            this.btnMakeRP.Name = "btnMakeRP";
            this.btnMakeRP.Size = new System.Drawing.Size(129, 23);
            this.btnMakeRP.TabIndex = 3;
            this.btnMakeRP.Text = "Make Report";
            this.btnMakeRP.UseVisualStyleBackColor = true;
            this.btnMakeRP.Click += new System.EventHandler(this.btnMakeRP_Click);
            // 
            // dgvTotalAmenity
            // 
            this.dgvTotalAmenity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalAmenity.Location = new System.Drawing.Point(12, 93);
            this.dgvTotalAmenity.Name = "dgvTotalAmenity";
            this.dgvTotalAmenity.Size = new System.Drawing.Size(1042, 304);
            this.dgvTotalAmenity.TabIndex = 4;
            // 
            // dtp
            // 
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(119, 9);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(141, 20);
            this.dtp.TabIndex = 6;
            this.dtp.Value = new System.DateTime(2019, 11, 13, 0, 0, 0, 0);
            // 
            // titledgv
            // 
            this.titledgv.AutoSize = true;
            this.titledgv.Location = new System.Drawing.Point(461, 65);
            this.titledgv.Name = "titledgv";
            this.titledgv.Size = new System.Drawing.Size(0, 13);
            this.titledgv.TabIndex = 7;
            // 
            // MakeReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 538);
            this.Controls.Add(this.titledgv);
            this.Controls.Add(this.dgvTotalAmenity);
            this.Controls.Add(this.btnMakeRP);
            this.Controls.Add(this.cbx_fday);
            this.Controls.Add(this.cbx_ffli);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.dtp);
            this.Name = "MakeReports";
            this.Text = "MakeReports";
            this.Load += new System.EventHandler(this.MakeReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalAmenity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbx_ffli;
        private System.Windows.Forms.CheckBox cbx_fday;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnMakeRP;
        private System.Windows.Forms.DataGridView dgvTotalAmenity;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label titledgv;
    }
}