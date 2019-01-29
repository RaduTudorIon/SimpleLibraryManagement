using SimpleLibraryManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Data.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllWithBooks();

        Author GetWithBook(int id);
    }
}
