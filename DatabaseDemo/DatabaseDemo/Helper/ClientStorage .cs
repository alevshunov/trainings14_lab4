using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Web;
using DatabaseDemo.Domain;
using DatabaseDemo.Domain.Model;

namespace DatabaseDemo.Helper
{
    public interface IClientStorage
    {
        double? A { get; set; }

        double? B { get; set; }

        Operator? Operator { get; set; }
    }

    public class ClientStorage : IClientStorage
    {
        private readonly HttpContextBase _context;

        public ClientStorage(HttpContextBase context)
        {
            _context = context;
        }

        private double? GetDoubleCookieOrDefault(string name)
        {
            double value;
            if (_context.Request.Cookies[name] != null
                && double.TryParse(_context.Request.Cookies[name].Value, out value))
                return value;

            return null;
        }

        private Operator? GetOperatorCookieOrDefault(string name)
        {
            Operator value;
            if (_context.Request.Cookies[name] != null
                && Enum.TryParse(_context.Request.Cookies[name].Value, out value))
                return value;

            return null;
        }

        private void SetCookie(string name, string value)
        {
            if (value == null)
                _context.Response.Cookies.Add(new HttpCookie(name, string.Empty) {Expires = DateTime.Now.AddYears(-1)});
            else
                _context.Response.Cookies.Add(new HttpCookie(name, value) {Expires = DateTime.Now.AddDays(1)});
        }

        public double? A {
            get { return GetDoubleCookieOrDefault("a"); }
            set { SetCookie("a", value == null ? null : value.ToString()); }
        }
        
        public double? B {
            get { return GetDoubleCookieOrDefault("b"); }
            set { SetCookie("b", value == null ? null : value.ToString()); }
        }
        
        public Operator? Operator {
            get { return GetOperatorCookieOrDefault("operator"); }
            set { SetCookie("operator", value == null ? null : value.ToString()); }
        }

        public void SetState(double? a, double? b, Operator? @operator)
        {
            A = a;
            B = b;
            Operator = @operator;
        }
    }
}