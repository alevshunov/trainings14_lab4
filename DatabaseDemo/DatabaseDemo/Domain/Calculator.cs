using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseDemo.Domain.Model;

namespace DatabaseDemo.Domain
{
    public class Calculator
    {
        public double Calculate(double a, double b, Operator @operator)
        {
            switch (@operator)
            {
                case Operator.Plus:
                    return a + b;
                    break;
                case Operator.Minus:
                    return a - b;
                    break;
                case Operator.Div:
                    return a / b;
                    break;
                case Operator.Mult:
                    return a * b;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("operator");
            }
        }
    }
}