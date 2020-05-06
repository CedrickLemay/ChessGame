using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole
{
    public abstract class Piece
    {
        private bool isWhite;

        public bool IsWhite { get => isWhite; set => isWhite = value; }

        public Piece(bool isWhite) { this.isWhite = isWhite; }

        public virtual void Afficher() { } //test

        public virtual ArrayList GetPossibleMoves(int x, int y) { return null; }

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

        public override ArrayList GetPossibleMoves(int x, int y)
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

        public override ArrayList GetPossibleMoves(int x, int y)
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

        public override ArrayList GetPossibleMoves(int x, int y)
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
        public override ArrayList GetPossibleMoves(int x, int y)
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
        public override ArrayList GetPossibleMoves(int x, int y)
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
        public override ArrayList GetPossibleMoves(int x, int y)
        {

            ArrayList possibleMoves = new ArrayList();



            int ny = (Convert.ToInt32(IsWhite) * -1) * 1 + y;   //Position in front of him. (True = 1)

            if (Board.GetSpacePiece(x, ny).IsWhite == this.IsWhite) 
                
            //Position in diagonal in front of him to check if there is enemy.
            if (Board.GetSpacePiece(x + 1, ny).IsWhite != this.IsWhite)
            
            if (Board.GetSpacePiece(x - 1, ny).IsWhite != this.IsWhite)



            // todo: changer tout les x y pour point PARTOUT
                   
                    
        }
    }
}
