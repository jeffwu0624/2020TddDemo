using WebApplication1.Models;

namespace WebApplication1.Infrastructure.Logistics
{
    public class PostOffice : ILogistics
    {
        private readonly string _companyName = "郵局";
        private double _fee = 0;

        public void Calculated()
        {
            //ltrLogistics.Text = ddlLogistics.SelectedItem.Text;

            //var weight = Convert.ToDouble(txtWeight.Text);
            //var feeByWeight = 80 + (weight * 10);

            //var width = Convert.ToDouble(txtWidth.Text);
            //var length = Convert.ToDouble(txtLength.Text);
            //var height = Convert.ToDouble(txtHeight.Text);

            //var size = width * length * height;
            //var feeBySize = size * 0.0000353 * 1100;

            //if (feeByWeight < feeBySize)
            //{
            //    ltrFee.Text = feeByWeight.ToString("C");
            //}
            //else
            //{
            //    ltrFee.Text = feeBySize.ToString("C");
            //}

            var weight = ShipProduct.Weight;
            var feeByWeight = 80 + (weight * 10);

            var width = ShipProduct.Width;
            var length = ShipProduct.Length;
            var height = ShipProduct.Height;

            var size = width * length * height;
            var feeBySize = size * 0.0000353 * 1100;

            if (feeByWeight < feeBySize)
            {
                _fee = feeByWeight;
            }
            else
            {
                _fee = feeBySize;
            }
        }

        public Product ShipProduct { get; set; }

        public string GetCompanyName()
        {
            return _companyName;
        }

        public double GetFee()
        {
            return _fee;
        }
    }
}