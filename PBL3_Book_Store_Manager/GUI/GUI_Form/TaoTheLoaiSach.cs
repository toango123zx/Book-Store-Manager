using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_Book_Store_Manager.BLL;

namespace PBL3_Book_Store_Manager.GUI.GUI_Form
{
    public partial class TaoTheLoaiSach : Form
    {
        public TaoTheLoaiSach()
        {
            InitializeComponent();
        }
        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            BLL_TheLoaiSach.Instance.ThemTheLoaiSach(txtTenTLS.Text);
            this.Dispose();
        }
    }
}