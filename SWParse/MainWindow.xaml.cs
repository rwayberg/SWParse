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
            //lblAtkBase.Content = "";
            //lblAtkPlus.Content = "";
            //lblHPBase.Content = "";
            //lblHPPlus.Content = "";
            //lblDefBase.Content = "";
            //lblDefPlus.Content = "";
            //lblSpeedBase.Content = "";
            //lblSpeedPlus.Content = "";
            //lblRuneResultAcc.Content = "";
            //lblRuneResultMon.Content = "";
            //lblRuneResultName.Content = "";
            //lblRuneResultGrade.Content = "";
            ClearLabels();
            btnRuneSearch.IsEnabled = false;
        }

        private void ClearLabels()
        {
            lblAtkBase.Content = "";
            lblAtkPlus.Content = "";
            lblHPBase.Content = "";
            lblHPPlus.Content = "";
            lblDefBase.Content = "";
            lblDefPlus.Content = "";
            lblSpeedBase.Content = "";
            lblSpeedPlus.Content = "";

            //S1
            lblRuneResultAcc.Content = "";
            lblRuneResultMon.Content = "";
            lblRuneResultName.Content = "";
            lblRuneResultGrade.Content = "";

            //S2
            lblRuneResultAccS2.Content = "";
            lblRuneResultMonS2.Content = "";
            lblRuneResultNameS2.Content = "";
            lblRuneResultGradeS2.Content = "";

            //S3
            lblRuneResultAccS3.Content = "";
            lblRuneResultMonS3.Content = "";
            lblRuneResultNameS3.Content = "";
            lblRuneResultGradeS3.Content = "";

            //S4
            lblRuneResultAccS4.Content = "";
            lblRuneResultMonS4.Content = "";
            lblRuneResultNameS4.Content = "";
            lblRuneResultGradeS4.Content = "";

            //S5
            lblRuneResultAccS5.Content = "";
            lblRuneResultMonS5.Content = "";
            lblRuneResultNameS5.Content = "";
            lblRuneResultGradeS5.Content = "";

            //S6
            lblRuneResultAccS6.Content = "";
            lblRuneResultMonS6.Content = "";
            lblRuneResultNameS6.Content = "";
            lblRuneResultGradeS6.Content = "";
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
            accRunes = mainDC.SortedRuneList(accRunes);

            if (accRunes[0] != default(SWData.Rune))
            {
                lblRuneResultName.Content = String.Format("+{0} {1}({2})", accRunes[0].level, accRunes[0].set, accRunes[0].slot);
                lblRuneResultAcc.Content = String.Format("Accuracy +{0}%", accRunes[0].sub_acc); //Acc always in %
                lblRuneResultMon.Content = "Mon NA";
                if (accRunes[0].monster_n.ToLower() != "unknown name")
                    lblRuneResultMon.Content = String.Format("Mon {0}", accRunes[0].monster_n);
                lblRuneResultGrade.Content = String.Format("Grade {0}", accRunes[0].grade);
            }

            if (accRunes[1] != default(SWData.Rune))
            {
                lblRuneResultNameS2.Content = String.Format("+{0} {1}({2})", accRunes[1].level, accRunes[1].set, accRunes[1].slot);
                lblRuneResultAccS2.Content = String.Format("Accuracy +{0}%", accRunes[1].sub_acc); //Acc always in %
                lblRuneResultMonS2.Content = "Mon NA";
                if (accRunes[1].monster_n.ToLower() != "unknown name")
                    lblRuneResultMonS2.Content = String.Format("Mon {0}", accRunes[1].monster_n);
                lblRuneResultGradeS2.Content = String.Format("Grade {0}", accRunes[1].grade);
            }

            if (accRunes[2] != default(SWData.Rune))
            {
                lblRuneResultNameS3.Content = String.Format("+{0} {1}({2})", accRunes[2].level, accRunes[2].set, accRunes[2].slot);
                lblRuneResultAccS3.Content = String.Format("Accuracy +{0}%", accRunes[2].sub_acc); //Acc always in %
                lblRuneResultMonS2.Content = "Mon NA";
                if (accRunes[2].monster_n.ToLower() != "unknown name")
                    lblRuneResultMonS3.Content = String.Format("Mon {0}", accRunes[2].monster_n);
                lblRuneResultGradeS3.Content = String.Format("Grade {0}", accRunes[2].grade);
            }

            if (accRunes[3] != default(SWData.Rune))
            {
                lblRuneResultNameS4.Content = String.Format("+{0} {1}({2})", accRunes[3].level, accRunes[3].set, accRunes[3].slot);
                lblRuneResultAccS4.Content = String.Format("Accuracy +{0}%", accRunes[3].sub_acc); //Acc always in %
                lblRuneResultMonS4.Content = "Mon NA";
                if (accRunes[3].monster_n.ToLower() != "unknown name")
                    lblRuneResultMonS4.Content = String.Format("Mon {0}", accRunes[3].monster_n);
                lblRuneResultGradeS4.Content = String.Format("Grade {0}", accRunes[3].grade);
            }

            if (accRunes[4] != default(SWData.Rune))
            {
                lblRuneResultNameS5.Content = String.Format("+{0} {1}({2})", accRunes[4].level, accRunes[4].set, accRunes[4].slot);
                lblRuneResultAccS5.Content = String.Format("Accuracy +{0}%", accRunes[4].sub_acc); //Acc always in %
                lblRuneResultMonS5.Content = "Mon NA";
                if (accRunes[4].monster_n.ToLower() != "unknown name")
                    lblRuneResultMonS5.Content = String.Format("Mon {0}", accRunes[4].monster_n);
                lblRuneResultGradeS5.Content = String.Format("Grade {0}", accRunes[4].grade);
            }

            if (accRunes[5] != default(SWData.Rune))
            {
                lblRuneResultNameS6.Content = String.Format("+{0} {1}({2})", accRunes[5].level, accRunes[5].set, accRunes[5].slot);
                lblRuneResultAccS6.Content = String.Format("Accuracy +{0}%", accRunes[5].sub_acc); //Acc always in %
                lblRuneResultMonS6.Content = "Mon NA";
                if (accRunes[5].monster_n.ToLower() != "unknown name")
                    lblRuneResultMonS6.Content = String.Format("Mon {0}", accRunes[5].monster_n);
                lblRuneResultGradeS6.Content = String.Format("Grade {0}", accRunes[5].grade);
            }
        }
    }
}
