namespace CarRentSystemManagement.RenatalTransaction
{
    partial class frmShowRentalTransactionInfo
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
            this.ctrRentalTransactionCard1 = new CarRentSystemManagement.RenatalTransaction.Control.ctrRentalTransactionCard();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrRentalTransactionCard1
            // 
            this.ctrRentalTransactionCard1.Location = new System.Drawing.Point(12, 80);
            this.ctrRentalTransactionCard1.Name = "ctrRentalTransactionCard1";
            this.ctrRentalTransactionCard1.Size = new System.Drawing.Size(891, 156);
            this.ctrRentalTransactionCard1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(292, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rental Transaction Info";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::CarRentSystemManagement.Properties.Resources.closeBlack32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(789, 246);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnClose.Size = new System.Drawing.Size(114, 36);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowRentalTransactionInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 293);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrRentalTransactionCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowRentalTransactionInfo";
            this.Text = "frmShowRentalTransactionInfo";
            this.Load += new System.EventHandler(this.frmShowRentalTransactionInfo_Load);
            this.Move += new System.EventHandler(this.frmShowRentalTransactionInfo_Move);
            this.Resize += new System.EventHandler(this.frmShowRentalTransactionInfo_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.ctrRentalTransactionCard ctrRentalTransactionCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}