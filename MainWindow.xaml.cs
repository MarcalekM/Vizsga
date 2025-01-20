using System.IO;
using System.Text;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vizsga;

namespace Vizsga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Diak> diakok = new();
        public MainWindow()
        {
            InitializeComponent();

            using StreamReader sr = new(
                path: @"../../../src/adatok.txt",
                encoding: Encoding.UTF8);

            while (!sr.EndOfStream) diakok.Add(new(sr.ReadLine()));

            VizsganResztvevokSzama.Content = $"{diakok.Count} diák vett részt a vizsgán";

            foreach (var diak in diakok) VizsgazokNevei.Items.Add(diak.Nev);
        }

        private void SikeresVizsga_Click(object sender, RoutedEventArgs e)
        {
            int sikeresekSzama = 0;
            foreach (var diak in diakok) if (diak.HalozatIrasbeli > 0.5 && diak.ProgramozasIrasbeli > 0.5 &&  diak.HalozatA > 0.5 && diak.HalozatB > 0.5 &&  diak.HalozatC > 0.5 &&  diak.HalozatD > 0.5 &&  diak.AngolSzobeli > 0.5 &&  diak.ITSzobeli > 0.5) sikeresekSzama++;
            SikeresVizsgaSzoveg.Content = $"{sikeresekSzama} fő";
        }

        private void FajlbaIras_Click(object sender, RoutedEventArgs e)
        {
            using StreamWriter sw = new(
                path: @"../../../src/vizsgaeredmenyek.txt",
                append: false);
            foreach (var diak in diakok) if (diak.Eredmeny > 0.5) sw.WriteLine($"{diak.Nev}\t{diak.Eredmeny}\t{diak.Erdemjegy(diak.Eredmeny)}");
        }

        private void KeresettTanulo_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool NincsTalalat = true;
            foreach (var diak in diakok)
            {
                if (diak.Nev.Contains(KeresettTanulo.Text))
                {
                    NincsTalalat = false;
                }
            }
            if(NincsTalalat) MessageBox.Show("Nincs találat");
        }
    }
}