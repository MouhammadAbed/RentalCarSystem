using CarRentalBusinessLayer;
using CarRentSystemManagement.GlobalClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentSystemManagement.Users
{
    public partial class frmFindUser : Form
    {
        int _UserID=0;
        public frmFindUser()
        {
            InitializeComponent();
        }
        public frmFindUser(int userID)
        {
            InitializeComponent();
            _UserID = userID;            
        }
        private void frmFindUser_Load(object sender, EventArgs e)
        {
            if(_UserID != 0)
            {
                ctrUserCardWithFilter1.EnableFilter = false;
                ctrUserCardWithFilter1.LoadUser(_UserID);
            }
            else
            {
                ctrUserCardWithFilter1.EnableFilter=true;
                ctrUserCardWithFilter1.SetFocus();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmFindUser_Move(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
        private void frmFindUser_Resize(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
    }
}
