using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_Book_Store_Manager.DAL;
using PBL3_Book_Store_Manager.DTO;

namespace PBL3_Book_Store_Manager.BLL
{
    public class BLL_KhuTrungBay
    {
        private static BLL_KhuTrungBay _Instance;
        public static BLL_KhuTrungBay Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new BLL_KhuTrungBay();
                return _Instance;
            }
            private set { }
        }
        public void getListKhuTrungBay(ComboBox cbb)
        {
            List<DTO.KhuTrungBay> KhuTrungBay = new List<DTO.KhuTrungBay>();
            KhuTrungBay = DAL_KhuTrungBay.Instance.getListKhuTrungBay();
            cbb.DisplayMember = "TenKhuTrungBay";
            cbb.DataSource = KhuTrungBay;
        }
        public DTO.KhuTrungBay getKhuTrungBay(string MaKhuTrungBay)
        {
            List<DTO.KhuTrungBay> KTB = DAL_KhuTrungBay.Instance.getListKhuTrungBay("MaKhuTrungBay", MaKhuTrungBay);
            return KTB[0];
        }
        public DTO.KhuTrungBay getKhuTrungBay_Ten(string TenKhuTrungBay)
        {
            List<DTO.KhuTrungBay> KTB = DAL_KhuTrungBay.Instance.getListKhuTrungBay("TenKhuTrungBay", TenKhuTrungBay);
            return KTB[0];
        }
        public void ThemKhuTrungBay(DTO.KhuTrungBay KhuTrungBay)
        {
            DAL_KhuTrungBay.Instance.ThemKhuTrungBay(KhuTrungBay);
        }
        public void CapNhatKhuTrungBay(DTO.KhuTrungBay KhuTrungBay)
        {
            DAL_KhuTrungBay.Instance.CapNhatKhuTrungBay(KhuTrungBay);
        }
    }
}