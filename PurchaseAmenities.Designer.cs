namespace Module5A
{
    partial class PurchaseAmenities
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBookingReference = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShowAmen = new System.Windows.Forms.Button();
            this.cbxTicket = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPassportNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCabinClass = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTotalPay = new System.Windows.Forms.Label();
            this.lbDuties = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Booking Reference:";
            // 
            // txtBookingReference
            // 
            this.txtBookingReference.Location = new System.Drawing.Point(134, 17);
            this.txtBookingReference.Name = "txtBookingReference";
            this.txtBookingReference.Size = new System.Drawing.Size(151, 20);
            this.txtBookingReference.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(291, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShowAmen);
            this.groupBox1.Controls.Add(this.cbxTicket);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(29, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 67);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flight list";
            // 
            // btnShowAmen
            // 
            this.btnShowAmen.Location = new System.Drawing.Point(440, 23);
            this.btnShowAmen.Name = "btnShowAmen";
            this.btnShowAmen.Size = new System.Drawing.Size(125, 23);
            this.btnShowAmen.TabIndex = 4;
            this.btnShowAmen.Text = "Show Amenities";
            this.btnShowAmen.UseVisualStyleBackColor = true;
            this.btnShowAmen.Click += new System.EventHandler(this.btnShowAmen_Click);
            // 
            // cbxTicket
            // 
            this.cbxTicket.FormattingEnabled = true;
            this.cbxTicket.Location = new System.Drawing.Point(123, 25);
            this.cbxTicket.Name = "cbxTicket";
            this.cbxTicket.Size = new System.Drawing.Size(311, 21);
            this.cbxTicket.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Choose your flight:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Full name:";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(80, 132);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(134, 13);
            this.lblFullName.TabIndex = 5;
            this.lblFullName.Text = "[ XXXXX XXXXXXXXXXX ]";
            // 
            // lblPassportNumber
            // 
            this.lblPassportNumber.AutoSize = true;
            this.lblPassportNumber.Location = new System.Drawing.Point(324, 132);
            this.lblPassportNumber.Name = "lblPassportNumber";
            this.lblPassportNumber.Size = new System.Drawing.Size(134, 13);
            this.lblPassportNumber.TabIndex = 7;
            this.lblPassportNumber.Text = "[ XXXXX XXXXXXXXXXX ]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Passport Number:";
            // 
            // lblCabinClass
            // 
            this.lblCabinClass.AutoSize = true;
            this.lblCabinClass.Location = new System.Drawing.Point(122, 163);
            this.lblCabinClass.Name = "lblCabinClass";
            this.lblCabinClass.Size = new System.Drawing.Size(134, 13);
            this.lblCabinClass.TabIndex = 9;
            this.lblCabinClass.Text = "[ XXXXX XXXXXXXXXXX ]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Your cabin class is:";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(29, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 94);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Purchase Amenities";
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Location = new System.Drawing.Point(131, 295);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(33, 13);
            this.lbTotalPrice.TabIndex = 10;
            this.lbTotalPrice.Text = "[$XX]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Items selected: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Duties and Taxes: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 341);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Total payable: ";
            // 
            // lbTotalPay
            // 
            this.lbTotalPay.AutoSize = true;
            this.lbTotalPay.Location = new System.Drawing.Point(131, 341);
            this.lbTotalPay.Name = "lbTotalPay";
            this.lbTotalPay.Size = new System.Drawing.Size(33, 13);
            this.lbTotalPay.TabIndex = 14;
            this.lbTotalPay.Text = "[$XX]";
            // 
            // lbDuties
            // 
            this.lbDuties.AutoSize = true;
            this.lbDuties.Location = new System.Drawing.Point(131, 318);
            this.lbDuties.Name = "lbDuties";
            this.lbDuties.Size = new System.Drawing.Size(33, 13);
            this.lbDuties.TabIndex = 15;
            this.lbDuties.Text = "[$XX]";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(386, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(163, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save and Confirm";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(386, 324);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PurchaseAmenities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 375);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbDuties);
            this.Controls.Add(this.lbTotalPay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTotalPrice);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblCabinClass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPassportNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtBookingReference);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseAmenities";
            this.Text = "Purchase Amenities";
            this.Load += new System.EventHandler(this.PurchaseAmenities_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBookingReference;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShowAmen;
        private System.Windows.Forms.ComboBox cbxTicket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPassportNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCabinClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTotalPay;
        private System.Windows.Forms.Label lbDuties;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
    }
}

