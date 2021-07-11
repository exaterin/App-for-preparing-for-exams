using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

    class ProcessQuestions{

        public static int score = 0;
        public static int skips = 0;
        public static int right_ans = 0;
        public static int number_of_tasks = 0;
        public static int incorrect_ans = 0;

        public static string[] text = Tasks.Questions.Split('\n');

        static int numer_of_questions = text.Length;


        public static string [] PrepeareTask(char topic) {

            string[] choosen_questions = new string[120];
            int count = 0;

            for (int i = 0; i < numer_of_questions; ++i) {
                if (text[i][0] == topic) {
                    choosen_questions[count] = text[i];
                    ++count;
                }
            }

        if (topic == '0')
            choosen_questions = text;

            int random = new Random().Next(0,count);


            string[] choosen_quest = choosen_questions[random].Split(';');

            string correct_answer = choosen_quest[2];

            int[] numbers = { 1, 2, 3, 4 };

        for (int i = 0; i < numbers.Length; ++i) {
            int k = new Random().Next(1, numbers.Length);
            int temp = numbers[i];
            numbers[i] = numbers[k];
            numbers[k] = temp;
        }



            string[] print = { choosen_quest[1], choosen_quest[numbers[0]+ 1], choosen_quest[numbers[1]+ 1], choosen_quest[numbers[2]+ 1], choosen_quest[numbers[3]+1], correct_answer};


            return print;
        
        }

        public static void CorrectAnswer() {

        right_ans += 1;
        number_of_tasks += 1;

    }

    public static void Incorrectanswer() {

        incorrect_ans += 1;
        number_of_tasks += 1;
    }





    }
