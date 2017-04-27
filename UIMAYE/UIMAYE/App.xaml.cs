using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIMAYE.Istatistik;
using UIMAYE.Views;
using Xamarin.Forms;

namespace UIMAYE
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new Gorevler();
            //MainPage = new ProjeTab();
            //MainPage = new Ayarlar();
          
            MainPage = new Login();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
