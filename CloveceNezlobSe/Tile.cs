using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloveceNezlobSe
{
    internal class Tile
    {
        public Tile()
        {
            pawnsOnTile = new List<Pawn> { };
            isFinish = false;
        }

        List<Pawn> pawnsOnTile;
        bool isFinish;

        public bool CheckThrowout()
        {
            if(pawnsOnTile.Count > 1)
            {
                return true;
            }
            return false;
        }

        public bool AddPawn(Pawn pawn)
        {
            pawnsOnTile.Add(pawn);
            if (isFinish)
            {
                pawn.Finish();
                return false;
            }
            return CheckThrowout();

        }

        public Pawn RemoveFirstPawn()
        {
            Pawn pawn = pawnsOnTile[0];
            pawnsOnTile.Remove(pawn);
            return pawn;
        }

        public Pawn RemovePawn(Pawn pawn)
        {
            pawnsOnTile.Remove(pawn);
            return pawn;
        }

        public void SetFinish() 
        {
            isFinish = true; 
        }

        public string Draw()
        {
            if(pawnsOnTile.Count == 0)
            {
                return "";
            }
            if(pawnsOnTile.Count == 1)
            {
                return pawnsOnTile[0].Name;
            }
            else
            {
                string returnString = pawnsOnTile[0].Name;
                for(int i = 1; i < pawnsOnTile.Count; i++)
                {
                    returnString += ", ";
                    returnString += pawnsOnTile[i].Name;
                }
                return returnString;
            }
        }
    }
}
