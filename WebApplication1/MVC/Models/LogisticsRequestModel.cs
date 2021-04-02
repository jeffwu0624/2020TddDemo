using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LogisticsRequestModel
    {
        [Required]
        public string Name{get; set; }

        public string Height { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Weight { get; set; }
        public string LogisticsType { get; set; }
    }
}