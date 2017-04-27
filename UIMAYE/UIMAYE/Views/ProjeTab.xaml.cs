using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIMAYE.businesslayer;
using UIMAYE.classes;
using UIMAYE.Istatistik;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace UIMAYE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjeTab : TabbedPage
    {
        bl b = new bl();
        List<int> idler;
        ObservableCollection<string> isimler;
        public ProjeTab()
        {
            InitializeComponent();



            listCek();
                                                          
                                  
        }
         

        private async void listCek()
        {
            var id = Application.Current.Properties["id"];
        
            List<LocalProject> lps = await b.getProjects(Convert.ToInt32(id));

            idler = new List<int>();        
            isimler = new ObservableCollection<string>();

            foreach (LocalProject lp in lps)
            {
                idler.Add(lp.id);
                isimler.Add(lp.ad);
            }

            degerler.ItemsSource = isimler;
        }

                

        private async void projeEkle(object sender, EventArgs e)
        {
            projInd.IsRunning = true;
            var id = Application.Current.Properties["id"];
            LocalProject lp = await b.addProject(Convert.ToInt32(id), ProjeAdi.Text);
            projInd.IsRunning = false;
            ProjeAdi.Text = "";
            idler.Add(lp.id);
            isimler.Add(lp.ad);

            degerler.ItemsSource = isimler;   
        }

        private void degerler_ItemTapped(object sender, ItemTappedEventArgs e)
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

            Navigation.PushModalAsync(new Gorevler(idler[i]));

        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Ayarlar());
        }

        private void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Raporx(isimler,idler));
        }
    }
}
