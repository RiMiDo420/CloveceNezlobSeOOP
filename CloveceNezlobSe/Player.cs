using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloveceNezlobSe
{
    internal class Player
    {
        public Player(string name, int pawnNum, Game g, Board b)
        {
            Name = name;
            pawns = new List<Pawn>();
            for(int i = 0; i < pawnNum; i++)
            {
                pawns.Add(new Pawn(this, b, i));
            }
            game = g;
        }
        List<Pawn> pawns;
        Game game;
        public string Name { get; }

        public void FinishPawn(Pawn pawn)
        {
            pawns.Remove(pawn);
            if(pawns.Count == 0)
            {
                game.Win(this);
            }
        }

        public Pawn SelectPawn()
        {
            return pawns[0];
        }
    }
}
