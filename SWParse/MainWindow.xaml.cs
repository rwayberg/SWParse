using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace SWParse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataControl mainDC;
        public MainWindow()
        {
            mainDC = null;
            InitializeComponent();
            lblAtkBase.Content = "";
            lblAtkPlus.Content = "";
            lblHPBase.Content = "";
            lblHPPlus.Content = "";
            lblDefBase.Content = "";
            lblDefPlus.Content = "";
            lblSpeedBase.Content = "";
            lblSpeedPlus.Content = "";
            lblRuneResultAcc.Content = "";
            lblRuneResultMon.Content = "";
            lblRuneResultName.Content = "";
            lblRuneResultGrade.Content = "";
            btnRuneSearch.IsEnabled = false;
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog loaddlg = new OpenFileDialog();
            loaddlg.FileName = "Document";
            loaddlg.DefaultExt = ".json";
            loaddlg.Filter = "JSON documents (.json)|*.json";

            Nullable<bool> result = loaddlg.ShowDialog();
            if(result == true)
            {
                string file = loaddlg.FileName;
                FileInfo optFI = new FileInfo(file);
                if (!optFI.Exists)
                {
                    MessageBoxResult badFileresult = MessageBox.Show(String.Format("Unable to find file {0}", file), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    if(badFileresult == MessageBoxResult.OK)
                    {
                        Load_Click(sender, e);
                    }
                }
                //lblTest.Content = file;
                mainDC = new DataControl(file);
                //lblTest.Content = dc.GetRuneCount().ToString();

                List<string> monsters = mainDC.GetMonsterList();
                if(monsters.Count > 0)
                {
                    cmbxMonList.IsEnabled = true;
                    cmbxMonList.ItemsSource = monsters;
                    btnRuneSearch.IsEnabled = true;
                }
                
            }
        }

        private void cmbxMonList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(!String.IsNullOrEmpty(e.Source.ToString()) && mainDC != null)
            {
                string selectedMon = e.AddedItems[0].ToString();
                SWData.Mon mon = mainDC.GetMonster(selectedMon);
                lblHPBase.Content = mon.b_hp.ToString();
                lblDefBase.Content = mon.b_def.ToString();
                lblAtkBase.Content = mon.b_atk.ToString();
                lblSpeedBase.Content = mon.b_spd.ToString();
                //lblTest.Content = e.AddedItems[0].ToString();
                List<SWData.Rune> runes = mainDC.GetMonsterRune(mon.name);
                lblTest.Content = runes.Count.ToString();
                SWData.Rune rune1 = runes.Find(x => x.slot == 1);
                txtblkRune1.Text = String.Format("{0} {1} {2} {3}", rune1.id, rune1.grade, rune1.set, rune1.slot);
            }
            else
            {
                lblHPBase.Content = "";
                lblDefBase.Content = "";
                lblAtkBase.Content = "";
                lblSpeedBase.Content = "";
            }
        }

        private void btnRuneSearch_Click(object sender, RoutedEventArgs e)
        {
            List<SWData.Rune> accRunes = mainDC.GetHighestAcc();

            lblRuneResultName.Content = String.Format("+{0} {1}({2})", accRune.level, accRune.set, accRune.slot);
            lblRuneResultAcc.Content = String.Format("Accuracy +{0}%", accRune.sub_acc); //Acc always in %
            lblRuneResultMon.Content = "Mon NA";
            if(accRune.monster_n.ToLower() != "unknown name")
                lblRuneResultMon.Content = String.Format("Mon {0}", accRune.monster_n);
            lblRuneResultGrade.Content = String.Format("Grade {0}", accRune.grade);
        }
    }
}
