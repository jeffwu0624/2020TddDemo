using System;

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

                var logistics = CreateLogistics(product, ddlLogistics.SelectedValue);

                logistics.Calculated();

                ltrLogistics.Text = logistics.GetCompanyName();

                ltrFee.Text = logistics.GetFee().ToString("c");
            }
        }

        private ILogistics CreateLogistics(Product product, string logisticsSelectedValue)
        {
            //string companyName;
            //double fee;
            //if ("1".Equals(ddlLogistics.SelectedValue))
            //{
            //    // 計算
            //    var blackCat = new BlackCat() {ShipProduct = product};
            //    blackCat.Calculated();

            //    // 顯示結果
            //    companyName = blackCat.GetCompanyName();
            //    fee = blackCat.GetFee();
            //}
            //else if ("2".Equals(ddlLogistics.SelectedValue))
            //{
            //    var hsinchu = new Hsinchu() {ShipProduct = product};
            //    hsinchu.Calculated();

            //    companyName = hsinchu.GetCompanyName();
            //    fee = hsinchu.GetFee();
            //}
            //else if ("3".Equals(ddlLogistics.SelectedValue))
            //{
            //    var postOffice = new PostOffice() {ShipProduct = product};
            //    postOffice.Calculated();

            //    companyName = postOffice.GetCompanyName();
            //    fee = postOffice.GetFee();
            //}

            if ("1".Equals(logisticsSelectedValue))
            {
                // 計算
                return new BlackCat() {ShipProduct = product};
            }
            else if ("2".Equals(logisticsSelectedValue))
            {
                return new Hsinchu() {ShipProduct = product};
            }
            else if ("3".Equals(logisticsSelectedValue))
            {
                return new PostOffice() {ShipProduct = product};
            }

            throw new ArgumentException("No Match Logistics");
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

    public interface ILogistics
    {
        void Calculated();
        string GetCompanyName();
        double GetFee();
        Product ShipProduct { get; set; }
    }

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

    public class Product
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
    }
}