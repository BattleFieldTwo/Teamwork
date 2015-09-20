namespace BattleField2.Models.Coordinates
{
    public struct Coordinates
    {
        public readonly int Row, Col;

        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public static bool operator ==(Coordinates a, Coordinates b)
        {
            return a.Row == b.Row && a.Col == b.Col;
        }

        public static bool operator !=(Coordinates a, Coordinates b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinates && this == (Coordinates)obj;
        }

        public override int GetHashCode()
        {
            return (this.Row << 16) ^ this.Col;
        }

        public override string ToString()
        {
            string result = string.Format("{0}  {1}", this.Row, this.Col);
            return result;
        }
    }
}