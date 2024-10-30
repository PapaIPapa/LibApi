using MediatR;
using LibApi.Data;
using LibApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace LibApi.Commands
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly LibraryContext _context;

        public DeleteBookCommandHandler(LibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);

            if (book == null)
            {
                // Возвращаем false, если книга не найдена
                return false;
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);

            // Возвращаем true, если удаление прошло успешно
            return true;
        }
    }
}