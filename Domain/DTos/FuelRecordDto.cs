﻿namespace FuelProject.Domain.DTos
{
    public class FuelRecordDto
    {
        public string NameOfFuelStation { get; set; }
        public float FuelAmount { get; set; }
        public int DashboardKms { get; set; }
        public float PricePerLiter { get; set; }
        public float TotalPrice { get; set; }
        public string CarId { get; set; }
    }
}