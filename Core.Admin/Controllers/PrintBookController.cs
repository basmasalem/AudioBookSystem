using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using X.PagedList;

namespace Core.Admin.Controllers
{
    public class PrintBookController : BaseController
    {
        private readonly IMemoryCache _cache;
        private IRepositoryWrapper _repoWrapper;
        public PrintBookController(IRepositoryWrapper repoWrapper, IMemoryCache cache, IWebHostEnvironment webHostEnvironment) : base(repoWrapper, webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
            _cache = cache;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListPrintBook(int page = 1)
        {
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            var model =_repoWrapper.PrintBookRepository.List().ToPagedList(page, ItemPerPage);
            return PartialView("_ListPrintBook", model);
        }
        public IActionResult ChangeStatus(int id)
        {
            var book = _repoWrapper.PrintBookRepository.Find(id);
            book.IsActive = !book.IsActive;
            _repoWrapper.PrintBookRepository.Update(book);
            _repoWrapper.PrintBookRepository.Commit();
            return Json(1);
        }

        public IActionResult DeletePrintBook(int id)
        {
            var book = _repoWrapper.PrintBookRepository.Find(id);
            _repoWrapper.PrintBookRepository.Delete(book);
            _repoWrapper.PrintBookRepository.Commit();
            return Json(1);
        }
    }
}
