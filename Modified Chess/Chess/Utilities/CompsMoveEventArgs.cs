namespace Chess.Utilities
{
    using System;

    public class CompsMoveEventArgs : EventArgs
    {
        public CompsMoveEventArgs(int[] coordinates)
        {
            this.Coordinates = coordinates;
        }

        public int[] Coordinates { get; set; }
    }
}
