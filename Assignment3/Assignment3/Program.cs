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

            Console.WriteLine("***** Arena fighter game ******");
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
            int opponentStrength = rand.Next(1, 8) + 2; //random strength for the opponent
            int opponentHealth = rand.Next(1, 8) + 2; //random health for the opponent

            //create a opponent with created random value
            Character opponent = new Character(opponentName, opponentStrength, opponentHealth);

            Console.ForegroundColor = ConsoleColor.Cyan; //change color when printing the characters info

            Console.WriteLine("------Your characters information------");
            Console.WriteLine("Name: " + character.Name);
            Console.WriteLine("Your strength: " + character.Strength);
            Console.WriteLine("Your health: " + character.Health);
            Console.WriteLine("Damage : " + character.Damage);

            Console.ForegroundColor = ConsoleColor.Yellow; //change color when printing opponents info
            Console.WriteLine("\n-----Your opponents information ------");
            Console.WriteLine("Name: " + opponent.Name);
            Console.WriteLine("Opponents strength: " + opponent.Strength);
            Console.WriteLine("Opponents health: " + opponent.Health);
            Console.WriteLine("Damage : " + opponent.Damage);

            //create a new battle
            Battle battle = new Battle(character, opponent);
            //set the number of rounds in the battle 
            battle.roundNumber = 1;

            //as long as either the character or the opponent is still alive, keep rolling the dice
            while (battle.Character.isAlive && battle.Opponent.isAlive)
            {
                //change the color for the round
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("-------------------------------");
                Console.WriteLine("\nRound number: " + battle.roundNumber);
                Console.WriteLine("-------------------------------");
                //create a new round
                Round round = new Round();
                
                //the character rolls the dice, random integer between 1 and 6. Add the roll to the round.
                round.CharacterRoll = rand.Next(1, 6);
                //calculate the characters total strength
                int characterTotalStrength = battle.Character.Strength + round.CharacterRoll;
                Console.WriteLine(battle.Character.Name + " rolled a " + round.CharacterRoll + " gives a total strength of: " +characterTotalStrength);

                //the opponent rolls the dice, random integer between 1 and 6. Add the roll to the round.
                round.OpponentRoll = rand.Next(1, 6);
                //calculate the opponents total strength
                int opponentTotalStrength = battle.Opponent.Strength + round.OpponentRoll;
                Console.WriteLine(battle.Opponent.Name + " rolled a " + round.OpponentRoll + " gives a total strength of: " + opponentTotalStrength);

                //the opponent won this round
                if (opponentTotalStrength > characterTotalStrength)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nThe opponent " +battle.Opponent.Name+ " won this round");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                   
                    //recalculate the characters health after the roll
                    battle.Character.Health = battle.Character.Health - battle.Opponent.Damage;
                   
                    //the character is dead... 
                    if (battle.Character.Health <= 0)
                    {
                        battle.Character.isAlive = false;
                        Console.WriteLine("Character is alive " + battle.Character.isAlive);

                        Console.WriteLine("Sorry you lost this battle....");
                  
                    }
                    else
                    {
                        Console.WriteLine("Your characters health after the round: " + battle.Character.Health);
                    }


                }
                else if (opponentTotalStrength < characterTotalStrength)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nThe character " +battle.Character.Name + " won this round");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    
                    //recalculate the opponents health after the roll
                    battle.Opponent.Health = battle.Opponent.Health - battle.Character.Damage;
                  

                    if (battle.Opponent.Health <= 0)
                    {
                        battle.Opponent.isAlive = false;
                        Console.WriteLine("Opponent is alive " + battle.Opponent.isAlive);
                        Console.WriteLine("Congratulations, you won over your opponent " +battle.Opponent.Name);

                    }
                    else
                    {
                        Console.WriteLine("The opponents health after the round: " + battle.Opponent.Health);

                    }


                }
                else
                {
                    Console.WriteLine("It's a draw!");

                }



                battle.rounds.Add(round);


                Console.WriteLine("Press any key for next round...");
                battle.roundNumber++;

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
