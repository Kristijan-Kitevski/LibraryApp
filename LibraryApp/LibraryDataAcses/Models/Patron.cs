﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDataAcses.Models
{
    public class Patron
    {
        public int Id { get; set; }
        public string FirstName { get; set; }                   
        public string LastName { get; set; }
        public string Adress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual LibraryCard LibraryCard { get; set; }
        public virtual LibraryBranch HomeLibraryBranch   { get; set; }



    }
}