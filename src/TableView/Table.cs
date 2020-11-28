using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#nullable enable

namespace TableView
{
    public class Table
    {
        public TableRow? Header { get; private set; }
        public IEnumerable<TableRow> Rows => rows;
        public int Margin { get; set; }
        public int TotalRows { get; private set; }
        public int TotalColumns { get; private set; }

        private List<TableRow> rows;
        private List<int> columnWidths;

        public Table()
        {
            this.rows = new List<TableRow>();
            columnWidths = new List<int>();
        }

        public Table(int columns, int rows)
        {
            this.rows = new List<TableRow>(rows);
            columnWidths = new List<int>(columns);

            for (int i = 0; i < rows; i++)
            {
                AddRow(new TableRow(columns));
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

        public void SetHeader(TableRow header)
        {
            Header = header;

            HandleRow(header);
        }

        public void AddRow(TableRow row)
        {
            rows.Add(row);

            TotalRows++;
            HandleRow(row);
        }

        public void Draw()
        {
            StringBuilder sb = new StringBuilder(TotalColumns);
            DrawLine(sb);
            if (Header != null)
            {
                DrawRow(sb, Header.Value);
                DrawLine(sb);
            }
            DrawRows(sb);
            DrawLine(sb);
            Console.Write(sb.ToString());
        }

        private void DrawRows(StringBuilder sb)
        {
            foreach (TableRow row in rows)
            {
                DrawRow(sb, row);
            }
        }

        private void DrawRow(StringBuilder sb, TableRow row)
        {
            for (int i = 0; i < TotalColumns; i++)
            {
                sb.Append('|');
                sb.Append(' ', Margin);
                if (i < row.TotalColumns)
                    sb.Append(row.Columns.ElementAt(i).PadRight(columnWidths[i]));
                else
                    sb.Append(' ', columnWidths[i]);
                sb.Append(' ', Margin);
            }
            sb.Append('|');
            sb.Append('\n');
        }

        private void DrawLine(StringBuilder sb)
        {
            for (int i = 0; i < TotalColumns; i++)
            {
                sb.Append('+');
                sb.Append('-', columnWidths[i] + Margin * 2);
            }
            sb.Append("+\n");
        }

        private void HandleRow(TableRow row)
        {
            if (row.TotalColumns > TotalColumns)
            {
                columnWidths.AddRange(new int[row.TotalColumns - TotalColumns]);
                TotalColumns = row.TotalColumns;
            }

            for (int i = 0; i < row.TotalColumns; i++)
            {
                int columnWidth = row.Columns.ElementAt(i).Length;
                if (columnWidth > columnWidths[i])
                    columnWidths[i] = columnWidth;
            }
        }
    }
}