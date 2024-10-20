namespace CarRentSystemManagement.Vehilces
{
    partial class frmAddUpdateVehicle
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMake = new System.Windows.Forms.ComboBox();
            this.lblVehicleID = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMileage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbFuelType = new System.Windows.Forms.ComboBox();
            this.chbIsAvailable = new System.Windows.Forms.CheckBox();
            this.txtPlateNumber = new System.Windows.Forms.TextBox();
            this.txtRentalPricePerDay = new System.Windows.Forms.TextBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.linklableAddNewPicture = new System.Windows.Forms.LinkLabel();
            this.linkLabelRemove = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(310, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(247, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add New Vehicle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(42, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vehicle Id: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(79, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Make:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(72, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Model:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(87, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Year:";
            // 
            // cmbMake
            // 
            this.cmbMake.FormattingEnabled = true;
            this.cmbMake.Location = new System.Drawing.Point(135, 146);
            this.cmbMake.Name = "cmbMake";
            this.cmbMake.Size = new System.Drawing.Size(153, 21);
            this.cmbMake.TabIndex = 5;
            // 
            // lblVehicleID
            // 
            this.lblVehicleID.AutoSize = true;
            this.lblVehicleID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleID.ForeColor = System.Drawing.Color.Black;
            this.lblVehicleID.Location = new System.Drawing.Point(135, 89);
            this.lblVehicleID.Name = "lblVehicleID";
            this.lblVehicleID.Size = new System.Drawing.Size(38, 21);
            this.lblVehicleID.TabIndex = 6;
            this.lblVehicleID.Text = "????";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(135, 203);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(151, 20);
            this.txtModel.TabIndex = 7;
            this.txtModel.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxValidating);
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(135, 259);
            this.nudYear.Maximum = new decimal(new int[] {
            2040,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(153, 20);
            this.nudYear.TabIndex = 8;
            this.nudYear.Value = new decimal(new int[] {
            2022,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(59, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Mileage:";
            // 
            // txtMileage
            // 
            this.txtMileage.Location = new System.Drawing.Point(135, 315);
            this.txtMileage.Name = "txtMileage";
            this.txtMileage.Size = new System.Drawing.Size(151, 20);
            this.txtMileage.TabIndex = 10;
            this.txtMileage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMileage_KeyPress);
            this.txtMileage.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxValidating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(376, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "Rental Price:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(14, 369);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 21);
            this.label8.TabIndex = 12;
            this.label8.Text = "Plate Number:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(336, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 21);
            this.label9.TabIndex = 13;
            this.label9.Text = "vehicle Category:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(391, 260);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 21);
            this.label11.TabIndex = 15;
            this.label11.Text = "Fuel Type:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(481, 204);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(153, 21);
            this.cmbCategory.TabIndex = 16;
            // 
            // cmbFuelType
            // 
            this.cmbFuelType.FormattingEnabled = true;
            this.cmbFuelType.Location = new System.Drawing.Point(479, 260);
            this.cmbFuelType.Name = "cmbFuelType";
            this.cmbFuelType.Size = new System.Drawing.Size(153, 21);
            this.cmbFuelType.TabIndex = 17;
            // 
            // chbIsAvailable
            // 
            this.chbIsAvailable.AutoSize = true;
            this.chbIsAvailable.Checked = true;
            this.chbIsAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIsAvailable.Enabled = false;
            this.chbIsAvailable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbIsAvailable.Location = new System.Drawing.Point(410, 313);
            this.chbIsAvailable.Name = "chbIsAvailable";
            this.chbIsAvailable.Size = new System.Drawing.Size(184, 25);
            this.chbIsAvailable.TabIndex = 18;
            this.chbIsAvailable.Text = "is Available For Rent";
            this.chbIsAvailable.UseVisualStyleBackColor = true;
            // 
            // txtPlateNumber
            // 
            this.txtPlateNumber.Location = new System.Drawing.Point(137, 371);
            this.txtPlateNumber.Name = "txtPlateNumber";
            this.txtPlateNumber.Size = new System.Drawing.Size(151, 20);
            this.txtPlateNumber.TabIndex = 19;
            this.txtPlateNumber.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxValidating);
            // 
            // txtRentalPricePerDay
            // 
            this.txtRentalPricePerDay.Location = new System.Drawing.Point(483, 148);
            this.txtRentalPricePerDay.Name = "txtRentalPricePerDay";
            this.txtRentalPricePerDay.Size = new System.Drawing.Size(151, 20);
            this.txtRentalPricePerDay.TabIndex = 20;
            this.txtRentalPricePerDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRentalPricePerDay_KeyPress);
            this.txtRentalPricePerDay.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxValidating);
            // 
            // pbImage
            // 
            this.pbImage.Image = global::CarRentSystemManagement.Properties.Resources.icons8_car_94;
            this.pbImage.Location = new System.Drawing.Point(688, 117);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(184, 191);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 21;
            this.pbImage.TabStop = false;
            // 
            // linklableAddNewPicture
            // 
            this.linklableAddNewPicture.AutoSize = true;
            this.linklableAddNewPicture.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklableAddNewPicture.Location = new System.Drawing.Point(737, 321);
            this.linklableAddNewPicture.Name = "linklableAddNewPicture";
            this.linklableAddNewPicture.Size = new System.Drawing.Size(86, 21);
            this.linklableAddNewPicture.TabIndex = 22;
            this.linklableAddNewPicture.TabStop = true;
            this.linklableAddNewPicture.Text = "Set Image";
            this.linklableAddNewPicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklableAddNewPicture_LinkClicked);
            // 
            // linkLabelRemove
            // 
            this.linkLabelRemove.AutoSize = true;
            this.linkLabelRemove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelRemove.Location = new System.Drawing.Point(718, 346);
            this.linkLabelRemove.Name = "linkLabelRemove";
            this.linkLabelRemove.Size = new System.Drawing.Size(124, 21);
            this.linkLabelRemove.TabIndex = 26;
            this.linkLabelRemove.TabStop = true;
            this.linkLabelRemove.Text = "Remove Image";
            this.linkLabelRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRemove_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::CarRentSystemManagement.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(774, 407);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnSave.Size = new System.Drawing.Size(114, 35);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::CarRentSystemManagement.Properties.Resources.closeBlack32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(654, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnCancel.Size = new System.Drawing.Size(114, 35);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAddUpdateVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 459);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.linkLabelRemove);
            this.Controls.Add(this.linklableAddNewPicture);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.txtRentalPricePerDay);
            this.Controls.Add(this.txtPlateNumber);
            this.Controls.Add(this.chbIsAvailable);
            this.Controls.Add(this.cmbFuelType);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMileage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.lblVehicleID);
            this.Controls.Add(this.cmbMake);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddUpdateVehicle";
            this.Load += new System.EventHandler(this.frmAddUpdateVehicle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMake;
        private System.Windows.Forms.Label lblVehicleID;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMileage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbFuelType;
        private System.Windows.Forms.CheckBox chbIsAvailable;
        private System.Windows.Forms.TextBox txtPlateNumber;
        private System.Windows.Forms.TextBox txtRentalPricePerDay;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.LinkLabel linklableAddNewPicture;
        private System.Windows.Forms.LinkLabel linkLabelRemove;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}