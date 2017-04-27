using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UIMAYE.businesslayer;
using UIMAYE.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIMAYE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Singing : ContentPage
    {
        bl b = new bl();
        public Singing()
        {
            InitializeComponent();
        }

        private async void kayitol(object sender, EventArgs e)
        {
            if(sifre.Text.Length > 5 )
            {
                if (Regex.IsMatch(eMail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                {
                    LocalLoginInformation ll = await b.register(sifre.Text,eMail.Text,adSoyad.Text);
                    if (ll.Id != 0)
                    {
                        Application.Current.Properties["id"] = ll.Id;
                        await Navigation.PushModalAsync(new ProjeTab());
                    }
                }
                else await DisplayAlert("Hata", "Bu doğru bir email değil", "kapat");
                              
            }
            else await DisplayAlert("Hata", "Şifre 6 haneden az olamaz", "kapat");

        }
    }
}
