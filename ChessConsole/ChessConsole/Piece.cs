using System;
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
    }
}
