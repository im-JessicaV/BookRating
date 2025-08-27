using System.Threading.Tasks;
using BookRating.Domain.Entities;

public class AddBookUseCase
{
    private readonly IBookRepository _repository;

    public AddBookUseCase(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Book book)
    {
        // Validações podem ser adicionadas aqui
        await _repository.AddAsync(book);
    }
}