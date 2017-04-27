using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIMAYE.businesslayer;
using UIMAYE.classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace UIMAYE.Istatistik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Raporx : TabbedPage
    {

        public Raporx(ObservableCollection<string> projeler, List<int> ids)
        {
            InitializeComponent();

            foreach (string s in projeler)
            {
                projeadi.Items.Add(s);
            }
                                       

           
            
        }

        bl b = new bl();
        private async void Button_Clicked(object sender, EventArgs e)
        {
            rapInd.IsRunning = true;
            List<LocalLog> ll = await b.getLogs(12, baslangic.Date.ToString("mm-dd-YYYY"), bitis.Date.ToString("mm-dd-YYYY"));
            rapInd.IsRunning = false;
            int topSure = 0;
            int topMola = 0;
            int topBekleme = 0;
            foreach (LocalLog l in ll)
            {
                topSure += l.toplamSure;
                topMola += l.toplamMola;
                topBekleme += l.beklemeSuresi;
            }

            Raporlama rapor = new Raporlama();
            rapor.projeAdi = ll.FirstOrDefault().projeAdi;
            rapor.toplamSure = topSure;
            rapor.toplamMola = topMola;
            rapor.toplamBeklemeSuresi = topBekleme;
            GrafikPage.Content = new CrossPieCharts.FormsPlugin.Abstractions.CrossPieChartSample().GetPageWithPieChart(rapor).Content;

            topBekle.Text = topBekleme.ToString();
            int top = (topSure + topMola + topBekleme)/60;
            
            topCal.Text = top.ToString() + " dk";
            topMol.Text = topMola.ToString();
        }

                                                 
    }
}
