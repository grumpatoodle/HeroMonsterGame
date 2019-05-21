using System;
using System.Collections.Generic;
using System.Text;

namespace HeroMonsterGame
{
    public class Hero
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Potions { get; set; }
        public bool PotionsUsed { get; set; }


        public void HeroAttack(Monster monster)
        {
            while (Health > 0) // wrong. not using MyActualProgram hero...
            {
                PotionsUsed = false;

                if (monster.PotionsUsed)
                {
                    Console.WriteLine("Monster used potion and blocked your attack!");
                }
                else
                {
                    Random attackValue = new Random(40);
                    monster.Health =- attackValue;
                    Console.WriteLine($"You chose {heroChoice}! Monster's HP is now {monster.Health}");
                }
            }
        }

        public void HeroHeal()
        {
            Health += 10;
            Console.WriteLine($"You chose {heroChoice}! Hero HP is now {Health}");
        }

        public void HeroPotion()
        {
            if (Potions <= 0)
            {
                Console.WriteLine("You tried to use a potion but you are all out!");
            }
            else
            {
                Potions--;
                Console.WriteLine($"You chose {heroChoice}! You blocked Monster's next attack! You now have {Hero.PotionsUsed} left.");
                PotionsUsed = true;
            }
        }

        public void HeroFireball()
        {
            Console.WriteLine("FIREBALL DOESN'T EXIT YET");
        }
    }
}
