﻿using Microsoft.AspNetCore.Mvc;
using SimpleLibraryManagement.Data.Interfaces;
using SimpleLibraryManagement.Data.Model;
using SimpleLibraryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Controllers
{
    public class BookController: Controller
    {
        private readonly IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;

        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public IActionResult List(int? authorId, int? borrowerId)
        {
            if(authorId == null && borrowerId == null)
            {
                //show all books -> all are null
                var books = _bookRepository.GetAllWithAuthor();
                //check books
                return CheckBooks(books);
            }
            else if(authorId !=null)
            {
                //filter by author id
                var author = _authorRepository
                    .GetWithBooks((int)authorId);
                //check author books
                if (author.Books.Count() == 0)
                {
                    return View("AuthorEmpty", author);
                }
                else
                {
                    return View(author.Books);
                }
            }
            else if (borrowerId != null)
            {
                //filter by borrower id
                var books = _bookRepository.FindWithAuthorAndBorrower(book=> book.BorrowerId == borrowerId);
                //check borrower books
                return CheckBooks(books);
            }
            else
            {
                //none of the is null
                throw new ArgumentException();
            }
        }

        public IActionResult CheckBooks(IEnumerable<Book> books)
        {
            if (books.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(books);
            }
        }

        public IActionResult Create()
        {
            var bookVM = new BookViewModel()
            {
                Authors = _authorRepository.GetAll()
            };
            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Create(BookViewModel bookViewModel)
        {
            _bookRepository.Create(bookViewModel.Book);

            return RedirectToAction("List");
        }


        public IActionResult Update(int id)
        {
            var bookVM = new BookViewModel()
            {
                Book = _bookRepository.GetById(id),
                Authors = _authorRepository.GetAll()
            };
            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Update(BookViewModel bookViewModel)
        {
            _bookRepository.Update(bookViewModel.Book);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetById(id);
            _bookRepository.Delete(book);
            return RedirectToAction("List");
        }
    }
}
