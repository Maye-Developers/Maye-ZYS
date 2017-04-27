using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIMAYE.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UIMAYE.businesslayer;
using UIMAYE.classes;

namespace UIMAYE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        bl b = new bl();
        public Login()
        {
            //Application.Current.Properties.Clear();                             
            if (Application.Current.Properties.ContainsKey("id"))
            {
                Navigation.PushModalAsync(new ProjeTab());
            }
            else InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Singing());
        }

        private async void girisyap(object sender, EventArgs e)
        {
            logInd.IsRunning = true;
            LocalLoginInformation ll = await b.login(kAdi.Text,sifre.Text);
            if (ll.Id != 0)
            {
                Application.Current.Properties["id"] = ll.Id;
                await Navigation.PushModalAsync(new ProjeTab());
            }
            else await DisplayAlert("Hata","Kullanıcı adı yada şifre yanlış","kapat");

            logInd.IsRunning = false;
        }
    }
}
