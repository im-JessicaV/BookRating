using BookRating.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly AddBookUseCase _addBookUseCase;

    public BooksController(AddBookUseCase addBookUseCase)
    {
        _addBookUseCase = addBookUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        await _addBookUseCase.ExecuteAsync(book);
        return Ok();
    }
}