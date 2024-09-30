using SQLite;
using System.ComponentModel.DataAnnotations;

namespace HealFit.Model; 
public class UsuarioModel {


    [PrimaryKey, AutoIncrement]
    public int UsuarioId { get; set; }

    [NotNull]
    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    public string Email { get; set; }

    [NotNull]
    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    public string Senha { get; set; }
}
