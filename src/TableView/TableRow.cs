using System.Collections.Generic;
using System.Linq;

namespace TableView
{
    public struct TableRow
    {
        public IEnumerable<string> Columns => columns;
        public int TotalColumns => Columns?.Count() ?? 0;

        private List<string> columns;

        public TableRow(int columns)
            : this(Enumerable.Repeat("", columns))
        {
        }

        public TableRow(IEnumerable<string> columns)
        {
            this.columns = new List<string>(columns);
        }

        public void AddColumn(string content)
        {
            columns.Add(content);
        }

        public void InsertColumn(int index, string content)
        {
            columns.Insert(index, content);
        }

        public void ClearColumns(string content)
        {
            columns.ForEach(x => { if (x == content) x = ""; });
        }

        public void ClearColumn(int index)
        {
            columns[index] = "";
        }

        public void ClearAll()
        {
            columns.ForEach(x => x = "");
        }

        public void RemoveColumns(string content)
        {
            columns.RemoveAll(x => x == content);
        }

        public void RemoveColumn(int index)
        {
            columns.RemoveAt(index);
        }

        public void RemoveAll()
        {
            columns.Clear();
        }
    }
}