﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheTop.Application.Entities;
using TheTop.Application.Services;
using TheTop.Application.Services.DTOs;
using TheTop.ViewModels;

namespace TheTop.Controllers
{
    
    public class TasksController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITaskService _taskService;

        public TasksController(
            UserManager<ApplicationUser> userManager,
            ITaskService taskService
        )
        {
            _userManager = userManager;
            _taskService = taskService;
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<TaskDTO> taskDtoList = _taskService.GetAllTasks().ToList();
            List<TaskVM> taskVMList = new();
            taskDtoList.ForEach(task =>
            {
                taskVMList.Add(new TaskVM
                {
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Duration = task.Duration,
                    ID = task.ID,
                    Priority = task.Priority == PriorityType.High.ToString() ? PriorityType.High :
                        task.Priority == PriorityType.Low.ToString() ? PriorityType.Low : PriorityType.Med,
                    Status = task.Status == StatusType.Done.ToString() ? StatusType.Done :
                        task.Status == StatusType.InProgress.ToString() ? StatusType.InProgress : StatusType.Todo,
                    EmployeeVm = new EmployeeVM() 
                    {
                        FirstName = task.User.FirstName,
                        LastName = task.User.LastName,
                        Email = task.User.Email,
                        Username = task.User.Username,
                        //ImageName = task.User.ImagName
                    }
                });
            });
            return View(taskVMList);
        } //

        [Authorize(Roles = "Programmer")]
        public async Task<ActionResult> GetTasksProgrammer(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            List<TaskDTO> taskDtoList = _taskService.GetEmployeeTasks(user.Id).ToList();
            List<TaskVM> taskVMList = new();
            taskDtoList.ForEach(task =>
            {
                taskVMList.Add(new TaskVM
                {
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Duration = task.Duration,
                    ID = task.ID,
                    Priority = task.Priority == PriorityType.High.ToString() ? PriorityType.High :
                        task.Priority == PriorityType.Low.ToString() ? PriorityType.Low : PriorityType.Med,
                    Status = task.Status == StatusType.Done.ToString() ? StatusType.Done :
                        task.Status == StatusType.InProgress.ToString() ? StatusType.InProgress : StatusType.Todo,
                });
            });
            return View(taskVMList);
        } //

        [Authorize]
        public ActionResult Details(int id)
        {
            TaskDTO taskDto = _taskService.GetTaskById(id);
            TaskVM taskVM = new TaskVM
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                Duration = taskDto.Duration,
                ID = taskDto.ID,
                Priority = taskDto.Priority == PriorityType.High.ToString() ? PriorityType.High :
                    taskDto.Priority == PriorityType.Low.ToString() ? PriorityType.Low : PriorityType.Med,
                Status = taskDto.Status == StatusType.Done.ToString() ? StatusType.Done :
                    taskDto.Status == StatusType.InProgress.ToString() ? StatusType.InProgress : StatusType.Todo,
                EmployeeVm = new EmployeeVM() 
                {
                    FirstName = taskDto.User.FirstName,
                    LastName = taskDto.User.LastName,
                    Email = taskDto.User.Email,
                    Username = taskDto.User.Username,
                    //ImageName = task.User.ImagName
                }
            };


            return View(taskVM);
        } //

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create()
        {
            //var data = _userManager.Users.ToList();
            var employees = await _userManager.GetUsersInRoleAsync("Programmer");
            List<SelectListItem> employeeList = new();
            foreach (var e in employees)
            {
                employeeList.Add(new SelectListItem {Text = e.UserName, Value = e.Id});
            }

            TaskVM taskVM = new TaskVM();
            taskVM.Employees = employeeList;
            return View(taskVM);
        } //

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskVM taskVM)
        {
            if (!ModelState.IsValid)
            {
                return View(taskVM);
            }

            _taskService.CreateNewTask(new TaskDTO
            {
                ID = taskVM.ID,
                Title = taskVM.Title,
                Description = taskVM.Description,
                ApplicationUserId = taskVM.EmployeeId,
                Duration = taskVM.Duration,
                DueDate = taskVM.DueDate,
                Priority = taskVM.Priority.ToString(),
                Status = taskVM.Status.ToString(),
            });
            return RedirectToAction(nameof(Index));
        } //

        [Authorize]
        public async Task<ActionResult> Edit(int id)
        {
            TaskDTO taskDto = _taskService.GetTaskById(id);

            var employees = await _userManager.GetUsersInRoleAsync("Programmer");
            List<SelectListItem> employeeList = new();
            foreach (var e in employees)
            {
                employeeList.Add(new SelectListItem {Text = e.UserName, Value = e.Id});
            }

            TaskVM taskVM = new TaskVM()
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                Duration = taskDto.Duration,
                ID = taskDto.ID,
                Priority = taskDto.Priority == PriorityType.High.ToString() ? PriorityType.High :
                    taskDto.Priority == PriorityType.Low.ToString() ? PriorityType.Low : PriorityType.Med,
                Status = taskDto.Status == StatusType.Done.ToString() ? StatusType.Done :
                    taskDto.Status == StatusType.InProgress.ToString() ? StatusType.InProgress : StatusType.Todo,
                Employees = employeeList
            };

            return View(taskVM);
        } //

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskVM taskVM)
        {
            if (!ModelState.IsValid)
            {
                return View(taskVM);
            }

            _taskService.UpdateTask(new TaskDTO
            {
                ID = taskVM.ID,
                Title = taskVM.Title,
                Description = taskVM.Description,
                ApplicationUserId = taskVM.EmployeeId,
                Duration = taskVM.Duration,
                DueDate = taskVM.DueDate,
                Priority = taskVM.Priority.ToString(),
                Status = taskVM.Status.ToString(),
            });
            return RedirectToAction(nameof(Index));
        } //

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProgrammer(TaskVM taskVM)
        {
            _taskService.UpdateTask(new TaskDTO
            {
                ID = taskVM.ID,
                Title = taskVM.Title,
                Description = taskVM.Description,
                ApplicationUserId = taskVM.EmployeeId,
                Duration = taskVM.Duration,
                DueDate = taskVM.DueDate,
                Priority = taskVM.Priority.ToString(),
                Status = taskVM.Status.ToString(),
            });
            return RedirectToAction(nameof(GetTasksProgrammer));
        } //

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var taskDto = _taskService.GetTaskById(id);
            var taskVM = new TaskVM
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                ID = taskDto.ID,
            };

            return View(taskVM);
        } //

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTask(int id)
        {
            _taskService.RemoveTask(id);
            return RedirectToAction(nameof(Index));
        } //

    }
}