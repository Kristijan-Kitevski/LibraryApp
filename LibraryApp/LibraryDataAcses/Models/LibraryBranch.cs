using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryDataAcses.Models
{
    public class LibraryBranch
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40, ErrorMessage ="Limit Branch name to 40 characters")]
        public string BranchName { get; set; }
        [Required]
        public string Address { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }

        public DateTime OpenDate { get; set; }



        public virtual IEnumerable<Patron> Patrons { get; set; }

        public virtual IEnumerable<LibraryAsset> HomeLibraryAssets  { get; set; }


        public string ImgUrl { get; set; }



    }
}
