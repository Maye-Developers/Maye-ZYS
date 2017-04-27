using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIMAYE.Istatistik;
using Xamarin.Forms;

namespace CrossPieCharts.FormsPlugin.Abstractions
{
    /// <summary>
    /// Shows how to use the PieCharts controls.
    /// </summary>
    public class CrossPieChartSample
    {
        public ContentPage GetPageWithPieChart(Raporlama rapor)
        {
            double verim = 100 - (((rapor.toplamSure + rapor.toplamMola) - rapor.toplamBeklemeSuresi) / 100);
            double toplam = 100 - (rapor.toplamSure / 100);
            double mola = 100 - (rapor.toplamMola / 100);
            double bekleme = 100 - (rapor.toplamBeklemeSuresi / 100);
            // The root page of your application
            var contentPage = new ContentPage
            {
                Content = new Grid
                {
                    Children =
                    {
                        new Grid // a trick to set the BackgroundColor of the ContentPage to white
                        {
                            BackgroundColor  = Color.White,
                        },
                        new StackLayout
                        {
                            Children =
                            {
                                new Label
                                {
                                    XAlign = TextAlignment.Center,
                                    Text = rapor.projeAdi+" Projesi Rapor Bilgileri",
                                    TextColor = Color.Black
                                },
                                new Grid
                                {
                                    Children =
                                    {
                                        new CrossPieChartView
                                        {
                                            Progress = (float)verim,//verim
                                            ProgressColor = Color.Green,
                                            ProgressBackgroundColor = Color.FromHex("#EEEEEEEE"),
                                            StrokeThickness = Device.OnPlatform(10, 20, 80),
                                            Radius = Device.OnPlatform(100, 120, 120),
                                            BackgroundColor = Color.White
                                        },
                                        new Label
                                        {
                                            Text = "Verim: "+verim+"%",
                                            Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                                            FontSize = 35,
                                            VerticalOptions = LayoutOptions.Center,
                                            HorizontalOptions = LayoutOptions.Center,
                                            TextColor = Color.Black
                                        }
                                    }
                                },
                                new StackLayout
                                {
                                    Orientation = StackOrientation.Horizontal,
                                    HorizontalOptions = LayoutOptions.Center,
                                    Children =
                                    {
                                         new Grid
                                {
                                    Children =
                                    {
                                        new CrossPieChartView
                                        {
                                            Progress = (float)toplam, // toplam süre
                                            ProgressColor = Color.Blue,
                                            ProgressBackgroundColor = Color.Gray,
                                            StrokeThickness = Device.OnPlatform(10, 10, 20),
                                            Radius = Device.OnPlatform(100, 50, 36),
                                            BackgroundColor = Color.White
                                        },
                                            new Label
                                        {
                                            Text = "Süre: "+toplam+"%",
                                            FontSize = 14,
                                            VerticalOptions = LayoutOptions.Center,
                                            HorizontalOptions = LayoutOptions.Center,
                                            TextColor = Color.Blue
                                        }
                                             }
                                         },
                                          new Grid
                                {
                                    Children =
                                    {
                                        new CrossPieChartView
                                        {
                                            Progress = (float)mola, //toplam mola
                                            ProgressColor = Color.Olive,
                                            ProgressBackgroundColor = Color.Gray,
                                            StrokeThickness = Device.OnPlatform(10, 10, 20),
                                            Radius = Device.OnPlatform(100, 50, 36),
                                            BackgroundColor = Color.White
                                        },
                                            new Label
                                        {
                                            Text = "Mola: "+mola+"%",
                                            FontSize = 14,
                                            VerticalOptions = LayoutOptions.Center,
                                            HorizontalOptions = LayoutOptions.Center,
                                            TextColor = Color.Olive
                                        }
                                              }
                                          },
                                           new Grid
                                {
                                    Children =
                                    {
                                        new CrossPieChartView
                                        {
                                            Progress =(float)bekleme, //toplam bekleme
                                            ProgressColor = Color.Red,
                                            ProgressBackgroundColor = Color.Gray,
                                            StrokeThickness = Device.OnPlatform(10, 10, 20),
                                            Radius = Device.OnPlatform(100, 50, 36),
                                            BackgroundColor = Color.White,
                                        },
                                            new Label
                                        {
                                            Text = "Bekleme: "+bekleme+"%",
                                            FontSize = 12,
                                            VerticalOptions = LayoutOptions.Center,
                                            HorizontalOptions = LayoutOptions.Center,
                                            TextColor = Color.Red
                                        }
                                               }
                                           },
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return contentPage;
        }
    }
}
