﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentSystem.Models;

namespace DocumentSystem.Controllers
{
	//public class BaseController : Controller
	//{
	//	//public BaseController()
	//	//{
	//	//	this._dbService = new BikeStores2Entities();

	//	//}

	//	//private BikeStores2Entities _dbService;


	//	public BaseController()
	//	{
	//		this._db = new BikeStores2Entities();
	//	}

	//	public BikeStores2Entities _db;

	//}


	public abstract class BaseController : Controller
	{
		protected BikeStores2Entities _db = new BikeStores2Entities();
	}




}