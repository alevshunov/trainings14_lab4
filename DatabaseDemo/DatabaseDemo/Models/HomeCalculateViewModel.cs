using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseDemo.Domain;
using DatabaseDemo.Domain.Model;

namespace DatabaseDemo.Models
{
    public class HomeCalculateViewModel
    {
        public HomeCalculateViewModel()
        {
        }

        public HomeCalculateViewModel(double a, double b, Operator @operator, double result)
        {
            A = a;
            B = b;
            Operator = @operator;
            Result = result;
        }

        public double A { get; set; }
        public double B { get; set; }
        public Operator Operator { get; set; }
        public double Result { get; set; }
    }
}