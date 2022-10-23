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
            Flower flower = flowers.FirstOrDefault(f => f.Id == id);
            //check if flower obect is valid
            if (flower == null) 
            {
                return NotFound();
            }

            return View(flower);

        }
    }
}
