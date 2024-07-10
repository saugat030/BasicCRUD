﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouse.Models.ProductViewModel
{
    public class ProductVM
    {
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public Product Product { get; set; }
    
    }
}
