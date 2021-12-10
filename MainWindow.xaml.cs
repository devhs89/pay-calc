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
using System.Globalization;

namespace PayCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    //  ##  NOTES   ##  //
    //  --------------
    //      >   Work In Progress
    //  --------------
    //  ##  END ##  //


    public partial class MainWindow : Window
    {
        Vars vars = new Vars(); /*  Vars Class  */
        DbSql dbSql = new DbSql(); /*  DbSql Class  */

        public MainWindow()
        {
            InitializeComponent();

            Populate();
            listBox.Items.Add(String.Format(vars.listBxFmt, "Shift Date", "Shift Hours", "Start", "Finish", "Total Hours", "Break"));
            listBox.Items.Add("------------------------------------------------------------------------------");
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (vars.dayCt <= 7)
            {
                Inputs();
                if (vars.inChk == true)
                {
                    DeterminePay(); Calculations();
                    if (vars.RateList.Contains(vars.Payrate))
                    {
                        for (int i = 0; i < vars.RateList.Length; i++)
                        {
                            if (vars.RateList[i] == vars.Payrate)
                            {
                                vars.HrsList[i] += vars.Hrs;
                                vars.dayCt++;
                            }
                        }
                    }
                    else
                    {
                        vars.RateList[vars.n] = vars.Payrate;
                        vars.HrsList[vars.n] = vars.Hrs;
                        vars.n++;
                        vars.dayCt++;
                    }

                    dbSql.Entry(vars.Id, vars.Lvl, vars.WrkPlace, vars.SftDt.ToShortDateString(), vars.StTime.ToString(), vars.EdTime.ToString(), vars.Hrs.ToString(), vars.AmPmNd.Remove(3).ToString(), breakCheck.IsChecked.Value, vars.Lau.ToString(), vars.Unf.ToString());
                    listBox.Items.Add(String.Format(vars.listBxFmt, vars.SftDt.ToShortDateString(), vars.AmPmNd, String.Format("{0:hh\\:mm}", vars.StTime), String.Format("{0:hh\\:mm}", vars.EdTime), vars.Hrs, breakCheck.IsChecked));

                    startTimeText.Clear(); endTimeText.Clear();
                }
                else
                {
                    vars.inChk = true;
                }
            }
            else
            {
                MessageBox.Show("Maximum of 7 days can be listed in one go.", "Limit Reached", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            if (vars.inChk == true)
            {
                Print printWindow = new Print(vars.FindWeek, vars.HrsList, vars.RateList, vars.Pm, vars.PmQty, vars.Nd, vars.NdQty, vars.Unf, vars.UnfQty, vars.Lau, vars.LauQty);
                this.Visibility = Visibility.Hidden;    /* Hidding Current Window */
                printWindow.Show();
            }
        }
        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
