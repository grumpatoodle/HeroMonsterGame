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

        Hero hero = new Hero();

        //if (monsterHP <= 0)
        //{
        //    var theEnd = new EndGame();
        //}

        public void MonsterTurn(int num)
        {
            Random monsterChoice = new Random(4);
        }

        public void MonsterAttack(Monster monster)
        {
            PotionsUsed = false;

            if (hero.PotionsUsed)
            {
                Console.WriteLine("Monster chose attack but his attack was worthless! Dumb bitch!");
            }
            else
            {
                Random attackValue = new Random(40);
                hero.Health - attackValue = hero.Health;
                Console.WriteLine($"Monster attacked! Hero HP is now {heroHP}");
            }
        }

        public void MonsterHeal()
        {
            Health += 8;
            Console.WriteLine($"Monster chose to heal! Monster's HP is now {Health}");
        }

        public void MonsterPotion()
        {
            if (Potions <= 0)
            {
                Console.WriteLine("Monster tried to use a potion but he was all out!");
            }
            else
            {
                Potions--;
                Console.WriteLine($"Monster chose {monsterChoice}! Monster blocked your next attack! Monster now has {monsterPotions} left.");
                PotionsUsed = true;
            }
        }

        public void MonsterFireball()
        {
            Console.WriteLine("FIREBALL DOESN'T EXIT YET");
        }
    }
}
