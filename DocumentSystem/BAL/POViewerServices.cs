using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentSystem.Models;

namespace DocumentSystem.BAL
{
	public class POViewerServices : BaseServiceClass
	{

		/// <summary>
		/// Find matching PO number from database
		/// </summary>
		/// <param name="PONumber">a string parameter</param>
		/// <returns>return a model</returns>
		public POViwerModel GetPODocument(string PONumber)
		{
			POViwerModel po = _db.InvoiceDocuments
								.Where(w => w.invoice_PO == PONumber)
								.Select(x => new POViwerModel
								{
									PONumber = x.invoice_PO,
									InvoiceID = x.invoice_id,
									InvoiceMIME = x.invoice_MIME,
									InvoiceDocument = x.invoice_document,
								}).FirstOrDefault();
			return po;
		}


		//public List<POViwerModel> GetPODetails(string PONumber)
		//{
		//	List<POViwerModel> doc = _db.vwDocumentLookups
		//							.Where(w => w.invoice_PO == PONumber)
		//							.Select(x => new POViwerModel
		//							{
		//								PONumber = x.invoice_PO,
		//								InvoiceID = x.invoice_id,
		//								OrderID = x.order_id,
		//								InvoiceMIME = x.invoice_MIME,
		//								InvoiceDocument = x.invoice_document,
		//								StoreID = x.store_id,
		//								StoreName = x.store_name
		//							}).ToList();
		//	return doc;
		//}

	}
}