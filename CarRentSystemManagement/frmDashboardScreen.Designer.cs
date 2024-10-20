namespace CarRentSystemManagement
{
    partial class frmDashboardScreen
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.vehiclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFindVehilce = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVehicleList = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAddClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFindClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClientList = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingVehicleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showBookingHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnVehiclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userListToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.signOUtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(47)))), ((int)(((byte)(81)))));
            this.MainPanel.Location = new System.Drawing.Point(27, 115);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(948, 456);
            this.MainPanel.TabIndex = 22;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.RoyalBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vehiclesToolStripMenuItem,
            this.clientsToolStripMenuItem,
            this.bookingVehicleToolStripMenuItem,
            this.returnVehiclesToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.usersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 91);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // vehiclesToolStripMenuItem
            // 
            this.vehiclesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddNew,
            this.tsmFindVehilce,
            this.tsmVehicleList});
            this.vehiclesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.vehiclesToolStripMenuItem.Image = global::CarRentSystemManagement.Properties.Resources.vehicles_35;
            this.vehiclesToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.vehiclesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.vehiclesToolStripMenuItem.Name = "vehiclesToolStripMenuItem";
            this.vehiclesToolStripMenuItem.Size = new System.Drawing.Size(139, 87);
            this.vehiclesToolStripMenuItem.Text = "Vehicles";
            // 
            // tsmAddNew
            // 
            this.tsmAddNew.Image = global::CarRentSystemManagement.Properties.Resources.Add_35;
            this.tsmAddNew.Name = "tsmAddNew";
            this.tsmAddNew.Size = new System.Drawing.Size(205, 34);
            this.tsmAddNew.Text = "Add Vehicle";
            this.tsmAddNew.Click += new System.EventHandler(this.tsmAddNew_Click);
            // 
            // tsmFindVehilce
            // 
            this.tsmFindVehilce.Image = global::CarRentSystemManagement.Properties.Resources.Find_vehicle;
            this.tsmFindVehilce.Name = "tsmFindVehilce";
            this.tsmFindVehilce.Size = new System.Drawing.Size(205, 34);
            this.tsmFindVehilce.Text = "Find Vehicle";
            this.tsmFindVehilce.Click += new System.EventHandler(this.tsmFindVehilce_Click);
            // 
            // tsmVehicleList
            // 
            this.tsmVehicleList.Image = global::CarRentSystemManagement.Properties.Resources.List_35;
            this.tsmVehicleList.Name = "tsmVehicleList";
            this.tsmVehicleList.Size = new System.Drawing.Size(205, 34);
            this.tsmVehicleList.Text = "Vehicle List";
            this.tsmVehicleList.Click += new System.EventHandler(this.tsmVehicleList_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddClient,
            this.tsmFindClient,
            this.tsmClientList});
            this.clientsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.clientsToolStripMenuItem.Image = global::CarRentSystemManagement.Properties.Resources.people_35;
            this.clientsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(126, 87);
            this.clientsToolStripMenuItem.Text = "Clients";
            // 
            // tsmAddClient
            // 
            this.tsmAddClient.Image = global::CarRentSystemManagement.Properties.Resources.Add_Client_35;
            this.tsmAddClient.Name = "tsmAddClient";
            this.tsmAddClient.Size = new System.Drawing.Size(192, 34);
            this.tsmAddClient.Text = "Add Client";
            this.tsmAddClient.Click += new System.EventHandler(this.tsmAddClient_Click);
            // 
            // tsmFindClient
            // 
            this.tsmFindClient.Image = global::CarRentSystemManagement.Properties.Resources.Find_user_351;
            this.tsmFindClient.Name = "tsmFindClient";
            this.tsmFindClient.Size = new System.Drawing.Size(192, 34);
            this.tsmFindClient.Text = "Find Client";
            this.tsmFindClient.Click += new System.EventHandler(this.tsmFindClient_Click);
            // 
            // tsmClientList
            // 
            this.tsmClientList.Image = global::CarRentSystemManagement.Properties.Resources.icons8_list_view_64;
            this.tsmClientList.Name = "tsmClientList";
            this.tsmClientList.Size = new System.Drawing.Size(192, 34);
            this.tsmClientList.Text = "Client List";
            this.tsmClientList.Click += new System.EventHandler(this.tsmClientList_Click);
            // 
            // bookingVehicleToolStripMenuItem
            // 
            this.bookingVehicleToolStripMenuItem.Checked = true;
            this.bookingVehicleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bookingVehicleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookingVehicleToolStripMenuItem1,
            this.showBookingHistoryToolStripMenuItem});
            this.bookingVehicleToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.bookingVehicleToolStripMenuItem.Image = global::CarRentSystemManagement.Properties.Resources.booking_35;
            this.bookingVehicleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bookingVehicleToolStripMenuItem.Name = "bookingVehicleToolStripMenuItem";
            this.bookingVehicleToolStripMenuItem.Size = new System.Drawing.Size(217, 87);
            this.bookingVehicleToolStripMenuItem.Text = "Booking vehicle";
            // 
            // bookingVehicleToolStripMenuItem1
            // 
            this.bookingVehicleToolStripMenuItem1.Name = "bookingVehicleToolStripMenuItem1";
            this.bookingVehicleToolStripMenuItem1.Size = new System.Drawing.Size(308, 34);
            this.bookingVehicleToolStripMenuItem1.Text = "Booking Vehicle";
            this.bookingVehicleToolStripMenuItem1.Click += new System.EventHandler(this.bookingVehicleToolStripMenuItem1_Click);
            // 
            // showBookingHistoryToolStripMenuItem
            // 
            this.showBookingHistoryToolStripMenuItem.Name = "showBookingHistoryToolStripMenuItem";
            this.showBookingHistoryToolStripMenuItem.Size = new System.Drawing.Size(308, 34);
            this.showBookingHistoryToolStripMenuItem.Text = "Show Booking History";
            this.showBookingHistoryToolStripMenuItem.Click += new System.EventHandler(this.showBookingHistoryToolStripMenuItem_Click);
            // 
            // returnVehiclesToolStripMenuItem
            // 
            this.returnVehiclesToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.returnVehiclesToolStripMenuItem.Image = global::CarRentSystemManagement.Properties.Resources.Return_vehicle_35;
            this.returnVehiclesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.returnVehiclesToolStripMenuItem.Name = "returnVehiclesToolStripMenuItem";
            this.returnVehiclesToolStripMenuItem.Size = new System.Drawing.Size(211, 87);
            this.returnVehiclesToolStripMenuItem.Text = "Return Vehicles";
            this.returnVehiclesToolStripMenuItem.Click += new System.EventHandler(this.returnVehiclesToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.transactionsToolStripMenuItem.Image = global::CarRentSystemManagement.Properties.Resources.Transaction_35;
            this.transactionsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(181, 87);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            this.transactionsToolStripMenuItem.Click += new System.EventHandler(this.transactionsToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewUserToolStripMenuItem,
            this.updatePasswordToolStripMenuItem,
            this.userListToolStrip,
            this.signOUtToolStripMenuItem1});
            this.usersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.usersToolStripMenuItem.Image = global::CarRentSystemManagement.Properties.Resources.User_32__2;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(93, 87);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Image = global::CarRentSystemManagement.Properties.Resources.users_64;
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(255, 34);
            this.addNewUserToolStripMenuItem.Text = "Add New User";
            this.addNewUserToolStripMenuItem.Click += new System.EventHandler(this.addNewUserToolStripMenuItem_Click);
            // 
            // updatePasswordToolStripMenuItem
            // 
            this.updatePasswordToolStripMenuItem.Image = global::CarRentSystemManagement.Properties.Resources.Password_32;
            this.updatePasswordToolStripMenuItem.Name = "updatePasswordToolStripMenuItem";
            this.updatePasswordToolStripMenuItem.Size = new System.Drawing.Size(255, 34);
            this.updatePasswordToolStripMenuItem.Text = "Update Password";
            this.updatePasswordToolStripMenuItem.Click += new System.EventHandler(this.updatePasswordToolStripMenuItem_Click);
            // 
            // userListToolStrip
            // 
            this.userListToolStrip.Image = global::CarRentSystemManagement.Properties.Resources.List_35;
            this.userListToolStrip.Name = "userListToolStrip";
            this.userListToolStrip.Size = new System.Drawing.Size(255, 34);
            this.userListToolStrip.Text = "Users List";
            this.userListToolStrip.Click += new System.EventHandler(this.userListToolStrip_Click);
            // 
            // signOUtToolStripMenuItem1
            // 
            this.signOUtToolStripMenuItem1.Image = global::CarRentSystemManagement.Properties.Resources.sign_out_32__2;
            this.signOUtToolStripMenuItem1.Name = "signOUtToolStripMenuItem1";
            this.signOUtToolStripMenuItem1.Size = new System.Drawing.Size(255, 34);
            this.signOUtToolStripMenuItem1.Text = "Sign Out";
            this.signOUtToolStripMenuItem1.Click += new System.EventHandler(this.signOUtToolStripMenuItem1_Click);
            // 
            // frmDashboardScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1006, 605);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDashboardScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Move += new System.EventHandler(this.frmDashboardScreen_Move);
            this.Resize += new System.EventHandler(this.frmDashboardScreen_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vehiclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnVehiclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmAddNew;
        private System.Windows.Forms.ToolStripMenuItem tsmFindVehilce;
        private System.Windows.Forms.ToolStripMenuItem tsmVehicleList;
        private System.Windows.Forms.ToolStripMenuItem tsmAddClient;
        private System.Windows.Forms.ToolStripMenuItem tsmFindClient;
        private System.Windows.Forms.ToolStripMenuItem tsmClientList;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userListToolStrip;
        private System.Windows.Forms.ToolStripMenuItem signOUtToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bookingVehicleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showBookingHistoryToolStripMenuItem;
    }
}

