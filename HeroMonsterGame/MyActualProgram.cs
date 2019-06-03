using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HeroMonsterGame
{
    public class MyActualProgram
    {
        public static Hero hero;
        public static Monster monster;

        public void StartHere()
        {
            Console.WriteLine("WELCOME TO THE GAME\n");
            Console.Write("What is your name? ");

            hero = new Hero
            {
                Name = Console.ReadLine(),
                Health = 100,
                DefensePotions = 3,
                PotionsUsed = false,
                AttackValue = HeroActions.GetHeroAttackValue()
            };

            monster = new Monster
            {
                Name = "Monster",
                Health = 100,
                DefensePotions = 3,
                PotionsUsed = false,
                AttackValue = MonsterActions.GetMonsterAttackValue()
            };
            

            Console.WriteLine($"{hero.Name}'s Health: {hero.Health}");
            Console.WriteLine($"{monster.Name}'s Health: {monster.Health}\n");

            while (hero.Health > 0)
            {
                Console.WriteLine($"It's your turn {hero.Name}, what's your next move?!\n");
                var heroOptions = Enum.GetValues(typeof(HeroChoice));

                foreach (var value in heroOptions)
                {
                    Console.WriteLine($"{(int) value}: {value.ToString().ConvertToCamelCase()}");
                }

                Console.WriteLine();
                
                HeroActions.ExecuteHeroTurn();

                if (monster.Health <= 0)
                {
                    break;
                }

                Console.WriteLine($"It's {monster.Name}'s turn! \n");

                MonsterActions.ExecuteMonsterTurn();

                Console.WriteLine("--------------------------------------------------------------------------");

            }

            if (hero.Health <= 0)
            {
                EndGame(hero, monster);
            }

            if (monster.Health <= 0)
            {
                EndGame(hero, monster);
            }
        }

        public void EndGame(Hero hero, Monster monster)
        {
            if (hero.Health <= 0)
            {
                Console.WriteLine("Monster wins!");
                Console.WriteLine($"{hero.Name}'s Health: {hero.Health}");
                Console.WriteLine($"{monster.Name}'s Health: {monster.Health}");
                return;
            }
            else if (monster.Health <= 0)
            {
                Console.WriteLine("Hero wins!");
                Console.WriteLine($"{hero.Name}'s Health: {hero.Health}");
                Console.WriteLine($"{monster.Name}'s Health: {monster.Health}");
                return;
            }
        }
    }
}

// magic fire ball attack, when chose 4
// Immediately deals HIGH damage
// The player or monster that used this attack must take a turn to recouperate 