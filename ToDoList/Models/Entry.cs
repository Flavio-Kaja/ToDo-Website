using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;




namespace ToDoList.Models
{
    public class Entry
    {
      
        public int Id { get; set; }
        [Required]
       
        public string Tittle { get; set; }
        public string Description { get; set; }
        public DateTime Expires { get; set; }
        public bool Completed { get; set; } = false;
        public string currentUserId { get; set; }


    }
}
