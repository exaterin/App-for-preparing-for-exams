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
	public partial class Menu : ContentPage
	{
		public Menu(){
			InitializeComponent();
		}
		private async void random_tasks(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RandomTasks());
		}
		private async void SCIO_but(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SCIO());
		}
		private async void Cvut_but(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CvutExams());
		}
		private async void cuni_but(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Cuni());
		}
		private async void masaryk_but(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new masaryk());
		}
		private async void stat_but(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new stat());
		}

	}
}