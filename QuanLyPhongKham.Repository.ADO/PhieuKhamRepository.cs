using QuanLyPhongKham.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongKham.Model.DTO;
using System.Data;

namespace QuanLyPhongKham.Repository.ADO
{
    public class PhieuKhamRepository : IPhieuKhamRepository
    {
        public List<PhieuKham_BenhNhanChoKham> DanhSachChoKham()
        {
            List<PhieuKham_BenhNhanChoKham> list = new List<PhieuKham_BenhNhanChoKham>();

            DataTable table = DataProvider.Instane.ExecuteReader("EXECUTE dbo.SP_Select_Phieukham_Chokham");



            foreach (DataRow row in table.Rows)
            {
                list.Add(new PhieuKham_BenhNhanChoKham(row));
            }
            return list;
        }   

        public List<PhieuKham_BenhNhanTimKiem> KetQuaTimPhieuKham(string ten)
        {
            List<PhieuKham_BenhNhanTimKiem> list = new List<PhieuKham_BenhNhanTimKiem>();
            DataTable table = DataProvider.Instane.ExecuteReader(" EXECUTE dbo.SP_Search_Phieukham_By_Ten @TEN", new object[] {ten});

            foreach (DataRow row in table.Rows)
            {
                list.Add(new PhieuKham_BenhNhanTimKiem(row));
            }
            return list;
        }
        public PhieuKham_BenhNhanLamSang DanhSachPhieuKham(int maphieu)
        {
            PhieuKham_BenhNhanLamSang pk = new PhieuKham_BenhNhanLamSang();
            DataTable table = DataProvider.Instane.ExecuteReader("EXECUTE dbo.SP_Search_Phieukham_By_Id @ID", new object[] { maphieu });

            foreach (DataRow row in table.Rows)
            {
               pk = new PhieuKham_BenhNhanLamSang(row);
            }
            return pk ;
        }

        public int LuuPhieuKham(PhieuKham_BenhNhanLamSang pkbn)
        {
            int row = DataProvider.Instane.ExecuteNonQuery("EXECUTE dbo.SP_Update_Phieukham @MAPHIEUKHAM , @MABN , @CHUANDOAN , @NHIPTIM , @NHIETDO , @HUYETAP , @CANNANG , @CHIEUCAO , @MAICD , @NGAYKHAM , @KETLUAN , @TIENSU", new object[] { pkbn.MaPhieuKham, pkbn.MaBN, pkbn.ChuanDoan, pkbn.NhipTim, pkbn.NhietDo, pkbn.HuyetAp, pkbn.CanNang, pkbn.ChieuCao, pkbn.MaICD, pkbn.NgayKham, pkbn.KetLuan, pkbn.TienSu});
            return row;
        }
    }
}
