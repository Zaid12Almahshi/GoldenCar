using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class VecihleModel
    {
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public double Price_Per_Day { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
    }
    public class AddVecihleModel
    {
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public double Price_Per_Day { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string CreateId { get; set; } = string.Empty;

    }
    public class UpdateVecihleModel
    {
        public string VecihleId { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public double Price_Per_Day { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string EditId { get; set; } = string.Empty;
    }
    public class GetVecihlByIdModel
    {
        public string VecihleId { get; set; } = string.Empty;
    }
    public class DeleteVecihleModel
    {
        public string VecihleId { get; set; } = string.Empty;
        public string EditId { get; set; } = string.Empty;
    }
    public class ActiveVecihleModel
    {
        public string VecihleId { get; set; } = string.Empty;
        public string EditId { get; set; } = string.Empty;
    }
}
