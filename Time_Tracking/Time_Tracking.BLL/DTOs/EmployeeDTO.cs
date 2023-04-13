﻿using System.ComponentModel.DataAnnotations;
using Time_Tracking.DAL.Entities.Models;

namespace Time_Tracking.BLL.DTOs;

public class EmployeeDTO : Employee
{
    public int Id { get; set; }

    [Required(ErrorMessage = "FirstName is required")]
    [StringLength(50, ErrorMessage = "FirstName length should be between 5 to 50 characters", MinimumLength = 5)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "LastName is required")]
    [StringLength(50, ErrorMessage = "LastName length should be between 5 to 50 characters", MinimumLength = 5)]
    public string LastName { get; set; }

    public string FullName { get; set; }

    [Required(ErrorMessage = "Department name is required")]
    [StringLength(50, ErrorMessage = "Department length should be between 5 to 50 characters", MinimumLength = 5)]
    public string Department { get; set; }
}