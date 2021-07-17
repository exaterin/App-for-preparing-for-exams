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
    public partial class SCIO : ContentPage
    {

        string correct;

        public SCIO()
        {

            InitializeComponent();
            PrintTask();
        }

        public void PrintTask()
        {



            string[] print = ProcessQuestions.PrepeareTask('2');

            questionXaml.Text = print[0];
            first.Text = print[1];
            second.Text = print[2];
            third.Text = print[3];
            fourth.Text = print[4];

            correct = print[5];

            right.Text = ProcessQuestions.right_ans.ToString();
            incorrect.Text = ProcessQuestions.incorrect_ans.ToString();


        }

        private async void first_clicked(object sender, EventArgs e)
        {
            if (first.Text == correct)
            {
                ProcessQuestions.CorrectAnswer();
                PrintTask();
                right.Text = ProcessQuestions.right_ans.ToString();
            }
            else
            {
                ProcessQuestions.Incorrectanswer();
                await DisplayAlert("Wrong answer", "You can skip or try again", "OK");
                incorrect.Text = ProcessQuestions.incorrect_ans.ToString();
            }

        }
        private async void second_clicked(object sender, EventArgs e)
        {
            if (second.Text == correct)
            {
                ProcessQuestions.CorrectAnswer();
                PrintTask();
                right.Text = ProcessQuestions.right_ans.ToString();
            }
            else
            {
                ProcessQuestions.Incorrectanswer();
                await DisplayAlert("Wrong answer", "You can skip or try again", "OK");
                incorrect.Text = ProcessQuestions.incorrect_ans.ToString();
            }

        }
        private async void third_clicked(object sender, EventArgs e)
        {
            if (third.Text == correct)
            {
                ProcessQuestions.CorrectAnswer();
                PrintTask();
                right.Text = ProcessQuestions.right_ans.ToString();
            }
            else
            {
                ProcessQuestions.Incorrectanswer();
                await DisplayAlert("Wrong answer", "You can skip or try again", "OK");
                incorrect.Text = ProcessQuestions.incorrect_ans.ToString();
            }
        }
        private async void fourth_clicked(object sender, EventArgs e)
        {
            if (fourth.Text == correct)
            {
                ProcessQuestions.CorrectAnswer();
                PrintTask();
                right.Text = ProcessQuestions.right_ans.ToString();
            }
            else
            {
                ProcessQuestions.Incorrectanswer();
                await DisplayAlert("Wrong answer", "You can skip or try again", "OK");
                incorrect.Text = ProcessQuestions.incorrect_ans.ToString();
            }
        }
        private async void SkipClicked(object sender, EventArgs e) {

            ProcessQuestions.number_of_tasks += 1;
            ProcessQuestions.skips += 1;
            PrintTask();
        }
        private async void RightAClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Correct answer is ", $"{correct}", "OK");
        }




    }
}