﻿using System;
using System.Collections;
using System.Drawing;
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
            bool[] stopVerif = Enumerable.Repeat(false,4).ToArray(); //that's fuck ugly .... need to change.

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (stopVerif[j]) continue;


                }

                if (stopVerif.All(v => v == false)) break;
            }

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

            
            int nx = ( IsWhite ? -1 : 1) * 1 + pos.X;
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
