using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentSystemManagement.GlobalClass
{
    public  class clsResizeMoveFom
    {
        public static void SetFormPosition(Form frm)
        {
            int x = (Screen.PrimaryScreen.Bounds.Width- frm.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - frm.Height) / 2;
            frm.Location=new System.Drawing.Point(x,y);
        }
    }
}
