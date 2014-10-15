using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatabaseDemo.Domain.Model;

namespace DatabaseDemo.Helper
{
    public static class OperatorTranslator
    {
        private static readonly Dictionary<Operator, string> OperatorToStringMap = new Dictionary<Operator, string>()
        {
            {Operator.Plus, "+"},
            {Operator.Minus, "-"},
            {Operator.Div, "/"},
            {Operator.Mult, "*"}
        };

        public static string AsString(Operator @operator)
        {
            return OperatorToStringMap[@operator];
        }
    }
}