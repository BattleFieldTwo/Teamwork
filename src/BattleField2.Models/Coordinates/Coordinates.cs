namespace BattleField2.Models.Coordinates
{
    /// <summary>
    /// Coordinates struct defines and handles the game field coordinates.
    /// </summary>
    public struct Coordinates
    {
        /// <summary>
        /// Readonly properties representing the Row and Column in the game field.
        /// </summary>
        public readonly int Row, Col;

        /// <summary>
        /// Coordinates method that sets the current coordinates by given properties.
        /// </summary>
        /// <param name="row">Row coordinate parameter.</param>
        /// <param name="col">Column coordinate parameter.</param>
        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        //public static bool operator ==(Coordinates a, Coordinates b)
        //{
        //    return a.Row == b.Row && a.Col == b.Col;
        //}

        //public static bool operator !=(Coordinates a, Coordinates b)
        //{
        //    return !(a == b);
        //}

        //public override bool Equals(object obj)
        //{
        //    return obj is Coordinates && this == (Coordinates)obj;
        //}

        //public override int GetHashCode()
        //{
        //    return (this.Row << 16) ^ this.Col;
        //}

        /// <summary>
        /// Overwritten ToString() method for the string representation
        /// of the game field coordinates. 
        /// </summary>
        /// <returns>Returns the string representation of the given game field coordinates.</returns>
        public override string ToString()
        {
            string result = string.Format("{0}  {1}", this.Row, this.Col);
            return result;
        }
    }
}