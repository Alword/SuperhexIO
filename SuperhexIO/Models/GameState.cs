using System;
using System.Collections.Generic;
using System.Text;

namespace SuperhexIO.Models
{
    public class GameState
    {
        private Queue<PlayerTranslation> Translations { get; set; }
        private Dictionary<int, string> PlayerNick { get; set; }
        private Dictionary<int, int> PlayerSkin { get; set; }

        public GameState()
        {
            this.PlayerSkin = new Dictionary<int, int>(100);
            this.PlayerNick = new Dictionary<int, string>(100);
            this.Translations = new Queue<PlayerTranslation>(256);
        }

        public void RegisterSkin(int playerId, int skinId)
        {
            RegisterDictionary(playerId, skinId, PlayerSkin);
            //Console.WriteLine($"skin {skinId} recived for player {playerId}");
        }

        public void RegisterTranslation(PlayerTranslation playerTranslation)
        {
            Translations.Enqueue(playerTranslation);
            if (Translations.Count > 100)
                Translations.Clear();
            // Console.WriteLine(playerTranslation);
        }

        public void RegisterNick(int playerId, string nickName)
        {
            RegisterDictionary(playerId, nickName, PlayerNick);
            // Console.WriteLine($"[Username] {nickName} received for player {playerId}");
        }

        private static void RegisterDictionary<Key, Value>(Key key, Value value, Dictionary<Key, Value> dictionary)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }
    }
}
