using System;
using System.Linq;


namespace QuizMasterChallenge
{
    internal class Program
    {
        private class Question
         {
            public string question {  get; set; }
            public string correctAnswer { get; set; }
            public bool result { get; set; }

            string UserAnswer;
            public string userAnswer 
            {
                get
                {
                    return UserAnswer;
                }
            set
                {
                    UserAnswer = value;
                    result = (UserAnswer==correctAnswer);
                }
            }
            public Question(string question, string correctAnswer)
            {
                this.question = question;
                this.correctAnswer = correctAnswer.ToLower();  
            }
         }
        static List<Question> generateQuestions()
        {
            List <Question> Questions= new List <Question>();
            Questions.Add(new Question("What is the most well-known Sunnah practiced during the first nine days of Dhul-Hijjah?", "Fasting"));                 
            Questions.Add(new Question("What is the term for the imaginary line that divides the Earth into Northern and Southern Hemispheres?", "Equator"));
            Questions.Add(new Question("What is the world most populated country?", "China"));
            Questions.Add(new Question("What is the world smallest country?", "Vatican City"));
            Questions.Add(new Question("Which vitamin is essential for healthy vision?", "A"));
            Questions.Add(new Question("What term describes persistent sadness and lack of interest?", "Depression"));
            Questions.Add(new Question("Which hormone is known as the “love hormone”?", "Oxytocin"));
            Questions.Add(new Question("What type of exercise improves cardiovascular health?", "Aerobic"));
            Questions.Add(new Question("Which sense is most closely linked to memory?", "Smell"));
            Questions.Add(new Question("What is the largest organ in the human body?", "Skin"));
       
            return Questions;
        }
        static void StartQuiz()
        {
            
            int finalScore = 0;
            int result;
            List<Question> questions = generateQuestions();
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine(questions[i].question);
                //handle the error
                string answer= Console.ReadLine();

                while (string.IsNullOrEmpty(answer)|| answer.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    answer = Console.ReadLine();
                }

                questions[i].userAnswer = answer.ToLower();

                if (questions[i].result)
                {
                    finalScore++;
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine("Correct\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Wrong");
                    Console.ResetColor();
                    Console.Write(" the answer is ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{questions[i].correctAnswer.ToUpper()}\n\n");
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Your Score is {finalScore}/10");
            Console.ResetColor();

        }
        static void Main(string[] args)
        {
            try
            {
                StartQuiz();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("The exam is finished");
            }
        }
    }
}