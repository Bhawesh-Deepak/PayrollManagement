﻿using HRMS.Core.Helpers.CommonHelper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.UserManagement
{
    public class Profile : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View(ViewHelper.GetViewPathDetails("Profile", "_EmployeeProfile")));
        }
    }
}