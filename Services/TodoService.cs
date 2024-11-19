using TodoApplication.Data;
using TodoApplication.Models;
using TodoApplication.Services.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TodoApplication.Services
{
    public class TodoService : ITodoService
    {
        
        public void Create(TodoDto dto)
        {
            dto.Id = Guid.NewGuid(); 
            dto.TaskDate = DateTime.Now; 
            Database.Todos.Add(dto); 
        }


    
        public void Update(TodoDto dto)
        {
            var existingTodo = Database.Todos.FirstOrDefault(todo => todo.Id == dto.Id);
            if (existingTodo != null)
            {
                existingTodo.TaskTitle = dto.TaskTitle;
                existingTodo.TaskDescription = dto.TaskDescription;
                existingTodo.TaskDate = dto.TaskDate; 
            }
            else
            {
                throw new InvalidOperationException("Todo not found.");
            }
        }

        
        public void Delete(Guid id)
        {
            var todo = Database.Todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                Database.Todos.Remove(todo); 
            }
            else
            {
                throw new InvalidOperationException("Todo not found.");
            }
        }
    }
}