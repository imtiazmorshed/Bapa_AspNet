using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.Framework
{
    public class CommonClass
    {

        public static string NumberInWord(string numeric)
        {
            int number = Convert.ToInt32(numeric);
            string strvalue = "";
            switch (number)
            {
                case 1:
                    strvalue = "one ";
                    break;

                case 2:
                    strvalue = "two ";
                    break;

                case 3:
                    strvalue = "three ";
                    break;

                case 4:
                    strvalue = "four ";
                    break;

                case 5:
                    strvalue = "five ";
                    break;

                case 6:
                    strvalue = "six ";
                    break;

                case 7:
                    strvalue = "seven ";
                    break;

                case 8:
                    strvalue = "eight ";
                    break;

                case 9:
                    strvalue = "nine ";
                    break;

                case 0:
                    strvalue = "";
                    break;

                default:
                    strvalue = "";
                    break;
            }

            return strvalue;
        }

        public static string TranslateNumber(decimal amount)
        {
            string number = amount.ToString();
            string[] strNumber = number.Split('.');

            string outputValue = "";

            int length = strNumber[0].Length;

            string currentNumber = "";
            string restNumber = "";
            string temp;
            if (length >= 8)
            {

                int cuttingX = 0;
                if (length == 10)
                {
                    currentNumber = strNumber[0].Substring(0, 3);
                    restNumber = strNumber[0].Substring(3, length - 3);
                }
                else if (length == 9)
                {
                    currentNumber = strNumber[0].Substring(0, 2);
                    restNumber = strNumber[0].Substring(2, length - 2);
                }
                else if (length == 8)
                {
                    currentNumber = strNumber[0].Substring(0, 1);
                    restNumber = strNumber[0].Substring(1, length - 1);
                }
                outputValue = outputValue + PseudoTranslator(currentNumber, "crore ");

                temp = restNumber;
                currentNumber = restNumber.Substring(0, 2);
                restNumber = temp.Substring(2, 5);
                outputValue = outputValue + PseudoTranslator(currentNumber, "lakh ");

                temp = restNumber;
                currentNumber = restNumber.Substring(0, 2);
                restNumber = temp.Substring(2, 3);
                outputValue = outputValue + PseudoTranslator(currentNumber, "thousand ");
                outputValue = outputValue + PseudoTranslator(restNumber, "");
            }
            else if (length > 5 && length < 8)
            {
                if (length == 7)
                {
                    currentNumber = strNumber[0].Substring(0, 2);
                    restNumber = strNumber[0].Substring(2, length - 2);
                    outputValue = outputValue + PseudoTranslator(currentNumber, "lakh ");

                    temp = restNumber;
                    currentNumber = restNumber.Substring(0, 2);
                    restNumber = temp.Substring(2, 3);
                    outputValue = outputValue + PseudoTranslator(currentNumber, "thousand ");
                    outputValue = outputValue + PseudoTranslator(restNumber, "");

                }
                else if (length == 6)
                {
                    currentNumber = strNumber[0].Substring(0, 1);
                    restNumber = strNumber[0].Substring(1, length - 1);
                    outputValue = outputValue + PseudoTranslator(currentNumber, "lakh ");

                    temp = restNumber;
                    currentNumber = restNumber.Substring(0, 2);
                    restNumber = temp.Substring(2, 3);
                    outputValue = outputValue + PseudoTranslator(currentNumber, "thousand ");
                    outputValue = outputValue + PseudoTranslator(restNumber, "");
                }
            }

            else if (length > 3 && length < 6)
            {
                if (length == 5)
                {
                    currentNumber = strNumber[0].Substring(0, 2);
                    restNumber = strNumber[0].Substring(2, length - 2);
                    outputValue = outputValue + PseudoTranslator(currentNumber, "thousand ");
                    outputValue = outputValue + PseudoTranslator(restNumber, "");
                }
                else if (length == 4)
                {
                    currentNumber = strNumber[0].Substring(0, 1);
                    restNumber = strNumber[0].Substring(1, length - 1);
                    outputValue = outputValue + PseudoTranslator(currentNumber, "thousand ");
                    outputValue = outputValue + PseudoTranslator(restNumber, "");
                }
            }
            else if (length < 4)
            {
                outputValue = outputValue + PseudoTranslator(strNumber[0], "");
            }
            //outputValue = outputValue+PseudoTranslator(strNumber[0]);
            if (strNumber.Count() > 1)
            {
                outputValue = outputValue + TranslateAfterPoint(strNumber[1]);
            }
            return outputValue;
        }

        public static string TranslateAfterPoint(string p)
        {
            string returnstr = "";
            int number = Convert.ToInt32(p);
            if (number > 0)
            {
                returnstr = " point";
                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i] == '0')
                    {
                        returnstr = returnstr + " zero";
                    }
                    else
                    {
                        returnstr = returnstr + " " + NumberInWord(p[i].ToString());
                    }
                }
            }

            return returnstr;
        }

        public static string PseudoTranslator(string p, string postfix)
        {
            string number = "";

            string first = "";
            string rest = "";

            if (p.Length == 3)
            {
                number = number + NumberInWord(p.Substring(0, 1));//+ " hundred ";
                if (Convert.ToInt32(p.Substring(0, 1)) > 0)
                {
                    number = number + " hundred ";
                }
                number = number + TwoDecimmalTranslation(p.Substring(1, p.Length - 1));
            }
            else if (p.Length > 0)
            {
                number = number + TwoDecimmalTranslation(p);
            }
            if (Convert.ToInt32(p) > 0)
            {
                number = number + " " + postfix;
            }

            return number;//+" "+postfix;
        }

        public static string TwoDecimmalTranslation(string p)
        {
            string t = "";
            int value = Convert.ToInt32(p);
            if (p.Length > 1)
            {
                if (value == 10)
                {
                    t = "ten ";
                }
                if (value == 11)
                {
                    t = "eleven ";
                }
                if (value == 12)
                {
                    t = "twelve ";
                }
                if (value == 13)
                {
                    t = "thirteen ";
                }
                if (value == 14)
                {
                    t = "fourteen ";
                }
                if (value == 15)
                {
                    t = "fifteen ";
                }
                if (value > 15 && value < 20)
                {
                    t = NumberInWord(value.ToString().Substring(1, 1)).Trim() + "teen ";
                }
                if (value == 30)
                {
                    t = "thirty ";
                }
                if (value > 19 && value < 30)
                {
                    t = "twenty " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 30 && value < 40)
                {
                    t = "thirty " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 40 && value < 50)
                {
                    t = "forty " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 50 && value < 60)
                {
                    t = "fifty " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 60 && value < 70)
                {
                    t = "sixty " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 70 && value < 80)
                {
                    t = "seventy " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 80 && value < 90)
                {
                    t = "eighty " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
                if (value >= 90 && value < 100)
                {
                    t = "ninety " + NumberInWord(value.ToString().Substring(1, 1)).Trim();
                }
            }
            else
            {
                t = NumberInWord(p);
            }
            return t;
        }
    }
}
