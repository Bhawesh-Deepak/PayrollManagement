﻿using HRMS.Admin.UI.AuthenticateService;
using HRMS.Core.Entities.Master;
using HRMS.Core.Entities.Payroll;
using HRMS.Core.Entities.UserManagement;
using HRMS.Core.ReqRespVm.RequestVm;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.UserManagement
{
    [CustomAuthenticate]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class UserLoginController : Controller
    {
        private readonly IGenericRepository<RoleMaster, int> _IRoleMasterRepoository;
        private readonly IGenericRepository<AuthenticateUser, int> _IAuthenticateRepository;
        private readonly IGenericRepository<EmployeeDetail, int> _IEmployeeDetailRepository;

        public UserLoginController(IGenericRepository<RoleMaster, int> roleMasterRepo,
            IGenericRepository<AuthenticateUser, int> authRepo, IGenericRepository<EmployeeDetail, int> employeeRepo)
        {
            _IRoleMasterRepoository = roleMasterRepo;
            _IAuthenticateRepository = authRepo;
            _IEmployeeDetailRepository = employeeRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public async task<iactionresult> createlogin(authenticateuser model)
        //{
        //    if (model.id)
        //        var response = await _iauthenticaterepository.createentity(model);
        //}

        private async Task PopulateViewBag()
        {
            var roleResponse = await _IRoleMasterRepoository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            ViewBag.Roles = roleResponse.Entities;

            var employeeResponse = await _IEmployeeDetailRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            ViewBag.EmployeeDetails = employeeResponse.Entities;
        }
    }
}
