using BookstoreManagement.Communication.Requests;
using BookstoreManagement.Communication.Responses;
using BookstoreManagement.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreManagement.Controllers;

[Route("api/book")]
[ApiController]
public class BookstoreController : ControllerBase
{
    private readonly BookstoreDbContext _context;

    public BookstoreController(BookstoreDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var books = await _context.Books.ToListAsync();
        return Ok(books);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound("Book not found");
        }

        return Ok(book);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] RequestRegisterBookJson request)
    {
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Gender = request.Gender,
            Price = request.Price,
            StockQuantity = request.StockQuantity
        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        var response = new ResponseRegisterBookJson
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Gender = book.Gender,
            Price = book.Price,
            StockQuantity = book.StockQuantity
        };

        return CreatedAtAction(nameof(Get), new { id = book.Id }, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookJson request)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound("Book not found");
        }

        book.Title = request.Title;
        book.Author = request.Author;
        book.Gender = request.Gender;
        book.Price = request.Price;
        book.StockQuantity = request.StockQuantity;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound("Book not found");
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}