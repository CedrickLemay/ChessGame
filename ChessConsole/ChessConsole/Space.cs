using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessConsole
{
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

}
