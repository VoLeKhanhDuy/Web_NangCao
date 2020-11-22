using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BangSanPham
{
    public string MaSP { get; set; }

    public string TenSP { get; set; }

    public string DonViTinh { get; set; }

    public int? SoLuong { get; set; }

    public int? DonGia { get; set; }

    public string MaSP_LonHon100000 { get; set; }

    public int? SoLuong_LonHon50 { get; set; }
}

class BangNhanVien
{

    public string Ho { get; set; }

    public string Ten { get; set; }

    public string DiaChi { get; set; }

    //public DateTime? NamSinh { get; set; }
}

class BangNhaCungCap
{

    public string DiaChiNCC { get; set; }

    public string DienThoai { get; set; }
}

class BangSP_BangNCC
{

    public string MaSP { get; set; }

    public string TenSP { get; set; }

    public string TenNCC { get; set; }

    public string MaSP_VietTienCC { get; set; }

    public string TenSP_VietTienCC { get; set; }
}

class BangKH_BangSP
{

    public string HoKH { get; set; }

    public string TenKH { get; set; }
}

class BangDDH_BangNV
{

    public string TenKhachHangDat { get; set; }

    public string NhanVienLap { get; set; }
}
