using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Disco2.Models
{
    public class ViewModel
    {
        public ViewModel()
        {
            PhoneBrands = new List<Музыканты>();
        }

        public List<Музыканты> PhoneBrands { get; set; }
    }
}