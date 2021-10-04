using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Admin.Models.ViewModels
{
    public class ClientVModel
    {
        public SearchClientVModel SearchClientVModel { get; set; }
        public IPagedList<Client> Clients { get; set; }
    }



    public class SearchClientVModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
