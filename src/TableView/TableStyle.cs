namespace TableView
{
    public struct TableStyle
    {
        public char Horizontal { get; set; }
        public char Vertical { get; set; }
        public EdgeStyle Top { get; set; }
        public EdgeStyle Middle { get; set; }
        public EdgeStyle Bottom { get; set; }

        public TableStyle(char horizontal, char vertical, EdgeStyle top, EdgeStyle middle, EdgeStyle bottom)
        {
            Horizontal = horizontal;
            Vertical = vertical;
            Top = top;
            Middle = middle;
            Bottom = bottom;
        }

        public static readonly TableStyle BasicStyle = new TableStyle(
            '-',
            '|',
            new EdgeStyle('+', '+', '+'),
            new EdgeStyle('+', '+', '+'),
            new EdgeStyle('+', '+', '+'));

        public static readonly TableStyle LineStyle = new TableStyle(
            '━',
            '┃',
            new EdgeStyle('┏', '┳', '┓'),
            new EdgeStyle('┣', '╋', '┫'),
            new EdgeStyle('┗', '┻', '┛'));

        public static readonly TableStyle DoubleLineStyle = new TableStyle(
            '═',
            '║',
            new EdgeStyle('╔', '╦', '╗'),
            new EdgeStyle('╠', '╬', '╣'),
            new EdgeStyle('╚', '╩', '╝'));

        public static readonly TableStyle InvisibleStyle = new TableStyle(
            ' ',
            ' ',
            new EdgeStyle(' ', ' ', ' '),
            new EdgeStyle(' ', ' ', ' '),
            new EdgeStyle(' ', ' ', ' '));

        public struct EdgeStyle
        {
            public char Left { get; set; }
            public char Middle { get; set; }
            public char Right { get; set; }

            public EdgeStyle(char left, char middle, char right)
            {
                Left = left;
                Middle = middle;
                Right = right;
            }
        }
    }
}