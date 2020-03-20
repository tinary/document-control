using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using DocumentSystem.Models;

namespace DocumentSystem.Controllers
{
	public class InvoiceUploadController : BaseController
	{
		/// <summary>
		/// GET: Index
		/// </summary>        
		/// <returns>Return index view</returns>
		public ActionResult Index()
		{
			UploadDocModel model = new UploadDocModel { File = null, FileList = new List<InvoiceDetailsModel>() };

			try
			{
				model.FileList = _db.spGetetAllFiles().Select(p => new InvoiceDetailsModel
				{
					InvoiceID = p.invoice_id,
					InvoicePO = p.invoice_PO,
					InvoiceMIME = p.invoice_MIME
				}).ToList();

			}
			catch (Exception ex)
			{
				Console.Write(ex);
			}
			return View(model);
		}


		/// <summary>
		/// POST: Index
		/// </summary>
		/// <param name="model">Model parameter</param>
		/// <returns>Return response information</returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Index(UploadDocModel model)
		{
			string fileName = string.Empty;
			byte[] fileContent;
			string fileExt = string.Empty;

			try
			{
				if (ModelState.IsValid)
				{
					byte[] uploadedFile = new byte[model.File.InputStream.Length];
					model.File.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

					fileName = Path.GetFileNameWithoutExtension(model.File.FileName);
					fileExt = model.File.ContentType;
					fileContent = uploadedFile;

					//save file to database
					_db.spAddFile(fileName, fileExt, fileContent);

				}

				model.FileList = _db.spGetetAllFiles().Select(p => new InvoiceDetailsModel
				{
					InvoiceID = p.invoice_id,
					InvoicePO = p.invoice_PO,
					InvoiceMIME = p.invoice_MIME
				}).ToList();


			}
			catch (Exception ex)
			{
				Console.Write(ex);
			}

			return View(model);

		}

		/// <summary>
		/// Download files to view or download physical copy if broswer doesn't support the file type
		/// </summary>
		/// <param name="fileId">File ID parameter</param>
		/// <returns>Return download file</returns>
		public ActionResult DownloadFile(int fileId)
		{
			UploadDocModel model = new UploadDocModel { File = null, FileList = new List<InvoiceDetailsModel>() };

			try
			{
				var fileInfo = _db.spGetFileDetails(fileId).First();

				return this.GetFile(fileInfo.invoice_document, fileInfo.invoice_MIME);
			}
			catch (Exception ex)
			{
				Console.Write(ex);
			}

			return View(model);

		}



		/// <summary>
		/// Get file method
		/// </summary>
		/// <param name="fileContent">File content parameter</param>
		/// <param name="fileType">File content type parameter</param>
		/// <returns>Returns file</returns>
		private FileResult GetFile(byte[] fileContent, string fileType)
		{
			FileResult file = null;

			try
			{
				byte[] byteContent = fileContent;
				file = this.File(byteContent, fileType);
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return file;
		}
	}
}