using HealFit.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealFit.Service; 
public interface IDadosService {
    Task<List<DadosPessoaisModel>> GetAllDados();
    Task<DadosPessoaisModel> GetDadosById(int registroId);
    Task<int> AddDados(DadosPessoaisModel dados);
    Task<int> UpdateDados(DadosPessoaisModel dados);
    Task<int> DeleteDadosById(int dadoId);
}
