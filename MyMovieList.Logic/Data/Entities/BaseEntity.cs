﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieList.Logic.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }
    }
}
