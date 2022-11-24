using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloveceNezlobSe
{
    internal class Board
    {
        public Board(int tileAmt)
        {
            tiles = new Tile[tileAmt];
            for(int i = 0; i < tileAmt; i++)
            {
                tiles[i] = new Tile();
            }
            tiles[tiles.Length - 1].SetFinish();
        }

        Tile[] tiles;

        public void MovePawn(Pawn pawn, int spaces)
        {
            int tileNum = pawn.GetTileNum();
            tiles[tileNum].RemovePawn(pawn);
            pawn.Move(spaces);
            tileNum += spaces;
            if (tileNum >= tiles.Length)
            {
                tileNum = tiles.Length - 1;
                pawn.ReturnToStart();
                pawn.Move(tileNum);
            }
            if (tiles[tileNum].AddPawn(pawn))
            {
                Pawn pawnToThrow = tiles[tileNum].RemoveFirstPawn();
                pawnToThrow.ReturnToStart();
                tiles[0].AddPawn(pawnToThrow);
            }
            
        }

        public void AddPawn(Pawn pawn)
        {
            tiles[0].AddPawn(pawn);
        }

        public void Draw()
        {
            string writeValue = "";
            foreach(Tile tile in tiles)
            {
                writeValue += "[";
                writeValue += tile.Draw();
                writeValue += "]";
            }
            Console.WriteLine(writeValue);
        }

    }
}
