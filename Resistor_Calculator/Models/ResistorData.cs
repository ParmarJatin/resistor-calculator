using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resistor_Calculator.Models
{
    public class ResistorData : IOhmValueCalculator
    {
        public IEnumerable<SelectListItem> BandColors;

        public IEnumerable<SelectListItem> Multipliers;

        public IEnumerable<SelectListItem> Tolerances;

        public string SelectedBandColor1 { get; set; }

        public string SelectedBandColor2 { get; set; }

        public string SelectedMultiplier { get; set; }

        public string SelectedTolerance { get; set; }

        public string ResistorValue = string.Empty;

        private const string PINK = "PINK";
        private const string SILVER = "SILVER";
        private const string GOLD = "GOLD";
        private const string NONE = "NONE";

        /// <summary>
        /// Loading all the default data to list and creating selected list for dropdown values
        /// </summary>
        public void LoadData()
        { 
            LoadBandData();
            LoadMultiplierData();
            LoadToleranceData();
        }

        /// <summary>
        /// loading all band colors to list
        /// </summary>
        private void LoadBandData()
        {
            List<BandColor.Colors> lstBandColor = new List<BandColor.Colors>
            {
                BandColor.Colors.BLACK,
                BandColor.Colors.BROWN,
                BandColor.Colors.RED,
                BandColor.Colors.ORANGE,
                BandColor.Colors.YELLOW,
                BandColor.Colors.GREEN,
                BandColor.Colors.BLUE,
                BandColor.Colors.VIOLET,
                BandColor.Colors.GRAY,
                BandColor.Colors.WHITE
            };

            BandColors = lstBandColor.Select(color => new SelectListItem { Value = color.ToString(), Text = color.ToString() });

        }

        /// <summary>
        /// loading all Multiplier data to list
        /// </summary>
        private void LoadMultiplierData()
        {
            List<string> lstMultiplier = new List<string>
            {
                PINK + " @ "+Multiplier.PinkMultiplier,
                SILVER +" @ "+Multiplier.SilverMultiplier,
                GOLD+" @ "+Multiplier.GoldMultiplier,
                BandColor.Colors.BLACK +" @ "+ Multiplier.BlackMultiplier,
                BandColor.Colors.BROWN +" @ "+Multiplier.BrownMultiplier,
                BandColor.Colors.RED +" @ "+Multiplier.RedMultiplier,
                BandColor.Colors.ORANGE +" @ "+Multiplier.OrangeMultiplier,
                BandColor.Colors.YELLOW +" @ "+ Multiplier.YellowMultiplier,
                BandColor.Colors.GREEN +" @ "+Multiplier.GreenMultiplier,
                BandColor.Colors.BLUE +" @ "+Multiplier.BlueMultiplier,
                BandColor.Colors.VIOLET +" @ "+Multiplier.VioletMultiplier,
                BandColor.Colors.GRAY +" @ "+Multiplier.GrayMultiplier,
                BandColor.Colors.WHITE +" @ "+Multiplier.WhiteMultiplier
            };

            Multipliers = lstMultiplier.Select(multiplier => new SelectListItem { Value = multiplier, Text = multiplier });
        }

        /// <summary>
        /// loading all Tolerance data to list..
        /// </summary>
        private void LoadToleranceData()
        {
            List<string> lstTolerance = new List<string>
            {
                NONE + " @ " +Tolerance.NoneTolerance,
                PINK + " @ "+Tolerance.PinkTolerance,
                SILVER + " @ "+Tolerance.SilverTolerance,
                GOLD +" @ "+Tolerance.GoldTolerance,
                BandColor.Colors.BLACK +" @ "+Tolerance.BlackTolerance,
                BandColor.Colors.BROWN +" @ "+ Tolerance.BrownTolerance,
                BandColor.Colors.RED +" @ "+Tolerance.RedTolerance,
                BandColor.Colors.ORANGE +" @ "+ Tolerance.OrangeTolerance,
                BandColor.Colors.YELLOW +" @ "+Tolerance.YellowTolerance,
                BandColor.Colors.GREEN +" @ "+Tolerance.GreenTolerance,
                BandColor.Colors.BLUE +" @ "+Tolerance.BlueTolerance,
                BandColor.Colors.VIOLET +" @ "+ Tolerance.VioletTolerance,
                BandColor.Colors.GRAY +" @ "+ Tolerance.GrayTolerance,
                BandColor.Colors.WHITE +" @ "+Tolerance.WhiteTolerance
            };

            Tolerances = lstTolerance.Select(tolerance => new SelectListItem { Value = tolerance, Text = tolerance });
        }

        /// <summary>
        /// interface method.. calculating value using all the selected data.
        /// </summary>
        /// <param name="bandAColor"></param>
        /// <param name="bandBColor"></param>
        /// <param name="bandCColor"></param>
        /// <param name="bandDColor"></param>
        /// <returns></returns>
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            int totalVal = 0;
            try
            {
                int bandAVAlue = GetBandColorValue(bandAColor);
                int bandBValue = GetBandColorValue(bandBColor);
                double bandCValue = GetMultiplierValue(bandCColor);
                double bandDValue = GetToleranceValue(bandDColor);
                double bandABValue = int.Parse(bandAVAlue.ToString() + bandBValue.ToString());
                double value = (double)(bandABValue * bandCValue);
                double percentVal = (value * bandDValue) / 100;
                totalVal = (int)(value - percentVal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return totalVal;
        }

        /// <summary>
        /// get value for selected color
        /// </summary>
        /// <param name="bandcolor"></param>
        /// <returns></returns>
        private int GetBandColorValue(string bandcolor)
        {
            switch (bandcolor.ToUpper())
            {
                case "BLACK":
                    return (int)BandColor.Colors.BLACK;
                case "BROWN":
                    return (int)BandColor.Colors.BROWN;
                case "RED":
                    return (int)BandColor.Colors.RED;
                case "ORANGE":
                    return (int)BandColor.Colors.ORANGE;
                case "YELLOW":
                    return (int)BandColor.Colors.YELLOW;
                case "GREEN":
                    return (int)BandColor.Colors.GREEN;
                case "BLUE":
                    return (int)BandColor.Colors.BLUE;
                case "VIOLET":
                    return (int)BandColor.Colors.VIOLET;
                case "GRAY":
                    return (int)BandColor.Colors.GRAY;
                case "WHITE":
                    return (int)BandColor.Colors.WHITE;
            }
            return 0;
        }

        /// <summary>
        /// get value for selected multiplier 
        /// </summary>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        private double GetMultiplierValue(string multiplier)
        {
            double mValue = 0;

            string[] data = multiplier.Split('@');

            try
            {
                if (data != null && data.Length > 1 && data[1] != null && data[1] != string.Empty)
                {
                    var plierVal = data[1].ToString().Trim();
                    switch (plierVal)
                    {
                        case "x0.001":
                            mValue = 0.001;
                            break;
                        case "×0.01":
                            mValue = 0.01;
                            break;
                        case "x0.1":
                            mValue = 0.1;
                            break;
                        case "x1":
                            mValue = 1;
                            break;
                        case "x10":
                            mValue = 10;
                            break;
                        case "x100":
                            mValue = 100;
                            break;
                        case "x1000":
                            mValue = 1000;
                            break;
                        case "x10 000":
                            mValue = 10000;
                            break;
                        case "x100 000":
                            mValue = 100000;
                            break;
                        case "x1 000 000":
                            mValue = 1000000;
                            break;
                        case "x10 000 000":
                            mValue = 10000000;
                            break;
                        case "x100 000 000":
                            mValue = 100000000;
                            break;
                        case "x1 000 000 000":
                            mValue = 1000000000;
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return mValue;
        }

        /// <summary>
        /// get value for selected tolerance
        /// </summary>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        private double GetToleranceValue(string tolerance)
        {
            double tValue = 0;

            string[] data = tolerance.Split('@');

            try
            {
                if (data!=null && data.Length > 1 && data[1] != null && data[1] != string.Empty)
                {
                    var ranceVal = data[1].ToString().Trim();
                    switch (ranceVal)
                    {
                        case "20%":
                            tValue = 20;
                            break;
                        case "-":
                            tValue = 0;
                            break;
                        case "10%":
                            tValue = 10;
                            break;
                        case "5%":
                            tValue = 5;
                            break;
                        case "1%":
                            tValue = 1;
                            break;
                        case "2%":
                            tValue = 2;
                            break;
                        case "0.5%":
                            tValue = 0.5;
                            break;
                        case "0.25%":
                            tValue = 0.25;
                            break;
                        case "0.1%":
                            tValue = 0.1;
                            break;
                        case "0.05%":
                            tValue = 0.05;
                            break;
                        default:
                            tValue = 20;
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return tValue;
        }
    }
}