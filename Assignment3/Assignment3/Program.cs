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
            bool outerAlive = true;
            //printing the initial menu
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***** Arena fighter game ******\n---------------------------------");
            Console.Write("Enter a name for your player: ");
            //the characters name, input from user
            string name = Console.ReadLine();
            //as long as the input name from user isn't valid ask for a valid input name
            while (name.Length == 0 || name == null)
            {
                //print error message and ask user to enter a valid name
                Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine("Please enter a valid name! ");
                Console.ForegroundColor = ConsoleColor.Green;
                name = Console.ReadLine();                
            }

            //random generate a strength and health for the character                       
            int strength = rand.Next(1, 8) + 2;
            int health = rand.Next(1, 8) + 2;
            //create a new character for the game
            Character player = new Character(name, strength, health, false);
            
            //print out the characters information
            //Console.ForegroundColor = ConsoleColor.Cyan; //change color when printing the characters info
            //Console.WriteLine("\n------Your characters information------");

            PrintStatus(player);
            //Console.WriteLine("Name: " + character.Name);
            //Console.WriteLine("Your strength: " + character.Strength);
            //Console.WriteLine("Your health: " + character.Health);
            //Console.WriteLine("Damage : " + character.Damage);
            Console.WriteLine("\nPress any key for generating your opponent...");
            Console.ReadKey();

            //      PrintStatus(character);


            //loop for playing the game more than once if the user wants to
            while (outerAlive)
            {
                
                if(player.battles.Count != 0 && player.isAlive)
                {

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //    PrintStatus(character);

                    Console.WriteLine("------Your characters current information after " + player.battles.Count + " battle------");
                    PrintStatus(player);
                    //Console.WriteLine("Name: " + character.Name);
                    //Console.WriteLine("Your strength: " + character.Strength);
                    //Console.WriteLine("Your health: " + character.Health);
                    //Console.WriteLine("Damage : " + character.Damage);
                    Console.WriteLine("Press any key for generating your opponent...");
                    Console.ReadKey();

                }
                                
                //create the opponent
                int seed = rand.Next(); //seed for generating the opponents name
                InfoGenerator generator = new InfoGenerator(seed); //create a new InfoGenerator for the opponent
                string opponentName = generator.NextFirstName(); //random name for the opponent
                int opponentStrength = rand.Next(1, 8) + 2; //random strength for the opponent
                int opponentHealth = rand.Next(1, 8) + 2; //random health for the opponent

                //create a opponent with created random values
                Character opponent = new Character(opponentName, opponentStrength, opponentHealth,true);
                
                //Print out the opponents information
                //Console.ForegroundColor = ConsoleColor.Yellow; //change color when printing opponents info
                //Console.WriteLine("\n-----Your opponents information ------");
                PrintStatus(opponent);
                //Console.WriteLine("Name: " + opponent.Name);
                //Console.WriteLine("Opponents strength: " + opponent.Strength);
                //Console.WriteLine("Opponents health: " + opponent.Health);
                //Console.WriteLine("Damage : " + opponent.Damage);
                Console.WriteLine("\nPress any key for starting a battle...");
                Console.ReadKey();
                
                //create a new battle
                Battle battle = new Battle(player, opponent);
                //set the number of rounds in the battle 
                battle.roundNumber = 1;

                //as long as either the character or the opponent is still alive, keep rolling the dice
                while (battle.Character.isAlive && battle.Opponent.isAlive)
                {

                    Console.Clear();

                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.WriteLine("\n------Your characters information------");
                    PrintStatus(player);
                    //Console.WriteLine("Name: " + character.Name);
                    //Console.WriteLine("Strength: " + character.Strength);
                    //Console.WriteLine("Health: " + character.Health);
                    //Console.WriteLine("Damage : " + character.Damage);
                 //   Console.WriteLine("Press any key for generating your opponent...");
                //    Console.ReadKey();


                    //Print out the opponents information
                    //Console.ForegroundColor = ConsoleColor.Yellow; //change color when printing opponents info
                    //Console.WriteLine("\n-----Your opponents information ------");
                    PrintStatus(opponent);
                    //Console.WriteLine("Name: " + opponent.Name);
                    //Console.WriteLine("Strength: " + opponent.Strength);
                    //Console.WriteLine("Health: " + opponent.Health);
                    //Console.WriteLine("Damage : " + opponent.Damage);

                    
                    //change the color for the round
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("\n****** Round number: " + battle.roundNumber+ " ******");
                    Console.WriteLine("-------------------------------");
                    //create a new round
                    Round round = new Round();

                    //the character rolls the dice, random integer between 1 and 6. Add the roll to the round.
                    round.PlayerRoll = rand.Next(1, 6);
                    //calculate the characters total strength
                    int playerTotalStrength = battle.Character.Strength + round.PlayerRoll;
                    round.PlayerTotal = playerTotalStrength;
                   //          Console.WriteLine(battle.Character.Name + " rolled a " + round.CharacterRoll + " gives a total strength of: " + characterTotalStrength);

                    Console.WriteLine(battle.Character.Name + " rolled a " + round.PlayerRoll + " => " +battle.Character.Strength + " + " + round.PlayerRoll + " = " + playerTotalStrength);

                    //the opponent rolls the dice, random integer between 1 and 6. Add the roll to the round.
                    round.OpponentRoll = rand.Next(1, 6);
                    //calculate the opponents total strength
                    int opponentTotalStrength = battle.Opponent.Strength + round.OpponentRoll;
                    round.OpponentTotal = opponentTotalStrength;
                   //            Console.WriteLine(battle.Opponent.Name + " rolled a " + round.OpponentRoll + " gives a total strength of: " + opponentTotalStrength);

                    Console.WriteLine(battle.Opponent.Name + " rolled a " + round.OpponentRoll + " => " + battle.Opponent.Strength + " + " + round.OpponentRoll + " = " + opponentTotalStrength);


                    //the opponent won this round
                    if (opponentTotalStrength > playerTotalStrength)
                    {
                        //    Console.ForegroundColor = ConsoleColor.Yellow;


                        //     Console.WriteLine("\nThe opponent " + battle.Opponent.Name + " won this round");

                        round.NameOfWinner = battle.Opponent.Name;
                        Console.WriteLine("\nThe opponent " + battle.Opponent.Name + " won this round and will deal damage to " + battle.Character.Name +  " with " + opponent.Damage );




                        //     Console.ForegroundColor = ConsoleColor.Magenta;

                        //recalculate the characters health after the roll
                        battle.Character.Health = battle.Character.Health - battle.Opponent.Damage;

                        //the character is dead... 
                        if (battle.Character.Health <= 0)
                        {
                            battle.Character.isAlive = false;
                            //    Console.WriteLine("Character is alive " + battle.Character.isAlive);
                                                      
                            Console.WriteLine("Sorry you lost this battle....");

                        }
                        else
                        {
                            //      PrintStatus(character);
                            //      PrintStatus(opponent);
                            //    Console.WriteLine("Your characters health after the round: " + battle.Character.Health);

                            Console.WriteLine("Press any key for starting the next round...");
                            Console.ReadKey();

                        }


                    }
                    else if (opponentTotalStrength < playerTotalStrength)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        //        Console.WriteLine("\nThe character " + battle.Character.Name + " won this round");

                        round.NameOfWinner = battle.Character.Name;

                        Console.WriteLine("\nThe player " + battle.Character.Name + " won this round and will deal damage to "+battle.Opponent.Name +  " with " + player.Damage);







                        //       PrintStatus(character);
                        //       PrintStatus(opponent);

                        Console.ForegroundColor = ConsoleColor.Magenta;

                        //recalculate the opponents health after the roll
                        battle.Opponent.Health = battle.Opponent.Health - battle.Character.Damage;


                        if (battle.Opponent.Health <= 0)
                        {
                            battle.Opponent.isAlive = false;
                      //      Console.WriteLine("Opponent is alive " + battle.Opponent.isAlive);
                            Console.WriteLine("Congratulations, you won over your opponent " + battle.Opponent.Name);

                        }
                        else
                        {
                            //  Console.WriteLine("The opponents health after the round: " + battle.Opponent.Health);

                            Console.WriteLine("Press any key for starting the next round...");
                            Console.ReadKey();

                        }


                    }
                    else
                    {
                        Console.WriteLine("It's a draw!");
                        round.NameOfWinner = "Draw";
                        Console.WriteLine("Press any key for starting the next round...");
                        Console.ReadKey();
                    }



                    battle.rounds.Add(round);
                   //TODO:: har denna hamnat rätt??
                    battle.roundNumber++;

                    Console.ReadKey();

                    //either the character or the opponent is dead print out the rolls foreach round

                    //TODO:: add the battle to the list for the character
                    if (battle.Character.isAlive == false || battle.Opponent.isAlive == false)
                    {

                        player.battles.Add(battle);
                        Console.WriteLine("Battle list " + player.battles.Count);

                       

                        
                        if (battle.rounds.Count != 0)
                        {
                            foreach (var item in battle.rounds)
                            {
                                
                                Console.WriteLine("Characterroll Item: " + item.PlayerRoll);
                                Console.WriteLine("Opponentroll item: " + item.OpponentRoll);


                            }



                        }
                    }
                    else
                    {
                        Console.WriteLine("Press any key for next round...");

                    }

                }

                Console.Write("Do you want to play again, (y) for yes and (n) for no: ");

                string choice = Console.ReadLine();


                if (choice == "n")
                {
                    outerAlive = false;

                    //TODO:: print the battle log

                    foreach (var item in player.battles)
                    {

                        Console.WriteLine("Player: " +item.Character.Name);
                        Console.WriteLine("Opponent: " +item.Opponent.Name);
                        Console.WriteLine("Roundnumber: "+item.roundNumber);
                        Console.WriteLine("Battle rounds antal: " +item.rounds.Count);

                        int i = 1;
                        foreach (var r in item.rounds)
                        {
                            
                            Console.WriteLine("-----Round "+ i);
                            Console.WriteLine("Player roll " + r.PlayerRoll);
                            Console.WriteLine("Player total: " +r.PlayerTotal);
                            Console.WriteLine("Opponent roll " + r.OpponentRoll);
                            Console.WriteLine("Opponent total: " +r.OpponentTotal);
                            Console.WriteLine("Who won " + r.NameOfWinner);
                            i++;

                        }



                    }
                

                }
                else
                {
                    outerAlive = true;
                }




                Console.ReadKey();
            }


        }



        /// <summary>
        /// A method for printing the characters informtion
        /// </summary>
        /// <param name="tempCharacter">the character who will be printed</param>
        public static void PrintStatus(Character tempCharacter)
        {

            //       Console.WriteLine("In printmethod");
            //       Console.ForegroundColor = ConsoleColor.Cyan; //change color when printing the characters info
            //        Console.WriteLine("\n------Your characters information------");

            if (!tempCharacter.IsOpponent)
            {
                Console.ForegroundColor = ConsoleColor.Cyan; //change color when printing the characters info
                Console.WriteLine("\n------Your players information------");


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow; //change color when printing the characters info
                Console.WriteLine("\n------Your opponents information------");

            }
            Console.WriteLine("Name: " + tempCharacter.Name);
            Console.WriteLine("Strength: " + tempCharacter.Strength);
            Console.WriteLine("Health: " + tempCharacter.Health);
            Console.WriteLine("Damage : " + tempCharacter.Damage);
      //      Console.WriteLine("Press any key for generating your opponent...");
      //      Console.ReadKey();

        }

    }
}
