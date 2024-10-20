namespace CarRentSystemManagement.ReturnVehicle
{
    partial class frmWhenVehicleReturn
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
            this.components = new System.ComponentModel.Container();
            this.txtAdditionalCharges = new System.Windows.Forms.TextBox();
            this.txtFinalCheckNotes = new System.Windows.Forms.TextBox();
            this.txtCurrentMileage = new System.Windows.Forms.TextBox();
            this.lblConsumedMileage = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblActualReturnDate = new System.Windows.Forms.Label();
            this.lblActualRentalDays = new System.Windows.Forms.Label();
            this.lblTotalRemaining = new System.Windows.Forms.Label();
            this.lblTotalDueAmount = new System.Windows.Forms.Label();
            this.lblReturnID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbReturnVehicle = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.ctrRentalTransactionWithFilter1 = new CarRentSystemManagement.RenatalTransaction.Control.ctrRentalTransactionWithFilter();
            this.gbReturnVehicle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAdditionalCharges
            // 
            this.txtAdditionalCharges.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionalCharges.Location = new System.Drawing.Point(400, 99);
            this.txtAdditionalCharges.Multiline = true;
            this.txtAdditionalCharges.Name = "txtAdditionalCharges";
            this.txtAdditionalCharges.Size = new System.Drawing.Size(271, 20);
            this.txtAdditionalCharges.TabIndex = 18;
            // 
            // txtFinalCheckNotes
            // 
            this.txtFinalCheckNotes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinalCheckNotes.Location = new System.Drawing.Point(400, 59);
            this.txtFinalCheckNotes.Multiline = true;
            this.txtFinalCheckNotes.Name = "txtFinalCheckNotes";
            this.txtFinalCheckNotes.Size = new System.Drawing.Size(271, 34);
            this.txtFinalCheckNotes.TabIndex = 17;
            // 
            // txtCurrentMileage
            // 
            this.txtCurrentMileage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentMileage.Location = new System.Drawing.Point(400, 20);
            this.txtCurrentMileage.Name = "txtCurrentMileage";
            this.txtCurrentMileage.Size = new System.Drawing.Size(271, 25);
            this.txtCurrentMileage.TabIndex = 16;
            this.txtCurrentMileage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrentMileage_KeyPress);
            this.txtCurrentMileage.Validating += new System.ComponentModel.CancelEventHandler(this.txtCurrentMileage_Validating);
            // 
            // lblConsumedMileage
            // 
            this.lblConsumedMileage.AutoSize = true;
            this.lblConsumedMileage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumedMileage.Location = new System.Drawing.Point(815, 28);
            this.lblConsumedMileage.Name = "lblConsumedMileage";
            this.lblConsumedMileage.Size = new System.Drawing.Size(42, 17);
            this.lblConsumedMileage.TabIndex = 15;
            this.lblConsumedMileage.Text = "[????]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(693, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "Consumed Mileage";
            // 
            // lblActualReturnDate
            // 
            this.lblActualReturnDate.AutoSize = true;
            this.lblActualReturnDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualReturnDate.Location = new System.Drawing.Point(139, 62);
            this.lblActualReturnDate.Name = "lblActualReturnDate";
            this.lblActualReturnDate.Size = new System.Drawing.Size(98, 17);
            this.lblActualReturnDate.TabIndex = 13;
            this.lblActualReturnDate.Text = "[dd/mm/yyyy]";
            // 
            // lblActualRentalDays
            // 
            this.lblActualRentalDays.AutoSize = true;
            this.lblActualRentalDays.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualRentalDays.Location = new System.Drawing.Point(139, 97);
            this.lblActualRentalDays.Name = "lblActualRentalDays";
            this.lblActualRentalDays.Size = new System.Drawing.Size(42, 17);
            this.lblActualRentalDays.TabIndex = 12;
            this.lblActualRentalDays.Text = "[????]";
            // 
            // lblTotalRemaining
            // 
            this.lblTotalRemaining.AutoSize = true;
            this.lblTotalRemaining.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRemaining.Location = new System.Drawing.Point(815, 102);
            this.lblTotalRemaining.Name = "lblTotalRemaining";
            this.lblTotalRemaining.Size = new System.Drawing.Size(46, 17);
            this.lblTotalRemaining.TabIndex = 11;
            this.lblTotalRemaining.Text = "[$$$$]";
            // 
            // lblTotalDueAmount
            // 
            this.lblTotalDueAmount.AutoSize = true;
            this.lblTotalDueAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDueAmount.Location = new System.Drawing.Point(815, 62);
            this.lblTotalDueAmount.Name = "lblTotalDueAmount";
            this.lblTotalDueAmount.Size = new System.Drawing.Size(46, 17);
            this.lblTotalDueAmount.TabIndex = 10;
            this.lblTotalDueAmount.Text = "[$$$$]";
            // 
            // lblReturnID
            // 
            this.lblReturnID.AutoSize = true;
            this.lblReturnID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnID.Location = new System.Drawing.Point(139, 25);
            this.lblReturnID.Name = "lblReturnID";
            this.lblReturnID.Size = new System.Drawing.Size(42, 17);
            this.lblReturnID.TabIndex = 9;
            this.lblReturnID.Text = "[????]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(706, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Total Remaining:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(685, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Actual Due Amount:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(264, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Additional Charges:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(272, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Final Check Notes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(283, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Current Mileage:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Actual Rental Days:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Actual Return Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Return Id:";
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnReturn.Enabled = false;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.Black;
            this.btnReturn.Image = global::CarRentSystemManagement.Properties.Resources.Return_vehicle_35;
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(775, 414);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnReturn.Size = new System.Drawing.Size(145, 34);
            this.btnReturn.TabIndex = 7;
            this.btnReturn.Text = "Return";
            this.btnReturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = global::CarRentSystemManagement.Properties.Resources.closeBlack32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(624, 414);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnCancel.Size = new System.Drawing.Size(145, 34);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbReturnVehicle
            // 
            this.gbReturnVehicle.Controls.Add(this.txtAdditionalCharges);
            this.gbReturnVehicle.Controls.Add(this.txtFinalCheckNotes);
            this.gbReturnVehicle.Controls.Add(this.txtCurrentMileage);
            this.gbReturnVehicle.Controls.Add(this.lblConsumedMileage);
            this.gbReturnVehicle.Controls.Add(this.label14);
            this.gbReturnVehicle.Controls.Add(this.lblActualReturnDate);
            this.gbReturnVehicle.Controls.Add(this.lblActualRentalDays);
            this.gbReturnVehicle.Controls.Add(this.lblTotalRemaining);
            this.gbReturnVehicle.Controls.Add(this.lblTotalDueAmount);
            this.gbReturnVehicle.Controls.Add(this.lblReturnID);
            this.gbReturnVehicle.Controls.Add(this.label9);
            this.gbReturnVehicle.Controls.Add(this.label7);
            this.gbReturnVehicle.Controls.Add(this.label6);
            this.gbReturnVehicle.Controls.Add(this.label5);
            this.gbReturnVehicle.Controls.Add(this.label4);
            this.gbReturnVehicle.Controls.Add(this.label3);
            this.gbReturnVehicle.Controls.Add(this.label2);
            this.gbReturnVehicle.Controls.Add(this.label1);
            this.gbReturnVehicle.Enabled = false;
            this.gbReturnVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReturnVehicle.Location = new System.Drawing.Point(8, 271);
            this.gbReturnVehicle.Name = "gbReturnVehicle";
            this.gbReturnVehicle.Size = new System.Drawing.Size(932, 137);
            this.gbReturnVehicle.TabIndex = 5;
            this.gbReturnVehicle.TabStop = false;
            this.gbReturnVehicle.Text = "Return Vehicle Info";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(317, -3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(314, 40);
            this.label8.TabIndex = 8;
            this.label8.Text = "Return Vehicle Screen";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.White;
            this.lblMessage.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMessage.Location = new System.Drawing.Point(330, 41);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(288, 23);
            this.lblMessage.TabIndex = 9;
            this.lblMessage.Text = "Vehicle returned successfully";
            this.lblMessage.Visible = false;
            // 
            // ctrRentalTransactionWithFilter1
            // 
            this.ctrRentalTransactionWithFilter1.Location = new System.Drawing.Point(8, 68);
            this.ctrRentalTransactionWithFilter1.Name = "ctrRentalTransactionWithFilter1";
            this.ctrRentalTransactionWithFilter1.Size = new System.Drawing.Size(932, 199);
            this.ctrRentalTransactionWithFilter1.TabIndex = 4;
            this.ctrRentalTransactionWithFilter1.TransactionID = 0;
            this.ctrRentalTransactionWithFilter1.TransactionFound += new System.Action<int>(this.ctrRentalTransactionWithFilter1_TransactionFound);
            this.ctrRentalTransactionWithFilter1.Resize += new System.EventHandler(this.ctrRentalTransactionWithFilter1_Resize);
            // 
            // frmWhenVehicleReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(948, 456);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbReturnVehicle);
            this.Controls.Add(this.ctrRentalTransactionWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(27, 115);
            this.Name = "frmWhenVehicleReturn";
            this.Text = "frmWhenVehicleReturn";
            this.Load += new System.EventHandler(this.frmWhenVehicleReturn_Load);
            this.Resize += new System.EventHandler(this.frmWhenVehicleReturn_Resize);
            this.gbReturnVehicle.ResumeLayout(false);
            this.gbReturnVehicle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAdditionalCharges;
        private System.Windows.Forms.TextBox txtFinalCheckNotes;
        private System.Windows.Forms.TextBox txtCurrentMileage;
        private System.Windows.Forms.Label lblConsumedMileage;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblActualReturnDate;
        private System.Windows.Forms.Label lblActualRentalDays;
        private System.Windows.Forms.Label lblTotalRemaining;
        private System.Windows.Forms.Label lblTotalDueAmount;
        private System.Windows.Forms.Label lblReturnID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbReturnVehicle;
        private RenatalTransaction.Control.ctrRentalTransactionWithFilter ctrRentalTransactionWithFilter1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblMessage;
    }
}