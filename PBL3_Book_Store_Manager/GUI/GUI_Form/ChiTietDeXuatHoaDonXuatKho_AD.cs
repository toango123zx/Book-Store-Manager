using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_Book_Store_Manager.GUI.GUI_Form
{
    public partial class ChiTietDeXuatHoaDonXuatKho_AD : Form
    {
        string MaDeXuat { get; set; }
        public ChiTietDeXuatHoaDonXuatKho_AD(string maDX)
        {
            InitializeComponent();
            MaDeXuat = maDX;
        }

        private void ChiTietDeXuatHoaDonXuatKho_AD_Load(object sender, EventArgs e)
        {

        }

        private void bt_QuayLai_ChiTietDeXuatHoaDonXuatKho_AD_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
