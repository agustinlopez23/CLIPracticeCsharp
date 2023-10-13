Console.WriteLine("Rock Paper Scissors");

while (true)
{
    Console.WriteLine("Are you ready");
    Console.WriteLine("Lets Start!!!!");
    var selectedChoice = SelectedChoice();
    var yourChoice = char.Parse(selectedChoice);

    Console.WriteLine($"You selected {yourChoice}");

    var opponentChoice = GetOpponentChoice();

    Console.WriteLine($"I choose {opponentChoice}");

    DecideWinner(opponentChoice, yourChoice);

    Console.WriteLine("Do you want to play Again?");
    Console.WriteLine("Enter Yes to play Again or any other key to stop...");

    var playAgain = Console.ReadLine();
    if (playAgain?.ToLower() == "yes")
        continue;
    else
    break;
}

string SelectedChoice()
{
    Console.WriteLine("Choose R, P, or S: [R]ock, [P]aper, [S]cissors:");
    var selectedChoice = Console.ReadLine();
    selectedChoice?.ToLower();
    if (selectedChoice?.ToLower() != "r" && selectedChoice?.ToLower() != "p" && selectedChoice?.ToLower() != "s")
    {
        Console.WriteLine("Please, select only one letter: R, P or S");
        selectedChoice = SelectedChoice();
    }
    return selectedChoice;
}

char GetOpponentChoice()
{
    char[] options = new char[] { 'R', 'P', 'S' };
    Random random = new Random();
    int randomIndex = random.Next(0,options.Length);
    return options[randomIndex];
}

void DecideWinner(char opponentChoice,char yourChoice)
    {
    bool equal = char.ToUpperInvariant(yourChoice) == char.ToUpperInvariant(opponentChoice);
    if (equal)
    {
        Console.WriteLine("Tie!");
        return;
    }
   
    switch (yourChoice)
        {
            case 'R':
            case 'r':
                if (opponentChoice == 'P')
                    Console.WriteLine("Paper beats Rock, I win!");
                else if (opponentChoice == 'S')
                    Console.WriteLine("Rock beats Scissors, You win");
                break;
            case 'S':
            case 's':
                if (opponentChoice == 'P')
                    Console.WriteLine("Scissors beats Paper, You win!");
                else if (opponentChoice == 'R')
                    Console.WriteLine("Rock beats Scissors, I win");
                break;
            case 'P':
            case 'p':
                if (opponentChoice == 'S')
                    Console.WriteLine("Scissors beats Paper, I win!");
                else if (opponentChoice == 'R')
                    Console.WriteLine("Paper beats Rock, You win!");
                break;
            default:
                break;
        }
    

}