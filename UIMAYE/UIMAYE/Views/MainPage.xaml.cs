using Acr.UserDialogs;
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
    public partial class MainPage : ContentPage
    {
        int saniye = 1500;
        bl b = new bl();
        int gorevId;
        int projeId;

        bool k = true;
        object syncLock = new object();

        public MainPage(string gorev,int gorevId,int projeId, int kaldigi)
        {
            InitializeComponent();

            this.gorevId = gorevId;
            this.projeId = projeId; 
            saniye = kaldigi;

            if (gorevId == 0) gizle.IsVisible = false;

            gorevCek(gorev);
        }

        private void gorevCek(string gorev)
        {
           
            gorevAdi.Text = gorev;


            timer(saniye);

            
        } 
        public async void dondur(int dur)
        {
            if (k)
            {
                uint x = (uint)(saniye * 1000);
                await box.RotateTo(360, x, Easing.SinInOut);
            }
            else
            {
                uint x = (uint)(dur * 1000);
                await box.RotateTo(360, x, Easing.SinInOut);
            }

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProjeTab());
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Singing());
        }

        private bool _kontrol;
        private bool kontrol
        {
            get
            {
                lock (this.syncLock)
                {
                    return this._kontrol;
                }
            }
            set
            {
                lock (this.syncLock)
                {               
                    this._kontrol = value;
                }
            }
        }

        int kalanZaman;
        private void timer(int zaman)
        {

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                dondur(zaman);
                if (k)
                {
                    zaman -= 1;
                    kalanZaman = zaman;
                    int dakika = zaman / 60;
                    int saniye = zaman % 60;
                    dakika = dakika % 60;

                    lblZaman.Text = String.Format("{0} : {1}", dakika, saniye);
                    if (zaman == 0.00)
                    {
                        SureBitir();

                        return false;
                    }
                    return true;
                }
                else
                {
                    dondur(0);
                    return false;

                }

            });



        }       

        private async void SureBitir()
        {
            k = false;
            var id = Application.Current.Properties["id"];

            if (gorevId == 0)
            {
                await b.TaskState(Convert.ToInt32(id), gorevId, 4, 0);
                await Navigation.PushModalAsync(new Gorevler(projeId));
            }
            else
            {
                LocalTask lt = await b.TaskState(Convert.ToInt32(id), gorevId, 2, 0);
                await DisplayAlert("Süre Doldu", "Geri sayım süresi bitti!", "Ok");
                LocalSetting ls = await b.GetSetting(Convert.ToInt32(id));
                if (ls.kacinciSure % 4 == 0)
                {
                    await Navigation.PushModalAsync(new MainPage("MOLA", 0, 0, (int)ls.uzunMola));
                }
                else
                {
                    await Navigation.PushModalAsync(new MainPage("MOLA", 0, 0, (int)ls.kisaMola));

                }
            }
           
        }
        private async void GucuKes_Click(object sender, EventArgs e)
        {
            k = false;
            var id = Application.Current.Properties["id"];

            LocalTask lt = await b.TaskState(Convert.ToInt32(id), gorevId, 1, kalanZaman);
            await DisplayAlert("Bilgi", "Görevi tamamladınız", "Tamam");
            await Navigation.PushModalAsync(new Gorevler(projeId));

        }
        private async void Duraklat_Click(object sender, EventArgs e)
        {
            k = false;
            var id = Application.Current.Properties["id"];
            await DisplayAlert("Duraklat", "Görev Duraklatma!", "Tamam");
            LocalTask lt = await b.TaskState(Convert.ToInt32(id), gorevId, 2, kalanZaman);
            await Navigation.PushModalAsync(new Gorevler(projeId));

        }
        private void YenidenBaslat_Click(object sender, EventArgs e)
        {
            DisplayAlert("Görev Yeniden Başlat", "Görev süresi sıfırlama!", "Tamam");

        }
        private void Hmenu_Click(object sender, EventArgs e)
        {
            ActionSheetConfig cfg = new ActionSheetConfig();
            cfg.Add("a", null, null);
            cfg.Add("b", null, null);
            cfg.Add("c", null, null);
            UserDialogs.Instance.ActionSheet(cfg);
        }


    }
}