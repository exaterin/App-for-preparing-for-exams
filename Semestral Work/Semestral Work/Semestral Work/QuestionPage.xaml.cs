using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semestral_Work
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        string correct;

        char topic1;

        string last;

        public QuestionPage(char topic)
        {

            InitializeComponent();
            PrintTask(topic);

            topic1 = topic;

            switch (topic) {
                case '0':
                    Title = "Random tasks";
                    break;
                case '1':
                    Title = "SCIO's exams";
                    break;
                case '2':
                    Title = "CVUT's exams";
                    break;
                case '3':
                    Title = "Charles university's exams";
                    break;
                case '4':
                    Title = "Masaryk university's exams";
                    break;
            }

        }


        public void PrintTask(char topic){


            string[] print = ProcessQuestions.PrepareTask(topic);


            questionXaml.Text = print[0];
            first.Text = print[1];
            second.Text = print[2];
            third.Text = print[3];
            fourth.Text = print[4];

            correct = print[5];

            last = print[6];

            right.Text = ProcessQuestions.right_ans.ToString();
            incorrect.Text = ProcessQuestions.incorrect_ans.ToString();


        }

        async void Clicked(object sender, EventArgs e, Button button){

            if (button.Text == correct){

                if (last == "last")
                {
                    ProcessQuestions.CorrectAnswer();
                    await DisplayAlert("Last task", "You have solved all tasks! If you want to solve them again, you can reset an application in the Statistics", "OK");
                }
                else
                {

                    ProcessQuestions.CorrectAnswer();
                    PrintTask(topic1);
                    right.Text = ProcessQuestions.right_ans.ToString();

                }

            }
            else
            {
                ProcessQuestions.Incorrectanswer();
                await DisplayAlert("Wrong answer", "You can skip or try again", "OK");
                incorrect.Text = ProcessQuestions.incorrect_ans.ToString();
            }
        }

        private void first_clicked(object sender, EventArgs e) { Clicked(sender, e, first); }
        private void second_clicked(object sender, EventArgs e) { Clicked(sender, e, second); }

        private void third_clicked(object sender, EventArgs e) { Clicked(sender, e, third); }

        private void fourth_clicked(object sender, EventArgs e) { Clicked(sender, e, fourth); }

        private async void SkipClicked(object sender, EventArgs e)
        {
            if (last == "last")
            {
                ProcessQuestions.skips += 1;
                await DisplayAlert("Last task", "You have solved all tasks! If you want to solve them again, you can reset an application in the Statistics", "OK");
            }
            else
            {
                ProcessQuestions.number_of_tasks += 1;
                ProcessQuestions.skips += 1;
                PrintTask(topic1);
            }
        }
        private async void RightAClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Correct answer is ", $"{correct}", "OK");
        }


    }
}