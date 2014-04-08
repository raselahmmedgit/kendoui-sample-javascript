using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RnD.KendoUISample.Models;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace RnD.KendoUISample.WebViews
{
    public partial class ExportToPdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AppDbContext _db = new AppDbContext();

                var categories = _db.Categories.ToList().Select(c => new Category { CategoryId = c.CategoryId, Name = c.Name });

                try
                {
                    this.gvExportToPdf.DataSource = categories;
                    this.gvExportToPdf.DataBind();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        protected void btnCodePrint_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToPDF();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnJQPrint_Click(object sender, EventArgs e)
        {

        }

        private void ExportToPDF()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    this.gvExportToPdf.AllowPaging = false;
                    //this.BindGridView();

                    this.gvExportToPdf.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=DashboardReport.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
            server control at run time. */
        }
    }
}