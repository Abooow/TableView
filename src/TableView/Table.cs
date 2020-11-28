using System.Collections.Generic;
using System.Linq;

#nullable enable

namespace TableView
{
    public class Table
    {
        public TableRow Header { get; }
        public IEnumerable<TableRow> Rows => rows;
        public int Margin { get; set; }
        public int TotalRows { get; private set; }
        public int TotalColumns { get; private set; }

        private List<TableRow> rows;
        private List<int> columnWidths;

        public Table(int rows, int columns)
        {
            TotalRows = rows;
            TotalColumns = columns;
            this.rows = new List<TableRow>(rows);
            columnWidths = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                this.rows.Add(new TableRow(columns));
            }
        }

        public Table(IEnumerable<TableRow> rows)
        {
            this.rows = new List<TableRow>(TotalRows);
            columnWidths = new List<int>();

            foreach (TableRow row in rows)
            {
                AddRow(row);
            }
        }

        public void AddRow(TableRow row)
        {
            rows.Add(row);

            TotalRows++;
            if (row.TotalColumns > TotalColumns)
                TotalColumns = row.TotalColumns;
        }
    }
}