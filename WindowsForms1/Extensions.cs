using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsForms1;
public static class StringExtensions
{
    public static bool IsAnInteger(this string aStr)
    {
        try
        {
            int.Parse(aStr);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    public static double ConvertFractionToDecimal(this string aFraction)
    {
        if(aFraction.IsAFraction())
        {
        string[] fraction = aFraction.Trim(' ').Split('/');
        return double.Parse(fraction[Constants.NUMERATOR]) / double.Parse(fraction[Constants.DENOMINATOR]);

        }
        else
        {
            throw new NotAFractionException(string.Format("{0} is not a fraction", aFraction));
        }
    }

    public static bool IsAFraction(this string aFraction)
    {
        aFraction = aFraction.Trim();
        string[] parts = aFraction.Split('/');
        if (parts.Length < Constants.PARTSOFFRACTION)
            throw new NotAFractionException(string.Format("{0} is not a fraction.", aFraction));
        if (!(parts[Constants.NUMERATOR].IsAnInteger()) || !(parts[Constants.DENOMINATOR].IsAnInteger()))
            throw new NotAFractionException(string.Format(" In the fraction {0}, {1} or {2} is not a number.", aFraction, 
                parts[Constants.NUMERATOR], parts[Constants.DENOMINATOR]));
        return true;

    }

    public static List<string> GetWholeAndFractionalParts(this string aNumber)
    {
        List<string> parts = new List<string>();
        foreach (string s in aNumber.Split(' '))
        {
            if (!string.IsNullOrEmpty(s))
                parts.Add(s);
        }
        if (parts.Count > Constants.MIXEDNUMBERPARTS)
            throw new NotAMixedNumberException(string.Format("{0} is not a mixed or whole number", aNumber));
        return parts;
    }

    public static double ConvertMixedNumberToDecimal(this string aDimension)
    {
        double theValue = 0;
        List<string> DimensionParts = aDimension.GetWholeAndFractionalParts();

        if (DimensionParts[Constants.FRACTIONALPART].IsAFraction())
            theValue = DimensionParts[Constants.FRACTIONALPART].ConvertFractionToDecimal() +
                double.Parse(DimensionParts[Constants.WHOLEPART]);

        return theValue;
    }
}
