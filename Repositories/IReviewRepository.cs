using LibreriaDigital.Models;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> GetAll();
    Task<Review?> GetById(int id);

    Task<Review> Add(Review review);
    Task<Review> Update(Review review);
    Task<bool> Delete(int id);
}
