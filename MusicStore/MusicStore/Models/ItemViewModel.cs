using Microsoft.AspNetCore.Http;
using MusicStore.Controllers;

namespace MusicStore.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Availability { get; set; }
        public IFormFile Photo { get; set; }
        public int ReviewNumber { get; set; }
        public int Stars { get; set; }
        public string Model { get; set; }
        public string Serie { get; set; }
        public string Forma { get; set; }
        public string Material { get; set; }
        public string Finisaj { get; set; }
        public int? NumarTaste { get; set; }
        public string Doze { get; set; }
        public ItemType Type { get; set; }

    }
}
