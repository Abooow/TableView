using System;

namespace TableView.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Table table = new Table
            {
                Margin = 1
            };
            table.SetHeader(new TableRow(new string[] { "Row", "Header 2", "Nothing." }));

            table.AddRow(new TableRow(new string[] { "1", "Hello" }));
            table.AddRow(new TableRow(new string[] { "2", "Hey", "Column 3" }));
            table.AddRow(new TableRow(new string[] { "3", "Hi", "Extra text", "New Column?" }));

            table.Draw();

            Console.ReadLine();
        }
    }
}