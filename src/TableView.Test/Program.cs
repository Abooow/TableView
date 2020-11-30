using System;
using System.Text;

namespace TableView.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Table table = new Table
            {
                Margin = 2
            };
            table.SetHeader(new TableRow(new string[] { "Row", "Header 2", "Nothing." }));

            table += new TableRow(new string[] { "1", "Hello" });
            table += new string[] { "Hey", "yo", "Man", "cool" };
            table.AddRow(new TableRow(new string[] { "2", "Hey", "Column 3" }));
            table.AddRow(new TableRow(new string[] { "3", "Hi", "Extra text", "New Column?" }));

            table.Draw(4);

            Console.ReadLine();
        }
    }
}