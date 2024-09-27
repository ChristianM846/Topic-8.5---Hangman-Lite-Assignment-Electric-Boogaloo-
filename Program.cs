namespace Topic_8._5___Hangman_Lite_Assignment__Electric_Boogaloo_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word, displayWord, guess, response;
            int incorrect, tempLength, difficulty;
            bool match, done;
            match = false;
            done = false;
            word = "";
            displayWord = "";
            incorrect = 0;
            List<string> lettersGuessed = new List<string>();
            List<string> easyWordList = new List<string>() { "EASY", "SMILE", "AISLE", "THANK", "ABODE", "YES", "HUE", "DOG", "CAT", "FISH", "FORCE"};
            List<string> medWordList = new List<string>() { "MEDIUM", "COMPUTER", "PANCAKES", "AVATAR", "GAMING", "ICEBERG", "MANSION", "PRESSURE", "YOURSELF", "DESKTOP",  };
            List<string> hardWordList = new List<string>() { "ENTERTAINMENT", "AARDVARKS", "FABRICATED", "SUPERCALIFRAGILISTICEXPIALIDOCIOUS", "HIPPOPOTOMONSTROSESQUIPPEDALIOPHOBIA", "HUMUHUMUNUKUNUKUAPUAA", "BEFUDDLED" };
            Random generator = new Random();

            Console.WriteLine("I want to play a game.");
            Console.WriteLine("A game of hangman to be exact!");
            Console.WriteLine();
            Console.WriteLine($"You know the rules: There is a secret word, and you must guess one letter at a time to figure it out");
            Console.WriteLine("You get five wrong guesses before you lose. Let's begin!");
            Console.WriteLine();

            while (!done)
            {
                Console.WriteLine("What difficulty would you like to play?");
                Console.WriteLine();
                Console.WriteLine("1 - Easy (3-5 letters)");
                Console.WriteLine("2 - Medium (6-8 letters)");
                Console.WriteLine("3 - Hard (9+ letters)");

                while (!Int32.TryParse(Console.ReadLine().Trim(), out difficulty) || difficulty <= 0 || difficulty > 3)
                {
                    Console.WriteLine("Please input the number matching your desired difficulty. ");
                }

                if (difficulty == 1)
                {
                    word = easyWordList[generator.Next(0, easyWordList.Count)];
                }
                else if (difficulty == 2)
                {
                    word = medWordList[generator.Next(0, medWordList.Count)];
                }
                else if (difficulty == 3)
                {
                    word = hardWordList[generator.Next(0, hardWordList.Count)];
                }

                tempLength = word.Length;
                displayWord = "";

                while (lettersGuessed.Count > 0)
                {
                    lettersGuessed.RemoveAt(lettersGuessed.Count - 1);
                }

                foreach (char letter in word)
                {
                    displayWord += "_";
                }

                incorrect = 0;
                match = false;

                while (incorrect < 5 && match == false)
                {
                    if (incorrect == 0)
                    {
                        NoIncorrect();
                    }
                    else if (incorrect == 1)
                    {
                        OneIncorrect();
                    }
                    else if (incorrect == 2)
                    {
                        TwoIncorrect();
                    }
                    else if (incorrect == 3)
                    {
                        ThreeIncorrect();
                    }
                    else if (incorrect == 4)
                    {
                        FourIncorrect();
                    }
                    

                    Console.WriteLine($"Current known letters: {displayWord}");
                    Console.WriteLine();
                    Console.WriteLine("Current guessed letters:");

                    foreach (string letter in lettersGuessed)
                    {
                        Console.Write(letter + ", ");
                    }

                    Console.WriteLine();
                    Console.WriteLine($"You have {5 - incorrect} incorrect guesses left");
                    Console.WriteLine();
                    Console.WriteLine("What letter would you like to guess:");
                    guess = Console.ReadLine().ToUpper().Trim();
                    Console.Beep();

                    while (guess == "" || guess.Length > 1 || lettersGuessed.Contains(guess))
                    {
                        Console.WriteLine("I'm sorry, please restrict your guesses to one character at a time and ensure you haven't already guessed it");
                        guess = Console.ReadLine().ToUpper().Trim();
                        Console.Beep();
                    }

                    if (word.Contains(guess))
                    {

                        for (int i = 0; i < tempLength; i++)
                        {
                            if (word[i] == guess[0])
                            {
                                displayWord = displayWord.Remove(i, 1);
                                displayWord = displayWord.Insert(i, guess);
                            }
                        }
                        Console.WriteLine(displayWord);
                        lettersGuessed.Add(guess);
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        Console.Beep();
                        Console.Clear();

                        if (word == displayWord)
                        {
                            match = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"The letter {guess} is not contained within the word.");
                        incorrect++;
                        lettersGuessed.Add(guess);
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadLine();
                        Console.Beep();
                        Console.Clear();
                    }
                }

                if (match)
                {
                    Console.WriteLine($"Congratulations, you found the word. It was {word}!");
                }
                else if (incorrect == 5)
                {
                    FiveIncorrect();
                    Console.WriteLine($"Too bad, you weren't able to find the word. The word this time around was {word}");
                }

                Console.WriteLine("Would you like to play again? (y/n)");
                response = Console.ReadLine().ToLower().Trim();

                while (response != "y" && response != "n")
                {
                    Console.WriteLine("That's not a valid response. Yes or No please.");
                    response = Console.ReadLine().ToLower().Trim();
                }

                if (response == "y")
                {
                    Console.WriteLine("Okay, let's do it! Press ENTER to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (response == "n")
                {
                    Console.WriteLine("Okay, I hope you enjoyed playing. Goodbye!");
                    done = true;
                }
            }
        }
        public static void NoIncorrect()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

        public static void OneIncorrect()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

        public static void TwoIncorrect()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine(" /|   |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

        public static void ThreeIncorrect()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine(" /|\\  |");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

        public static void FourIncorrect()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine(" /|\\  |");
            Console.WriteLine(" /    |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }

        public static void FiveIncorrect()
        {
            Console.WriteLine("  +---+");
            Console.WriteLine("  |   |");
            Console.WriteLine("  O   |");
            Console.WriteLine(" /|\\  |");
            Console.WriteLine(" / \\  |");
            Console.WriteLine("      |");
            Console.WriteLine("=========");
        }
    }
}
