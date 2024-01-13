//Allan Foote
//Building a Dice Rolling game that allows the user to determine how many tmie a pair of die are tossed and displays the frequency at which a certain number is landed on
using System;

namespace DiceRollingSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Welcome user and grab how many rolls they would like to roll
            System.Console.WriteLine("Welcome to the dice throwing simulator!");
            System.Console.Write("How many dice rolls would you like to simulate? ");

            //turn number of rolls entered into an actual number
            int numberOfRolls = int.Parse(System.Console.ReadLine());

            //calling the diceroller class
            DiceRoller roller = new DiceRoller();
            int[] results = roller.RollDice(numberOfRolls);

            //display ending result saying
            System.Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
            System.Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            System.Console.WriteLine($"Total number of rolls = {numberOfRolls}.");

            //logic to determine and print out the histogram 
            for (int i = 2; i <= 12; i++)
            {
                System.Console.Write($"{i}: ");
                int percent = results[i - 2] * 100 / numberOfRolls;
                System.Console.WriteLine(new String('*', percent));
            }


            //end game
            System.Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
        }
    }
}

namespace DiceRollingSimulator
{
    public class DiceRoller
    {
        private Random random = new Random();

        public int[] RollDice(int numberOfRolls)
        {
            int[] counts = new int[11];

            //actually rolling the dice
            for (int i = 0; i < numberOfRolls; i++)
            {
                int rollOne = random.Next(1, 7);
                int rollTwo = random.Next(1, 7);
                int sum = rollOne + rollTwo;

                counts[sum - 2]++;
            }

            return counts;
        }
    }
}