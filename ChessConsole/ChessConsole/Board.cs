using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    board[(j * 5) + 1, i] = new Space(new Pawn(isWhite), Convert.ToByte((j * 5) + 1), i);
                }

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

        public static void Show()
        {
            //afficher le board en console
            Console.WriteLine("  0 1 2 3 4 5 6 7");
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
        }


        public static void Move(int ox, int oy, int nx, int ny) 
        {
            board[nx, ny].Piece = board[ox, oy].Piece;
            board[ox, oy].Piece = null;
        }

        internal static Piece GetSpacePiece(int x, int y)
        {
            return board[x, y].Piece;
        }
    }
}
