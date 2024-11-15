﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Zaha_Maria_Lab2.Data;
using Zaha_Maria_Lab2.Models;

namespace Zaha_Maria_Lab2.Pages.Books
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Zaha_Maria_Lab2.Data.Zaha_Maria_Lab2Context _context;

        public CreateModel(Zaha_Maria_Lab2.Data.Zaha_Maria_Lab2Context context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "AuthorName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");


            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);

            return Page();
        }


        [BindProperty]
        public Book Book { get; set; } //= default!;


        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                PopulateAssignedCategoryData(_context, new Book());

                return Page();
            }

            var newBook = new Book
            {
                Title = Book.Title,
                AuthorID = Book.AuthorID,
                Price = Book.Price,
                PublishingDate = Book.PublishingDate,
                PublisherID = Book.PublisherID,
                BookCategories = new List<BookCategory>()
            };

            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }

            Book.BookCategories = newBook.BookCategories;


            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}