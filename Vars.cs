using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCalculator
{
    class Vars
    {
        //  START - MAIN-WINDOW VARIABLES
        public int Id { get; set; }                 /* Employee ID */
        public int PmQty { get; set; }              /* Number of PM Shifts */
        public int NdQty { get; set; }              /* Number of Night Shifts */
        public int UnfQty { get; set; }             /* Number of Uniform Allowances */
        public int LauQty { get; set; }             /* Number of Laundry Allowances */
        public double Payrate { get; set; }         /* Pay Rate derived from Selected Nurse Level and Work Place */
        public double Lvl { get; set; }             /* Current Nurse Level */ 
        public double Hrs { get; set; }             /* Total Shift Hours derived from GetTotalHrs Variable */
        public double Pm { get; set; }              /* PM Shift Allowance */
        public double Nd { get; set; }              /* Night Shift Allowance */
        public double Unf { get; set; }             /* Uniform Allowance */
        public double Lau { get; set; }             /* Laundry Allowance */
        public string AmPmNd { get; set; }          /* Time of the Shift - AM, PM or Night Duty (ND) */
        public string WrkPlace { get; set; }        /* Selected Work Place */
        public DateTime FindWeek { get; set; }      /* Week Start Date and End Date based on Shift Dates Entered */
        public DateTime SftDt { get; set; }         /* DateTime Picker - Selected Date */
        public TimeSpan GetTotalHrs { get; set; }   /* Total Hours from StartTime - EndTime Variables */
        public TimeSpan StTime { get; set; }        /* Start Time of Shift */
        public TimeSpan EdTime { get; set; }        /* End Time of Shift */
        public TimeSpan MlBr { get; set; }          /* Meal Break taken? */
        
        public bool inChk = true;                   /* Data Validation before Adding Shift */
        public int n = 0;                           /* Adding New Pay Rates to PayrateList Array & HrsList Array */
        public int dayCt = 1;    

        private double[] rateList = new double[7];  /* Pay Rate Array - Sent to Print Window */
        public double[] RateList
        {
            get { return rateList; }
            set { rateList = value; }
        }

        private double[] hrsList = new double[7];   /* Shift Hours Array - Sent to Print Window */
        public double[] HrsList
        {
            get { return hrsList; }
            set { hrsList = value; }
        }

        private string[] wrkArr = { "HealthScope", "Ramsay", "St John of God", "Arcare", "Regis Aged Care", "Others" };
        public string[] WrkArr                      /* ^ Work Places Array - Sent to WorkPace Combo Box */
        {
            get { return wrkArr; }
        }

        private string[] wrkHrs = { "AM Shift", "PM Shift", "ND Shift" };
        public string[] WrkHrs                      /* ^ Shift Hours Array - Sent to Work Hours Combo Box */
        {
            get { return wrkHrs; }
        }

        public string listBxFmt = "{0,-13}{1,13}{2,12}{3,12}{4,17:n2}{5,10}";

        //  END - MAIN-WINDOW VARIABLES

        //  START - PRINT VARIABLES

        public string strFmt1 = "{0,-30}{1,10:n2}{2,12}{3,12:n2}{4}{5,12:n2}";
        public string strFmt2 = "{0,-30}{1,10}{2,9}{3,15:n2}{4}{5,12:n2}";

        //  END - PRINT VARIABLES

        //  START - PAYRATE ARRAY
        private double[][] payArray = new double[][]
        {
            //  #0   EN Levels ## ( Specialist EN = 2.8 )
            new double[] { 1.1, 1.2, 1.3, 1.4, 1.5, 1.6, 2.1, 2.2, 2.3, 2.4, 2.5, 2.6, 2.7, 2.8 },
            //  #1   Standard - Rates
            new double[] { 32.49, 33.16, 33.82, 34.50, 35.32, 36.92, 35.49, 36.20, 36.90, 37.58, 38.27, 38.74, 39.45, 41.60 },
            //  #2   HealthScope, Ramsay & St John of God & Arcare - Rates ( Arcare - No Specialist EN rate mentioned )
            new double[] { 31.24, 31.88, 32.52, 33.17, 33.96, 35.50, 34.13, 34.81, 35.48, 36.14, 36.80, 37.25, 37.93, 40.00 },
            //  Regis Aged Care ( From level 2.1 - 2.8 Only ) ( Level 2.1 & 2.2 - Same PayRate )
            new double[] { 33.52, 33.52, 34.20, 34.87, 35.54, 36.19, 36.64, 37.32 },   /* #3   AM Shifts */
            new double[] { 38.55, 38.55, 39.34, 40.10, 40.87, 41.62, 42.14, 42.92 },   /* #4   PM Shifts */
            new double[] { 41.91, 41.91, 42.75, 43.58, 44.43, 45.25, 45.81, 46.66 },   /* #5   Night Shifts */
            new double[] { 50.28, 50.28, 51.30, 52.31, 53.31, 54.29, 54.97, 55.98 },   /* #6   Saturday */
            new double[] { 58.67, 58.67, 59.85, 61.02, 62.20, 63.35, 64.12, 65.32 },   /* #7   Sunday */
            new double[] { 67.05, 67.05, 68.40, 67.74, 71.07, 72.39, 73.29, 74.64 },    /* #8  Public Holiday */
            //  PM, ND, Uniform & Laundry Allowances
            new double[] { 26.62, 66.02, 1.75, 0.46 },  /* #9   Standard */
            new double[] { 25.81, 61.93, 1.75, 0.46, 1.63, 0.44 },  /* #10  HealthScope, Ramsay & St John of God (Arcare - Index 4 & 5 > Uniform & Laundry Respectively) */
            new double[] { 55.35 }  /*  #11 EN Level - 2.3 Only - Weekend Rate  */
        };
        public double[][] PayArray
        {
            get { return payArray; }
        }
        //  END - PAYRATE ARRAY
    }
}
