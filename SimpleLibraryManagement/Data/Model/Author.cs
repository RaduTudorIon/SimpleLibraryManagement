﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLibraryManagement.Data.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public virtual ICollection<Book> Books { get; set; }
    }
}
