namespace Module5A
{
    partial class MainOptions
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
            this.btnBuyAmenities = new System.Windows.Forms.Button();
            this.btnMakeRp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBuyAmenities
            // 
            this.btnBuyAmenities.Location = new System.Drawing.Point(40, 27);
            this.btnBuyAmenities.Name = "btnBuyAmenities";
            this.btnBuyAmenities.Size = new System.Drawing.Size(200, 23);
            this.btnBuyAmenities.TabIndex = 0;
            this.btnBuyAmenities.Text = "Purchase Amenities";
            this.btnBuyAmenities.UseVisualStyleBackColor = true;
            this.btnBuyAmenities.Click += new System.EventHandler(this.btnBuyAmenities_Click);
            // 
            // btnMakeRp
            // 
            this.btnMakeRp.Location = new System.Drawing.Point(42, 59);
            this.btnMakeRp.Name = "btnMakeRp";
            this.btnMakeRp.Size = new System.Drawing.Size(200, 23);
            this.btnMakeRp.TabIndex = 1;
            this.btnMakeRp.Text = "Make Report ";
            this.btnMakeRp.UseVisualStyleBackColor = true;
            this.btnMakeRp.Click += new System.EventHandler(this.btnMakeRp_Click);
            // 
            // MainOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.btnMakeRp);
            this.Controls.Add(this.btnBuyAmenities);
            this.Name = "MainOptions";
            this.Text = "MainOptions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuyAmenities;
        private System.Windows.Forms.Button btnMakeRp;
    }
}