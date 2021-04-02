using System;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LogisticsRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var result = new LogisticsResponseModel();

                if ("1".Equals(request.LogisticsType))
                {
                    result.LogisticsName = "黑貓";
                    var weight = Convert.ToDouble(request.Weight);

                    if (weight > 20)
                    {
                        result.Fee = 500;
                    }
                    else
                    {
                        result.Fee = (100 + weight * 10);
                    }
                }
                else if ("2".Equals(request.LogisticsType))
                {
                    result.LogisticsName = "新竹貨運";

                    var width = Convert.ToDouble(request.Width);
                    var length = Convert.ToDouble(request.Length);
                    var height = Convert.ToDouble(request.Height);

                    var size = (width * length * height);

                    if (length > 100 || width > 100 || height > 100)
                    {
                        result.Fee = (size * 0.0000353 * 1100 + 500);
                    }
                    else
                    {
                        result.Fee = (size * 0.0000353 * 1200);
                    }
                }
                else if ("3".Equals(request.LogisticsType))
                {
                    result.LogisticsName = "郵局";

                    var weight = Convert.ToDouble(request.Weight);
                    var feeByWeight = 80 + (weight * 10);

                    var width = Convert.ToDouble(request.Width);
                    var length = Convert.ToDouble(request.Length);
                    var height = Convert.ToDouble(request.Height);

                    var size = width * length * height;
                    var feeBySize = size * 0.0000353 * 1100;

                    if (feeByWeight < feeBySize)
                    {
                        result.Fee = feeByWeight;
                    }
                    else
                    {
                        result.Fee = feeBySize;
                    }
                }

                return View("Result", result);
            }

            return View(request);
        }
    }
}