using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentSystem.Models;
using DocumentSystem.BAL;

namespace DocumentSystem.Controllers
{
    public class POViewerController : Controller
    {
        // GET: POViewer
    //    public ActionResult Index(string PONumber)
				//{
				//	POViwerModel POModel = new POViwerModel();

				//	try
				//	{
				//		POViewerServices PSvc = new POViewerServices();
				//		POModel = PSvc.GetPODocument(PONumber).Select(p => new POViwerModel
				//		{
				//			InvoiceID = p.invoice_id,
				//			InvoicePO = p.invoice_PO,
				//			InvoiceMIME = p.invoice_MIME
				//		}).ToList();

				//	}
				//	catch (Exception ex)
				//	{
				//		Console.Write(ex);
				//	}
				//	return this.View(POModel);
				//}


				public ActionResult GetPOFile(string PONumber)
				{
					POViwerModel POModel = new POViwerModel();

					try
					{
						POViewerServices PSvc = new POViewerServices();
						POModel = PSvc.GetPODocument(PONumber);

						if (POModel.InvoiceDocument.Length > 0)
						{
							return File(POModel.InvoiceDocument, POModel.InvoiceMIME);
						}
					}
					catch (Exception ex)
					{
						Console.Write(ex);
					}
					return View("POViewer", POModel);
				}


				public ActionResult Index()
				{
					return View();
				}
		
	}
}