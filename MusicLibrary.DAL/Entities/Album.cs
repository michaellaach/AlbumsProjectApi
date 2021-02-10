using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace MusicLibrary.DAL.Entities
{
   public class Album : BaseEntity
    {
        public Album()
        {
            MusicUsers = new List<MusicUsers>();
        }

        public string Title { get; set; }
        public string Author { get; set; }

        [Min(0)]
        public int QuantityInStock { get; set; }

        public List<MusicUsers> MusicUsers { get; set; } = new List<MusicUsers>();
    }
}
