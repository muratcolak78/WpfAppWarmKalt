using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWarmKalt
{
    public class User
    {
        private List<Game> games;
        private int totalScore;

        public string userName { get; set; }

        public int TotalScore
        {
            get { return totalScore; }
            private set { totalScore = value; }
        }

        public List<Game> Games
        {
            get { return games; }
            set
            {
                if (games != null)
                {
                    foreach (var game in games)
                    {
                        game.OnScoreChanged -= Game_OnScoreChanged; // Eski oyunlardan olayı kaldır
                    }
                }

                games = value;

                if (games != null)
                {
                    foreach (var game in games)
                    {
                        game.OnScoreChanged += Game_OnScoreChanged; // Yeni oyunlara olayı ekle
                    }
                }

                UpdateTotalScore();
            }
        }

        public User(string userName)
        {
            this.userName = userName;
            this.games = new List<Game>();
        }

        private void Game_OnScoreChanged(object sender, EventArgs e)
        {
            UpdateTotalScore();
        }

        private void UpdateTotalScore()
        {
            totalScore = games.Sum(g => g.Score);
        }

        public void AddGame(Game game)
        {
            games.Add(game);
            game.OnScoreChanged += Game_OnScoreChanged;
            UpdateTotalScore();
        }

        public void RemoveGame(Game game)
        {
            if (games.Remove(game))
            {
                game.OnScoreChanged -= Game_OnScoreChanged;
                UpdateTotalScore();
            }
        }
    }
}
