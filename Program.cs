using JeuCours.World;
using JeuCours.Living;
using JeuCours.Interfaces;

namespace World
{
    using System;
    using JeuCours.Living;

    class Program
    {
        static void Main(string[] args)
        {
            Character player = new Character("Player", 100, 10, 5,
                                                new Weapon("Sword", 5));
            IEnemy[] enemies = new Enemy[] {
                new Enemy("Goblin", 50, 5, 2),
                new Enemy("Troll", 80, 8, 4),
                new Enemy("Dragon", 200, 20, 10)
            };
            int currentEnemyIndex = 0;
            bool gameOver = false;

            Console.WriteLine("Welcome to the RPG game! You will face three enemies with different strengths and weaknesses. You have a sword," +
                                " a bow, and a wand at your disposal, and you also know how to cast a heal spell and a fireball spell. Good luck!");

            while (!gameOver)
            {
                Console.WriteLine("Your health: " + player.Health);
                Console.WriteLine("Enemy health: " + enemies[currentEnemyIndex].Health);

                Console.Write("Choose an action: (1) Attack, (2) Cast Spell, (3) Switch Weapon, (4) Run Away: ");
                int.TryParse(Console.ReadLine(), out int playerAction);
                switch (playerAction)
                {
                    case 1:
                        player.AttackEnemy(enemies[currentEnemyIndex]);
                        break;
                    case 3:
                        Console.Write("Choose a weapon: ");
                        Console.Write("(1) Sword ");
                        Console.Write("(2) Bow ");
                        Console.Write("(3) Wand ");
                        Console.WriteLine();
                        int.TryParse(Console.ReadLine(), out int weaponIndex);
                        switch (weaponIndex -1)
                        {
                            case 0:
                                player.EquippedWeapon = new Weapon("Sword", 5);
                                break;
                            case 1:
                                player.EquippedWeapon = new Weapon("Bow", 7);
                                break;
                            case 2:
                                player.EquippedWeapon = new Weapon("Wand", 3);
                                break;
                            default:
                                Console.WriteLine("This weapon doesn't exist you foul !");
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("You run away!");
                        gameOver = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                if (enemies[currentEnemyIndex].IsDead())
                {
                    Console.WriteLine("You defeated the " + enemies[currentEnemyIndex].Name + "!");
                    currentEnemyIndex++;
                    if (currentEnemyIndex >= enemies.Length)
                    {
                        Console.WriteLine("Congratulations! You won the game!");
                        gameOver = true;
                    }
                    else
                    {
                        Console.WriteLine("You encounter a " + enemies[currentEnemyIndex].Name + "!");
                    }
                }
                else
                {
                    enemies[currentEnemyIndex].AttackCharacter(player);
                    if (player.IsDead())
                    {
                        Console.WriteLine("You were defeated by the " + enemies[currentEnemyIndex].Name + "! Game over!");
                        gameOver = true;
                    }
                }
            }
        }
    }
}

