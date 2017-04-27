using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIMAYE.businesslayer;
using UIMAYE.classes;
using UIMAYE.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace UIMAYE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gorevler : TabbedPage
    {

        bl b = new bl();
        List<int> idler;
        List<int> saniye;
        List<int> durum;
        ObservableCollection<string> isimler;
        int projeId;
        public Gorevler(int projeId)
        {
            InitializeComponent();
            this.projeId = projeId;
            gorevCek(projeId);
        }

        private async void gorevCek(int projeId)
        {
            List<LocalTask> lps = await b.GetTasks(projeId);

            idler = new List<int>();
            isimler = new ObservableCollection<string>();
            saniye = new List<int>();
            durum = new List<int>();                         


            foreach (LocalTask lp in lps)
            {
                
                if (lp.oncelik == true)
                {
                    idler.Add(lp.id);
                    saniye.Add((int)lp.kaldigiSure);
                    isimler.Add(lp.ad);
                    durum.Add((int)lp.durum);
                }                         
            }

            foreach (LocalTask lp in lps)
            {
                
                if (lp.oncelik == false)
                {
                    idler.Add(lp.id);
                    saniye.Add((int)lp.kaldigiSure);
                    isimler.Add(lp.ad);
                    durum.Add((int)lp.durum);
                }
            }


            listGorevler.ItemsSource = isimler;
        }



        private async void gorevEkle(object sender, EventArgs e)
        {
            gorevInd.IsRunning = true;
            var id = Application.Current.Properties["id"];
            int deger = 0;
            if (gorevOncelik.IsToggled)
            {
                deger = 1;
            }
            LocalTask lp = await b.AddTask(Convert.ToInt32(id), gorevAdi.Text,deger,projeId);
            gorevAdi.Text = "";
            gorevInd.IsRunning = false;

            gorevCek(projeId);

        }

        private async void listGorevler_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int i = 0;
            foreach (string s in isimler)
            {
                if (isimler[i] == e.Item.ToString())
                {
                    break;
                }
                i++;
            }
            if(durum[i] == 2)
            {
                var id = Application.Current.Properties["id"];

                await b.TaskState(Convert.ToInt32(id), idler[i], 3, 0);
                await Navigation.PushModalAsync(new MainPage(e.Item.ToString(), idler[i], projeId, saniye[i]));  
            }
            else if(durum[i] == 1)
            {
                await DisplayAlert("Bilgi","Bu görevi zaten tamamladınız","kapat");
            }
            else
            {
                await Navigation.PushModalAsync(new MainPage(e.Item.ToString(), idler[i], projeId, saniye[i]));
            }

        }
    }
}
