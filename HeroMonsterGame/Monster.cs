using System;
using System.Collections.Generic;
using System.Text;

namespace HeroMonsterGame
{
    public class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DefensePotions { get; set; }
        public bool PotionsUsed { get; set; }
        public int AttackValue { get; set; }
    }

    public class MonsterActions
    {
        public static Hero hero = MyActualProgram.hero;
        public static Monster monster = MyActualProgram.monster;

        public static int GetMonsterAttackValue()
        {
            Random rndAttack = new Random();
            var attackValue = rndAttack.Next(4, 26);
            return attackValue;
        }

        public static void ExecuteMonsterTurn()
        {
            Random monsterRnd = new Random();
            var monsterChoice = monsterRnd.Next(1, 4); // change 4 to 5 for fireball
            var selectedMonsterChoice = (MonsterChoice)monsterChoice;
            Console.WriteLine($"Monster chose to {selectedMonsterChoice.ToString().ConvertToCamelCase()}!");

            if (selectedMonsterChoice == MonsterChoice.Attack)
            {
                MonsterAttack(monster, hero);
            }
            else if (selectedMonsterChoice == MonsterChoice.Heal)
            {
                MonsterHeal(monster);
            }
            else if (selectedMonsterChoice == MonsterChoice.DefensePotion)
            {
                MonsterPotion(monster);
            }
            //else if (selectedMonsterChoice == MonsterChoice.Fireball)
            //{
            //    MonsterFireball(monster);
            //}
        }

        public static void MonsterAttack(Monster monster, Hero hero)
        {
            if (hero.PotionsUsed == true)
            {
                Console.WriteLine($"His attack was worthless because of your defense potion! Dumb bitch!\n");
                hero.PotionsUsed = false;
            }
            else
            {
                hero.Health -= monster.AttackValue;
                Console.WriteLine($"Hero HP is now {hero.Health}\n");
            }
        }

        public static void MonsterHeal(Monster monster)
        {
            if (monster.Health < 100)
            {
                monster.Health += 8;
                if (monster.Health >= 100)
                {
                    monster.Health = 100;
                    Console.WriteLine($"{monster.Name}'s HP is now {monster.Health}\n");
                }
                else
                {
                    Console.WriteLine($"{monster.Name}'s HP is now {monster.Health}\n");
                }
            }
            else
            {
                Console.WriteLine(
                    $"{monster.Name} is at the max health of {monster.Health}! He can't be any healthier than this.\n");
            }
        }

        public static void MonsterPotion(Monster monster)
        {
            if (monster.DefensePotions <= 0)
            {
                Console.WriteLine($"{monster.Name} tried to use a potion but he was all out!\n");
                monster.PotionsUsed = false;
            }
            else
            {
                monster.DefensePotions--;
                Console.WriteLine($"{monster.Name} blocked your next attack! {monster.Name} now has {monster.DefensePotions} left.\n");
                monster.PotionsUsed = true;
            }
        }

        //public static void MonsterFireball(Monster monster)
        //{
        //    Console.WriteLine("FIREBALL DOESN'T EXIT YET!\n");
        //}
    }
}
