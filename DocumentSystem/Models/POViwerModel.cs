using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentSystem.Models
{
	public class PODetailModel
	{
		public String PONumber { get; set; }
		public List<POViwerModel> POList { get; set; }
		
	}

	public class POViwerModel
	{
		public String PONumber { get; set; }
		public Int32? InvoiceID { get; set; }
		public Int32? OrderID { get; set; }
		public String InvoiceMIME { get; set; }
		public Byte[] InvoiceDocument { get; set; }
		public Int32 StoreID { get; set; }
		public String StoreName { get; set; }
	}
}