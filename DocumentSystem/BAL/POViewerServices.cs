using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentSystem.Models;

namespace DocumentSystem.BAL
{
	public class POViewerServices : BaseServiceClass
	{

		//public List<POViwerModel> GetPODocument(string PONumber)
		//{
		//	List<POViwerModel> po = _db.vwDocumentLookups
		//						.Where(w => w.invoice_PO == PONumber)
		//						.Select(x => new POViwerModel
		//						{
		//							PONumber = x.invoice_PO,
		//							OrderID = x.order_id,
		//							InvoiceMIME = x.invoice_MIME,
		//							InvoiceDocument = x.invoice_document,
		//							StoreID = x.store_id,
		//							StoreName = x.store_name
		//							}).ToList();
		//	return po;
		//}

		public POViwerModel GetPODocument(string PONumber)
		{
			POViwerModel po = _db.vwDocumentLookups
								.Where(w => w.invoice_PO == PONumber)
								.Select(x => new POViwerModel
								{
									PONumber = x.invoice_PO,
									InvoiceID = x.invoice_id,
									OrderID = x.order_id,
									InvoiceMIME = x.invoice_MIME,
									InvoiceDocument = x.invoice_document,
									StoreID = x.store_id,
									StoreName = x.store_name
								}).FirstOrDefault();
			return po;
		}

	}
}