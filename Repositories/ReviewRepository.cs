using Microsoft.EntityFrameworkCore;
using LibreriaDigital.Models;
using LibreriaDigital.Data;

public class ReviewRepository : IReviewRepository
{
    private readonly AppDbContext _context;

    public ReviewRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Review>> GetAll()
    {
        return await _context.Reviews.Include(r => r.Book).Include(r => r.User).ToListAsync();
    }

   public async Task<Review?> GetById(int id) 

    {
        return await _context.Reviews.Include(r => r.Book).Include(r => r.User).FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Review> Add(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task<Review> Update(Review review)
    {
        _context.Entry(review).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task<bool> Delete(int id)
    {
        var review = await _context.Reviews.FindAsync(id);
        if (review == null) return false;
        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
        return true;
    }
}
