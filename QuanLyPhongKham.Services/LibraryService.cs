using QuanLyPhongKham.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongKham.Model.DTO;

namespace QuanLyPhongKham.Services
{
    public class LibraryService :
        IBenhNhanRepository, ICanLamSanRepository, IChiTietCLSRepository,
        IChiTietDonThuocRepository, IChiTietNhapVatTuRepository,
        IChucDanhRepository, IChucVuRepository, IDichVuCLSRepository, IDonThuocRepository,
        IDonViTinhRepository, IHangSanXuatRepository, IHinhThucKhamRepository,
        IHoaDonRepository, IKhoaRepository, ILoaiCanLamSangRepository,
        ILoaiThuocRepository, INhaCungCapRepository, INhanVienRepository,
        IPhieuNhapRepository, IQuocGiaRepository, IChiTietNhapThuocRepository,
        ITaiKhoanRepository, IThuocRepository, IVatTuYTeRepository,
        IPhanQuyenRepository, IPhieuKhamRepository
    {


        #region Repositories

        private IBenhNhanRepository benhNhanRepository;
        private ICanLamSanRepository canLamSanRepository;
        private IChiTietCLSRepository chiTietCLSRepository;
        private IChiTietDonThuocRepository chiTietDonThuocRepository;
        private IChiTietNhapVatTuRepository chiTietNhapVatTuRepository;
        private IChiTietNhapThuocRepository chiTietNhapThuocRepository;
        private IChucDanhRepository chucDanhRepository;
        private IChucVuRepository chucVuRepository;
        private IDichVuCLSRepository dichVuCLSRepository;
        private IDonThuocRepository donThuocRepository;
        private IDonViTinhRepository donViTinhRepository;
        private IHangSanXuatRepository hangSanXuatRepository;
        private IHinhThucKhamRepository hinhThucKhamRepository;
        private IHoaDonRepository hoaDonRepository;
        private IKhoaRepository khoaRepository;
        private ILoaiCanLamSangRepository loaiCanLamSanRepository;
        private ILoaiThuocRepository loaiThuocRepository;
        private INhaCungCapRepository nhaCungCapRepository;
        private INhanVienRepository nhanVienRepository;
        private IPhanQuyenRepository phanQuyenRepository;
        private IPhieuKhamRepository phieuKhamRepository;
        private IPhieuNhapRepository phieuNhapRepository;
        private IQuocGiaRepository quocGiaRepository;
        private ITaiKhoanRepository taiKhoanRepository;
        private IThuocRepository thuocRepository;
        private IVatTuYTeRepository vatTuYTeRepository;


        #endregion



        #region constructor

        internal LibraryService() { }

        internal LibraryService(IBenhNhanRepository benhNhanRepository, ICanLamSanRepository canLamSanRepository, IChiTietCLSRepository chiTietCLSRepository, IChiTietDonThuocRepository chiTietDonThuocRepository, IChiTietNhapVatTuRepository chiTietNhapVatTuRepository, IChiTietNhapThuocRepository chiTietNhapThuocRepository, IChucDanhRepository chucDanhRepository, IChucVuRepository chucVuRepository, IDichVuCLSRepository dichVuCLSRepository, IDonThuocRepository donThuocRepository, IDonViTinhRepository donViTinhRepository, IHangSanXuatRepository hangSanXuatRepository, IHinhThucKhamRepository hinhThucKhamRepository, IHoaDonRepository hoaDonRepository, IKhoaRepository khoaRepository, ILoaiCanLamSangRepository loaiCanLamSanRepository, ILoaiThuocRepository loaiThuocRepository, INhaCungCapRepository nhaCungCapRepository, INhanVienRepository nhanVienRepository, IPhanQuyenRepository phanQuyenRepository, IPhieuKhamRepository phieuKhamRepository, IPhieuNhapRepository phieuNhapRepository, IQuocGiaRepository quocGiaRepository, ITaiKhoanRepository taiKhoanRepository, IThuocRepository thuocRepository, IVatTuYTeRepository vatTuYTeRepository)
        {
            this.benhNhanRepository = benhNhanRepository;
            this.canLamSanRepository = canLamSanRepository;
            this.chiTietCLSRepository = chiTietCLSRepository;
            this.chiTietDonThuocRepository = chiTietDonThuocRepository;
            this.chiTietNhapVatTuRepository = chiTietNhapVatTuRepository;
            this.chiTietNhapThuocRepository = chiTietNhapThuocRepository;
            this.chucDanhRepository = chucDanhRepository;
            this.chucVuRepository = chucVuRepository;
            this.dichVuCLSRepository = dichVuCLSRepository;
            this.donThuocRepository = donThuocRepository;
            this.donViTinhRepository = donViTinhRepository;
            this.hangSanXuatRepository = hangSanXuatRepository;
            this.hinhThucKhamRepository = hinhThucKhamRepository;
            this.hoaDonRepository = hoaDonRepository;
            this.khoaRepository = khoaRepository;
            this.loaiCanLamSanRepository = loaiCanLamSanRepository;
            this.loaiThuocRepository = loaiThuocRepository;
            this.nhaCungCapRepository = nhaCungCapRepository;
            this.nhanVienRepository = nhanVienRepository;
            this.phanQuyenRepository = phanQuyenRepository;
            this.phieuKhamRepository = phieuKhamRepository;
            this.phieuNhapRepository = phieuNhapRepository;
            this.quocGiaRepository = quocGiaRepository;
            this.taiKhoanRepository = taiKhoanRepository;
            this.thuocRepository = thuocRepository;
            this.vatTuYTeRepository = vatTuYTeRepository;
        }


        #endregion



        #region Services cho tài khoản
        public int Login(string userName, string passWord)
        {
            return taiKhoanRepository.Login(userName, passWord);
        }





        #endregion



        #region BenhNhanServices
        public List<BenhNhan> DanhSachBenhNhan()
        {
            return benhNhanRepository.DanhSachBenhNhan();
        }



        public List<BenhNhan> TimKiemBenhNhan(string col, string info)
        {
            return benhNhanRepository.TimKiemBenhNhan(col, info);
        }


        #endregion

        #region PhieuKhamServices
        public List<PhieuKham_BenhNhanChoKham> DanhSachChoKham()
        {
            return phieuKhamRepository.DanhSachChoKham();
        }


        public List<PhieuKham_BenhNhanTimKiem> KetQuaTimPhieuKham(string ten)
        {
            return phieuKhamRepository.KetQuaTimPhieuKham(ten);

        }
        public PhieuKham_BenhNhanLamSang DanhSachPhieuKham(int maphieu)
        {
            return phieuKhamRepository.DanhSachPhieuKham(maphieu);
        }

        public int LuuPhieuKham(PhieuKham_BenhNhanLamSang pkbn)
        {
            int row = phieuKhamRepository.LuuPhieuKham(pkbn);
            return row;
        }

        public List<PhieuKham_LichSuKham> LichSuKham(int mabn)
        {
            return phieuKhamRepository.LichSuKham(mabn);
        }

        #endregion

        #region DonThuocServices


        public int ThemDonThuoc(Donthuoc donthuoc)
        {
            int row = donThuocRepository.ThemDonThuoc(donthuoc);
            return row;
        }

        public int TaoChiTietDonThuoc(Chitietdonthuoc ctdt, int maphieu)
        {
            int row = chiTietDonThuocRepository.TaoChiTietDonThuoc(ctdt, maphieu);
            return row;
        }

        public List<Chitietdonthuoc_Thuoc> DanhSachChiTietDonThuoc(int maphieu)
        {
            return chiTietDonThuocRepository.DanhSachChiTietDonThuoc(maphieu);
        }



        #endregion


    }
}

