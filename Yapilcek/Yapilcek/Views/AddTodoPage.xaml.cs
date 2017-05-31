using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yapilcek.Models.Domains;
using Yapilcek.Providers;

namespace Yapilcek.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTodoPage : ContentPage
    {
        public AddTodoPage()
        {
            InitializeComponent();
        }

        private async void AddTodoClicked(object sender, EventArgs e)
        {
            AddButton.IsEnabled = false;
            string text = TodoName.Text;

            if(string.IsNullOrEmpty(text))
            {
                AddButton.IsEnabled = true;
                return;
            }

            DatabaseProvider.Current.Create(new Todo() { Name = text });
            await Navigation.PopModalAsync();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            AddButton.Clicked -= AddTodoClicked;
        }
    }
}