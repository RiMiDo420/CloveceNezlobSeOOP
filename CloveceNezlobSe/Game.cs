using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloveceNezlobSe
{
    internal class Game
    {
        public Game(string[] playerNames, int pawnsPerPlayer = 4, int boardLength = 15)
        {
            board = new Board(boardLength);
            players = new List<Player>();
            for(int i = 0; i < playerNames.Length; i++)
            {
                players.Add(new Player(playerNames[i], pawnsPerPlayer, this, board));
            }
        }

        Board board;
        List<Player> players;
        bool isOver = false;
        public void Win(Player p)
        {
            Console.WriteLine(p.Name + " wins");
            isOver = true;
        }

        public void Turn(Player playerToMove)
        {
            Console.WriteLine(playerToMove.Name + " to move");
            int die = RollDice();
            Console.WriteLine("Rolled a " + die);
            Pawn pawnToMove = playerToMove.SelectPawn();
            board.MovePawn(pawnToMove, die);
            board.Draw();
        }

        public int RollDice()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }

        public void Play()
        {
            int playerToMove = 0;
            while (!isOver)
            {
                Turn(players[playerToMove]);
                playerToMove++;
                if(playerToMove >= players.Count)
                {
                    playerToMove = 0;
                }
            }
        }
    }
}
