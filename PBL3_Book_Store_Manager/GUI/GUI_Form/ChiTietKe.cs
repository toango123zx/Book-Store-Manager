using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_Book_Store_Manager.DTO;
using PBL3_Book_Store_Manager.BLL;

namespace PBL3_Book_Store_Manager.GUI.GUI_Form
{
    public partial class ChiTietKe : Form
    {
        string makhutrungbay;
        public ChiTietKe(string MaKhuTrungBay)
        {
            InitializeComponent();
            Show(MaKhuTrungBay);
            makhutrungbay = MaKhuTrungBay;
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void Show(string MaKhuTrungBay)
        {
            DTO.KhuTrungBay KTB = BLL_KhuTrungBay.Instance.getKhuTrungBay(MaKhuTrungBay);
            txtTenKTB.Text = KTB.TenKhuTrungBay.ToString();
            txtSoLuongToiDa.Text = KTB.SoLuongToiDa.ToString();
        }
        private void btOK_Click(object sender, EventArgs e)
        {
            DTO.KhuTrungBay KhuTrungBay = new KhuTrungBay();
            KhuTrungBay.MaKhuTrungBay = makhutrungbay;
            KhuTrungBay.TenKhuTrungBay = txtTenKTB.Text.ToString().Trim();
            KhuTrungBay.SoLuongToiDa = Convert.ToInt16(txtSoLuongToiDa.Text.Trim());
            MessageBox.Show("Dữ liệu của khu trưng bày sẽ được cập nhật");
            BLL_KhuTrungBay.Instance.CapNhatKhuTrungBay(KhuTrungBay);
            MessageBox.Show("Dữ liệu đã được cập nhật");
        }
    }
}