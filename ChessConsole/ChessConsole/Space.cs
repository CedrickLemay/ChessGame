using System.Collections;
using System.Drawing;

namespace ChessConsole
{
    public class Space
    {
        private Piece piece;
        private Point position;

        public Piece Piece { get => piece; set => piece = value; }

        public Space(Point pos)
        {
            piece = null;
            this.position = pos;
        }

        public Space(Piece p, Point pos)
        {
            piece = p;
            this.position = pos;
        }

        public ArrayList GetPossibleMoves()
        {
            if (piece == null) return null;

            return piece.GetPossibleMoves(position);
        }

    }

}
