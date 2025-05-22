using LibreriaDigital.Models;

namespace LibreriaDigital.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Comentario { get; set; } =string.Empty;
        public int Calificacion { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; } 

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
