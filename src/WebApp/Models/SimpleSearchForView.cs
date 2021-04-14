using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SimpleSearchForView
    {
        public string TextToFind { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }

    public class SimpleSearchToGet
    {
        public string TextToFind { get; set; }
        public string Categories { get; set; }
    }
}
