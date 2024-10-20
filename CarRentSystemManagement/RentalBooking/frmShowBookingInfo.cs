using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentSystemManagement.RentalBooking
{
    public partial class frmShowBookingInfo : Form
    {
        int _bookingId;
        public frmShowBookingInfo(int bookingId)
        {
            InitializeComponent();
            _bookingId = bookingId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowBookingInfo_Load(object sender, EventArgs e)
        {
            ctrrRentalBookingCard1._LoadBookingInfo(_bookingId);
        }
    }
}
