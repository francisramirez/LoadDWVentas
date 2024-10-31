﻿

using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDWVentas.Data.Entities.DwVentas
{
    [Table("DimEmployees")]
    public class DimEmployee
    {
        public int EmployeeKey { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
    }
}
