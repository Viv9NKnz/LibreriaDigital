using LibreriaDigital.Data;
using LibreriaDigital.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaDigital.Repositories {
  public class BookRepository : IBookRepository {
    private readonly AppDbContext _context;
    public BookRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Book>> GetAllAsync() => await _context.Books.Include(b => b.Reviews).ToListAsync();
    public async Task<Book?> GetByIdAsync(int id) => await _context.Books.Include(b => b.Reviews).FirstOrDefaultAsync(b => b.Id == id);
    public async Task AddAsync(Book book) { _context.Books.Add(book); await _context.SaveChangesAsync(); }
    public async Task UpdateAsync(Book book) { _context.Books.Update(book); await _context.SaveChangesAsync(); }
    public async Task DeleteAsync(int id) {
      var book = await _context.Books.FindAsync(id);
      if (book != null) { _context.Books.Remove(book); await _context.SaveChangesAsync(); }
    }
  }
}
