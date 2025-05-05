using System.ComponentModel;
using System.Threading.Tasks;
using BooksService.WebAPI.Models;
using BooksService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksService.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class BooksController : ControllerBase
  {
    private readonly IBookService _bookService;
    private readonly IValidatorService _validatorService;

    public BooksController(IBookService bookService, IValidatorService validatorService)
    {
      _bookService = bookService;
      _validatorService = validatorService;
    }
    [HttpPost]
    public async Task<IActionResult> Validate(Book book)
    {

      var checkBookRequirements = _validatorService.ValidateBook(book);
      if (checkBookRequirements.Any())
      {
        return BadRequest(new { Errors = checkBookRequirements });
      }
      await _bookService.Add(book);
      return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var books = await _bookService.GetAll();
      return Ok(books);
    }
  }
}
