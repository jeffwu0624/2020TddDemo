using WebApplication1.Models;

namespace WebApplication1.Infrastructure.Logistics
{
    public class Hsinchu : ILogistics
    {
        private readonly string _companyName = "新竹貨運";
        private double _fee = 0;

        public void Calculated()
        {
            //ltrLogistics.Text = ddlLogistics.SelectedItem.Text;

            //var width = Convert.ToDouble(txtWidth.Text);
            //var length = Convert.ToDouble(txtLength.Text);
            //var height = Convert.ToDouble(txtHeight.Text);

            //var size = (width * length * height);

            //if (length > 100 || width > 100 || height > 100)
            //{
            //    ltrFee.Text = (size * 0.0000353 * 1100 + 500).ToString("C");
            //}
            //else
            //{
            //    ltrFee.Text = (size * 0.0000353 * 1200).ToString("C");
            //}

            var width = ShipProduct.Width;
            var length = ShipProduct.Length;
            var height = ShipProduct.Height;

            var size = (width * length * height);

            if (length > 100 || width > 100 || height > 100)
            {
                _fee = (size * 0.0000353 * 1100 + 500);
            }
            else
            {
                _fee = (size * 0.0000353 * 1200);
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