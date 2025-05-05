using BooksService.WebAPI.Data;
using BooksService.WebAPI.Models;

namespace BooksService.WebAPI.Services
{
  public interface IValidatorService
  {
    List<string> ValidateBook(Book book);
  }
  public class ValidatorService : IValidatorService
  {
    private readonly BookContext _bookContext;
    public ValidatorService(BookContext bookContext)
    {
      _bookContext = bookContext;
    }

    public  List<string> ValidateBook(Book book)
    {
      var errors = new List<string>();
      if (string.IsNullOrWhiteSpace(book.Title) || book.Title.Length < 5 || book.Title.Length > 255 || !char.IsUpper(book.Title[0]))
      {
        errors.Add("Title is invalid: The title must contain a minimum of 5 characters and a maximum of 255, and the first letter should be in upper case.");
      }
      if (string.IsNullOrWhiteSpace(book.Author) || book.Author.Length < 3 || book.Author.Length > 30 || !char.IsUpper(book.Author[0]))
      {
        errors.Add("Author is invalid: Author must contain a minimum of 3 characters and a maximum of 30, and the first letter should be in upper case.");
      }
      if (book.PublicationDate < new DateTime(1900,01,01)||book.PublicationDate >=DateTime.Now)
      {
        errors.Add("PublicationDate is invalid: PublicationDate must be after 01/01/1900 and before current date.");
      }
      return errors;
    }
  }
}
