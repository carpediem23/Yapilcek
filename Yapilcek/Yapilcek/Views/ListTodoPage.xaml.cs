using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yapilcek.Dependencies;
using Yapilcek.Models.Domains;
using Yapilcek.Providers;

namespace Yapilcek.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListTodoPage : ContentPage
    {
        private bool canSelect;
        private List<Todo> todos;
        public List<string> DummyData = new List<string>()
        {
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5"
        };

        public ListTodoPage()
        {
            InitializeComponent();
            InitilizePage();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            canSelect = true;
            MessagingCenter.Subscribe<DetailTodoPage, int>(this, "delete", (sender, arg) =>
            {
                DatabaseProvider.Current.Delete(arg);
                RefreshModel();
                TodoList.ItemsSource = todos;
                TodoList.ItemSelected += OnTodoItemSelected;
                return;
            });

            RefreshModel();
            TodoList.ItemsSource = todos;
            TodoList.ItemSelected += OnTodoItemSelected;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            TodoList.ItemSelected -= OnTodoItemSelected;
            MessagingCenter.Unsubscribe<DetailTodoPage>(this, "delete");
        }

        private async void OnTodoItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!canSelect)
                return;

            Todo todo = e.SelectedItem as Todo;
            DetailTodoPage detail = new DetailTodoPage(todo);
            canSelect = false;
            await Navigation.PushModalAsync(new DetailTodoPage(todo), true);
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddTodoPage(), true);
        }

        private void InitilizePage()
        {
            RefreshModel();
        }

        private void RefreshModel()
        {
            todos = DatabaseProvider.Current.GetAll().OrderByDescending(o => o.CreatedDate).ToList<Todo>();
        }
    }
}
