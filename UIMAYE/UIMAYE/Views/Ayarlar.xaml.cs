using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIMAYE.businesslayer;
using UIMAYE.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIMAYE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ayarlar : ContentPage
    {
        bl b = new bl();
        public Ayarlar()
        {
            InitializeComponent();
            var id = Application.Current.Properties["id"];
            ayarCek(Convert.ToInt32(id));
        }

        private async void ayarCek(int kulId)
        {
            LocalSetting ls = await b.GetSetting(kulId);
            kisaMolaSuresi.Text = ls.kisaMola.ToString();
            uzunMolaSuresi.Text = ls.uzunMola.ToString();
            gorevSuresi.Text = ls.gorevSure.ToString();
        }

        private async void ayarGuncelle(object sender, EventArgs e)
        {
            var id = Application.Current.Properties["id"];
            int kisaMola = Convert.ToInt32(kisaMolaSuresi.Text);
            int uzunMola = Convert.ToInt32(uzunMolaSuresi.Text);
            int gorevSure = Convert.ToInt32(gorevSuresi.Text);

            await b.ChangeSettings(Convert.ToInt32(id), uzunMola, kisaMola, gorevSure);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}
