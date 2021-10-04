using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Model;
using Core.Service;
using Core.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Core.Web.Controllers
{
    public class PrintBookController : Controller
    {
        private IServiceWrapper _serviceWrapper;
        private readonly IMapper _mapper;
        public PrintBookController(IServiceWrapper serviceWrapper, IMapper mapper)
        {
            _serviceWrapper = serviceWrapper;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var model = new PrintBookModel { Attachment = "0", CreationDate = DateTime.Now, IsDeleted = false };
            return View(model);
        }
        [HttpPost]
        public IActionResult SavePrintBook(PrintBookModel model)
        {
            var printBook = _mapper.Map<PrintBook>(model);
            _serviceWrapper.PrintBookService.CreatePrintBook(printBook);
            _serviceWrapper.PrintBookService.SavePrintBook();
            return Json(1);
        }
    }
}
