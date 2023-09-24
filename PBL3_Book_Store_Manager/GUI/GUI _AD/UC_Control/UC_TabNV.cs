using PBL3_Book_Store_Manager.BLL;
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

namespace PBL3_Book_Store_Manager.GUI__AD.UC_Control
{
    public partial class UC_TabNV : UserControl
    {

        public UC_TabNV()
        {
            InitializeComponent();
            Show();
            ShowNV();
        }

        public void Show()
        {
            dgvCaLam.DataSource = BLL_CaLam.Instance.GetListCTCaLam_BLLByTrangThai();
            dgvCaLam.Columns[0].HeaderText = "Mã ca làm";
            // dgvHDBH.Columns[0].Width = 500;
            dgvCaLam.Columns[1].HeaderText = "Tên ca làm";
            // dgvHDBH.Columns[1].Width = 500;
            dgvCaLam.Columns[2].HeaderText = "Giờ bắt đầu";
            //dgvHDBH.Columns[2].Width = 500;
            dgvCaLam.Columns[3].HeaderText = "Giờ kết thúc";
            dgvCaLam.Columns[4].HeaderText = "Phụ cấp ca làm";
            dgvCaLam.Columns[5].HeaderText = "Trạng thái";
            dgvCaLam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbbSortCaLam.SelectedIndex = 0;
           // cbbSortHDBH.SelectedIndex = 0;
        }
        public void ShowNV()
        {
            dgvNV.DataSource = BLL_NV.Instance.GetListNV();
            dgvNV.Columns["GioiTinh"].Visible = false;
            dgvNV.Columns["MaChucVu"].Visible = false ;
            dgvNV.Columns[0].HeaderText = "Mã nhân viên";
            // dgvHDBH.Columns[0].Width = 500;
            dgvNV.Columns[1].HeaderText = "Tên nhân viên";
            // dgvHDBH.Columns[1].Width = 500;
            //dgvCaLam.Columns[2].HeaderText = "Giới tính";
            //dgvHDBH.Columns[2].Width = 500;
            dgvNV.Columns[3].HeaderText = "Ngày sinh";
            dgvNV.Columns[4].HeaderText = "Số căn cước công dân";
            dgvNV.Columns[5].HeaderText = "Số điện thoại";
            dgvNV.Columns[6].HeaderText = "Địa chỉ";
            // dgvCaLam.Columns[7].HeaderText = "Chức vụ";
            dgvNV.Columns[8].HeaderText = "Trạng thái";
            dgvNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbbSortNV.SelectedIndex = 0;


        }

        private void btThemNV_Click(object sender, EventArgs e)
        {
            ThemNV themnv = new ThemNV();
            themnv.d += new ThemNV.MyDel(ShowNV);
            themnv.ShowDialog();
        }

        private void btThemCaLam_Click(object sender, EventArgs e)
        {
            ThemCaLam themCa = new ThemCaLam();
            themCa.d += new ThemCaLam.MyDel(Show);
            themCa.ShowDialog();
        }

        private void btChiTietCaLam_Click(object sender, EventArgs e)
        {
            if (dgvCaLam.SelectedRows.Count == 0) MessageBox.Show("Vui lòng chọn ca làm cần xem chi tiết");
            else if (dgvCaLam.SelectedRows.Count == 1)
            {
                ChiTietCaLam chiTietCa = new ChiTietCaLam(dgvCaLam.SelectedRows[0].Cells["MaCaLam"].Value.ToString());
                chiTietCa.d += new ChiTietCaLam.MyDel(Show);
                chiTietCa.ShowDialog();

            }
        }

        private void btXoaCaLam_Click(object sender, EventArgs e)
        {
            DialogResult results = MessageBox.Show("Bạn có muốn xác nhận tạm ngưng ca làm không ?", "Xác nhận tạm ngưng", MessageBoxButtons.YesNo);
            if (results == DialogResult.Yes)
            {
                if (dgvCaLam.SelectedRows.Count == 0) MessageBox.Show("Vui lòng chọn ca làm cần tạm ngưng");
                else if (dgvCaLam.SelectedRows.Count == 1)
                {
                    BLL_CaLam.Instance.TamNgungCaLam(dgvCaLam.SelectedRows[0].Cells["MaCaLam"].Value.ToString());
                    MessageBox.Show("Tạm ngưng ca làm thành công");
                    Show();

                }
            }
            
        }

        private void btSearchCaLam_Click(object sender, EventArgs e)
        {
            if(cbbSortCaLam.SelectedIndex == 0)
            {
               dgvCaLam.DataSource = BLL_CaLam.Instance.GetListCaLamByMaCaLam(txtSearchCaLam.Text);

            }else if(cbbSortCaLam.SelectedIndex == 1)
            {
                dgvCaLam.DataSource = BLL_CaLam.Instance.GetListCaLamByTenCaLam(txtSearchCaLam.Text);

            }else if (cbbSortCaLam.SelectedIndex == 2)
            {
                dgvCaLam.DataSource = BLL_CaLam.Instance.GetListCaLamByPhuCap(txtSearchCaLam.Text);
            }
        }

       

        private void cbbSortCaLam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbSortCaLam.SelectedIndex == 2)
            {
                dgvCaLam.DataSource = BLL_CaLam.Instance.GetListCaLamByPhuCap("");
            }    
        }

        private void btSearchNV_Click(object sender, EventArgs e)
        {
            dgvNV.DataSource = BLL_NV.Instance.GetListNV(cbbSortNV.Text.ToString(), txtSearchNV.Text.ToString().Trim());
        }

        private void btDetailNV_Click(object sender, EventArgs e)
        {
            if (dgvNV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đối tượng nhân viên cần xem chi tiết");
            }
            else if (dgvNV.SelectedRows.Count == 1)
            {
                ChiTIetNV detailncu = new ChiTIetNV(dgvNV.SelectedRows[0].Cells["MaNhanVien"].Value.ToString(),"CV000");
                detailncu.d += new ChiTIetNV.MyDel(ShowNV);
                detailncu.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chỉ được chọn 1 đối tượng nhân viên để xem chi tiết");
            }
        }

        private void btXoaNV_Click(object sender, EventArgs e)
        {
            DialogResult results = MessageBox.Show("Bạn có muốn xác nhận tạm ngưng nhân viên không ?", "Xác nhận tạm ngưng", MessageBoxButtons.YesNo);
            if (results == DialogResult.Yes)
            {
                if (dgvNV.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn đối tượng nhân viên cần tạm ngưng");
                }
                else if (dgvNV.SelectedRows.Count == 1)
                {
                    BLL_NV.Instance.UpdateTrangThaiNV(dgvNV.SelectedRows[0].Cells["MaNhanVien"].Value.ToString());
                    BLL_CaLam.Instance.TamNgungCTCaLam_BLL(dgvNV.SelectedRows[0].Cells["MaNhanVien"].Value.ToString());
                    ShowNV();
                    MessageBox.Show("Tạm ngưng nhân viên thành công");
                }
                else
                {
                    MessageBox.Show("Vui lòng chỉ được chọn 1 đối tượng nhân viên để tạm ngưng");
                }
            }    
           
        }
    }
}
