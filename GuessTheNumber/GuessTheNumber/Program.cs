// See https://aka.ms/new-console-template for more information
string? player; 
Random random = new Random();
int attemps = 0;
int higuestAttempsScore = 0;
List<int> attempsList = new List<int>();
Console.WriteLine("Guess The Number");
StartGame();
void StartGame()
{
    Console.WriteLine("Hello! Welcome to the game...");
    Console.WriteLine("Whats is your name?");
   
    var randomNumber = random.Next(1, 10);
    player = Console.ReadLine();
    WantToPlay(randomNumber);
}
void WantToPlay(int randomNumber,bool playAgain =false)
{
    if (!playAgain) 
        Console.WriteLine($"Hi {player}, are your ready to play?(Enter Yes/No)");
        else 
        Console.WriteLine($"{player}, do you want to play again?(Enter Yes/No)");
    var wantToPlay = Console.ReadLine();

    switch (wantToPlay?.ToLower())
    {
        case "yes":
            Play(randomNumber);
            break;
        case "no":
            DontPlay();
            break;
        default:
            Console.WriteLine("Thats is not a valid option.");
            WantToPlay(randomNumber);
            break;
    }
}
void Play(int randomNumber)
{
    

    try
    {
        Console.WriteLine("Pick a number between 1 and 10");
        var pickedNumber = Console.ReadLine();
        if (pickedNumber is null) throw new Exception("You need to pick a value.");
        if (int.Parse(pickedNumber) < 1 || int.Parse(pickedNumber) > 10) throw new Exception("Please pick a number between 1 and 10");
        if (int.Parse(pickedNumber) == randomNumber)
        {
            YouGuess();
        }
        else if(int.Parse(pickedNumber) < randomNumber) {
            Console.WriteLine("Try again! The number is higher");
            attemps++;
            Play(randomNumber);
        }else if (int.Parse(pickedNumber) > randomNumber)
        {
            Console.WriteLine("Try again! The number is lower");
            attemps++;
            Play(randomNumber);
        }

    }
    catch(Exception ex)
    {
        Console.WriteLine($"There has been an error: {ex.Message}");
        Play(randomNumber);
    }
}
void DontPlay()
{
    Console.WriteLine("No worries! Have a good one!");
}
void YouGuess()
{
    Console.WriteLine("Nice! You guess the number!");
    attemps++;
    attempsList.Add(attemps);
    if (higuestAttempsScore == 0 || attemps < higuestAttempsScore) 
        higuestAttempsScore = attemps;
    
    Console.WriteLine($"Its has taken you {attemps} to guess the number");
    ShowScore();
    var randomNumber = random.Next(1, 10);
    WantToPlay(randomNumber, true);
}


void ShowScore()
{
    if (higuestAttempsScore == 0)
    {
        Console.WriteLine("There is currently no high score, it´s you for the taking!");
    }
    else
    {
        Console.WriteLine($"The current high score is {higuestAttempsScore}!");
    }
}
