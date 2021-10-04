using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Admin.Models.ViewModels
{
    public class ContactUsVModel
    {
        public SearchContactUsVModel SearchContactUsVModel { get; set; }
        public IPagedList<ContactUs> ContactUs { get; set; }
    }

    public class SearchContactUsVModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
