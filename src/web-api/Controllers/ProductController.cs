using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.BL;
using web_api.ViewModels;

namespace web_api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        IDatabaseManager dbsaver;
        public ProductController(IDatabaseManager dbSaver)
        {
            this.dbsaver = dbSaver;
        }
        // GET: ProductController
        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }

        // GET: ProductController/Details/5
        [HttpGet("view/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var prod = dbsaver.GetProduct(id);
            if(prod != null)
            {
                return Ok(prod);
            }
            return NotFound();
        }

        // GET: ProductController/Create
        [HttpPost]
        public ActionResult Create()
        {
            return Ok();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return Ok();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        // GET: ProductController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return Ok();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        [HttpPost]
        public ActionResult SaveNewTest([FromBody] TestObjectToSave test)
        {

            var saveResult = dbsaver.SaveOne(test);
            if (saveResult == 1)
            {
                return BadRequest(new Error { ErrorCode = 9000, ErrorMessage = $"{nameof(dbsaver.SaveOne)} method failed saving data" });
            }

            saveResult = dbsaver.SaveTwo();
            if (saveResult == 1)
            {
                return BadRequest(new Error { ErrorCode = 9000, ErrorMessage = $"{nameof(dbsaver.SaveTwo)} method failed saving data" });
            }
            return Ok();
        }
    }

    public class TestObjectToSave
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Error
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
