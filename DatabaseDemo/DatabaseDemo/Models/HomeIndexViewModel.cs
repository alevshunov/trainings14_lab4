using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseDemo.Domain;
using DatabaseDemo.Domain.Model;

namespace DatabaseDemo.Models
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel()
        {
        }

        public HomeIndexViewModel(double? a, double? b, Operator? @operator)
        {
            A = a;
            B = b;
            Operator = @operator;
        }

        public double? A { get; set; }
        
        public double? B { get; set; }

        public Operator? Operator { get; set; }
    }
}