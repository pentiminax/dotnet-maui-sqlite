using MyPasswordManager.Models;
using SQLite;

namespace MyPasswordManager.Data;

public class Database
{
    private SQLiteAsyncConnection connection;

    public Database()
    {

    }

    private async Task Initialize()
    {
        if (connection is not null)
            return;

        connection = new(Constants.DatabasePath);

        await connection.CreateTableAsync<LoginCrendential>();
    }

    public async Task<List<LoginCrendential>> GetItemsAsync()
    {
        await Initialize();
        return await connection.Table<LoginCrendential>().ToListAsync();
    }

    public async Task<int> SaveItemAsync(LoginCrendential item)
    {
        await Initialize();

        if (item.Id != 0)
        {
            return await connection.UpdateAsync(item);
        }
        else
        {
            return await connection.InsertAsync(item);
        }
    }

    public async Task<int> DeleteItemAsync(LoginCrendential item)
    {
        await Initialize();
        return await connection.DeleteAsync(item);
    }
}
