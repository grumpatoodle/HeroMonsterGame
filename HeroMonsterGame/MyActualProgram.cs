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

            Console.WriteLine("WELCOME TO THE GAME\n");

            Hero hero = new Hero();
            Console.Write("What is your name? ");
            hero.Name = Console.ReadLine();
            hero.Health = 100;
            hero.DefensePotions = 3;
            hero.PotionsUsed = false;
            hero.AttackValue = GetHeroAttackValue();

            Monster monster = new Monster();
            monster.Name = "Monster";
            monster.Health = 100;
            monster.Potions = 3;
            monster.PotionsUsed = false;
            monster.AttackValue = GetMonsterAttackValue();

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
                var heroChoice = Console.ReadLine();
                var selectedHeroChoice = Enum.Parse<HeroChoice>(heroChoice);
                Console.WriteLine(
                    $"You chose to {Enum.Parse<HeroChoice>(heroChoice).ToString().ConvertToCamelCase()}!");

                switch (selectedHeroChoice)
                {
                    case HeroChoice.Attack:
                        HeroAttack(hero, monster);
                        break;
                    case HeroChoice.Heal:
                        HeroHeal(hero);
                        break;
                    case HeroChoice.DefensePotion:
                        HeroPotion(hero, monster);
                        break;
                    //case HeroChoice.Fireball:
                    //    HeroFireball(hero);
                    //    break;
                }

                if (monster.Health <= 0)
                {
                    break;
                }

                Console.WriteLine($"It's {monster.Name}'s turn!\n");

                Random monsterRnd = new Random();
                var monsterChoice = monsterRnd.Next(1, 4); // change 4 to 5 for fireball
                var selectedMonsterChoice = (MonsterChoice) monsterChoice;
                Console.WriteLine($"Monster chose to {selectedMonsterChoice.ToString().ConvertToCamelCase()}!");

                switch (selectedMonsterChoice)
                {
                    case MonsterChoice.Attack:
                        MonsterAttack(monster, hero);
                        break;
                    case MonsterChoice.Heal:
                        MonsterHeal(monster);
                        break;
                    case MonsterChoice.DefensePotion:
                        MonsterPotion(monster);
                        break;
                    //case MonsterChoice.Fireball:
                    //    MonsterFireball(monster);
                    //    break;
                }

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

        public int GetHeroAttackValue()
        {
            Random rndAttack = new Random();
            var attackValue = rndAttack.Next(7, 31);
            return attackValue;
        }

        public void HeroAttack(Hero hero, Monster monster)
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

        public void HeroHeal(Hero hero)
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

        public void HeroPotion(Hero hero, Monster monster)
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

        //public void HeroFireball(Hero hero)
        //{
        //    Console.WriteLine("FIREBALL DOESN'T EXIT YET!\n");
        //}

        public int GetMonsterAttackValue()
        {
            Random rndAttack = new Random();
            var attackValue = rndAttack.Next(4, 26);
            return attackValue;
        }

        public void MonsterAttack(Monster monster, Hero hero)
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

        public void MonsterHeal(Monster monster)
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

        public void MonsterPotion(Monster monster)
        {
            if (monster.Potions <= 0)
            {
                Console.WriteLine($"{monster.Name} tried to use a potion but he was all out!\n");
                monster.PotionsUsed = false;
            }
            else
            {
                monster.Potions--;
                Console.WriteLine($"{monster.Name} blocked your next attack! {monster.Name} now has {monster.Potions} left.\n");
                monster.PotionsUsed = true;
            }
        }

        //public void MonsterFireball(Monster monster)
        //{
        //    Console.WriteLine("FIREBALL DOESN'T EXIT YET!\n");
        //}

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