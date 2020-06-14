using System;
using ToDoApp.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp
{
    public partial class App : Application
    {
        private static ToDoContext database;

        public static ToDoContext Instance
        {
            get
            {
                if (database == null)
                {
                    database = new ToDoContext(Constants.DatabasePath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            Constants.InitAsync(Instance);
            AutofacLocator autofac = new AutofacLocator();
            autofac.Register();
            ServiceProvider.RegisterSerivceLocator(autofac);
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
