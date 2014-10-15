using System;

namespace DatabaseDemo.Domain.Model
{
    public class HistoryEntry
    {
        public int Id { get; set; }

        public double A { get; set; }

        public double B { get; set; }

        public Operator Operator { get; set; }

        public DateTime Date { get; set; }

        public string Ip { get; set; }
    }
}