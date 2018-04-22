using Resistor_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resistor_Calculator.Controllers
{
    public class ResistorCalculatorController : Controller
    {
        ResistorData Rd = new ResistorData();
        // GET: Resistor_Calculator

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            Rd.LoadData();
            return View(Rd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resistorData"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Index(ResistorData resistorData) 
        {
            JsonResult jsonResult = new JsonResult();
            try
            {
                if (ModelState.IsValid)
                {
                    Rd.LoadData();
                    int resisterVal = Rd.CalculateOhmValue(resistorData.SelectedBandColor1, resistorData.SelectedBandColor2, resistorData.SelectedMultiplier, resistorData.SelectedTolerance);
                    ViewBag.ResistorValue = resisterVal;
                    Rd.ResistorValue = resisterVal.ToString();
                    jsonResult.Data = Rd.ResistorValue;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jsonResult;
        }
       
    }
}
