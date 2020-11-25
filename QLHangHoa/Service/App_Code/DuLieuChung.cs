using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BangSanPham
{
    public string MaSP { get; set; }

    public string TenSP { get; set; }

    public string DonViTinh { get; set; }

    public int SoLuong { get; set; }

    public int DonGia { get; set; }

    public string MaSP_LonHon100000 { get; set; }

    public int SoLuong_LonHon50 { get; set; }
}

public class BangNhanVien
{

    public string Ho { get; set; }

    public string Ten { get; set; }

    public string DiaChi { get; set; }

    public String NamSinh { get; set; }
}

public class BangNhaCungCap
{

    public string DiaChiNCC { get; set; }

    public string DienThoai { get; set; }
}

public class BangSP_BangNCC
{

    public string MaSP { get; set; }

    public string TenSP { get; set; }

    public string TenNCC { get; set; }

    public string MaSP_VietTienCC { get; set; }

    public string TenSP_VietTienCC { get; set; }

}

public class BangKH_BangSP
{
    public string HoKH { get; set; }

    public string TenKH { get; set; }
}

public class BangDDH_BangNV
{

    public string TenKhachHangDat { get; set; }

    public string NhanVienLap { get; set; }
}

public class BangSP_BangNCC_BangLH
{
    public string TenSanPham { get; set; }
    public string LoaiSP { get; set; }
    public string CongTyCC { get; set; }
    public string DiaChiCC { get; set; }
}
