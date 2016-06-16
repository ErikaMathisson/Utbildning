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
            Console.WriteLine("***** Arena fighter game ******\n---------------------------------");
            Console.Write("Enter a name for your player: ");
            //the characters name, input from user
            string name = Console.ReadLine();
            //as long as the input name from user isn't valid ask for a valid input name
            while (name.Length == 0 || name == null)
            {
                //print error message and ask user to enter a valid name
                  Console.WriteLine("Please enter a valid name! ");
                  name = Console.ReadLine();
            }

            //random generate a strength and health for the character                       
            int strength = rand.Next(1, 8) + 2;
            int health = rand.Next(1, 8) + 2;
            //create a new character for the game
            Character player = new Character(name, strength, health, false);        
            
            //loop for playing the game more than once if the user wants to
            while (outerAlive)
            {
                Console.Clear();

                //print information about the player
                PrintStatus(player);
                Console.WriteLine("\nPress any key for generating your opponent...");
                Console.ReadKey();

                //create the opponent
                int seed = rand.Next(); //seed for generating the opponents name
                InfoGenerator generator = new InfoGenerator(seed); //create a new InfoGenerator for the opponent
                string opponentName = generator.NextFirstName(); //random name for the opponent
                int opponentStrength = rand.Next(1, 8) + 2; //random strength for the opponent
                int opponentHealth = rand.Next(1, 8) + 2; //random health for the opponent

                //create a opponent with created random values
                Character opponent = new Character(opponentName, opponentStrength, opponentHealth, true);
               
                //Print out the opponents information
                PrintStatus(opponent);
                //start a new battle
                Console.WriteLine("\nPress any key for starting a battle...");
                Console.ReadKey();

                //create a new battle
                Battle battle = new Battle(player, opponent);
                //set the number of rounds in the battle 
                battle.roundNumber = 1;

                //as long as either the character or the opponent is still alive, keep rolling the dice
                while (battle.Player.isAlive && battle.Opponent.isAlive)
                {
                    Console.Clear();
                    //print the current status for the player before each new round                   
                    PrintStatus(player);
                    //print the current status for the opponent before each new round
                    PrintStatus(opponent);                    
                    Console.WriteLine("\n-------------------------------");
                    Console.WriteLine("Round number: " + battle.roundNumber);
                    Console.WriteLine("-------------------------------\n");
                    //create a new round
                    Round round = new Round();
                    //the character rolls the dice, random integer between 1 and 6. Add the roll to the round.
                    round.PlayerRoll = rand.Next(1, 6);
                    //calculate the characters total strength
                    int playerTotalStrength = battle.Player.Strength + round.PlayerRoll;
                    //set the players total strength to the round
                    round.PlayerTotal = playerTotalStrength;
                    //print the roll and total strength for the player                  
                    Console.WriteLine(battle.Player.Name + " rolled a " + round.PlayerRoll + " => " + battle.Player.Strength + " + " + round.PlayerRoll + " = " + playerTotalStrength);

                    //the opponent rolls the dice, random integer between 1 and 6. Add the roll to the round.
                    round.OpponentRoll = rand.Next(1, 6);
                    //calculate the opponents total strength
                    int opponentTotalStrength = battle.Opponent.Strength + round.OpponentRoll;
                    //set the opponents total strength to the round
                    round.OpponentTotal = opponentTotalStrength;
                    //print the roll and the total strength for the opponent                   
                    Console.WriteLine(battle.Opponent.Name + " rolled a " + round.OpponentRoll + " => " + battle.Opponent.Strength + " + " + round.OpponentRoll + " = " + opponentTotalStrength);
                                      
                    //check who won the round and print information accordingly
                    //the opponent won this round
                    if (opponentTotalStrength > playerTotalStrength)
                    {
                        //set the name of the winner to the round
                        round.NameOfWinner = battle.Opponent.Name;
                        Console.WriteLine("\nThe opponent " + battle.Opponent.Name + " won this round and will deal damage to " + battle.Player.Name + " with " + opponent.Damage + "\n");

                        //recalculate the characters health after the roll
                        battle.Player.Health = battle.Player.Health - battle.Opponent.Damage;
                        //check if the player still has any health left and print information accordingly
                        //the player is dead... 
                        if (battle.Player.Health <= 0)
                        {
                            Console.ReadKey();
                            //set information that the player has no health left => dead
                            battle.Player.isAlive = false;
                            Console.Clear();
                            //print the current status for the player
                            PrintStatus(player);
                            Console.WriteLine("Sorry you lost this battle, you are dead....\n");
                        }
                        else
                        {
                            //the player is still alive start a new round                            
                            Console.WriteLine("Press any key for starting the next round...");
                            Console.ReadKey();
                        }
                    }
                    //the player won this round
                    else if (opponentTotalStrength < playerTotalStrength)
                    {
                        //set the name of the winner to the round and print information to the user
                        round.NameOfWinner = battle.Player.Name;
                        Console.WriteLine("\nThe player " + battle.Player.Name + " won this round and will deal damage to " + battle.Opponent.Name + " with " + player.Damage + "\n");

                        //recalculate the opponents health after the roll
                        battle.Opponent.Health = battle.Opponent.Health - battle.Player.Damage;

                        //check if the opponent still has any health left and print information accordingly
                        //the opponent is dead... 
                        if (battle.Opponent.Health <= 0)
                        {

                            Console.ReadKey();
                            //set the information that the opponent hasn't any health left aka is dead
                            battle.Opponent.isAlive = false;
                            Console.Clear();
                            //print the last status for the opponent
                            PrintStatus(opponent);
                            Console.WriteLine("\nCongratulations, your opponent is dead, you win!");
                            //add a score to the player after the win                    
                            player.Score = player.Score + Character.ScoreWin;
                        }
                        else
                        {
                            //the opponent still has any health left, start a new round
                            Console.WriteLine("Press any key for starting the next round...");
                            Console.ReadKey();
                        }
                    }
                    //no one won this round, it's a draw. Start a new round...
                    else
                    {
                        Console.WriteLine("It's a draw!\n");
                        //set the information about the draw to the round
                        round.NameOfWinner = "Draw";
                        Console.WriteLine("Press any key for starting the next round...");
                        Console.ReadKey();
                    }

                    //add the round to the battle
                    battle.rounds.Add(round);
                    battle.roundNumber++;

                    //check if either the player or the opponent is dead                                  
                    if (battle.Player.isAlive == false || battle.Opponent.isAlive == false)
                    {
                        //Add the battle to the players battle log
                        player.battles.Add(battle);

                    }
                    else
                    {
                        Console.WriteLine("Press any key for next round...");
                    }
                }

                //the player is still alive, play another game?
                if (battle.Player.isAlive)
                {
                    Console.Write("Do you want to play again, (y) for yes and (n) for no: ");
                    string choice = Console.ReadLine();

                    //check if the user entered a valid option, print error message until the option is valid
                    while (choice != "y" && choice != "n")
                    {
                        Console.WriteLine("Only (y) or (n) is valid option, please try again ");
                        choice = Console.ReadLine();
                    }
                    //the user wants to play again
                    if (choice == "y")
                    {
                        outerAlive = true;
                        Console.WriteLine("Press any key to continue...");                 
                    }
                    //the user don't want to play again, print the battle log and end the game
                    else if (choice == "n")
                    {
                        Console.WriteLine("You didn't want to play again. Press any key to print the battle log!\n");
                        Console.ReadKey();
                        PrintBattleLog(player);
                        outerAlive = false;
                    }

                }
                //the user is dead, the battle log should be printed and the game should end
                else
                {
                    Console.WriteLine("Press any key to print battle log! \n");
                    Console.ReadKey();
                    PrintBattleLog(player);
                    outerAlive = false;
                }
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Method for printing the battlelog after the player died or don't want to play anymore.
        /// </summary>
        /// <param name="player">player whos battlelog will be printed</param>
        private static void PrintBattleLog(Character player)
        {
            //clear the screen and print the battle log
            Console.Clear();
            Console.WriteLine("****** Battle log ******");
            //print information for every battle in the battle log
            foreach (var item in player.battles)
            {
                Console.WriteLine("\n" + item.Player.Name + " --- vs --- " + item.Opponent.Name);
                int i = 1;
                //print every round in each battle
                foreach (var r in item.rounds)
                {
                    Console.WriteLine("\n-----Round " + i + " ---------");
                    Console.WriteLine(item.Player.Name + " rolled " + r.PlayerRoll + " gave total of: " + r.PlayerTotal);
                    Console.WriteLine(item.Opponent.Name + " rolled " + r.OpponentRoll + " gave total of: " + r.OpponentTotal);
                    Console.WriteLine("Who won: " + r.NameOfWinner);
                    i++;
                }
                
                Console.WriteLine("\nPress any key to continue..");
                Console.ReadKey();
                Console.Clear();

            }

            //print the players total score 
            Console.WriteLine("\nYour total score is: " + player.Score);
            //print out wether the player is still alive or not
            if (player.isAlive)
            {
                Console.WriteLine("You are still alive :-) ");
            }
            else
            {
                Console.WriteLine("Unfortunately you are dead... :-( ");
            }

            Console.WriteLine("\nPress any key to continue...");
        }

        /// <summary>
        /// A method for printing the characters informtion
        /// </summary>
        /// <param name="tempCharacter">the character who will be printed</param>
        public static void PrintStatus(Character tempCharacter)
        {
            //determine title of information based on whether the character is opponent or not
            if (!tempCharacter.IsOpponent)
            {
               Console.WriteLine("\n------Your players information------");
            }
            else
            {
                Console.WriteLine("\n------Your opponents information------");
            }
            Console.WriteLine("Name: " + tempCharacter.Name);
            Console.WriteLine("Strength: " + tempCharacter.Strength);
            Console.WriteLine("Health: " + tempCharacter.Health);
            Console.WriteLine("Damage : " + tempCharacter.Damage);

        }

    }
}
