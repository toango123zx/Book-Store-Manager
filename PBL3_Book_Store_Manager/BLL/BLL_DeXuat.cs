 using PBL3_Book_Store_Manager.DAL;
using PBL3_Book_Store_Manager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_Book_Store_Manager.BLL
{
    public class BLL_DeXuat
    {
        private static BLL_DeXuat _Instance;
        public static BLL_DeXuat Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BLL_DeXuat();
                }
                return _Instance;
            }
            private set { }
        }
        private BLL_DeXuat()
        {

        }
        //DE XUAT

        public List<DeXuat> GetAllListDeXuat_BLL()
        {
            return DAL_DeXuat.Instance.GetAllListDeXuat();
        }
        public List<DeXuat> GetAllListDeXuatView_BLL()
        {
            List<DeXuat> result = new List<DeXuat> ();
            foreach(DeXuat i in GetAllListDeXuat_BLL())
            {
                DeXuat de = i;
                de.MaNhanVien = BLL_NV.Instance.GetNVByMaNV(i.MaNhanVien).TenNhanVien;
                result.Add(de);
            }
            return result;
        }
        public DeXuat GetDeXuatByMaDeXuat(string MaDX)
        {
            foreach(DeXuat i in GetAllListDeXuat_BLL())
            {
                if(i.MaDeXuat == MaDX)
                {
                    DeXuat s = i;
                    return s;
                }
            }
            return null;
        }
        public DeXuat GetDeXuatViewByMaDeXuat(string MaDX)
        {
            foreach (DeXuat i in GetAllListDeXuatView_BLL())
            {
                if (i.MaDeXuat == MaDX)
                {
                    DeXuat s = i;
                    return s;
                }
            }
            return null;
        }

        public void AddDeXuat_BLL(DeXuat s)
        {
            DAL_DeXuat.Instance.AddDeXuat(s);
        }
        public DeXuat GetLasTestDeXuat()
        {
            List<DeXuat> data = GetAllListDeXuat_BLL();
            return data[data.Count - 1];
        }

        public List<DeXuat> SearchListDeXuatByMaDX(string MaDX)
        {
            List<DeXuat> data = GetAllListDeXuatView_BLL();
            List<DeXuat> result = new List<DeXuat>();
            if (MaDX == null) result = data;
            else
            {
                foreach (DeXuat i in data)
                {
                    if (i.MaDeXuat.Contains(MaDX) )
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }

        public List<DeXuat> SearchListDeXuatByTenNV(string TenNV)
        {
            List<DeXuat> data = GetAllListDeXuatView_BLL();
            List<DeXuat> result = new List<DeXuat>();
            if (TenNV == null) result = data;
            else
            {
                foreach (DeXuat i in data)
                {
                    if (i.MaNhanVien.Contains(TenNV))
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }

        public List<DeXuat> SearchListDeXuatByLoaiDX(string LoaiDX)
        {
            List<DeXuat> data = GetAllListDeXuatView_BLL();
            List<DeXuat> result = new List<DeXuat>();
            if (LoaiDX == null) result = data;
            else
            {
                foreach (DeXuat i in data)
                {
                    if (i.LoaiDeXuat.Contains(LoaiDX))
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }

        public List<DeXuat> SearchListDeXuatByTinhTrang(string TinhTrang)
        {
            List<DeXuat> data = GetAllListDeXuatView_BLL();
            List<DeXuat> result = new List<DeXuat>();
            if (TinhTrang == null) result = data;
            else
            {
                foreach (DeXuat i in data)
                {
                    if (i.TinhTrang.Contains(TinhTrang))
                    {
                        result.Add(i);
                    }
                }
            }
            return result;
        }

        public void UpdateTrangThaiDX_BLL(string TinhTrang, string MaDeXuat)
        {
            DAL_DeXuat.Instance.UpdateTrangThaiDX(TinhTrang, MaDeXuat);
        }
        //CHI TIET DE XUAT 


        //NCU
        public List<ChiTietDeXuatNCU> GetAllListCTDeXuatNCU_BLL()
        {
            return DAL_DeXuat.Instance.GetAllListCTDeXuatNCU();
        }
        public ChiTietDeXuatNCU GetChiTietDeXuatNCUByMaDX(string maDX)
        {
            foreach(ChiTietDeXuatNCU i in GetAllListCTDeXuatNCU_BLL())
            {
                if(i.MaDeXuat == maDX )
                {
                    return i;
                }
            }
            return null;
        }
        public void AddChiTietDeXuat_BLL(ChiTietDeXuatNCU s)
        {
            DAL_DeXuat.Instance.AddCTDeXuatNCU(s);
        }



        //HH
        public List<ChiTietDeXuatHH> GetAllListCTDeXuatHH_BLL()
        {
            return DAL_DeXuat.Instance.GetAllListCTDeXuatHH();
        }
        public ChiTietDeXuatHH GetChiTietDeXuatHHByMaDX(string maDX)
        {
            foreach (ChiTietDeXuatHH i in GetAllListCTDeXuatHH_BLL())
            {
                if (i.MaDeXuat == maDX)
                {
                    return i;
                }
            }
            return null;
        }
        public void AddChiTietDeXuatHH_BLL(ChiTietDeXuatHH s)
        {
            DAL_DeXuat.Instance.AddCTDeXuatHH(s);
        }

        //HOA DON

        public List<ChiTietDeXuatHD> GetAllListCTDeXuatHD_BLL()
        {
            return DAL_DeXuat.Instance.GetAllListCTDeXuatHD();
        }
        public ChiTietDeXuatHD GetChiTietDeXuatHDByMaDX(string maDX)
        {
            foreach (ChiTietDeXuatHD i in GetAllListCTDeXuatHD_BLL())
            {
                if (i.MaDeXuat == maDX)
                {
                    return i;
                }
            }
            return null;
        }
        public void AddChiTietDeXuatHD_BLL(ChiTietDeXuatHD s)
        {
            DAL_DeXuat.Instance.AddCTDeXuatHD(s);
        }

        //PHAN HOI 
        public List<PhanHoi> GetAllListPhanHoi_BLL()
        {
            return DAL_DeXuat.Instance.GetAllListPhanHoi();
        }

        public PhanHoi GetListPhanHoiByMaDeXuat(string MaDX)
        {
            foreach(PhanHoi i in GetAllListPhanHoi_BLL())
            {
                if(i.MaDeXuat == MaDX)
                {
                    return i;
                }
            }
            return null;
        }
        public void AddPhanHoi(PhanHoi s)
        {
            DAL_DeXuat.Instance.AddPhanHoi(s);
        }
    }
}
