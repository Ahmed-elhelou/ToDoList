using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ToDoListProject.Models;

namespace ToDoListProject.Controllers
{
    public class ToDoController : Controller
    {
        static List<ToDoModel> toDoModels = new();
       
        public IActionResult Index()
        {
            return View(nameof(Index),toDoModels);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost([Bind] ToDoModel toDoModel)
        {

            toDoModels.Add(toDoModel);
            return Index();
        }
        public IActionResult Edit(int id)
        {
            ToDoModel m = toDoModels.FirstOrDefault(x => x.Id == id);
            if(m == null)
                return NotFound(); 
            return View(m);
        }
        [HttpPost]
        public IActionResult Edit(int id,[Bind] ToDoModel toDoModel)
        {

            ToDoModel curr =  toDoModels.FirstOrDefault(x => x.Id == id);
            if (curr == null)
                return NotFound();
            curr.WhatToDo = toDoModel.WhatToDo; 
            curr.WhenToDo = toDoModel.WhenToDo;
            curr.Notes = toDoModel.Notes;  
            return Index();
        }
        public IActionResult Delete(int id)
        {
            ToDoModel model = toDoModels.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();
            return View(model);

        }
        [HttpPost("[Controller]/Delete/{id}")]
        public IActionResult DeletePost(int id)
        {
            ToDoModel model = toDoModels.FirstOrDefault(x => x.Id == id);
            toDoModels.Remove(model);
            return Index();
        }
        public IActionResult Details(int id)
        {
            ToDoModel model = toDoModels.FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View(); 
        }
        public IActionResult Finish(int id)
        {
            ToDoModel model = toDoModels.FirstOrDefault(x => x.Id == id);
            return View(model);

        }
        [HttpPost]
        public IActionResult Finish(int id, [Bind] ToDoModel toDoModel)
        {

            ToDoModel curr = toDoModels.FirstOrDefault(x => x.Id == id);
            if (curr == null)
                return NotFound();
            curr.IsFinished = true;
            return Index();
        }
    }
}
