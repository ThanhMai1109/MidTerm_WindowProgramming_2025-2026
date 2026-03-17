using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.Managerment
{
    internal class GameManager
    {
        public List<Note> notes = new List<Note>();

        Random rand = new Random();

        public int score;
        public int combo;

        public int totalHit;
        public int perfectHit;
        public int greatHit;
        public int goodHit;
        public int badHit;

        int spawnTimer = 0;
        int spawnInterval = 50;

        public void SpawnNote(int panelWidth)
        {
            spawnTimer++;

            if (spawnTimer < spawnInterval)
                return;

            spawnTimer = 0;

            int lane = rand.Next(0, 4);

            int laneWidth = panelWidth / 4;

            Note n = new Note();

            n.lane = lane;
            n.x = lane * laneWidth + laneWidth / 2 - n.noteWidth / 2;
            n.y = -50;

            notes.Add(n);
        }

        public void MoveNotes()
        {
            foreach (Note n in notes)
            {
                n.y += n.speed;
            }
        }

        public void RemoveMiss(int hitlineY)
        {
            foreach (Note n in notes.ToList())
            {
                if (n.y > hitlineY + 580)
                {
                    combo = 0;
                    totalHit++;

                    notes.Remove(n);
                }
            }
        }
        public float GetAccuracy()
        {
            float acc = (perfectHit * 300 + greatHit * 200 + goodHit * 100 + badHit * 50) / (float)(totalHit * 300);
            return acc;
        }
    }
}