using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
    string cn = @"Data Source=MARGARET; Initial Catalog=PsiqueHelp_ProyectDB; Integrated Security=True;";

        SqlConnection con = new SqlConnection(cn);

        SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("SELEC * FROM tb_UserDa;"));

        DataSet ds = new DataSet();

        adapter.Fill(ds);


        ReportDocument rp = new ReportDocument();
        rp.Load(Server.MapPath("RegistrosUsuarios.rpt"));
        rp.SetDataSource(ds.Tables["tb_UserDa"]);

        CrystalReportViewer1.ReportSource = rp;
        rp.ExportToHttpResponse(
            ExportFormatType.PortableDocFormat,
            Response,
            false,
            "RegistrosUsuarios"
            );

        Response.End();

    }
}