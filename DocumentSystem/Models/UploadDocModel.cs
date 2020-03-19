using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentSystem.Models
{
	public class UploadDocModel
	{
		public HttpPostedFileBase File { get; set; }
		//public List<FileDetailsModel> FileList { get; set; }
		public List<InvoiceDetailsModel> FileList { get; set; }
	}


	//public class InvoiceDetailsModel
	//{
	//	public int InvoiceID { get; set; }
	//	public int OrderID { get; set; }
	//	public string InvoicePO { get; set; }
	//	public string InvoiceMIME { get; set; }
	//	public string InvoiceDocument { get; set; }
	//}


	public class InvoiceDetailsModel
	{
		public Int32? InvoiceID { get; set; }
		public Int32? OrderID { get; set; }
		public String InvoicePO { get; set; }
		public String InvoiceMIME { get; set; }
		public Byte[] InvoiceDocument { get; set; }
	}

}