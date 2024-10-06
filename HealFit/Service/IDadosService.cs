using HealFit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealFit.Service; 
public interface IDadosService {

    Task<DadosPessoais> GetDadosById(int id);
    Task<bool> GetDadosByUserId(int id);
    Task<bool> AddDados(DadosPessoais dados);
    Task<bool> UpdateDados(DadosPessoais dados);
    Task<bool> DeleteDados(int id);
}
