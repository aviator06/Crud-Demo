using LearnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnApp.ViewModel
{
    public class CategoryModel
    {
        public string SelectedAns { get; set; }
        public List<Customer> ListCategory { get; set; }

        public Customer getValue { get; set; }
    }
}
