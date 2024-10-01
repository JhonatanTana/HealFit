using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealFit.DTO.Request; 
public class CadastraDadosDTORequest {

    public int DadosId { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public DateTime DataNascimento { get; set; } = DateTime.Now;
    public string Peso { get; set; }
    public string Cep { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }
    public string Bairro { get; set; }
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public int UsuarioId { get; set; }
}
