using TodoApplication.Models;
using System.Collections.Generic;

namespace TodoApplication.Data
{
    public static class Database
    {
        public static List<TodoDto> Todos { get; set; } = new List<TodoDto>(); 
    }
}