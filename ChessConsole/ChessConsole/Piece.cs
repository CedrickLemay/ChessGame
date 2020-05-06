using System;
using System.Collections;
using System.Drawing;

namespace ChessConsole
{
    public abstract class Piece
    {
        private bool isWhite;

        public bool IsWhite { get => isWhite; set => isWhite = value; }

        public Piece(bool isWhite) { this.isWhite = isWhite; }

        public virtual void Afficher() { } //test

        public virtual ArrayList GetPossibleMoves(Point pos) { return null; }

    }

    public class Queen : Piece
    {
        public Queen(bool isWhite) : base(isWhite)
        {
        }

        public override void Afficher()
        {
            Console.Write('Q');
        }

        public override ArrayList GetPossibleMoves(Point pos)
        {
            return null;
        }

    }

    public class King : Piece
    {
        public King(bool isWhite) : base(isWhite)
        {
        }

        public override void Afficher()
        {
            Console.Write('K');
        }

        public override ArrayList GetPossibleMoves(Point pos)
        {
            return null;
        }
    }

    public class Rook : Piece
    {
        public Rook(bool isWhite) : base(isWhite)
        {
        }
        public override void Afficher()
        {
            Console.Write('R');
        }

        public override ArrayList GetPossibleMoves(Point pos)
        {
            return null;
        }
    }

    public class Knight : Piece
    {
        public Knight(bool isWhite) : base(isWhite)
        {
        }
        public override void Afficher()
        {
            Console.Write('K');
        }
        public override ArrayList GetPossibleMoves(Point pos)
        {
            return null;
        }
    }

    public class Bishop : Piece
    {
        public Bishop(bool isWhite) : base(isWhite)
        {
        }

        public override void Afficher()
        {
            Console.Write('B');
        }
        public override ArrayList GetPossibleMoves(Point pos)
        {
            return null;
        }
    }

    public class Pawn : Piece
    {
        public Pawn(bool isWhite) : base(isWhite)
        {
        }
        public override void Afficher()
        {
            Console.Write('P');
        }
        public override ArrayList GetPossibleMoves(Point pos)
        {

            ArrayList possibleMoves = new ArrayList();

            Point verifPos; //Point used to verify

            
            int nx = (Convert.ToInt32(IsWhite) * -1) * 1 + pos.X;   //Position in front of him. (True = 1)
            verifPos = new Point(nx, pos.Y);

            if (Board.GetSpacePiece(verifPos) == null)
                possibleMoves.Add(verifPos);

            //Position in diagonal in front of him to check if there is enemy.
            int ny = pos.Y + 1;
            verifPos = new Point(nx, ny);
            if (Board.GetSpacePiece(verifPos) != null && Board.GetSpacePiece(verifPos).IsWhite != this.IsWhite)
                possibleMoves.Add(verifPos);


            ny = pos.Y - 1;
            verifPos = new Point(nx, ny);
            if (Board.GetSpacePiece(verifPos) != null && Board.GetSpacePiece(verifPos).IsWhite != this.IsWhite)
                possibleMoves.Add(verifPos);


            return possibleMoves;



        }
    }
}
