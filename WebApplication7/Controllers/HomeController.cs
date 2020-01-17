using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string ssrsUrl = ConfigurationManager.AppSettings["SSRSReportsUrl"].ToString();
            ReportViewer viewer = new ReportViewer();
            IReportServerCredentials irsc = new CustomReportCredentials("uname", "pwd", "domain");

            viewer.ServerReport.ReportServerCredentials = irsc;
            viewer.ProcessingMode = ProcessingMode.Remote;
            viewer.SizeToReportContent = true;
            viewer.AsyncRendering = true;
            viewer.ServerReport.ReportServerUrl = new Uri(ssrsUrl);
            viewer.ServerReport.ReportPath = "/Temperature_Graphs_Reports/Temperature_Graphs";
            viewer.ServerReport.Refresh();

            ViewBag.ReportViewer = viewer;

            return View();
        }
    }
}