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
                if (n.lane != lane) continue;

                int noteCenter = n.y + 20;

                if(noteCenter< hitlineY-100)    continue;

                int distance = Math.Abs(noteCenter - hitlineY);

                if (distance < 10)
                {
                    game.combo++;
                    game.score += (int)(300 * (1 + game.combo / 25f));

                    game.perfectHit++;
                    game.totalHit++;

                    hitText = "PERFECT";
                    game.notes.Remove(n);
                    break;
                }
                else if (distance < 25)
                {
                    game.combo++;
                    game.score += (int)(200 * (1 + game.combo / 25f)); ;

                    game.greatHit++;
                    game.totalHit++;

                    hitText = "GREAT";
                    game.notes.Remove(n);
                    break;
                }
                else if (distance < 40)
                {
                    game.combo++;
                    game.score += (int)(100 * (1 + game.combo / 25f)); ;

                    game.goodHit++;
                    game.totalHit++;

                    hitText = "GOOD";
                    game.notes.Remove(n);
                    break;
                }
                else if (distance < 50)
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