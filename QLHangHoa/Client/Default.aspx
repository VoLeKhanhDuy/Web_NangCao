<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Hiển thị danh sách sản phẩm"></asp:Label><br />
        <asp:GridView ID="ltr_dssp" runat="server"></asp:GridView>
        <br /><br /><br />
        <asp:Label ID="Label2" runat="server" Text="Hiển thị danh sách nhà cung cấp"></asp:Label><br />
        <asp:GridView ID="ltr_dsncc" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label3" runat="server" Text="Hiển thị danh sách nhân viên"></asp:Label><br />
        <asp:GridView ID="ltr_dsnv" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label4" runat="server" Text="Hiển thị danh sách đơn hàng"></asp:Label><br />
        <asp:GridView ID="ltr_dsdh" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label5" runat="server" Text="Hiển thị thông tin Sản phẩm bao gồm Mã sản phẩm, tên sản phẩm, đơn vị tính, số lượng và đơn giá"></asp:Label><br />
        <asp:GridView ID="ltr_cau2" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label6" runat="server" Text="Họ tên và địa chỉ và năm sinh (lưu ý chỉ năm sinh không lấy ngày tháng) của các nhân viên trong công ty"></asp:Label><br />
        <asp:GridView ID="ltr_cau3" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label7" runat="server" Text="Cho biết địa chỉ và điện thoại của nhà cung cấp có tên TAM VIET là gì?"></asp:Label><br />
        <asp:GridView ID="ltr_cau4" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label8" runat="server" Text="Cho biết mã và tên của các sản phẩm có giá lớn hơn 100000 và số lượng hiện có ít hơn 50"></asp:Label><br />
        <asp:GridView ID="ltr_cau5" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label9" runat="server" Text="Cho biết mỗi sản phẩm trong công ty do ai cung cấp"></asp:Label><br />
        <asp:GridView ID="ltr_cau6" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label10" runat="server" Text="Công ty Việt Tiến đã cung cấp những mặt hàng nào?"></asp:Label><br />
        <asp:GridView ID="ltr_cau7" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label11" runat="server" Text="Cho biết mỗi sản phẩm thuộc loại sản phẩm nào và do những công ty nào cung cấp và địa chỉ của các công ty đó là gì?"></asp:Label><br />
        <asp:GridView ID="ltr_cau8" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label12" runat="server" Text="Những khách hàng nào đã đặt mua sản phẩm Sữa hộp XYZ của công ty?"></asp:Label><br />
        <asp:GridView ID="ltr_cau9" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label13" runat="server" Text="Đơn đặt hàng số 1 do ai đặt và do nhân viên nào lập"></asp:Label><br />
        <asp:GridView ID="ltr_cau10" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label14" runat="server" Text="Sắp xếp tăng dần danh sách nhân viên theo tên"></asp:Label>    <br />
        <asp:GridView ID="ltr_cau11" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label15" runat="server" Text="Sắp xếp giảm dần danh sách nhân viên có địa chỉ ở trà vinh theo Ho"></asp:Label><br /> 
        <asp:GridView ID="ltr_cau12_ho" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label16" runat="server" Text="Sắp xếp giảm dần danh sách nhân viên có địa chỉ ở trà vinh theo Ten"></asp:Label><br />
        <asp:GridView ID="ltr_cau12_ten" runat="server"></asp:GridView>
         <br /><br /><br />
        <asp:Label ID="Label17" runat="server" Text="Sắp xếp giảm dần các sản phẩm có đơn giá < 10000"></asp:Label> <br />    
        <asp:GridView ID="ltr_cau13" runat="server"></asp:GridView>

    </div>
    </form>
</body>
</html>
