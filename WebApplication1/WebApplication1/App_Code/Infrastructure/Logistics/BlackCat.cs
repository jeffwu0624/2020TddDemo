using WebApplication1.Models;

namespace WebApplication1.Infrastructure.Logistics
{
    public class BlackCat : ILogistics
    {
        private readonly string _companyName = "黑貓";

        private double _fee = 0;

        public void Calculated()
        {
            //ltrLogistics.Text = ddlLogistics.SelectedItem.Text;

            //var weight = Convert.ToDouble(txtWeight.Text);

            //if (weight > 20)
            //{
            //    ltrFee.Text = 500.ToString("C");
            //}
            //else
            //{
            //    ltrFee.Text = (100 + weight * 10).ToString("C");
            //}

            var weight = ShipProduct.Weight;

            if (weight > 20)
            {
                _fee = 500;
            }
            else
            {
                _fee = 100 + (weight * 10);
            }
        }

        public string GetCompanyName()
        {
            return _companyName;
        }

        public double GetFee()
        {
            return _fee;
        }

        public Product ShipProduct { get; set; }
    }
}