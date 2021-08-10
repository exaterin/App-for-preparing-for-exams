using System;
using System.Collections.Generic;


public class QuestionInfo {
    public string question;
    public string[] answers = new string[4];
    public string correct;
    public bool is_last;
}
class ProcessQuestions {
    public static int skips = 0;
    public static int right_ans = 0;
    public static int number_of_tasks = 0;
    public static int incorrect_ans = 0;
    public static int [] last = {0,0,0,0,0};

    public static string[] text = Tasks.Questions.Split('\n');
    static int number_of_questions = text.Length;

    public static QuestionInfo PrepareTask(char topic) {

        QuestionInfo questionInfo = new QuestionInfo();
        int topic_num = Int32.Parse(topic.ToString());

        List<string> chosen_questions = new List<string>();
        int count = 0;

        for (int i = 0; i < number_of_questions; ++i) {

            if (topic == '0')
                chosen_questions.Add(text[i]);

            else if (text[i][0] == topic) {
                chosen_questions.Add(text[i]);
                ++count;
            }
        }

        string[] chosen_quest = chosen_questions[last[topic_num]].Split(';');

        string correct_answer = chosen_quest[2];

        int[] numbers = { 1, 2, 3, 4 };

        for (int i = numbers.Length - 1; i > 0; --i) {
            int k = new Random().Next(i + 1);
            (numbers[i], numbers[k]) = (numbers[k], numbers[i]);
        }

        questionInfo.question = chosen_quest[1];

        for (int i = 0; i < 4; ++i)
            questionInfo.answers[i] = chosen_quest[numbers[i] + 1];

        questionInfo.correct = correct_answer;

        questionInfo.is_last = last[topic_num] + 1 == count || last[topic_num] + 1 == number_of_questions;

        return questionInfo;
    }

    public static void CorrectAnswer() {
        right_ans += 1;
        number_of_tasks += 1;   
    }

    public static void IncorrectAnswer() {
        incorrect_ans += 1;
        number_of_tasks += 1;
    }
}
