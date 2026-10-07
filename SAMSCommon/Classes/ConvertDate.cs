using System;
using System.Collections.Generic;
using System.Text;

namespace SAMSCommon.Classes
{
    public class ConvertDate
    {

        public static String British_To_American(string britishDate)
        {
            string americanDate = "";
            if (!checkDateString(britishDate))
            {
                throw (new Exception("parameter: britishDate, Invalid date format(please supply the in 'dd-MM-yyyy'"));
            }
            else
            {
                String[] arrDate = britishDate.Split('/');

                if (Convert.ToInt32(arrDate[2]) >= 0000 && Convert.ToInt32(arrDate[2]) > 9999)
                    throw (new Exception("parameter: britishDate, Invalid year please enter between(0000-9999)"));

                if (Convert.ToInt32(arrDate[0]) < 1 || Convert.ToInt32(arrDate[0]) > 31 || !checkDays(Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]), Convert.ToInt32(arrDate[2])))
                    throw (new Exception("parameter: britishDate, Invalid Day please enter between(1-31)"));

                if (Convert.ToInt32(arrDate[1]) < 1 && Convert.ToInt32(arrDate[2]) > 12)
                    throw (new Exception("parameter: britishDate, Invalid Month please enter between(1-12)"));


                americanDate = arrDate[1] + '/' + arrDate[0] + '/' + arrDate[2];
            }

            return americanDate;
        }

        public static String British_To_American2(string britishDate)
        {
            string americanDate = "";
            if (!checkDateString2(britishDate))
            {
                throw (new Exception("parameter: britishDate, Invalid date format(please supply the in 'dd-MM-yyyy'"));
            }
            else
            {
                String[] arrDate = britishDate.Split('-');

                if (Convert.ToInt32(arrDate[2]) >= 0000 && Convert.ToInt32(arrDate[2]) > 9999)
                    throw (new Exception("parameter: britishDate, Invalid year please enter between(0000-9999)"));

                if (Convert.ToInt32(arrDate[0]) < 1 || Convert.ToInt32(arrDate[0]) > 31 || !checkDays(Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]), Convert.ToInt32(arrDate[2])))
                    throw (new Exception("parameter: britishDate, Invalid Day please enter between(1-31)"));

                if (Convert.ToInt32(arrDate[1]) < 1 && Convert.ToInt32(arrDate[2]) > 12)
                    throw (new Exception("parameter: britishDate, Invalid Month please enter between(1-12)"));


                americanDate = arrDate[2] + '-' + arrDate[1] + '-' + arrDate[0];
            }

            return americanDate;
        }

        private static bool checkDateString2(String date)
        {

            if (date == "")
                return false;

            if (!date.Contains("-"))
                return false;

            if (date.Length < 10)
                return false;

            return true;

        }

        public static String American_To_British(string americanDate)
        {
            string britishDate = "";
            if (!checkDateString(britishDate))
            {
                throw (new Exception("parameter: americanDate, Invalid date format(please supply the in 'MM-dd-yyyy'"));
            }
            else
            {
                String[] arrDate = americanDate.Split('-');

                if (Convert.ToInt32(arrDate[2]) >= 1753 && Convert.ToInt32(arrDate[2]) >= 9999 == false)
                    throw (new Exception("parameter: americanDate, Invalid year please enter between(1753-9999)"));

                if (Convert.ToInt32(arrDate[0]) < 1 || Convert.ToInt32(arrDate[0]) > 31 || !checkDays(Convert.ToInt32(arrDate[1]), Convert.ToInt32(arrDate[0]), Convert.ToInt32(arrDate[2])))
                    throw (new Exception("parameter: americanDate, Invalid Day please enter between(1-31)"));

                if (Convert.ToInt32(arrDate[2]) < 1 || Convert.ToInt32(arrDate[2]) > 12)
                    throw (new Exception("parameter: americanDate, Invalid Month please enter between(1-12)"));


                britishDate = arrDate[1] + '-' + arrDate[0] + '-' + arrDate[2];
            }

            return britishDate;
        }

        private static bool checkDateString(String date)
        {

            if (date == "")
                return false;

            if (!date.Contains("/"))
                return false;

            if (date.Length < 10)
                return false;

            return true;

        }

        private static bool checkDays(int days, int month, int year)
        {
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                if (days > 31)
                    return false;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (days > 30)
                    return false;
            }
            else if (month == 2)
            {
                //impliment leap year check..
                if (days > 29)
                    return false;
            }

            return true;
        }
    }
}
