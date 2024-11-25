using System;
using System.Collections.Generic;

namespace DatabaseFirstEFCore.Models;

public partial class Employee
{
    public string Name { get; set; } = null!;

    public string Designation { get; set; } = null!;

    public int Salary { get; set; }

    public long Id { get; set; }

    public string Status { get; set; } = null!;
}
