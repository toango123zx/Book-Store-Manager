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
    public partial class TaoKe : Form
    {
        public TaoKe()
        {
            InitializeComponent();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            DTO.KhuTrungBay KhuTrungBay = new DTO.KhuTrungBay();

            KhuTrungBay.TenKhuTrungBay = txtTenKTB.Text.ToString().Trim();
            KhuTrungBay.SoLuongToiDa = Convert.ToInt16(txtSoLuongToiDa.Text.Trim());

            MessageBox.Show("Khu trưng bày mới sẽ được thêm vào nhà sách");
            BLL_KhuTrungBay.Instance.ThemKhuTrungBay(KhuTrungBay);
            MessageBox.Show("Khu trưng bày mới đã được thêm vào nhà sách ");

            this.Dispose();
        }
    }
}