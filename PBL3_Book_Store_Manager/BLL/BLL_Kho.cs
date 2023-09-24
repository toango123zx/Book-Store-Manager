using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_Book_Store_Manager.DAL;

namespace PBL3_Book_Store_Manager.BLL
{
    public class BLL_Kho
    {
        private static BLL_Kho _Instance;
        public static BLL_Kho Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_Kho();
                return _Instance;
            }
            private set { }
        }
        public void getListKho(ComboBox cbb)
        {
            List<DTO.Kho> kho = new List<DTO.Kho>();
            kho = DAL_Kho.Instance.getListKho();
            cbb.DisplayMember = "TenKho";
            cbb.DataSource = kho;
        }
        public DTO.Kho getKho(string MaKho)
        {
            List<DTO.Kho> Kho = DAL_Kho.Instance.getListKho("MaKho", MaKho);
            return Kho[0];
        }
    }
}