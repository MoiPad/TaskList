using SQLite;
using TaskList.Models;

namespace TaskList.Services
{
    public class TareaService
    {
        private readonly SQLiteConnection _dbConnection;

        public TareaService()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TaskList.db3");
                _dbConnection = new SQLiteConnection(dbPath);
                _dbConnection.CreateTable<Tarea>();

            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it or display an error message)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public List<Tarea> GetAll()
        {
            var res = _dbConnection.Table<Tarea>().ToList();
            return res;
        }

        public int Insert(Tarea tarea)
        {
            return _dbConnection.Insert(tarea);
        }

        public int Update(Tarea tarea)
        {
            return _dbConnection.Update(tarea);
        }

        public int Delete(Tarea tarea)
        {
            return _dbConnection.Delete(tarea);
        }
    }
}
