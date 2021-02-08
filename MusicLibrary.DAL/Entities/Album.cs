using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLibrary.DAL.Entities
{
   public class Album : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int QuantityInStock { get; set; }

        public List<MusicUsers> MusicUsers { get; set; } = new List<MusicUsers>();
    }
}
