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
    public partial class frmShowUserInfo : Form
    {
        int _UserID;
        public frmShowUserInfo(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }
        private void frmShowUserInfo_Load(object sender, EventArgs e)
        {
            ctrUserCard1.LoadUserbyUserID(_UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowUserInfo_Move(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }

        private void frmShowUserInfo_Resize(object sender, EventArgs e)
        {
            clsResizeMoveFom.SetFormPosition(this);
        }
    }
}
