using System;
using System.Collections.Generic;
using System.Text;

namespace HeroMonsterGame
{
    public class MyActualProgram
    {
        public void StartHere()
        {
            var thisVariableShouldNeverBeUsed = "PUT A BREAK POINT ON THIS LINE AND DEBUG EVERY THING YOU EVER DO";

            Console.WriteLine("WELCOME TO THE GAME");

            Hero hero = new Hero();
            Console.Write("What is your name? ");
            hero.Name = Console.ReadLine();
            hero.Health = 100;
            hero.Potions = 3;
            hero.PotionsUsed = false;

            Monster monster = new Monster();
            monster.Name = "Monster";
            monster.Health = 100;
            monster.Potions = 3;
            monster.PotionsUsed = false;

            Console.WriteLine($"It's your turn {hero.Name}, what's your next move?!");
            var heroOptions = Enum.GetValues(typeof(HeroChoice));

            foreach (var value in heroOptions)
            {
                Console.WriteLine($"{(int)value}: {value.ToString().ConvertToCamelCase()}");
            }

            // int choice = Convert.ToInt32(Console.ReadLine());

            var heroChoice = Console.ReadLine();
            var selectedChoice = Enum.Parse<HeroChoice>(heroChoice);
            Console.WriteLine($"You chose to {Enum.Parse<HeroChoice>(heroChoice).ToString().ConvertToCamelCase()}\n");

            if (selectedChoice == HeroChoice.Attack)
            {
                var heroAttack = new Hero();
                heroAttack.HeroAttack();
            }
            else if (selectedChoice == HeroChoice.Heal)
            {
                var heroHeal = new Hero();
                heroHeal.HeroHeal();
            }
            else if (selectedChoice == HeroChoice.Potion)
            {
                var heroPotion = new Hero();
                heroPotion.HeroPotion();
            }
            else if (selectedChoice == HeroChoice.Fireball)
            {
                var heroFireball = new Hero();
                heroFireball.HeroFireball();
            }

            Console.WriteLine("It's Monster's turn!");
            // call monster turn
        }

        public void EndGame(Hero hero)
        {
            if (hero <= 0)
            {
                Console.WriteLine("Monster wins!");
            }
            if (monsterHP <= 0)
            {
                Console.WriteLine("Hero wins!");
            }
        }
    }
}

// magic fire ball attack, when chose 4
// Immediately deals HIGH damage
// The player or monster that used this attack must take a turn to recouperate 