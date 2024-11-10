namespace HealFit.Model;
public class DadosPessoais {

    public int DadosId { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; } = DateTime.UtcNow;
    public decimal Altura { get; set; }
    public decimal Peso { get; set; }
    public string Cep { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Bairro { get; set; }
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public int UsuarioId { get; set; }
}
