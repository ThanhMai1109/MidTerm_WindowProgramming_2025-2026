using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid.Managerment
{
    internal class GameManager
    {
        public List<Note> notes = new List<Note>();
        public List<NoteData> noteDataList = new List<NoteData>();

        public int score;
        public int combo;

        public int totalHit;
        public int perfectHit;
        public int greatHit;
        public int goodHit;
        public int badHit;

        int currentIndex = 0;
        public int startTime;

        public void LoadFile(string FilePath)
        {
            noteDataList.Clear();
            currentIndex = 0;

            foreach (var line in File.ReadAllLines(FilePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',', ' ');

                if (parts.Length < 2) continue;

                if (int.TryParse(parts[0], out int time) &&
                    int.TryParse(parts[1], out int lane))
                {
                    noteDataList.Add(new NoteData
                    {
                        time = time,
                        lane = lane
                    });
                }
            }
        }

        public void SpawnNote(int[] laneX)
        {
            int currentTime = Environment.TickCount - startTime;
            int offset = 1000; // chỉnh để note rơi đúng hitline

            while (currentIndex < noteDataList.Count && noteDataList[currentIndex].time <= currentTime + offset)
            {
                var data = noteDataList[currentIndex];

                Note n = new Note();
                n.lane = data.lane;
                n.x = laneX[data.lane];
                n.y = -40;

                notes.Add(n);
                currentIndex++;
            }
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
                if (n.y > hitlineY + 200)
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