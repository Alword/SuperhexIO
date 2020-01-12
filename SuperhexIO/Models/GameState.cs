using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Models
{
    public class GameState
    {
        private Queue<PlayerTranslation> Translations { get; set; }
        public Dictionary<int, int> PlayerSkin { get; private set; }

        public GameState()
        {
            this.PlayerSkin = new Dictionary<int, int>(100);
            this.Translations = new Queue<PlayerTranslation>(256);
        }

        public void RegisterTranslation(PlayerTranslation playerTranslation)
        {
            Translations.Enqueue(playerTranslation);
            if (Translations.Count > 100)
                Translations.Clear();
            Console.WriteLine(playerTranslation);
        }
    }
}
