using System;
using System.Collections.Generic;
using System.Text;

namespace HeroMonsterGame
{
    public class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Potions { get; set; }
        public bool PotionsUsed { get; set; }
        public int AttackValue { get; set; }
    }
}
