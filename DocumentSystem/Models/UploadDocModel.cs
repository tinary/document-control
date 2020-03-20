using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentSystem.Models
{
	public class UploadDocModel
	{
		public HttpPostedFileBase File { get; set; }
		public List<InvoiceDetailsModel> FileList { get; set; }

		public Int32? OrderID { get; set; }
	}

	public class InvoiceDetailsModel
	{
		public Int32? InvoiceID { get; set; }
		public Int32? OrderID { get; set; }
		public String InvoicePO { get; set; }
		public String InvoiceMIME { get; set; }
		public Byte[] InvoiceDocument { get; set; }
	}

}