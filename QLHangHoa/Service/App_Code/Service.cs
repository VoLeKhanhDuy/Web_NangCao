using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    QLHangHoaDataContext db = new QLHangHoaDataContext();
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    // Hiển thị danh sách sản phẩm
    public List<SANPHAM> HienThi_DSSP()
    {
        return db.SANPHAMs.ToList();
    }

    [WebMethod]
    // Hiển thị danh sách nhà cung cấp
    public List<NHACUNGCAP> HienThi_DSNCC()
    {
        return db.NHACUNGCAPs.ToList();
    }

    [WebMethod]
    // Hiển thị danh sách nhân viên
    public List<NHANVIEN> HienThi_DSNV()
    {
        return db.NHANVIENs.ToList();
    }

    [WebMethod]
    // Hiển thị danh sách đơn hàng
    public List<DONDATHANG> HienThi_DSDH()
    {
        return db.DONDATHANGs.ToList();
    }

    [WebMethod]
    // Hiển thị thông tin Sản phẩm bao gồm Mã sản phẩm, tên sản phẩm, đơn vị tính, số lượng và đơn giá
    public List<BangSanPham> HienThi_TTSP()
    {
        var result = from sp in db.SANPHAMs
                     select new BangSanPham
                     {
                         MaSP = sp.MaSP,
                         TenSP = sp.TenSP,
                         DonViTinh = sp.DonViTinh,
                         SoLuong = Int32.Parse(sp.SoLuong.ToString()),
                         DonGia = Int32.Parse(sp.DonGia.ToString())
                     };
        return result.ToList();
    }

    [WebMethod]
    // Họ tên và địa chỉ và năm sinh (lưu ý chỉ năm sinh không lấy ngày tháng) của các nhân viên trong công ty.
    public List<BangNhanVien> HienThi_TTNV()
    {
        var result = from nv in db.NHANVIENs
                     select new BangNhanVien
                     {
                         Ho = nv.Ho,
                         Ten = nv.Ten,
                         DiaChi = nv.DiaChi,
                         NamSinh = nv.NgaySinh.Value.Year.ToString()
                     };
        return result.ToList();
    }

    [WebMethod]
    // Cho biết địa chỉ và điện thoại của nhà cung cấp có tên TAM VIET là gì?
    public List<BangNhaCungCap> HienThi_TTNCC()
    {
        var result = from ncc in db.NHACUNGCAPs
                     where ncc.TenNCC == "TAM VIET"
                     select new BangNhaCungCap
                     {
                         DiaChiNCC = ncc.DiaChi,
                         DienThoai = ncc.DienThoai
                     };
        return result.ToList();
    }

    [WebMethod]
    // Cho biết mã và tên của các sản phẩm có giá lớn hơn 100000 và số lượng hiện có ít hơn 50
    public List<BangSanPham> HienThi_MaTenSP()
    {
        var result = from sp in db.SANPHAMs
                     where sp.DonGia > 100000 && sp.SoLuong < 50
                     select new BangSanPham
                     {
                         MaSP_LonHon100000 = sp.MaSP,
                         SoLuong_LonHon50 = Int32.Parse(sp.SoLuong.ToString())
                     };
        return result.ToList();
    }

    [WebMethod]
    // Cho biết mỗi sản phẩm trong công ty do ai cung cấp.
    public List<BangSP_BangNCC> HienThi_SP_NCC()
    {
        var result = from sp in db.SANPHAMs
                     join ncc in db.NHACUNGCAPs on sp.MaNCC equals ncc.MaNCC            
                     select new BangSP_BangNCC
                     {
                         MaSP = sp.MaSP,
                         TenSP = sp.TenSP,
                         TenNCC = ncc.TenNCC
                     };
        return result.ToList();
    }

    [WebMethod]
    // Công ty Việt Tiến đã cung cấp những mặt hàng nào?
    public List<BangSP_BangNCC> HienThi_SP_NCC_VietTien()
    {
        var result = from sp in db.SANPHAMs
                     join ncc in db.NHACUNGCAPs on sp.MaNCC equals ncc.MaNCC
                     where ncc.TenNCC == "Việt Tiến"
                     select new BangSP_BangNCC
                     {
                         MaSP_VietTienCC = sp.MaSP,
                         TenSP_VietTienCC = sp.TenSP
                     };
        return result.ToList();
    }

    [WebMethod]
    //Cho biết mỗi sản phẩm thuộc loại sản phẩm nào và do những công ty nào cung cấp và địa chỉ của các công ty đó là gì?
    public List<BangSP_BangNCC_BangLH> HienThi_SP_NNC_DC()
    {
        var result = from sp in db.SANPHAMs
                     join lh in db.LOAIHANGs on sp.MaLH equals lh.MaLoai
                     join ncc in db.NHACUNGCAPs on sp.MaNCC equals ncc.MaNCC
                     select new BangSP_BangNCC_BangLH
                     {
                         TenSanPham = sp.TenSP,
                         LoaiSP = lh.TenLoai,
                         CongTyCC = ncc.TenNCC,
                         DiaChiCC = ncc.DiaChi
                     };
        return result.ToList();
    }


    [WebMethod]
    // Những khách hàng nào đã đặt mua sản phẩm Sữa hộp XYZ của công ty?    public List<BangKH_BangSP> HienThi_KH_SP()
    {
        var result = from kh in db.KHACHHANGs
                     join dh in db.DONDATHANGs on kh.MaKH equals dh.MaKH
                     join ctdh in db.CHITIETDATHANGs on dh.SoDDH equals ctdh.SoDDH
                     join sp in db.SANPHAMs on ctdh.MaSP equals sp.MaSP
                     where sp.TenSP == "Sũa hộp XYZ"
                     select new BangKH_BangSP
                     {
                         HoKH = kh.Ho,
                         TenKH = kh.Ten,
                     };
        return result.ToList();
    }

    [WebMethod]
    // Đơn đặt hàng số 1 do ai đặt và do nhân viên nào lập
    public List<BangDDH_BangNV> HienThi_KH_NV()
    {
        var result = from kh in db.KHACHHANGs
                     join ddh in db.DONDATHANGs on kh.MaKH equals ddh.MaKH
                     join nv in db.NHANVIENs on ddh.MaNV equals nv.MaNV
                     where ddh.SoDDH == "01"
                     select new BangDDH_BangNV
                     {
                         TenKhachHangDat = kh.Ten,
                         NhanVienLap = nv.Ten
                     };
                     
        return result.ToList();
    }

    [WebMethod]
    // Sắp xếp tăng dần danh sách nhân viên theo tên
    public List<NHANVIEN> SapTang_NV_Ten()
    {
        var result = from nv in db.NHANVIENs
                     orderby nv.Ten ascending
                     select nv;
        return result.ToList();
    }

    [WebMethod]
    // Sắp xếp giảm dần danh sách nhân viên có địa chỉ ở trà vinh theo Ho, Ten
    public List<NHANVIEN> SapGiam_NVTV_Ho()
    {
        var result = from nv in db.NHANVIENs
                     where nv.DiaChi == "Trà Vinh"
                     orderby nv.Ho descending
                     select nv;
        return result.ToList();
    }
    [WebMethod]
    // Sắp xếp giảm dần danh sách nhân viên có địa chỉ ở trà vinh theo Ho, Ten
    public List<NHANVIEN> SapGiam_NVTV_Ten()
    {
        var result = from nv in db.NHANVIENs
                     where nv.DiaChi == "Trà Vinh"
                     orderby nv.Ten descending
                     select nv;
        return result.ToList();
    }

    [WebMethod]
    // Sắp xếp giảm dần các sản phẩm có đơn giá < 10000
    public List<SANPHAM> SapGiam_SP_DonGiaDuoi10000()
    {
        var result = from sp in db.SANPHAMs
                     where sp.DonGia < 10000
                     orderby sp.TenSP descending
                     select sp;
        return result.ToList();
    }

  


}