using Microsoft.AspNetCore.Mvc;
using SapphireFlowerShop.Data;
using SapphireFlowerShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;

namespace SapphireFlowerShop.Controllers
{
    public class FlowerController : Controller
    {
        private List<Flower> flowers;
        public FlowerController(IFlowerList flowerList)
        {
            flowers = flowerList.GetFlowers();
        }


        public IActionResult Index()
        {
            return View(flowers);
        }

        public IActionResult Details(int id) 
        {
            //get flower from the flower list
            Flower flower = flowers.SingleOrDefault(f => f.Id == id);
            //check if flower obect is valid
            if (flower == null) 
            {
                return NotFound();
            }

            return View(flower);

        }
        //Edit endpoint
        //This is the Get endpoint for Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id==0)
            {
                return NotFound();
            }
            //This method takes an id and returns 1 Flower from the flowerList
            Flower flower = flowers.SingleOrDefault(f => f.Id == id);

            if(flower == null) 
            {
                return NotFound();
            }
            //The return is going to look for a view
            return View(flower);
        }
        [HttpPost]
        public IActionResult Edit(Flower model)
        {
            Flower flower = flowers.SingleOrDefault(f => f.Id == model.Id);
            if (flower == null)
            {
                return NotFound();
            }
           flower.Name = model.Name;
           flower.Color = model.Color;
           flower.Description = model.Description;
           flower.Price = model.Price;
            //send the user to the view of the item they edited, using a redirect
            return RedirectToAction("Details", new Flower {Id = flower.Id});
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Flower model) 
        {
            //This will check if we got invalid data from the post request
            //if it's invalid user will be sent back to the view
            if (!ModelState.IsValid) 
            {
                return Json(model);
            }
            //if we get here, means that the data inside the model is valid. 
            //then this model will be added to the database
            model.Id = flowers.Count() + 1;
            flowers.Add(model);
            //display the new flower added to the list
            return RedirectToAction("Details", new Flower { Id = model.Id});

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id== 0)
            {
                return NotFound();
            }
            //pull the flower out of the database
            var model = flowers.SingleOrDefault(f => f.Id == id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //Pull single item from the list of flowers
            var flower = flowers.SingleOrDefault(f => f.Id == id);
            //then check if we get valid data
            if(flower == null)
            {
                return NotFound();
            }
            //if we get here, go into my collection and remove it
            flowers.Remove(flower);
            return RedirectToAction("Index");
        }
    }
}
