using LibreriaDigital.Models;
using System.Text.Json.Serialization;


namespace LibreriaDigital.Models
{
    public class Review
    {

public int Id { get; set; }
public int UserId { get; set; }
public int BookId { get; set; }
public int Calificacion { get; set; }
public string Comentario { get; set; } = string.Empty;
[JsonIgnore]

public User User { get; set; } = null!;
[JsonIgnore]

public Book Book { get; set; } = null!;

    }
}
