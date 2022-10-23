using SapphireFlowerShop.Models;
using System.Collections.Generic;

namespace SapphireFlowerShop.Data   
{
    public class FlowerList : IFlowerList
    {
        int idCounter = 1;
        List<Flower> flowers;
        public FlowerList()
        {
            flowers = new List<Flower> 
            {
                new Flower { Id = idCounter ++, Name ="Orchid", Color = "Black Sapphire, Cream, Yellow", Description = "Single Large Orchid", Price = 65.99m},
                new Flower { Id = idCounter ++, Name ="Darling Orchids", Color = "Pink, Yellow, White", Description = "15 Pack Plant height: 8-12in", Price = 150.99m},
                new Flower { Id = idCounter ++, Name = "Cascade Orchids", Color = "Magenta blooms", Description = "6 Pack  Plant height: 20-26in", Price = 160.99m},
                new Flower { Id = idCounter ++, Name = "Gemstone Orchids", Color = "Assorted", Description = "10 Pack Plants height: 20-26in Includes ceramic pots",Price = 250.99m},
                new Flower { Id = idCounter ++, Name = "Moonstone Orchids", Color = "Lillac, Pink", Description = "10 phalaenopsis orchids per box Plant height: 20-26in Includes ceramic pots", Price = 260.99m},
                new Flower { Id = idCounter ++, Name = "Geese Garden", Color = "Assorted seasonal colors", Description = "4 arrangements per box, Plant height: 14-20in", Price = 160.99m },
                new Flower { Id = idCounter ++, Name = "Table top Orchids", Color = "Assorted seasonal colors", Description = "15 pack per box with ceracmic pots Plant Height: 16-20in Double spike", Price = 190.99m}
            };
        }

        public List<Flower> GetFlowers() { return flowers; }
    }
}
