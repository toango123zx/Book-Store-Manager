using PBL3_Book_Store_Manager.GUI.GUI_Form;
using PBL3_Book_Store_Manager.GUI_Form;
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

namespace PBL3_Book_Store_Manager.GUI_KHO.UC_Control
{
    public partial class UC_TabKhoHH : UserControl
    {
        public void setGUI(DataGridView dvg)
        {
            dvg.Columns["MaTheLoaiHangHoa"].Visible = false;
            dvg.Columns["NhaSanXuat"].Visible = false;
            dvg.Columns["NamSanXuat"].Visible = false;
            dvg.Columns["MaKhuTrungBay"].Visible = false;
            dvg.Columns["SoLuongTrenKhuTrungBay"].Visible = false;
            dvg.Columns[0].HeaderText = "Mã Hàng Hóa";
            dvg.Columns[1].HeaderText = "Tên Hàng Hóa";
            dvg.Columns[4].HeaderText = "Mã Nhà Cung Ứng";
            dvg.Columns[8].HeaderText = "Mã Kho";
            dvg.Columns[9].HeaderText = "Số Lượng Trong Kho";
            dvg.Columns[10].HeaderText = "Giá Nhập";
            dvg.Columns[11].HeaderText = "Giá Bán";
            dvg.Columns[12].HeaderText = "Trạng Thái";
            dvg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        string MaNhanVien;
        public UC_TabKhoHH(string MaNhanVien)
        {
            InitializeComponent();
            this.MaNhanVien = MaNhanVien;
            BLL_KhuTrungBay.Instance.getListKhuTrungBay(cbbKe);
            BLL_HangHoa.Instance.getListHangHoa(dgvHHTrongKho);
            setGUI(dgvHHTrongKho);
            {
                BLL_HangHoa.Instance.getListHangHoa(dataGridView1);
                setGUI(dataGridView1);
            }
        }

        private void btTaoHdXuatKho_Click(object sender, EventArgs e)
        {
            ThemHoaDonXuatKho hdxk = new ThemHoaDonXuatKho();
            hdxk.Show();
        }

        private void btThemKe_Click(object sender, EventArgs e)
        {
            TaoKe taoKe = new TaoKe();
            taoKe.ShowDialog();
            BLL_KhuTrungBay.Instance.getListKhuTrungBay(cbbKe);
        }

        private void btTaoSach_Click(object sender, EventArgs e)
        {
            TaoHangHoa taoSach = new TaoHangHoa(MaNhanVien);
            taoSach.Show();
        }

        private void btTaoHH_Click(object sender, EventArgs e)
        {
            TaoHangHoa taoHH = new TaoHangHoa(MaNhanVien);
            taoHH.ShowDialog();
            BLL_HangHoa.Instance.getListHangHoa(dgvHHTrongKho);
            setGUI(dgvHHTrongKho);
        }

        private void btTaoHDNhap_Click(object sender, EventArgs e)
        {
            ThemHoaDonNhapKho taoHD = new ThemHoaDonNhapKho("CV002",MaNhanVien);
            taoHD.Show();

        }

        private void btSearchTrongKho_Click(object sender, EventArgs e)
        {
            if (txtSearchTrongKho.Text != "")
            {
                BLL_HangHoa.Instance.TimKiemHangHoa(cbbSortTrongKho.Text.ToString(), txtSearchTrongKho.Text.ToString(), dgvHHTrongKho);
                setGUI(dgvHHTrongKho);
            }
            else
                BLL_HangHoa.Instance.getListHangHoa(dgvHHTrongKho);
        }

        private void btChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvHHTrongKho.SelectedRows.Count == 0)
                MessageBox.Show("Vui lòng chọn đối tượng hàng hóa");
            else
                if (dgvHHTrongKho.SelectedRows.Count == 1)
            {
                if (BLL_TheLoaiHangHoa.Instance.getTheLoaiHangHoa(dgvHHTrongKho.SelectedRows[0].Cells["MaTheLoaiHangHoa"].Value.ToString()).TenTheLoaiHangHoa.Trim() == "Sách")
                {
                    using (ChiTietSach cts = new ChiTietSach(dgvHHTrongKho.SelectedRows[0].Cells["MaHangHoa"].Value.ToString(), MaNhanVien))
                        cts.ShowDialog();
                }
                else
                    using (ChiTietHangHoa cthh = new ChiTietHangHoa(dgvHHTrongKho.SelectedRows[0].Cells["MaHangHoa"].Value.ToString(), MaNhanVien))
                        cthh.ShowDialog();
            }
            else
                MessageBox.Show("Vui lòng chọn 1 hàng hóa");
            BLL_HangHoa.Instance.getListHangHoa();
            setGUI(dgvHHTrongKho);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

            if (BLL_HangHoa.Instance.NgungKinhDoanh(dgvHHTrongKho))
            {
                MessageBox.Show("Đề xuất tạm ngừng thành công");
                btSearchTrongKho_Click(sender, e);
            }
            else
                MessageBox.Show("Tạm ngừng không thành công");
        }

        private void btChiTietHHKe_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("Vui lòng chọn đối tượng hàng hóa");
            else
                if (dataGridView1.SelectedRows.Count == 1)
            {
                using (ChiTietHangHoa cthh = new ChiTietHangHoa(dataGridView1.SelectedRows[0].Cells["MaHangHoa"].Value.ToString(), MaNhanVien))
                {
                    cthh.ShowDialog();
                }
            }
        }

        private void btChiTietKe_Click(object sender, EventArgs e)
        {
            ChiTietKe CTke = new ChiTietKe(BLL_KhuTrungBay.Instance.getKhuTrungBay_Ten(cbbKe.Text).MaKhuTrungBay.ToString());
            CTke.ShowDialog();
            BLL_KhuTrungBay.Instance.getListKhuTrungBay(cbbKe);
        }

        private void btSearchTrenKe_Click(object sender, EventArgs e)
        {
            BLL_HangHoa.Instance.TimKiemHangHoa("TenKhuTrungBay", cbbKe.Text.ToString(), cbbSortTrenKe.Text.ToString(), txtSearchTrenKe.Text.ToString(), dataGridView1);
            setGUI(dataGridView1);
        }

        private void UC_TabKhoHH_Load(object sender, EventArgs e)
        {

        }
    }
}