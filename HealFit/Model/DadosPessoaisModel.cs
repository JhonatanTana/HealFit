using SQLite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealFit.Model; 
public class DadosPessoaisModel {

    [PrimaryKey, AutoIncrement]
    public int DadosId { get; set; }

    [NotNull]
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Nome { get; set; }

    [NotNull]
    [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
    public string Sobrenome { get; set; }

    [NotNull]
    [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
    public DateTime DataNascimento { get; set; }

    public double Altura { get; set; }
    public double Peso { get; set; }
    public int Cep { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Bairro { get; set; }
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public int UsuarioId { get; set; }
}
