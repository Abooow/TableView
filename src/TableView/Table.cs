using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#nullable enable

namespace TableView
{
    public class Table
    {
        public TableRow? Header
        {
            get => _header;
            set => SetHeader(value);
        }

        private TableRow? _header;
        public IEnumerable<TableRow> Rows => rows;
        public TableStyle TableStyle { get; set; }
        public TextAlignment TextAlignment { get; set; }
        public int TotalRows { get; private set; }
        public int TotalColumns { get; private set; }

        public int Margin
        {
            get => _margin;
            set
            {
                if (value < 0)
                    value = 0;
                _margin = value;
            }
        }

        private int _margin;

        private List<TableRow> rows;
        private List<int> columnWidths;

        public Table()
        {
            Initialize(0, 0);
        }

        public Table(int columns, int rows)
        {
            Initialize(columns, rows);

            for (int i = 0; i < rows; i++)
            {
                AddRow(new TableRow(columns));
            }
        }

        public Table(IEnumerable<TableRow> rows)
        {
            Initialize(0, rows.Count());

            foreach (TableRow row in rows)
            {
                AddRow(row);
            }
        }

        private void Initialize(int columns, int rows)
        {
            this.rows = new List<TableRow>(rows);
            columnWidths = new List<int>(columns);
            TableStyle = TableStyle.BasicStyle;
            TextAlignment = TextAlignment.Left;
        }

        public void SetHeader(TableRow? header)
        {
            _header = header;

            if (header != null)
                HandleRow(header.Value);
        }

        public void AddRow(TableRow row)
        {
            rows.Add(row);

            TotalRows++;
            HandleRow(row);
        }

        public string GetTableAsString(int letfMargin = 0)
        {
            StringBuilder sb = new StringBuilder(TotalColumns);

            DrawLine(sb, TableStyle.Top, letfMargin);
            if (Header != null)
            {
                DrawRow(sb, Header.Value, letfMargin);
                DrawLine(sb, TableStyle.Middle, letfMargin);
            }
            DrawRows(sb, letfMargin);
            DrawLine(sb, TableStyle.Bottom, letfMargin);

            return sb.ToString();
        }

        public void Draw(int letfMargin = 0)
        {
            Console.Write(GetTableAsString(letfMargin));
        }

        private void DrawRows(StringBuilder sb, int letfMargin)
        {
            foreach (TableRow row in rows)
            {
                DrawRow(sb, row, letfMargin);
            }
        }

        private void DrawRow(StringBuilder sb, TableRow row, int letfMargin)
        {
            sb.Append(' ', letfMargin);
            for (int i = 0; i < TotalColumns; i++)
            {
                sb.Append(TableStyle.Vertical);
                sb.Append(' ', Margin);
                if (i < row.TotalColumns)
                    sb.Append(AlignText(row.Columns.ElementAt(i), columnWidths[i]));
                else
                    sb.Append(' ', columnWidths[i]);
                sb.Append(' ', Margin);
            }
            sb.Append(TableStyle.Vertical);
            sb.Append('\n');
        }

        private void DrawLine(StringBuilder sb, TableStyle.EdgeStyle edge, int letfMargin)
        {
            sb.Append(' ', letfMargin);
            sb.Append(edge.Left);
            for (int i = 0; i < TotalColumns; i++)
            {
                if (i != 0)
                    sb.Append(edge.Middle);
                sb.Append(TableStyle.Horizontal, columnWidths[i] + Margin * 2);
            }
            sb.Append(edge.Right);
            sb.Append("\n");
        }

        private string AlignText(string text, int totalWidth)
        {
            return TextAlignment switch
            {
                TextAlignment.Left => text.PadRight(totalWidth),
                TextAlignment.Center => text.PadCenter(totalWidth),
                TextAlignment.Right => text.PadLeft(totalWidth),
                _ => text.PadRight(totalWidth)
            };
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

        public static Table operator +(Table table, TableRow row)
        {
            table.AddRow(row);
            return table;
        }

        public static Table operator +(Table table, IEnumerable<string> row)
        {
            table.AddRow(new TableRow(row));
            return table;
        }
    }
}