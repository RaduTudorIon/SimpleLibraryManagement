using SimpleLibraryManagement.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Data.Interfaces
{
    public interface BookRepository 
    {
         IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate);

         IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate);

         IEnumerable<Book> GetAllWithAuthor();
    }
}
