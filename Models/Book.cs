namespace LibreriaDigital.Models {
  public class Book {
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public int AnioPublicacion { get; set; }
    public string? ImagenPortadaUrl { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public ICollection<Review>? Reviews { get; set; }
  }
}
