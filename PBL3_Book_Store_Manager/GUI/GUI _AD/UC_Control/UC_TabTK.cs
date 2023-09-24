using PBL3_Book_Store_Manager.BLL;
using PBL3_Book_Store_Manager.DAL;
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
    public partial class UC_TabTK : UserControl
    {
        public UC_TabTK()
        {
            InitializeComponent();
            SetGUI();
        }


        public void Show()
        {
            dgvThu.DataSource = BLL_ThongKe.Instance.GetListHDViewByTG(dtpBatDauThu.Value, dtpKetThucThu.Value);
            dgvThu.Columns[0].HeaderText = "Mã hóa đơn";
            // dgvHDBH.Columns[0].Width = 500;
            dgvThu.Columns[1].HeaderText = "Thời gian tạo";
            // dgvHDBH.Columns[1].Width = 500;
            dgvThu.Columns[2].HeaderText = "Tên nhân viên";
            //dgvHDBH.Columns[2].Width = 500;
            dgvThu.Columns[2].HeaderText = "Tổng tiền";
            dgvThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbbSortThu.SelectedIndex = 0;
            SetDoanhThuThu(dtpBatDauThu.Value, dtpKetThucThu.Value);
           // MessageBox.Show(dtpKetThucThu.Value.ToString());
        }
        public void SetGUI()
        {
            dtpBatDauThu.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpKetThucThu.Value = dtpBatDauThu.Value.AddYears(1).AddDays(-1);
            Show(); 
           
        }
        private void btSearchChi_Click(object sender, EventArgs e)
        {

        }

        public void SetDoanhThuThu(DateTime dateFrom, DateTime dateTo)
        {
             lbToTalThu.Text =  BLL_ThongKe.Instance.TinhDoanhThuByTG(dateFrom,dateTo)+ " VNĐ";
             lbSoHoaDon.Text = dgvThu.Rows.Count.ToString();
            lbSoLuongBan.Text = DAL_ThongKe.Instance.GetSoLuongHhBanByTG_DAL(dateFrom, dateTo).ToString();
        }
        public void SetDoanhThuThuBySearch(DateTime dateFrom, DateTime dateTo,string Search,string ThongTin)
        {
            lbToTalThu.Text =   BLL_ThongKe.Instance.TinhDoanhThuByTGSearch(dateFrom,dateTo,Search,ThongTin) + " VNĐ";
            lbSoHoaDon.Text = dgvThu.Rows.Count.ToString();
            lbSoLuongBan.Text = DAL_ThongKe.Instance.GetSoLuongHhBanByTG_DAL(dateFrom, dateTo).ToString();
        }



        private void btSearchThu_Click(object sender, EventArgs e)
        {
            
                if (cbbSortThu.SelectedIndex == 0)
                {
                if (txtSearchThu.Text == null)
                {
                    dgvThu.DataSource = BLL_ThongKe.Instance.GetListHDViewByTG(dtpBatDauThu.Value, dtpKetThucThu.Value);
                    lbSoLuongBan.Text = DAL_ThongKe.Instance.GetSoLuongHhBanByTG_DAL(dtpBatDauThu.Value, dtpKetThucThu.Value).ToString();
                }
                else
                {
                    dgvThu.DataSource = BLL_ThongKe.Instance.SearchListHDBHViewByMaHd(txtSearchThu.Text, dtpBatDauThu.Value, dtpKetThucThu.Value);
                    SetDoanhThuThuBySearch(dtpBatDauThu.Value, dtpKetThucThu.Value, "MaHoaDon", txtSearchThu.Text);
                    lbSoLuongBan.Text = BLL_ThongKe.Instance.GetSoLuongBan().ToString();
                }    
                
                }
                else if (cbbSortThu.SelectedIndex == 1)
                {
                if (txtSearchThu.Text == null)
                {
                    dgvThu.DataSource = BLL_ThongKe.Instance.GetListHDViewByTG(dtpBatDauThu.Value, dtpKetThucThu.Value);
                    lbSoLuongBan.Text = DAL_ThongKe.Instance.GetSoLuongHhBanByTG_DAL(dtpBatDauThu.Value, dtpKetThucThu.Value).ToString();
                }
                else 
                {
                    dgvThu.DataSource = BLL_ThongKe.Instance.SearchListHDBHViewByTenNV(txtSearchThu.Text, dtpBatDauThu.Value, dtpKetThucThu.Value);
                    SetDoanhThuThuBySearch(dtpBatDauThu.Value, dtpKetThucThu.Value, "TenNV", txtSearchThu.Text);
                    lbSoLuongBan.Text = BLL_ThongKe.Instance.GetSoLuongBan().ToString();
                }
                }
         }

        private void btOkThu_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void btDetailHH_Click(object sender, EventArgs e)
        {
            if (dgvThu.SelectedRows.Count == 0) MessageBox.Show("Vui lòng chọn đối tượng hóa đơn");
            else if (dgvThu.SelectedRows.Count == 1)
            {
                ChiTietHoaDonNhapKho hd = new ChiTietHoaDonNhapKho(dgvThu.SelectedRows[0].Cells["MaHoaDon"].Value.ToString());
                hd.ShowDialog();
                
            }
        }
    }
 }

