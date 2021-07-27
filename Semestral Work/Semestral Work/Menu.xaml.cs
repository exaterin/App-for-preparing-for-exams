using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semestral_Work {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage {
        public Menu() {
            InitializeComponent();
        }
        private async void random_tasks(object sender, EventArgs e) { await Navigation.PushAsync(new QuestionPage('0')); }
        private async void SCIO_but(object sender, EventArgs e) { await Navigation.PushAsync(new QuestionPage('1')); }
        private async void Cvut_but(object sender, EventArgs e) { await Navigation.PushAsync(new QuestionPage('2')); }
        private async void cuni_but(object sender, EventArgs e) { await Navigation.PushAsync(new QuestionPage('3')); }
        private async void masaryk_but(object sender, EventArgs e) { await Navigation.PushAsync(new QuestionPage('4')); }
        private async void stat_but(object sender, EventArgs e) { await Navigation.PushAsync(new Statistics()); }

    }
}