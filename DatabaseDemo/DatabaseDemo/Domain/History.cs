using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DatabaseDemo.Domain.Model;

namespace DatabaseDemo.Domain
{
    public interface IHistoryProvider
    {
        void AddHistoryEntry(double a, double b, Operator @operator, string ip);

        IEnumerable<HistoryEntry> GetHistory();
    }

    public class HistoryProvider : IHistoryProvider
    {
        private readonly SqlConnection _connection;

        public HistoryProvider()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Main"].ConnectionString);
            _connection.Open();
        }

        public void AddHistoryEntry(double a, double b, Operator @operator, string ip)
        {
            var command = new SqlCommand("insert into History(a,b,operator,ip,date) values(@a,@b,@operator,@ip,@date)", _connection);
            command.Parameters.Add(new SqlParameter() {ParameterName = "a", Value = a});
            command.Parameters.Add(new SqlParameter() {ParameterName = "b", Value = b});
            command.Parameters.Add(new SqlParameter() {ParameterName = "Operator", Value = @operator.ToString()});
            command.Parameters.Add(new SqlParameter() {ParameterName = "ip", Value = ip});
            command.Parameters.Add(new SqlParameter() {ParameterName = "date", Value = DateTime.Now});

            command.ExecuteNonQuery();
        }

        public IEnumerable<HistoryEntry> GetHistory()
        {
            var command = new SqlCommand("select * from History order by date desc", _connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var historyEntry = new HistoryEntry();
                historyEntry.Id = (int)reader["ID"];
                historyEntry.A = (double)reader["A"];
                historyEntry.B = (double)reader["B"];
                historyEntry.Operator = (Operator) Enum.Parse(typeof(Operator), (string)reader["Operator"]);
                historyEntry.Date = (DateTime)reader["Date"];
                historyEntry.Ip = (string)reader["Ip"];
                yield return historyEntry;
            }
            reader.Close();
        }
    }
}