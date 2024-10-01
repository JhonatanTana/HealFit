using HealFit.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealFit.Service; 
public class DadosService : IDadosService {

    private SQLiteAsyncConnection _dbConnection;

    public DadosService() {

        SetUpDb();
    }

    private async void SetUpDb() {

        if (_dbConnection == null) {

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HealFit.db3");

            _dbConnection = new SQLiteAsyncConnection(dbPath);
            await _dbConnection.CreateTableAsync<DadosPessoaisModel>();
        }
    }

    public async Task<int> AddDados(DadosPessoaisModel dados) {
        return await _dbConnection.InsertAsync(dados);
    }

    public Task<int> DeleteDadosById(int dadoId) {
        throw new NotImplementedException();
    }

    public async Task<List<DadosPessoaisModel>> GetAllDados() {
        return await _dbConnection.Table<DadosPessoaisModel>().ToListAsync();
    }

    public async Task<DadosPessoaisModel> GetDadosById(int usuarioId) {

        return await _dbConnection.Table<DadosPessoaisModel>().FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);

    }

    public Task<int> UpdateDados(DadosPessoaisModel dados) {
        throw new NotImplementedException();
    }

}
