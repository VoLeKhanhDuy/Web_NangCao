using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    ServiceReference.ServiceSoapClient sv = new ServiceReference.ServiceSoapClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        ltr_dssp.DataSource = sv.HienThi_DSSP();
        ltr_dssp.DataBind();

        ltr_dsncc.DataSource = sv.HienThi_DSNCC();
        ltr_dsncc.DataBind();

        ltr_dsnv.DataSource = sv.HienThi_DSNV();
        ltr_dsnv.DataBind();

        ltr_dsdh.DataSource = sv.HienThi_DSDH();
        ltr_dsdh.DataBind();

        ltr_cau2.DataSource = sv.HienThi_TTSP();
        ltr_cau2.DataBind();

        ltr_cau3.DataSource = sv.HienThi_TTNV();
        ltr_cau3.DataBind();

        ltr_cau4.DataSource = sv.HienThi_TTNCC();
        ltr_cau4.DataBind();

        ltr_cau5.DataSource = sv.HienThi_MaTenSP();
        ltr_cau5.DataBind();

        ltr_cau6.DataSource = sv.HienThi_SP_NCC();
        ltr_cau6.DataBind();

        ltr_cau7.DataSource = sv.HienThi_SP_NCC_VietTien();
        ltr_cau7.DataBind();

        ltr_cau8.DataSource = sv.HienThi_SP_NNC_DC();
        ltr_cau8.DataBind();

        ltr_cau9.DataSource = sv.HienThi_KH_SP();
        ltr_cau9.DataBind();

        ltr_cau10.DataSource = sv.HienThi_KH_NV();
        ltr_cau10.DataBind();

        ltr_cau11.DataSource = sv.SapTang_NV_Ten();
        ltr_cau11.DataBind();

        ltr_cau12_ho.DataSource = sv.SapGiam_NVTV_Ho();
        ltr_cau12_ho.DataBind();

        ltr_cau12_ten.DataSource = sv.SapGiam_NVTV_Ten();
        ltr_cau12_ten.DataBind();

        ltr_cau13.DataSource = sv.SapGiam_SP_DonGiaDuoi10000();
        ltr_cau13.DataBind();
    }
}