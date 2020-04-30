using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole
{
    class Program
    {
        static private Space[,] board;
        static void Main(string[] args)
        {
            board = new Space[8, 8];

            InitiateBoard();
            
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    if (board[i, j].Piece != null)
                        board[i, j].Piece.Afficher();
                    else
                        Console.Write(' ');

                    Console.Write(' ');
                }
                Console.WriteLine();
            }

            Console.ReadKey();

        }

        static public void InitiateBoard()
        {

            bool isWhite = false;
            for (var j = 0; j < 2; j++)
            {
                //Pawn
                for (var i = 0; i < 8; i++)
                {
                    board[(j * 5) + 1, i] = new Space(new Pawn(isWhite));
                }

                   //the empty spaces
                    //SWITCH THE ARRAY TO AN ARRAY OF SPACES. SPACES WOULD CONTAIN POSSIBLE PIECES.

                //Rook
                board[(j * 7), 0] = new Space(new Rook(isWhite));
                board[(j * 7), 7] = new Space(new Rook(isWhite));

                //Knight
                board[(j * 7), 1] = new Space(new Knight(isWhite));
                board[(j * 7), 6] = new Space(new Knight(isWhite));

                //Bishop
                board[(j * 7), 2] = new Space(new Bishop(isWhite));
                board[(j * 7), 5] = new Space(new Bishop(isWhite));

                //Queen
                board[(j * 7), 3] = new Space(new Queen(isWhite));

                //King
                board[(j * 7), 4] = new Space(new King(isWhite));

                isWhite = true;
            }

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    board[2 + i, j] = new Space();
                }
                
            }


        }
    }

    public class Space
    {
        private Piece piece;

        public Piece Piece { get => piece; set => piece = value; }

        public Space()
        {
            piece = null;
        }

        public Space(Piece p)
        {
            piece = p;
        }
    }

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
