using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using TheTop.Application.Entities;
using TheTop.Application.Services;
using TheTop.ViewModels;

namespace TheTop.Controllers
{
    public class ReportsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IReportService _reportService;

        public ReportsController(
            UserManager<ApplicationUser> userManager,
            IReportService reportService
        )
        {
            _userManager = userManager;
            _reportService = reportService;
        }


        public IActionResult GetMonthlySellsReport(bool asPdf)
        {
            var report = _reportService.GetMonthlySellsReport();
            var sellsReportVM = new SellsReportVM()
            {
                DateTim = report.DateTim,
                Orders = report.orders.Select(order => new OrderVM()
                {
                    CreatedAT = order.CreatedAt,
                    TotalPrice = order.TotalPrice,
                    DiscountPrice = order.DiscountPrice
                }).ToList(),
                TotalPrice = report.TotalPrice,
                SellsCount = report.SellsCount,
                Profit = report.Profit, 
                asPdf = asPdf
            };
            
            return asPdf ? new ViewAsPdf(sellsReportVM) : View(sellsReportVM);
        }

        public IActionResult GetAnnualSellsReport(bool asPdf, DateTime searchDate)
        {
            var report = _reportService.GetAnnualSellsReport(searchDate);
            var sellsReportVM = new SellsReportVM()
            {
                DateTim = report.DateTim,
                Orders = report.orders.Select(order => new OrderVM()
                {
                    CreatedAT = order.CreatedAt,
                    TotalPrice = order.TotalPrice,
                    DiscountPrice = order.DiscountPrice
                }).ToList(),
                TotalPrice = report.TotalPrice,
                SellsCount = report.SellsCount,
                Profit = report.Profit,
                asPdf = asPdf,
                SearchDate = searchDate,
            };

            return asPdf ? new ViewAsPdf(sellsReportVM) : View(sellsReportVM);
        }

        public IActionResult GetMonthlyEmployeeSalariesReport( bool asPdf)
        {
            var report = _reportService.GetMonthlySalariesReport();
            var employeeSalariesReportVM = new MonthlyEmployeeSalariesReportVM()
            {
                
                asPdf = asPdf,
                TotalSalaries = report.TotalSalaries,
                TotalWorkingHours = report.TotalWorkingHours,
                Employees = report.Employees.Select(employee => new EmployeeSalaryVM()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    ShouldSalary = employee.ShouldSalary,
                    HourSalary = employee.HourSalary,
                    ShouldWorkingHours = employee.ShouldWorkingHours,
                    WorkingHours = employee.WorkingHours
                }).ToList(),
                Month = report.Month,
                DateTim = report.DateTie,
            };

            return asPdf ? new ViewAsPdf(employeeSalariesReportVM) : View(employeeSalariesReportVM);
        }

        public IActionResult GetAnnualEmployeeSalariesReport(bool asPdf)
        {
            var annualEmployeeSalariesReport = _reportService.GetAnnualEmployeeSalariesReport();
            var annualEmployeeSalariesReportVM = new AnnualEmployeeSalariesReportVM()
            {
                asPdf = asPdf,
                DateTim = annualEmployeeSalariesReport.DateTim,
                TotalWorkingHours = annualEmployeeSalariesReport.TotalWorkingHours,
                TotalSalaries = annualEmployeeSalariesReport.TotalSalaries,
                MonthlyEmployeesSalariesReporrtsVM =
                annualEmployeeSalariesReport.MonthlyEmployeesSalariesReporrts.Select(report =>
                new MonthlyEmployeeSalariesReportVM()
                        {
                            TotalSalaries = report.TotalSalaries,
                            TotalWorkingHours = report.TotalWorkingHours,
                            Month = report.Month,
                            DateTim = report.DateTie,
                            Employees = report.Employees.Select(employee => new EmployeeSalaryVM()
                            {
                                FirstName = employee.FirstName,
                                LastName = employee.LastName,
                                Email = employee.Email,
                                Salary = employee.Salary,
                                ShouldSalary = employee.ShouldSalary,
                                HourSalary = employee.HourSalary,
                                ShouldWorkingHours = employee.ShouldWorkingHours,
                                WorkingHours = employee.WorkingHours
                            }).ToList()
                        }).ToList()
            };

            return asPdf ? new ViewAsPdf(annualEmployeeSalariesReportVM) : View(annualEmployeeSalariesReportVM);
        }

        public IActionResult GetMonthlySalarySlip(bool asPdf)
        {
            var report = _reportService.GetMonthlySalarySlip(_userManager.GetUserId(User));
            var monthlySlip = new EmployeeSalaryVM()
            {
                asPdf = asPdf,
                FirstName = report.FirstName,
                LastName = report.LastName,
                Email = report.Email,
                HourSalary = report.HourSalary,
                Salary = report.Salary,
                ShouldSalary = report.ShouldSalary,
                ShouldWorkingHours = report.ShouldWorkingHours,
                WorkingHours = report.WorkingHours,
                DateTim = report.DateTim,
            };
            return asPdf ? new ViewAsPdf(monthlySlip) : View(monthlySlip);
        }
    }
}