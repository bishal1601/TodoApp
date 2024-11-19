using System;
using System.Collections.Generic;
using System.Linq;
using TodoApplication.Data;
using TodoApplication.Models;
using TodoApplication.Repositories.Interfaces;

namespace TodoApplication.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public List<TodoDto> GetAll()
        {
            return Database.Todos.ToList();
        }

        public TodoDto GetbyId(Guid id)
        {
            return Database.Todos.FirstOrDefault(t => t.Id == id);
        }

        public void Delete(Guid id)
        {
            var todo = Database.Todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                Database.Todos.Remove(todo);
            }
        }
    }
}