﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLibrary.Business.Models.Album
{
  public  class AlbumModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public int QuantityInStock { get; set; }
    }
}
