using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.ViewModels;

namespace web_api.Controllers
{
    [ApiController]
    //[Route("api/products")]
    public class ProductController : Controller
    {
        // GET: ProductController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        [HttpGet("view/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            Product result = new Product();
            if(id == default(int))
            {
                return NoContent();
            }
            return View(result);
        }

        // GET: ProductController/Create
        [HttpPost]
        public ActionResult Create()
        {
            return View();
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
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
                return View();
            }
        }

        // GET: ProductController/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return View();
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
                return View();
            }
        }

        [HttpPost]
        public ActionResult SaveNewTest([FromBody] Test test)
        {
            if(test.Id == 1)
            {
                return Ok();
            }

            return BadRequest(new Error { ErrorCode = 9000 });
            
        }
    }

    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Error
    {
        public int ErrorCode { get; set; }
    }
}
