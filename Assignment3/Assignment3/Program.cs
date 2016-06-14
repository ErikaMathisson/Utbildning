using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            Console.WriteLine("Arena fighter game ");
            Console.WriteLine("---------------------------------");
            Console.Write("Enter a name for your character: ");

            //todo validation of name
            string name = Console.ReadLine();
            //random generate a strength for the character                       
            int strength = rand.Next(1, 8) + 2;
            //random generate a health for the the character
            int health = rand.Next(1, 8) + 2;
            //create a new character for the game
            Character character = new Character(name, strength, health);
            
            //create the opponent
            int seed = rand.Next(); //seed for generating the opponents name
            InfoGenerator generator = new InfoGenerator(seed); //create a new InfoGenerator for the opponent
            string opponentName = generator.NextFirstName(); //random name for the opponent
            int opponentStrength = rand.Next(1, 8) + 2;
            int opponentHealth = rand.Next(1, 8) + 2;

            //create a opponent
            Character opponent = new Character(opponentName, opponentStrength, opponentHealth);

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("------Your characters information------");
            Console.WriteLine("Name: " +character.Name);
            Console.WriteLine("Your strength: "+character.Strength);
            Console.WriteLine("Your health: " +character.Health);
            Console.WriteLine("Damage : " +character.Damage);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n-----Your opponents information ------");
            Console.WriteLine("Name: " + opponent.Name);
            Console.WriteLine("Opponents strength: " + opponent.Strength);
            Console.WriteLine("Opponents health: " + opponent.Health);
            Console.WriteLine("Damage : " + opponent.Damage);


            Battle battle = new Battle(character, opponent);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("The first round ");


            Console.WriteLine("Character is alive " + battle.Character.isAlive);
            Console.WriteLine("Opponent is alive " +battle.Opponent.isAlive);

            while(battle.Character.isAlive && battle.Opponent.isAlive)
                {

                Round round = new Round();

                //characterRoll
                round.CharacterRoll = rand.Next(1, 6);
                Console.WriteLine("Characterroll " + round.CharacterRoll);

                int characterTotalStrength = battle.Character.Strength + round.CharacterRoll;

                Console.WriteLine("CharacterTotalStrength: " + characterTotalStrength);

                round.OpponentRoll = rand.Next(1, 6);
                Console.WriteLine("Opponentroll " + round.OpponentRoll);
                int opponentTotalStrength = battle.Opponent.Strength + round.OpponentRoll;

                Console.WriteLine("OpponentTotalStrength: " + opponentTotalStrength);

                if (opponentTotalStrength > characterTotalStrength)
                {

                    Console.WriteLine("The opponent won this round");
                    Console.WriteLine("Health before damage " + battle.Character.Health);
                    battle.Character.Health = battle.Character.Health - battle.Opponent.Damage;
                    Console.WriteLine("Health after damage " + battle.Character.Health);

                    if (battle.Character.Health <0)
                    {
                        battle.Character.isAlive = false;
                        Console.WriteLine("Character is alive " + battle.Character.isAlive);
                        Console.WriteLine("Opponent is alive " + battle.Opponent.isAlive);



                    }


                }
                else if (opponentTotalStrength < characterTotalStrength)
                {

                    Console.WriteLine("The character won this round");
                    Console.WriteLine("Health before damage " + battle.Opponent.Health);
                    battle.Opponent.Health = battle.Opponent.Health - battle.Character.Damage;
                    Console.WriteLine("Health after damage " + battle.Opponent.Health);

                    if (battle.Opponent.Health < 0)
                    {
                        battle.Opponent.isAlive = false;
                        Console.WriteLine("Opponent is alive " + battle.Opponent.isAlive);



                    }


                }
                else
                {
                    Console.WriteLine("It's a draw!");

                }



                battle.rounds.Add(round);

                Console.WriteLine("Press any key for next round...");

                Console.ReadKey();

                //either the character or the opponent is dead print out the rolls foreach round
                if (battle.Character.isAlive == false || battle.Opponent.isAlive == false)
                {
                    if (battle.rounds.Count != 0)
                    {
                        foreach (var item in battle.rounds)
                        {
                            Console.WriteLine("Characterroll Item: " + item.CharacterRoll);
                            Console.WriteLine("Opponentroll item: " + item.OpponentRoll);


                        }

                    }
                }

            }
            Console.ReadKey();
        }


    }
}
