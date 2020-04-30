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
            for (byte j = 0; j < 2; j++)
            {
                //Pawn
                for (byte i = 0; i < 8; i++)
                {
                    board[(j * 5) + 1, i] = new Space(new Pawn(isWhite),Convert.ToByte((j * 5) + 1), i);
                }

                   //the empty spaces
                    //SWITCH THE ARRAY TO AN ARRAY OF SPACES. SPACES WOULD CONTAIN POSSIBLE PIECES.

                //Rook
                board[(j * 7), 0] = new Space(new Rook(isWhite), Convert.ToByte(j * 7), 0);
                board[(j * 7), 7] = new Space(new Rook(isWhite), Convert.ToByte(j * 7), 7);

                //Knight
                board[(j * 7), 1] = new Space(new Knight(isWhite), Convert.ToByte(j * 7), 1);
                board[(j * 7), 6] = new Space(new Knight(isWhite), Convert.ToByte(j * 7), 6);

                //Bishop
                board[(j * 7), 2] = new Space(new Bishop(isWhite), Convert.ToByte(j * 7), 2);
                board[(j * 7), 5] = new Space(new Bishop(isWhite), Convert.ToByte(j * 7), 5);

                //Queen
                board[(j * 7), 3] = new Space(new Queen(isWhite), Convert.ToByte(j * 7), 3);

                //King
                board[(j * 7), 4] = new Space(new King(isWhite), Convert.ToByte(j * 7), 4);

                isWhite = true;
            }

            for (byte i = 0; i < 4; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    board[2 + i, j] = new Space(Convert.ToByte(2 + i), j);
                }
                
            }


        }
    }

    public class Space
    {
        private Piece piece;
        private byte posX;
        private byte posY;

        public Piece Piece { get => piece; set => piece = value; }

        public Space(byte posX, byte posY)
        {
            piece = null;
            this.posX = posX;
            this.posY = posY;
        }

        public Space(Piece p, byte posX, byte posY)
        {
            piece = p;
            this.posX = posX;
            this.posY = posY;
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
