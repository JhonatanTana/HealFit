using SQLite;
using System.ComponentModel.DataAnnotations;

namespace HealFit.Model; 
public class Usuario {

    public int UsuarioId { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}
