namespace LibreriaDigital.Models {
  public class Review {
    public int Id { get; set; }
    public int Puntuacion { get; set; }
    public string Comentario { get; set; } = string.Empty;
    public int BookId { get; set; }
    public Book? Book { get; set; }
  }
}
