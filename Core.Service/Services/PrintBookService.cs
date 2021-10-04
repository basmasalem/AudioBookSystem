using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Service
{
    public class PrintBookService : IPrintBookService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IDataProtector _protector;
        public PrintBookService(IRepositoryWrapper repoWrapper, IDataProtectionProvider provider)
        {
            this._repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
        }

        public void CreatePrintBook(PrintBook PrintBook)
        {
            _repoWrapper.PrintBookRepository.Add(PrintBook);
        }

        public void DeletePrintBook(int id)
        {
            var model = GetPrintBook(id);
            _repoWrapper.PrintBookRepository.Delete(model);
        }

        public PrintBook GetPrintBook(int id)
        {
            return _repoWrapper.PrintBookRepository.Find(id);
        }

        public List<PrintBook> GetPrintBooks()
        {
            return _repoWrapper.PrintBookRepository.List().ToList();
        }

        public void SavePrintBook()
        {
            _repoWrapper.PrintBookRepository.Commit();
        }

        public void UpdatePrintBook(PrintBook PrintBook)
        {
            _repoWrapper.PrintBookRepository.Update(PrintBook);
        }
    }
    public interface IPrintBookService
    {
        List<PrintBook> GetPrintBooks();
        PrintBook GetPrintBook(int id);
        void CreatePrintBook(PrintBook PrintBook);
        void UpdatePrintBook(PrintBook PrintBook);
        void DeletePrintBook(int id);
        void SavePrintBook();
    }
}
