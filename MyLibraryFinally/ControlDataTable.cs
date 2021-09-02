using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyLibraryFinally
{
    public class ControlDataTable
    {
        public static DataTable CreateDataTableExample(DataTable table)
        {
            table = new DataTable();
            //DataTable table = new DataTable();
            DataColumn colbelgetarihi = new DataColumn("Belge Tarihi", typeof(String));
            table.Columns.Add(colbelgetarihi);
            DataColumn colbelgeturu = new DataColumn("Belge Türü", typeof(String));
            table.Columns.Add(colbelgeturu);
            DataColumn colsirketkodu = new DataColumn("Şirket Kodu", typeof(String));
            table.Columns.Add(colsirketkodu);
            DataColumn colkayittarihi = new DataColumn("Kayıt Tarihi", typeof(String));
            table.Columns.Add(colkayittarihi);
            DataColumn colbelgeparabirimi = new DataColumn("Belge Para Birimi", typeof(String));
            table.Columns.Add(colbelgeparabirimi);

            DataRow rows = table.NewRow();
            rows[0] = DateTime.Now.ToShortDateString();
            rows[1] = "FATURA";
            rows[2] = "51239";
            rows[3] = DateTime.Now.ToShortDateString();
            rows[4] = "TRY";
            return table;
        }

        public static void DownloadAsExcelFromDataTable(DataTable table)
        {
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=SapFI.xls");
            //Response.Charset = "";
            //Response.ContentEncoding = Encoding.UTF8;
            //Response.ContentType = "application/vnd.ms-excel";
            //GridView excel = new GridView();
            //excel.DataSource = table;
            //excel.DataBind();
            //excel.RenderControl(new HtmlTextWriter(Response.Output));
            //Response.Flush();
            //Response.End();
        }
    }
}
