using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]


public class DuLieuChung
{

    public DuLieuChung()
    {
    }
    public string TenLop { get; set; }
    public string TenSinhVien { get; set; }
    public int SiSo { get; set; }
    public string DiaChi { get; set; }
    public string MaSinhVien { get; set; }
    public string MaLop { get; set; }
}



public class HienThiTenLop
{
    public string tenLop { get; set; }
}
public class Service : System.Web.Services.WebService
{
 
    DataQLSVDataContext db = new DataQLSVDataContext();

   

    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public List<SinhVien> HienThiSinhVien()
    {
        var danhSachSinhVien = db.SinhViens.ToList();
        return danhSachSinhVien;
    }

    [WebMethod]
    public List<SinhVien> HienThiSinhVien_DiaChiTraVinh()
    {
        var danhSachSinhVien_dcTraVinh = db.SinhViens.Where(sv => sv.DiaChi == "Trà Vinh").ToList();
        return danhSachSinhVien_dcTraVinh;
    }

    [WebMethod]
    public List<SinhVien> HienThiSinhVien_Nam_DiaChiTraVinh()
    {
        var danhSachSinhVien_nam_dcTraVinh = db.SinhViens.Where(sv => sv.DiaChi == "Trà Vinh" && sv.GioiTinh == "Nam").ToList();
        return danhSachSinhVien_nam_dcTraVinh;
    }

    [WebMethod]
    public List<HienThiTenLop> HienThiLop_SiSiLon20()
    {
        //var hienThiTenLop = db.Lops.Where(l => l.SiSo > 20).ToList();
        var hienThiTenLop = from l in db.Lops
                            where l.SiSo > 20
                            select new HienThiTenLop
                            {
                                tenLop = l.TenLop
                            };
        return hienThiTenLop.ToList();
    }

    //BT_18-11
    [WebMethod]
    //In ra họ tên sinh viên, tên lớp 
    public List<DuLieuChung> In_TenSV_Lop()
    {
        var result = from s in db.SinhViens
                     join l in db.Lops on s.MaLop equals l.MaLop
                     select new DuLieuChung()
                     {
                         TenSinhVien = s.HoTen,
                         TenLop = l.TenLop
                     };
        return result.ToList();
    }

    [WebMethod]
    // In ra họ tên sinh viên, tên lớp, sĩ số, địa chỉ của những sinh viên là nữ
    public List<DuLieuChung> In_SV()
    {
        var result = from s in db.SinhViens
                     join l in db.Lops on s.MaLop equals l.MaLop
                     where s.GioiTinh == "Nữ"
                     select new DuLieuChung()
                     {
                         TenSinhVien = s.HoTen,
                         TenLop = l.TenLop,
                         SiSo = Int32.Parse(l.SiSo.ToString()),
                         DiaChi = s.DiaChi
                     };
        return result.ToList();
    }

    [WebMethod]
    // In ra mã sinh viên, họ tên, giới tính, tên sinh viên có sĩ số >25
    public List<DuLieuChung> In_SV_siso25()
    {
        var result = from s in db.SinhViens
                     join l in db.Lops on s.MaLop equals l.MaLop
                     where l.SiSo > 25
                     select new DuLieuChung()
                     {
                         TenSinhVien = s.HoTen,
                         TenLop = l.TenLop,
                         SiSo = Int32.Parse(l.SiSo.ToString()),
                         DiaChi = s.DiaChi
                     };
        return result.ToList();
    }

    [WebMethod]
    // In ra mã sinh viên, họ tên, mã lớp, tên lớp có sĩ số <30 và có địa chỉ ở Trà Vinh
    public List<DuLieuChung> In_SV_Siso_TV()
    {
        var result = from s in db.SinhViens
                     join l in db.Lops on s.MaLop equals l.MaLop
                     where l.SiSo < 25 && s.DiaChi == "Trà Vinh"
                     select new DuLieuChung()
                     {
                         MaSinhVien = s.MaSV,
                         TenSinhVien = s.HoTen,
                         MaLop = l.MaLop,
                         TenLop = l.TenLop,                 
                     };
        return result.ToList();
    }

    [WebMethod]
    //In ra mã sinh viên, tên sinh viên, tên lớp  có sĩ số <30 hoặc có giới tính là nam
    public List<DuLieuChung> In_SV_SiSo_Nam()
    {
        var result = from s in db.SinhViens
                     join l in db.Lops on s.MaLop equals l.MaLop
                     where l.SiSo < 30 && s.GioiTinh == "Nam"
                     select new DuLieuChung()
                     {
                         MaSinhVien = s.MaSV,
                         TenSinhVien = s.HoTen,
                         TenLop = l.TenLop,
                     };
        return result.ToList();
    }

    [WebMethod]
    //Sắp xếp thông tin lớp tăng dần theo sĩ số
    public List<Lop> SapXepTangSS()
    {
        var result = from l in db.Lops
                     orderby l.SiSo ascending
                     select l;
                   
        return result.ToList();
    }

    [WebMethod]
    //Sắp xếp tăng dần theo tên sinh viên có giới tính là Nam
    public List<SinhVien> SapXepTangTenSV()
    {
        var result = from s in db.SinhViens
                     where s.GioiTinh == "Nam"
                     orderby s.HoTen ascending
                     select s;
        return result.ToList();
    }








}

