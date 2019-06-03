using System;
using System.Collections.Generic;
using System.Text;

namespace HeroMonsterGame
{
    public class Hero
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DefensePotions { get; set; }
        public bool PotionsUsed { get; set; }
        public int AttackValue { get; set; }
    }

    public class HeroActions
    {
        public static Hero hero = MyActualProgram.hero;
        public static Monster monster = MyActualProgram.monster;

        public static int GetHeroAttackValue()
        {
            Random rndAttack = new Random();
            var attackValue = rndAttack.Next(7, 31);
            return attackValue;
        }

        public static void ExecuteHeroTurn()
        {
            var heroChoice = Console.ReadLine();
            var selectedHeroChoice = Enum.Parse<HeroChoice>(heroChoice);
            Console.WriteLine(
                $"You chose to {Enum.Parse<HeroChoice>(heroChoice).ToString().ConvertToCamelCase()}!");

            if (selectedHeroChoice == HeroChoice.Attack)
            {
                HeroActions.HeroAttack(hero, monster);
            }
            else if (selectedHeroChoice == HeroChoice.Heal)
            {
                HeroActions.HeroHeal(hero);
            }
            else if (selectedHeroChoice == HeroChoice.DefensePotion)
            {
                HeroActions.HeroPotion(hero, monster);
            }
            //else if (selectedHeroChoice == HeroChoice.Fireball)
            //{
            //    HeroFireball(hero);
            //}
        }

        public static void HeroAttack(Hero hero, Monster monster)
        {
            if (monster.PotionsUsed == true)
            {
                Console.WriteLine($"{monster.Name} previously used potion and blocked your attack!\n");
                monster.PotionsUsed = false;
            }
            else
            {
                monster.Health -= hero.AttackValue;
                Console.WriteLine($"{monster.Name}'s HP is now {monster.Health}\n");
            }
        }

        public static void HeroHeal(Hero hero)
        {
            if (hero.Health < 100)
            {
                hero.Health += 10;
                if (hero.Health >= 100)
                {
                    hero.Health = 100;
                    Console.WriteLine($"{hero.Name}'s HP is now {hero.Health}\n");
                }
                else
                {
                    Console.WriteLine($"{hero.Name}'s HP is now {hero.Health}\n");
                }
            }
            else
            {
                Console.WriteLine(
                    $"{hero.Name} is at the max health of {hero.Health}! Sorry, you can't be any healthier than this.\n");
            }
        }

        public static void HeroPotion(Hero hero, Monster monster)
        {
            if (hero.DefensePotions <= 0)
            {
                Console.WriteLine("You tried to use a potion but you are all out!\n");
                hero.PotionsUsed = false;
            }
            else
            {
                hero.DefensePotions--;
                Console.WriteLine($"You blocked {monster.Name}'s next attack! You now have {hero.DefensePotions} left.\n");
                hero.PotionsUsed = true;
            }
        }

        //public static void HeroFireball(Hero hero)
        //{
        //    Console.WriteLine("FIREBALL DOESN'T EXIT YET!\n");
        //}
    }
}
