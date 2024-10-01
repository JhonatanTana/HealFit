using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealFit.DTO.Request; 
public class RegistroUsuarioDTORequest {

    public string Email { get; set; }
    public string Senha { get; set; }
    public string ConfSenha{ get; set; }
}
