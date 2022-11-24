using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloveceNezlobSe
{
    internal class Pawn
    {
        public Pawn(Player p, Board b, int x)
        {
            player = p;
            gameBoard = b;
            tileNum = 0;
            gameBoard.AddPawn(this);
            Name = p.Name + x;
        }

        Player player;
        Board gameBoard;
        int tileNum;
        public string Name { get; }

        public int GetTileNum()
        {
            return tileNum;
        }

        public void ReturnToStart()
        {
            tileNum = 0;
        }

        public void Move(int amount)
        {
            tileNum += amount;
        }

        public void Finish()
        {
            player.FinishPawn(this);
        }
    }
}
