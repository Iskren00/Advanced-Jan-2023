﻿using System;
using System.Text;
using System.Xml.Linq;

namespace Basketball
{
    public class Player
    {
        public Player(string name, string position, double rating, int games)
        {
            Name = name;
            Position = position;
            Rating = rating;
            Games = games;
            Retired = false;
        }

        public string Name { get; set; }

        public string Position { get; set; }

        public double Rating { get; set; }

        public int Games { get; set; }

        public bool Retired { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"-Player: {Name}");
            result.AppendLine($"--Position: {Position}");
            result.AppendLine($"--Rating: {Rating}");
            result.AppendLine($"--Games played: {Games}");

            return result.ToString().Trim();
        }
    }
}
