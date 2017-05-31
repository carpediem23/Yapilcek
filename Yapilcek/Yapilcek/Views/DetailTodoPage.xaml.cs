using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yapilcek.Models.Domains;

namespace Yapilcek.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailTodoPage : ContentPage
    {
        private Todo model;

        public DetailTodoPage(Todo todo)
        {
            InitializeComponent();
            InitializePage(todo);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            model = null;
        }

        private void InitializePage(Todo todo)
        {
            model = todo;
            LabelTodoDetail.Text = model.Name;
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<DetailTodoPage, int>(this, "delete", model.TodoId);
            await Navigation.PopModalAsync();
        }
    }
}