using UnityEngine;
using System.Collections;

public class BigNumberDisplay {


    public static string ConvertNumber(double number, double divider)
    {
        int multiplier = 0;
        while(number > divider*1000)
        {
            divider *= 1000;
            multiplier++;
        }
        string result = "";
        if (number % divider != 0)
        {
            result = (((int)(number / divider)).ToString().Length > 3 ? ((int)(number / divider)).ToString().Substring(0, 3) : ((int)(number / divider)).ToString()) +
                "." +
               (((int)(number % divider)).ToString().Length > 2 ? ((int)(number % divider)).ToString().Substring(0, 2) : ((int)(number % divider)).ToString());
        }
        else
        {
            result = (((int)(number / divider)).ToString().Length > 3 ? ((int)(number / divider)).ToString().Substring(0, 3) : ((int)(number / divider)).ToString());
        }

        //add more but no more than range of double
        switch(multiplier)
        {
            case 0:
                result = result.Split('.')[0];
                break;
            case 1:
                result += "K";
                break;
            case 2:
                result += "M";
                break;
            case 3:
                result += "B";
                break;
            case 4:
                result += "q";
                break;
            case 5:
                result += "Q";
                break;
            case 6:
                result += "s";
                break;
            case 7:
                result += "S";
                break;
            case 8:
                result += "O";
                break;
        }
        
        return result;
    }
}
