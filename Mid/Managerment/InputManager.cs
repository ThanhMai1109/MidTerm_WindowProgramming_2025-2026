using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.Managerment
{
    internal class InputManager
    {
        public string hitText = "";
        public void HitLane(GameManager game, int lane, int hitlineY)
        {
            foreach (Note n in game.notes.ToList())
            {
                if (n.lane == lane)
                {
                    int noteCenter = n.y + 20;
                    int distance = Math.Abs(noteCenter - 550);

                    if (distance < 20)
                    {
                        game.combo++;
                        game.score += (int)(300 * (1 + game.combo / 25f));

                        game.perfectHit++;
                        game.totalHit++;

                        hitText = "PERFECT";
                        game.notes.Remove(n);
                        break;
                    }
                    else if (distance < 40)
                    {
                        game.combo++;
                        game.score += (int)(200 * (1 + game.combo / 25f)); ;

                        game.greatHit++;
                        game.totalHit++;

                        hitText = "GREAT";
                        game.notes.Remove(n);
                        break;
                    }
                    else if (distance < 60)
                    {
                        game.combo++;
                        game.score += (int)(100 * (1 + game.combo / 25f)); ;

                        game.goodHit++;
                        game.totalHit++;

                        hitText = "GOOD";
                        game.notes.Remove(n);
                        break;
                    }
                    else if (distance < 100)
                    {
                        game.combo++;
                        game.score += (int)(50 * (1 + game.combo / 25f)); ;

                        game.badHit++;
                        game.totalHit++;
                        hitText = "BAD";
                        game.notes.Remove(n);
                        break;
                    }
                }
            }
        }
    }
}
