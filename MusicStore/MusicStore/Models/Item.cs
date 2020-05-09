using System;
using System.Collections.Generic;

namespace MusicStore.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Availability { get; set; }
        public string Photo { get; set; }
        public int ReviewNumber { get; set; }
        public int Stars { get; set; }
        public string Model { get; set; }
        public string Serie { get; set; }
        public string Forma { get; set; }
        public string Material { get; set; }
        public string Finisaj { get; set; }
        public int? NumarTaste { get; set; }
        public string Doze { get; set; }
        public int Type { get; set; }
    }
}
