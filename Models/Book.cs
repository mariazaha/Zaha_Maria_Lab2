﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Zaha_Maria_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Display(Name = "Book Title")]

        [Required(ErrorMessage = "Titlul este obligatoriu.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Titlul trebuie să aibă între 3 și 150 de caractere.")]
      
        public string Title { get; set; }

       

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        public int? PublisherID { get; set; }

        public Publisher? Publisher { get; set; }

        [Display(Name = "Author")]
        public int? AuthorID { get; set; }
        public Author? Author { get; set; }

        public int? BorrowingID { get; set; }
        public Borrowing? Borrowing { get; set; }

        public ICollection<BookCategory>? BookCategories { get; set; }

    }
}
