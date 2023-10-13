// See https://aka.ms/new-console-template for more information
using QuizGame;

Console.WriteLine("Quiz Game...");
var questions = new List<Question>();
var answers = new List<Answer>();
var scores = new Dictionary<string, int>();
SeedQuestionsAndOptions();
StartGame();
void StartGame() {
    Console.WriteLine("Are you ready? We are starting now...");
    Console.WriteLine("Whats your name?");
    var player = Console.ReadLine();
    Console.WriteLine($"Ok {player} lets do this");

    foreach(var item in questions)
    {
        Console.WriteLine(item.QuestionText);
        Console.WriteLine("Please, enter 1,2,3,4");
        
        foreach (var option in item.Options)
        {
            Console.WriteLine($"{option.Id}. {option.Text}");
        }
        var answer=GetSelectedAnswer();
        AddAnswerToList(answer, item);
    }
    int score = GetScore();
    Console.WriteLine($"Nice Try {player}! Your answered well {score} questions...");
   
    UpdateScore(player, score); 
    ShowScores();

    answers = new List<Answer>();
    Console.WriteLine("Do you want to play again?");
    Console.WriteLine("Enter yes to play again or any other key to stop...");

    var playAgain = Console.ReadLine();
    if (playAgain?.ToLower().Trim() == "yes")
    {
        StartGame();
    }
};

string GetSelectedAnswer()
{
    var answer=Console.ReadLine();
    if (answer != null && (answer == "1") || (answer == "2") || (answer == "3") || (answer == "4"))
        return answer;
        else
    {
        Console.WriteLine("There is not a valid option, try again");
        answer = GetSelectedAnswer();
    }
    return answer;
}

void AddAnswerToList(string answer, Question question)
{
    answers.Add(new Answer
    {
        QuestionId = question.Id,
        SelectedOption = GetSelectedOption(answer, question)
    });
}

Option GetSelectedOption(string answer, Question question)
{
    var selectedOption = new Option();
    foreach(var option in question.Options)
    {
        if (option.Id == int.Parse(answer))
            selectedOption = option;
    }
    return selectedOption;
}
void SeedQuestionsAndOptions()
{
    questions.Add(new Question
    {
        Id = 1,
        QuestionText = "Whats is the biggest country on earth?",
        Options = new List<Option>
        {
            new Option {Id=1, Text="Australia"},
            new Option {Id=2,Text="China"},
            new Option {Id=3,Text="Canada"},
            new Option {Id=4,Text="Rusia", isValid=true}
        }
        
    });
    questions.Add(new Question
    {
        Id = 2,
        QuestionText = "What is the country with the greatest population?",
        Options = new List<Option> {
      new Option{Id=1, Text="India"},
      new Option{Id=2, Text="China", isValid=true},
      new Option{Id=3, Text="United States"},
      new Option{Id=4,Text="Indonesia"}
      }
    });
    questions.Add(new Question
    {
        Id = 3,
        QuestionText = "What was the less corrupt country in the world in 2021?",
        Options = new List<Option> {
      new Option{Id=1, Text="Finland"},
      new Option{Id=2, Text="New Zealand"},
      new Option{Id=3, Text="Denmark", isValid=true},
      new Option{Id=4,Text="Norway"}
      }
    });
    questions.Add(new Question
    {
        Id = 3,
        QuestionText = "What was the best country for quality life in 2021?",
        Options = new List<Option> {
      new Option{Id=1, Text="Norway", isValid=true},
      new Option{Id=2, Text="Belgica"},
      new Option{Id=3, Text="Sweden"},
      new Option{Id=4,Text="Switzerland"}
      }
    });
}

int GetScore()
{
    int score = 0;
    foreach (var item in answers)
    {
        if (item.SelectedOption.isValid)
            score++;
    }
    return score;

}

void UpdateScore(string player, int score)
{   bool update = false;
    foreach (var item in scores)
        {
        
        if (item.Key == player)
        {
            scores[item.Key] = score;
            update = true;
        }

        
    }
    if (!update) {
            scores.Add(player, score);
                }
}

void ShowScores()
{
    Console.WriteLine("Scores:");

    foreach (var item in scores)
    {
        Console.WriteLine($"{item.Key}, score: {item.Value}");
    }
}