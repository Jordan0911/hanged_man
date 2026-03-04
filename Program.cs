namespace hanged_man
{
    internal class Program
 {
     static bool Game()
     {
         string checker = "";
         char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
         string[] sports = { "ball", "goal", "team", "run", "referee", "quarterback", "dribble", "tournament", "decathlon", "velodrome", "puck", "stalemate", "steeplechase", "zamboni", "equestrian" };
         string[] war = { "tank", "boot", "rank", "base", "patrol", "ordnance", "artillery", "regiment", "ordnance", "logistics", "plate", "ammunition", "reconnaissance", "surveillance", "countermeasure" };
         string[] animals = { "cat", "dog", "fish", "bear", "rabbit", "dolphin", "giraffe", "penguin", "platypus", "chameleon", "axolotl", "Capybara", "proboscis", "aardvark", "quetzalcoaltus" };
         string[] chosen_stuff = new string[2];
         char guess = ' ';
         bool win = false,letter_found=false,end=false; 
         int difficulty = 0,tries=5;
         string chosen_word = "",decision="",chosen_argument="",used_letters="";
         Console.WriteLine("insert difficulty ");
         difficulty = Convert.ToInt32(Console.ReadLine());
         chosen_stuff= Word_chooser(sports,war,animals,difficulty);
         chosen_word = chosen_stuff[0];
         chosen_argument = chosen_stuff[1];
         char[] censured_word = new char[chosen_word.Length];
        
         for (int i = 0; i < chosen_word.Length; i++)
         {
             if (i == 0 || i == chosen_word.Length - 1)
                 censured_word[i] = chosen_word[i];
             else
                 censured_word[i] = '_';
         }
         Console.WriteLine($"the theme is: {chosen_argument}");
         while (end == false)
         {
             if (tries == 0)
             {
                 Console.WriteLine($"You lost, the word was {chosen_word}");
                 return false;
             }
             letter_found = false;
             Console.WriteLine(censured_word);
             checker = string.Join("",censured_word);
             if (checker== chosen_word)
             {
                 Console.WriteLine($"You've guessed the word {chosen_word}, good grief.");


                 return true;
             }
             Console.WriteLine($"you used the letters {used_letters} ");
             Console.WriteLine("insert your guess");
             guess=Convert.ToChar(Console.ReadLine());
             for (int i = 0;i < chosen_word.Length; i++)
             {
                 if (guess == chosen_word[i])
                 {
                     Console.WriteLine("Good guess bromium");
                     used_letters += " " + guess;
                     censured_word[i]= guess;
                     letter_found=true;

                 }
             }
             if(letter_found == false)
             {
                 tries--;
                 Console.WriteLine($"you guessed wrong, you have {tries} tries left");
                 used_letters += " " +guess;
                 
             }
             Console.WriteLine(censured_word);
             if (tries > 0)
             {
                 Console.WriteLine("Do you wish to try and guess the word?");
                 decision=Console.ReadLine();
                 if (decision == "yes")
                 {
                     Console.WriteLine("insert your guess then ");
                     decision = Console.ReadLine();
                     if (decision == chosen_word)
                     {
                         Console.WriteLine("Good guess my man");
                         return true;
                     }
                     if(decision != chosen_word)
                     {
                         tries--;
                         Console.WriteLine($"better luck next time young buck, you have {tries} tries left");
                     }
                 }    
             }
            
            
         }

         return false;
     }
     static Random roll = new Random();
     static string[] Word_chooser(string[] sports, string[] war,string[] animals,int difficulty)
     {
         
         string[] arguments = { "sports", "war", "animals" };
         string[] result = new string[2];
         string chosen_word = "";
         int chosen_argument = roll.Next(0, 3),a=0;
         if (difficulty == 1)
         {
             a = roll.Next(0, 6);
         }
         if (difficulty == 2)
         {
             a = roll.Next(6, 11);
         }
         if (difficulty == 3)
         {
             a = roll.Next(10, 15);
         }
         if (chosen_argument == 0)
         {
             chosen_word = sports[a];
         }
         else if (chosen_argument == 1)
         {
             chosen_word = war[a];
         }
         else
         {
             chosen_word = animals[a];
         }

         result[0] = chosen_word;
         result[1] = arguments[chosen_argument];
         return result;
     }
    
     static void Main(string[] args)
     {
         string choice;
         bool end = false;
         while (end == false)
         {
             Console.WriteLine("You ready to play? Of course you are. Lets roll!");
             if (Game() == true)
             {
                 Console.WriteLine("wanna play again?");
                 choice = Console.ReadLine();
                 if (choice == "no")
                 {
                     Console.WriteLine("ookay...(╥﹏╥)");
                     end = true;
                 }
                 else
                 {
                     Console.WriteLine("AAAAAIGHHHT BEEEEET");
                 }
                 
             }
         }
     }
 }
}
