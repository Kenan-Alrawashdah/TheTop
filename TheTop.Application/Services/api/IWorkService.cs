﻿using System;
using TheTop.Application.Entities;
using TheTop.Application.Services.DTOs;

namespace TheTop.Application.Services
{
    public interface IWorkService
    {
        void StartWork(WorkDTO workDto);
        void EndWork(WorkDTO workDto);
        Work FindStartDate(DateTime date, string userId);
        Work FindEndDate(DateTime date, string userId);
    }
}