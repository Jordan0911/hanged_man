namespace hanged_man
{
    internal class Program
 {
     static Random roll = new Random();
     static string Word_chooser(string[] sports, string[] war,string[] animals,int difficulty)
     {
         string chosen_word = "";
         int chosen_argument = roll.Next(1, 4);

         if (chosen_argument == 1)
         {
             chosen_word = sports[difficulty - 1];
         }
         else if (chosen_argument == 2)
         {
             chosen_word = war[difficulty - 1];
         }
         else
         {
             chosen_word = animals[difficulty - 1];
         }
         return chosen_word;
     }
    
     static void Main(string[] args)
     {
         char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
         string[] sports = { "soccer", "Basketball", "javelin" },
         war = { "soldier", "drone", "icbm" },
         animals = { "dog", "werehog", "cockroach" };
      
         char guess = ' ';
         bool win = false,letter_found=false; 
         int difficulty = 0,chosen_argument=0,tries=0;
         string chosen_word = "",decision="";
         Console.WriteLine("insert difficulty ");
         difficulty = Convert.ToInt32(Console.ReadLine());
         chosen_word = Word_chooser(sports,war,animals,difficulty);
         char[] censured_word = new char[chosen_word.Length];
        
         for (int i = 0; i < chosen_word.Length; i++)
         {
             censured_word[i] = '_';
         }
         while (win == false)
         {
             letter_found = false;
             Console.WriteLine(censured_word);
             Console.WriteLine("insert your guess");
             guess=Convert.ToChar(Console.ReadLine());
             for (int i = 0;i < chosen_word.Length; i++)
             {
                 if (guess == chosen_word[i])
                 {
                     censured_word[i]= guess;
                     letter_found=true;

                 }
             }
             if(letter_found == false)
             {
                 tries--;
                 Console.WriteLine($"you guessed wrong, you have {tries} tries left");
             }
             Console.WriteLine(censured_word);
             Console.WriteLine("Do you wish to try and guess the word?");
             decision=Console.ReadLine();
         }


     }
 }
}
