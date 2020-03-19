using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using DocumentSystem.Models;

namespace DocumentSystem.Controllers
{
    public class InvoiceUploadController : Controller
    {
        /// <summary>
        /// Initiate database entity
        /// </summary>     
				private BikeStores2Entities _dbService = new BikeStores2Entities();



				/// <summary>
        /// GET: UploadPI Index
        /// </summary>        
        /// <returns>Return index view</returns>
				public ActionResult Index()
				{
					UploadDocModel model = new UploadDocModel { File = null, FileList = new List<InvoiceDetailsModel>() };

					try
					{
						model.FileList = this._dbService.sp_get_all_files().Select(p => new InvoiceDetailsModel
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
					return this.View(model);
				}


				/// <summary>
        /// POST: UploadPI Index
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

							fileName = Path.GetFileName(model.File.FileName);
							fileExt = model.File.ContentType;
							fileContent = uploadedFile;


							//save file to database
							this._dbService.sp_insert_file(fileName, fileExt, fileContent);

						}

						model.FileList = _dbService.sp_get_all_files().Select(p => new InvoiceDetailsModel
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

					return this.View(model);

				}

				/// <summary>
				/// Download files to view or download physical copy if broswer don't support the file type
				/// </summary>
				/// <param name="fileId">File ID parameter</param>
				/// <returns>Return download file</returns>
				public ActionResult DownloadFile(int fileId)
				{
					UploadDocModel model = new UploadDocModel { File = null, FileList = new List<InvoiceDetailsModel>() };

					try
					{
						var fileInfo = this._dbService.sp_get_file_details(fileId).First();

						return this.GetFile(fileInfo.invoice_document, fileInfo.invoice_MIME);
					}
					catch (Exception ex)
					{
						Console.Write(ex);
					}

					return this.View(model);

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