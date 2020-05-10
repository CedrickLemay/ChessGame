using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Linq;

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
            ArrayList possibleMoves = new ArrayList();
            Point p;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    try
                    {
                        p = new Point(pos.X + i, pos.Y + j);

                        if (Board.GetSpacePiece(p) == null || Board.GetSpacePiece(p).IsWhite != this.IsWhite)
                            possibleMoves.Add(p);
                    }
                    catch (System.IndexOutOfRangeException e)
                    {
                        continue;
                    }
                    
                }
            }
             
            return possibleMoves;

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
            ArrayList possibleMoves = new ArrayList();

            bool[] stopVerif = Enumerable.Repeat(false,4).ToArray(); 

            int nx, ny;
            Point nPos;

            for (int i = 1; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (stopVerif[j]) continue;                    
                    //      at 0, we look up
                    //      at 1, we look left
                    //      at 2, we look down
                    //      at 3, we look rigth

                    nx = ((j + 1) % 2) * (j - 1) * i; 
                    ny = (j % 2) * (j - 2) * i;


                    nPos = new Point(pos.X + nx, pos.Y + ny);

                    try
                    {
                        Board.GetSpacePiece(nPos);
                    }
                    catch (System.IndexOutOfRangeException e)
                    {
                        stopVerif[j] = true;
                        continue;
                    }

                    if (Board.GetSpacePiece(nPos) == null)
                        possibleMoves.Add(nPos);
                    else if (Board.GetSpacePiece(nPos).IsWhite != this.IsWhite)
                    {
                        possibleMoves.Add(nPos);
                        stopVerif[j] = true;
                    }                    
                    else if (Board.GetSpacePiece(nPos).IsWhite == this.IsWhite)
                        stopVerif[j] = true;

                }

                if (stopVerif.All(v => v == true)) break;
            }

            return possibleMoves;
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
            ArrayList possibleMoves = new ArrayList();
            Point verifPos;
            int nx, ny;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j+=2)
                {
                    nx = ((i + 1) % 2) * (i - 1) * 2 + (i % 2) * (j - 1);
                    ny = (i % 2) * (i - 2) * 2 + ((i + 1) % 2) * (j - 1);

                    verifPos = new Point(pos.X + nx, pos.Y + ny);

                    try 
                    {
                        if(Board.GetSpacePiece(verifPos) == null || Board.GetSpacePiece(verifPos).IsWhite != this.IsWhite)
                            possibleMoves.Add(verifPos);
                    }
                    catch (System.IndexOutOfRangeException e){}
                }                
            }


            return possibleMoves;
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
            ArrayList possibleMoves = new ArrayList();
            Point verifPos;
            int nx, ny;
            bool[] stopVerif = Enumerable.Repeat(false, 4).ToArray();
            int verif_i;

            //ew... O(n3) ... ew...
            for (int i = 1; i < 7; i++)
            {
                for (int j = -1; j <= 1; j+=2)
                {
                    for (int k = -1; k <= 1; k += 2)
                    {
                        verif_i = (j + 1) + ((k + 1) / 2);

                        if (stopVerif[verif_i] == true) continue;

                        nx = pos.X + (i * j);
                        ny = pos.Y + (i * k);

                        verifPos = new Point(nx, ny);

                        try
                        {
                            Board.GetSpacePiece(verifPos);
                        }
                        catch (System.IndexOutOfRangeException e)
                        {
                            stopVerif[verif_i] = true;
                            continue;
                        }

                        if (Board.GetSpacePiece(verifPos) == null)
                            possibleMoves.Add(verifPos);
                        else if (Board.GetSpacePiece(verifPos).IsWhite != this.IsWhite)
                        {
                            possibleMoves.Add(verifPos);
                            stopVerif[verif_i] = true;
                        }
                        else if (Board.GetSpacePiece(verifPos).IsWhite == this.IsWhite)
                            stopVerif[verif_i] = true;
                    }
                }
            }

            return possibleMoves;

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

            int nx, ny;
            
            nx = ( IsWhite ? -1 : 1) * 1 + pos.X;
            verifPos = new Point(nx, pos.Y);
            try
            {
                if (Board.GetSpacePiece(verifPos) == null)
                    possibleMoves.Add(verifPos);
            }
            catch (System.IndexOutOfRangeException e) { }


            //Position in diagonal in front of him to check if there is enemy.
            ny = pos.Y + 1;
            verifPos = new Point(nx, ny);
            try
            {
                if (Board.GetSpacePiece(verifPos) != null && Board.GetSpacePiece(verifPos).IsWhite != this.IsWhite)
                    possibleMoves.Add(verifPos);
            }
            catch (System.IndexOutOfRangeException e) { }


            ny = pos.Y - 1;
            verifPos = new Point(nx, ny);
            try
            {
                if (Board.GetSpacePiece(verifPos) != null && Board.GetSpacePiece(verifPos).IsWhite != this.IsWhite)
                    possibleMoves.Add(verifPos);
            }
            catch (System.IndexOutOfRangeException e) { }


            return possibleMoves;
        }
    }
}
