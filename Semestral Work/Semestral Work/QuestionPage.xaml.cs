using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semestral_Work {
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class QuestionPage : ContentPage {

        string correct;
        char topicPrint;
        bool last;

        public QuestionPage(char topic) {
            InitializeComponent();
            PrintTask(topic);
            topicPrint = topic;

            string[] titles = {"Random tasks", "SCIO's exams", "CVUT's exams", "Charles University's exams", "Masaryk University's exams" };

            Title = titles[topic - '0'];
        }


        public void PrintTask(char topic){
            QuestionInfo print = ProcessQuestions.PrepareTask(topic);

            questionXaml.Text = print.question;
            first.Text = print.answers[0];
            second.Text = print.answers[1];
            third.Text = print.answers[2];
            fourth.Text = print.answers[3];
            correct = print.correct;
            last = print.is_last;

            right.Text = ProcessQuestions.right_ans.ToString();
            incorrect.Text = ProcessQuestions.incorrect_ans.ToString();
        }

        async void Clicked(object sender, EventArgs e, Button button) {
            if (button.Text == correct) {
                ProcessQuestions.CorrectAnswer();
                if (last)
                    await DisplayAlert("Last task", "You have solved all tasks! If you want to solve them again, you can reset the application in the Statistics", "OK");
                else {
                    PrintTask(topicPrint);
                    right.Text = ProcessQuestions.right_ans.ToString();
                }
            } else {
                ProcessQuestions.IncorrectAnswer();
                await DisplayAlert("Wrong answer", "You can skip or try again", "OK");
                incorrect.Text = ProcessQuestions.incorrect_ans.ToString();
            }
        }

        private void first_clicked(object sender, EventArgs e) { Clicked(sender, e, first); }
        private void second_clicked(object sender, EventArgs e) { Clicked(sender, e, second); }

        private void third_clicked(object sender, EventArgs e) { Clicked(sender, e, third); }

        private void fourth_clicked(object sender, EventArgs e) { Clicked(sender, e, fourth); }

        private async void SkipClicked(object sender, EventArgs e) {
            ProcessQuestions.skips += 1;
            if (last)
                await DisplayAlert("Last task", "You have solved all tasks! If you want to solve them again, you can reset the application in the Statistics", "OK");
            else{
                ProcessQuestions.number_of_tasks += 1;
                PrintTask(topicPrint);
            }
        }
        private async void RightAClicked(object sender, EventArgs e) {
            await DisplayAlert("Correct answer is ", $"{correct}", "OK");
        }
    }
}