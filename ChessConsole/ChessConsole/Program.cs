using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Board.InitiateBoard();

            Board.Show();

            string posString = Console.ReadLine();

            Point p = new Point(Convert.ToInt32(posString.Split(' ')[0]), Convert.ToInt32(posString.Split(' ')[1]));

            Board.GetSpace(p).GetPossibleMoves(); //fix this

            Console.ReadKey();

        }

    }

    
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      