using SQLite;

namespace TaskList.Models
{
    public class Tarea
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Buscar { get; set; }
    }
}
