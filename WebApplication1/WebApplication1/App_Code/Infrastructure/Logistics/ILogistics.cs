using WebApplication1.Models;

namespace WebApplication1.Infrastructure.Logistics
{
    public interface ILogistics
    {
        void Calculated();
        string GetCompanyName();
        double GetFee();
        Product ShipProduct { get; set; }
    }
}