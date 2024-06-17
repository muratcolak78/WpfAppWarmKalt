using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWarmKalt
{
    public class Game
    {
        private int attempts;
        private int score;

        public Game(string gameNiveue, int attempts)
        {
            this.gameNiveue = gameNiveue;
            this.Attempts = attempts;
            SetScore();
        }
     

        public string gameNiveue { get; set; }
        public int Attempts
        {
            get { return attempts; }
            set
            {
                attempts = value;
                SetScore();
            }
        }
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                OnScoreChanged?.Invoke(this, EventArgs.Empty); // Score değiştiğinde olayı tetikle
            }
        }

        private void SetScore()
        {
            if (attempts == 1)
            {
                Score = 100;
            }
            else if (attempts <= 20)
            {
                Score = 100 - (attempts - 1) * 5;
            }
            else
            {
                Score = 0;
            }
        }

        public event EventHandler OnScoreChanged; // Score değiştiğinde tetiklenecek olay
    }
}
   