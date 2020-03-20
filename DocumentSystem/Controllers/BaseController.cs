using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentSystem.Models;

namespace DocumentSystem.Controllers
{
	public abstract class BaseController : Controller
	{
		protected BikeStores2Entities _db = new BikeStores2Entities();
	}




}