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
            int sikeresekSzama = diakok.Where(d => d.Erdemjegy() != "Elégtelen").Count();
            SikeresVizsgaSzoveg.Content = $"{sikeresekSzama} fő";
        }

        private void FajlbaIras_Click(object sender, RoutedEventArgs e)
        {
            using StreamWriter sw = new(
                path: @"../../../src/vizsgaeredmenyek.txt",
                append: false);
            foreach (var diak in diakok) if (diak.Vegeredmeny > 0.5) sw.WriteLine($"{diak.Nev}\t{diak.Vegeredmeny}\t{diak.Erdemjegy()}");
        }

        private void KeresettTanulo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (KeresettTanulo.Text != "") {
                bool NincsTalalat = true;
                var diak = diakok.Where(d => d.Nev.Contains(KeresettTanulo.Text)).FirstOrDefault();
                if (diak != null)
                {
                    List<float> eredmenyek = new() { diak.ITSzobeli, diak.AngolSzobeli, diak.HalozatA, diak.HalozatB, diak.HalozatC, diak.HalozatD, diak.ProgramozasIrasbeli, diak.HalozatIrasbeli};
                    NincsTalalat = false;
                    KeresesiEredmeny.Text = $"Legjobb eredménye: {eredmenyek.Max()}\nLeggyengébb eredménye: {eredmenyek.Min()}\n{(diak.Erdemjegy() != "Elégtelen" ? "Sikeres vizsgát tett" : "Nem sikerült a sikeres vizsgatétel")}";
                }
                if (NincsTalalat) MessageBox.Show("Nincs találat");
            }
            else KeresesiEredmeny.Text = "";

        }
    }
}