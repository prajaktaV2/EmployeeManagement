﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Models
{
    public class SalesResponse
    {
        public string ProductName {  get; set; }=string.Empty;
        public double TotalSales { get; set; }
    }
}
