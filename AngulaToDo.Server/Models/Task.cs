﻿namespace AngulaToDo.Server.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }

        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }
    }
}
