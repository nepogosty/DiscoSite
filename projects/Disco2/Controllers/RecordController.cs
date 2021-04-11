using ClosedXML;
using Disco2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Disco2.Controllers
{
    public class RecordController : Controller
    {
        // GET: Record
        public IList<RecordModel> GetEmployeeList()
        {
            DiscoContext db = new DiscoContext();
            var employeeList = (from e in db.Музыканты
                                    // join d in db.Жанры on e.ID_жанра equals d.ID_жанра
                                select new RecordModel
                                {
                                    Фамилия = e.Фамилия,
                                    Имя = e.Имя,


                                    Отчество = e.Отчество,
                                    Гражданство = e.Гражданство,
                                }).ToList();
            return employeeList;
        }
        // GET: Employee  
        public ActionResult Index()
        {
            return View(this.GetEmployeeList());
        }
        public ActionResult ExportToExcel()
        {
            var gv = new GridView();
            gv.DataSource = this.GetEmployeeList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return Redirect("/Record/Index");
        }
    }
}

