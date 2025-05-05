using System;
using System.ComponentModel.DataAnnotations;

namespace BooksService.WebAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}