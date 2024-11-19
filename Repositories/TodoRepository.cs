using TodoApplication.Data;
using TodoApplication.Models;
using TodoApplication.Repositories.Interfaces;

namespace TodoApplication.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public List<TodoDto> GetAll()
        {
            var todos = Database.Todos.ToList();
            return todos;
        }

        public List<TodoDto> GetbyId(Guid id)
        {
            var todos = Database.Todos.ToList();
            return todos;
        }
    }
}