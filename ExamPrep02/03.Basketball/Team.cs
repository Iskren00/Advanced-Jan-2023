using System;
using System.Collections.Generic;

namespace Basketball
{
    public class Team
    {

        public Team(string name, int openPositions, char group)
        {
            Players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public List<Player> Players { get; set; }

        public string Name { get; set; }

        public int OpenPositions { get; set; }

        public char Group { get; set; }

        public int Count { get { return Players.Count; } }

        public string AddPlayer(Player player)
        {
            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Name == null || player.Position == null || player.Name == "" || player.Position == "")
            {
                return "Invalid player's information.";
            }

            if (player.Rating < 80) 
            {
                return "Invalid player's rating.";
            }

            Players.Add(player);
            OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            foreach (var player in Players)
            {
                if (player.Name == name)
                {
                    Players.Remove(player);
                    OpenPositions++;
                    return true;
                }
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = 0;
            List<Player> players = new List<Player>(Players);

            foreach (var player in Players)
            {
                if (player.Position == position)
                {
                    players.Remove(player);
                    count++;
                    OpenPositions++;
                }
            }

            Players = players;

            return count;
        }

        public Player RetirePlayer(string name)
        {
            foreach (var player in Players)
            {
                if (player.Name == name)
                {
                    player.Retired = true;
                    return player;
                }
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            List<Player> playersByGames = new List<Player>();

            foreach (var player in Players)
            {
                if (player.Games >= games)
                {
                    playersByGames.Add(player);
                }
            }

            return playersByGames;
        }

        public string Report()
        {
            List<Player> playersThatNotRetired = new List<Player>();

            foreach (var player in Players)
            {
                if (player.Retired == false)
                {
                    playersThatNotRetired.Add(player);
                }
            }

            return $"Active players competing for Team {Name} from Group {Group}:{Environment.NewLine}{string.Join(Environment.NewLine, playersThatNotRetired)}";
        }
    }
}
