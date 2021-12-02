using System;

namespace ToDoListProject.Models
{
    public class ToDoModel
    {
        public int Id { get;  }
        private static int numOfModels = 0;
        public string WhatToDo { get; set; }
        public DateTime WhenToDo { get; set; }
        public DateTime AddingTime { get; }
        public string Notes { get; set; }
        
        public bool IsFinished { get; set; }
        public ToDoModel()
        {
            Id = ++numOfModels;
            AddingTime = DateTime.Now;
        }
        public bool IsLate()
        {
            return WhenToDo.CompareTo(DateTime.Now) <= 0;
        }

    }
}
