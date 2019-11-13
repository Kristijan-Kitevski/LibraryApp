using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Models.Catalog
{
    public class AssetIndexListingModel
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }

        public string Title { get; set; }

        public string AutorOrDirector  { get; set; }

        public string Type { get; set; }

        public string  DewyCallNumber { get; set; }

        public string NumberOfCopies { get; set; }
    }
}
