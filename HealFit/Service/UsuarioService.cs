using HealFit.Model;
using Microsoft.Maui.Controls.PlatformConfiguration;
using SQLite;

namespace HealFit.Service;
public class UsuarioService : IUsuarioService {

    private SQLiteAsyncConnection _dbConnection;

    public UsuarioService() {

        SetUpDb();
    }
    private async void SetUpDb() {

        if (_dbConnection == null) {

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HealFit.db3");

            _dbConnection = new SQLiteAsyncConnection(dbPath);
            await _dbConnection.CreateTableAsync<UsuarioModel>();
        }
    }

    public async Task<int> AddUsuario(UsuarioModel usuario) {
        await _dbConnection.InsertAsync(usuario);
        return usuario.UsuarioId; // Retorna o ID do usuário recém-criado
    }

    public Task<int> DeleteUsuarioById(int registroId) {
        throw new NotImplementedException();
    }

    public async Task<List<UsuarioModel>> GetAllUsuarios() {

        return await _dbConnection.Table<UsuarioModel>().ToListAsync();
    }

    public async Task<UsuarioModel> GetUsuarioById(int usuarioId) {

        return await _dbConnection.Table<UsuarioModel>().FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);
    }

    public async Task<int> UpdateUsuario(UsuarioModel usuario) {

        return await _dbConnection.UpdateAsync(usuario);
    }
}
