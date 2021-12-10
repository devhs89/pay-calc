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
using System.Windows.Shapes;
using System.Globalization;

namespace PayCalculator
{
    /// <summary>
    /// Interaction logic for Print.xaml
    /// </summary>
    public partial class Print : Window
    {
        MainWindow mainWindow = new MainWindow();
        Vars vars = new Vars();
        double grossIncome = 0;

        public Print(DateTime getFindWeek, double[] shiftHours, double[] payrate, double pm, int pmQty, double nd, int ndQty, double unf, int unfQty, double lau, int lauQty)
        {
            InitializeComponent();

            printListBox.Items.Add(String.Format("{0,-50}{1}{2,27}", "PAYSLIP SOLUTIONS", "|", "PERIOD From " + FirstDay(getFindWeek).ToShortDateString()));
            printListBox.Items.Add(String.Format("{0,-50}{1}{2,27}", "ABN 44635956442", "|", "To " + LastDay(getFindWeek).ToShortDateString()));
            printListBox.Items.Add("---------------------------------------------------------------------------------");
            printListBox.Items.Add(String.Format("{0,-45}{1,22}", "\tHarpreet Singh", "Personnel No [12345]"));
            printListBox.Items.Add(String.Format("{0,-45}", "\t123 Some St, Suburb VIC 3210"));
            printListBox.Items.Add("-------------------------------------------------------------------|-------------");
            printListBox.Items.Add(String.Format(vars.strFmt1, "PAYMENTS", "PAY RATE", "HRS/UNIT", "AMOUNT", "   |", "$ TOTAL"));
            for (int i = 0; i < payrate.Length; i++)
            {
                if (payrate[i] > 0)
                {
                    printListBox.Items.Add(String.Format(vars.strFmt1, "Casual", payrate[i], shiftHours[i], payrate[i] * shiftHours[i], "   |", ""));
                    grossIncome += (payrate[i] * shiftHours[i]);
                }
            }

            if (pm > 0 && pmQty > 0)
            {
                grossIncome += (pm * pmQty);
                printListBox.Items.Add(String.Format(vars.strFmt1, "PM Shift Allowaance", pm, pmQty, (pm * pmQty), "   |", ""));
            }
            if (nd > 0 && ndQty > 0)
            {
                grossIncome += (nd * ndQty);
                printListBox.Items.Add(String.Format(vars.strFmt1, "Night Shift Allowaance", nd, ndQty, (nd * ndQty), "   |", ""));
            }
            if (unf > 0 && unfQty > 0)
            {
                grossIncome += (unf * unfQty);
                printListBox.Items.Add(String.Format(vars.strFmt1, "Uniform", unf, unfQty, (unf * unfQty), "   |", ""));
            }
            if (lau > 0 && lauQty > 0)
            {
                grossIncome += (lau * lauQty);
                printListBox.Items.Add(String.Format(vars.strFmt1, "Laundry Allowance", lau, lauQty, (lau * lauQty), "   |", ""));
            }
            printListBox.Items.Add(String.Format(vars.strFmt1, "", "", "", "----------", "   |", grossIncome));
            printListBox.Items.Add("-------------------------------------------------------------------|-------------");
            printListBox.Items.Add(String.Format(vars.strFmt2, "LESS Deductions", "YTD Amount", "WKS", "AMOUNT", "   |", ""));
            printListBox.Items.Add(String.Format(vars.strFmt2, "PAYG Taxation", "___", "_", TaxCalc(grossIncome), "   |", ""));
            printListBox.Items.Add(String.Format(vars.strFmt2, "", "", "", "----------", "   |", -TaxCalc(grossIncome)));
            printListBox.Items.Add("-------------------------------------------------------------------|-------------");
            printListBox.Items.Add(String.Format("{0,-30}{1,10:c2}{2,-24}{3}{4,7}", "SUPER-ANNUATION Super ", SuperCalc(grossIncome, (unf * unfQty), (lau * lauQty)), " this pay", "   |", ""));
            printListBox.Items.Add("-------------------------------------------------------------------|-------------");
            printListBox.Items.Add(String.Format("{0,-15}{1,-10:c2}{2,23}{3,-16}{4}{5,12:c2}", "YTD Gross ", "____", "PAID BY BANK TRANSFER  ", LastDay(getFindWeek).AddDays(1).ToShortDateString(), "   |", grossIncome - TaxCalc(grossIncome)));
            printListBox.Items.Add("-------------------------------------------------------------------|-------------");
        }

        private static DateTime FirstDay(DateTime addedDate)
        {
            //Finding Start of the Week
            CultureInfo culture = new CultureInfo("en-AU");
            culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
            int daysDiff = addedDate.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (daysDiff < 0)
                daysDiff += 7;
            return addedDate.AddDays(-daysDiff).Date;
        }
        private static DateTime LastDay(DateTime addedDate)
        {
            //Finding End of the Week
            return FirstDay(addedDate).AddDays(6);
        }

        private static double TaxCalc(double weekIncome)
        {
            //Tax Calculations
            int grossIncome = 0; int taxWithheld = 0; int medicareLevy = 0;
            grossIncome = Convert.ToInt32(weekIncome * 52);

            if (grossIncome > 18200)
                medicareLevy = Convert.ToInt32(weekIncome * 2) / 100;

            if (grossIncome <= 18200)
            {
                taxWithheld = 0;
            }
            else if (grossIncome > 18200 && grossIncome < 37000)
            {
                grossIncome = grossIncome - 18200;
                taxWithheld = grossIncome * 19 / 100;
            }
            else if (grossIncome > 37001 && grossIncome < 90000)
            {
                grossIncome = grossIncome - 37000;
                taxWithheld = Convert.ToInt32((grossIncome * 32.5 / 100) + 3572);
            }
            else if (grossIncome > 90001 && grossIncome < 180000)
            {
                grossIncome = grossIncome - 90000;
                taxWithheld = (grossIncome * 37 / 100) + 20797;
            }
            else
            {
                grossIncome = grossIncome - 180000;
                taxWithheld = (grossIncome * 45 / 100) + 54097;
            }

            taxWithheld = taxWithheld / 52;
            return taxWithheld + medicareLevy;
        }
        private static double SuperCalc(double grossIncome, double unf, double lau)
        {
            //  Super-annuation Calculations
            grossIncome = (grossIncome - unf) - lau;
            double super = grossIncome * 9.5 / 100;
            return super;
        }

        private void printPdfButton_Click(object sender, RoutedEventArgs e)
        {
            //  Work In Progress
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            this.Close();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
            Application.Current.Shutdown();
        }
    }
}
