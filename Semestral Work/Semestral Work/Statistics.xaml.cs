using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semestral_Work {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistics : ContentPage {
        public Statistics() {
            InitializeComponent();
            PrintStat();
        }

        public void PrintStat() {
            solved.Text = (ProcessQuestions.right_ans + ProcessQuestions.incorrect_ans).ToString();
            skipped.Text = ProcessQuestions.skips.ToString();
            if (ProcessQuestions.number_of_tasks == 0 || ProcessQuestions.right_ans + ProcessQuestions.incorrect_ans == 0)
                winrate.Text = "100 %";
            else {
                double win = ProcessQuestions.right_ans * 1.0 / (ProcessQuestions.right_ans + ProcessQuestions.incorrect_ans) * 1.0 * 100;
                winrate.Text = Math.Round(win, 0).ToString() + " %";
            }
        }

        private void reset_s(object sender, EventArgs e) {
            ProcessQuestions.right_ans = 0;
            ProcessQuestions.incorrect_ans = 0;
            ProcessQuestions.number_of_tasks = 0;
            ProcessQuestions.skips = 0;
            int[] last1 = { 0, 0, 0, 0, 0 };
            ProcessQuestions.last = last1;

            PrintStat();
        }
    }
}