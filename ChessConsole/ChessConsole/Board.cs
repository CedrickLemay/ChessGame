using System;
using System.Drawing;

namespace ChessConsole
{
    public static class Board
    {
        static private Space[,] board;

        public static void InitiateBoard()
        {
            board = new Space[8, 8];

            bool isWhite = false;
            for (byte j = 0; j < 2; j++)
            {
                //Pawn
                for (byte i = 0; i < 8; i++)
                {
                    board[(j * 5) + 1, i] = new Space(new Pawn(isWhite), new Point(((j * 5) + 1), i));
                }

                //Rook
                board[(j * 7), 0] = new Space(new Rook(isWhite), new Point((j * 7), 0));
                board[(j * 7), 7] = new Space(new Rook(isWhite), new Point((j * 7), 7));

                //Knight
                board[(j * 7), 1] = new Space(new Knight(isWhite), new Point((j * 7), 1));
                board[(j * 7), 6] = new Space(new Knight(isWhite), new Point((j * 7), 6));

                //Bishop
                board[(j * 7), 2] = new Space(new Bishop(isWhite), new Point((j * 7), 2));
                board[(j * 7), 5] = new Space(new Bishop(isWhite), new Point((j * 7), 5));

                //Queen
                board[(j * 7), 3] = new Space(new Queen(isWhite), new Point((j * 7), 3));

                //King
                board[(j * 7), 4] = new Space(new King(isWhite), new Point((j * 7), 4));

            isWhite = true;
            }

            for (byte i = 0; i < 4; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    board[2 + i, j] = new Space(new Point(2 + i, j));
                }

            }

            board[4, 4] = new Space(new Rook(isWhite), new Point(4,4));
        }

        public static Space GetSpace(Point p)
        {
            return board[p.X, p.Y];
        }

        public static void Show()
        {
            //afficher le board en console
            Console.WriteLine("  0 1 2 3 4 5 6 7  Y");
            for (var i = 0; i < 8; i++)
            {
                Console.Write(i + " ");
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
            Console.WriteLine('X');
        }


        public static void Move(Point oldPos, Point newPos) 
        {
            board[newPos.X, newPos.Y].Piece = board[oldPos.X, oldPos.Y].Piece;
            board[oldPos.X, oldPos.Y].Piece = null;
        }

        internal static Piece GetSpacePiece(Point pos)
        {
            return board[pos.X, pos.Y].Piece;
        }
    }
}
