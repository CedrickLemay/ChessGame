using System;
using System.Collections.Generic;
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

            //afficher mouvement possible
            int[] pos =  {Convert.ToInt32(posString.Split(' ')[0]), Convert.ToInt32(posString.Split(' ')[1]) };



            Console.ReadKey();

        }

    }

    
}
