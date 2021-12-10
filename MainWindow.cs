using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace PayCalculator
{
    partial class MainWindow
    {
        private void Populate()
        {
            for (int i = 0; i < vars.PayArray[0].Length; i++)
                levelCombo.Items.Add(vars.PayArray[0][i]);          /* Nurse Level Combo Box */

            for (int i = 0; i < vars.WrkArr.Length; i++)
                workCombo.Items.Add(vars.WrkArr[i]);                /* Workplace Combo Box */

            for (int i = 0; i < vars.WrkHrs.Length; i++)
                workHourCombo.Items.Add(vars.WrkHrs[i]);            /* Work (Shift) Hours */
        }
        private void Inputs()
        {
            //  Getting all the Inputs
            try
            {
                vars.Lvl = Convert.ToDouble(levelCombo.SelectedValue);
                vars.WrkPlace = workCombo.SelectedValue.ToString();
                vars.SftDt = shiftDatePicker.SelectedDate.Value.Date;
                vars.AmPmNd = workHourCombo.SelectedValue.ToString();
                vars.StTime = TimeSpan.ParseExact(startTimeText.Text, "hh\\:mm", CultureInfo.InvariantCulture);
                vars.EdTime = TimeSpan.ParseExact(endTimeText.Text, "hh\\:mm", CultureInfo.InvariantCulture);
                vars.Id = Convert.ToInt32(idTextBox.Text);
                if (breakCheck.IsChecked == true)
                    vars.MlBr = TimeSpan.Parse("00:30");
            }
            catch (Exception)
            {
                vars.inChk = false;
                MessageBox.Show("Invalid Input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DeterminePay()
        {
            //  Determine Pay Rate and Other Variables
            for (int i = 0; i < vars.PayArray[0].Length; i++)
            {
                if (vars.WrkPlace == "HealthScope" || vars.WrkPlace == "Ramsay" || vars.WrkPlace == "St John of God" || vars.WrkPlace == "Arcare")
                {
                    if (vars.Lvl == vars.PayArray[0][i])
                    {
                        if (vars.AmPmNd == vars.WrkHrs[0])              /* AM Shift Selected */
                        {
                            vars.Payrate = vars.PayArray[2][i];
                        }
                        else if (vars.AmPmNd == vars.WrkHrs[1])         /* PM Shift Selected */
                        {
                            vars.Payrate = vars.PayArray[2][i];
                            vars.Pm = vars.PayArray[10][0];
                        }
                        else if (vars.AmPmNd == vars.WrkHrs[2])         /* Night Duty Selected */
                        {
                            vars.Payrate = vars.PayArray[2][i];
                            vars.Nd = vars.PayArray[10][1];
                        }
                        if (uniformCheck.IsChecked == true)             /* Uniform Allowance Selected */
                        {
                            if (vars.WrkPlace == "HealthScope" || vars.WrkPlace == "Ramsay" || vars.WrkPlace == "St John of God")
                                vars.Unf = vars.PayArray[10][2];
                            else if (vars.WrkPlace == "Arcare")
                                vars.Unf = vars.PayArray[10][4];
                        }
                        if (laundryCheck.IsChecked == true)             /* Laundry Allowance Selected */
                        {
                            if (vars.WrkPlace == "HealthScope" || vars.WrkPlace == "Ramsay" || vars.WrkPlace == "St John of God")
                                vars.Lau = vars.PayArray[10][3];
                            else if (vars.WrkPlace == "Arcare")
                                vars.Lau = vars.PayArray[10][5];
                        }
                    }
                }
                else if (vars.WrkPlace == "Regis Aged Care")
                {
                    if (vars.Lvl >= 2.1 && vars.Lvl <= 2.8)
                    {
                        if (vars.Lvl == vars.PayArray[0][i])
                        {
                            if (vars.AmPmNd == vars.WrkHrs[0])                  /* AM Shift Selected */
                                vars.Payrate = vars.PayArray[3][i - 6];
                            else if (vars.AmPmNd == vars.WrkHrs[1])             /* PM Shift Selected */
                                vars.Payrate = vars.PayArray[4][i - 6];
                            else if (vars.AmPmNd == vars.WrkHrs[2])             /* Night Duty Selected */
                                vars.Payrate = vars.PayArray[5][i - 6];
                            else if (vars.SftDt.DayOfWeek.Equals("Saturday"))
                                vars.Payrate = vars.PayArray[6][i - 6];
                            else if (vars.SftDt.DayOfWeek.Equals("Sunday"))
                                vars.Payrate = vars.PayArray[7][i - 6];
                            else if (vars.SftDt.DayOfWeek.Equals("Sunday"))
                                vars.Payrate = vars.PayArray[7][i - 6];
                        }
                    }
                }
                else
                {
                    if (vars.Lvl == vars.PayArray[0][i])
                    {
                        if (vars.Lvl == 2.3 && (vars.SftDt.DayOfWeek.Equals(DayOfWeek.Saturday) || vars.SftDt.DayOfWeek.Equals(DayOfWeek.Sunday)))
                        {
                            vars.Payrate = vars.PayArray[11][0];
                        }
                        else
                        {
                            if (vars.AmPmNd == vars.WrkHrs[0])          /* AM Shift Selected */
                            {
                                vars.Payrate = vars.PayArray[1][i];
                            }
                            else if (vars.AmPmNd == vars.WrkHrs[1])     /* PM Shift Selected */
                            {
                                vars.Payrate = vars.PayArray[1][i];
                                vars.Pm = vars.PayArray[9][0];
                            }
                            else if (vars.AmPmNd == vars.WrkHrs[2])     /* Night Duty Selected */
                            {
                                vars.Payrate = vars.PayArray[1][i];
                                vars.Nd = vars.PayArray[9][1];
                            }
                            if (uniformCheck.IsChecked == true)         /* Uniform Allowance Selected */
                                vars.Unf = vars.PayArray[9][2];
                            if (laundryCheck.IsChecked == true)         /* Laundry Allowance Selected */
                                vars.Lau = vars.PayArray[9][3];
                        }
                    }
                }
            }
        }
        private void Calculations()
        {
            vars.FindWeek = shiftDatePicker.SelectedDate.Value.Date;
            if (vars.AmPmNd == "PM Shift")
                vars.PmQty++;
            else if (vars.AmPmNd == "ND Shift")
                vars.NdQty++;
            if (uniformCheck.IsChecked == true)
                vars.UnfQty++;
            if (laundryCheck.IsChecked == true)
                vars.LauQty++;

            vars.GetTotalHrs = vars.EdTime.Subtract(vars.StTime);
            vars.GetTotalHrs = vars.GetTotalHrs.Subtract(vars.MlBr);
            if (vars.EdTime < vars.StTime)
            {
                vars.Hrs = (24 - Math.Abs(vars.GetTotalHrs.TotalHours));
            }
            else
            {
                vars.Hrs = vars.GetTotalHrs.TotalHours;
            }
        }
    }
}
