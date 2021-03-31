using System;
using WebApplication1.Infrastructure.Logistics;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCalculator_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                var product = GetProduct();

                var logistics = LogisticsFactory.CreateLogistics(product, ddlLogistics.SelectedValue);

                logistics.Calculated();

                ltrLogistics.Text = logistics.GetCompanyName();

                ltrFee.Text = logistics.GetFee().ToString("c");
            }
        }

        private Product GetProduct()
        {
            return new Product()
            {
                Weight = Convert.ToDouble(txtWeight.Text),
                Length = Convert.ToDouble(txtLength.Text),
                Width = Convert.ToDouble(txtWidth.Text),
                Height = Convert.ToDouble(txtHeight.Text),
            };
        }
    }
}