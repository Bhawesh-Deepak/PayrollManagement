﻿using HRMS.Core.Entities.Common;
using HRMS.Core.Entities.Master;
using HRMS.Core.Helpers.CommonHelper;
using HRMS.Core.Helpers.ExcelHelper;
using HRMS.Core.ReqRespVm.Response.Reporting;
using HRMS.Core.ReqRespVm.SqlParams;
using HRMS.Services.Implementation.SqlConstant;
using HRMS.Services.Repository.GenericRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Admin.UI.Controllers.Reporting
{
    public class BonusRegisterController : Controller
    {
        private readonly IDapperRepository<BonusRegisterParams> _BonusRegisterRepository;
        private readonly IGenericRepository<AssesmentYear, int> _IAssesmentYearRepository;
        private readonly IHostingEnvironment _IHostingEnviroment;
        public BonusRegisterController(IDapperRepository<BonusRegisterParams> bonusRegisterRepo , IHostingEnvironment hostingEnvironment, IGenericRepository<AssesmentYear, int> assesmentyearRepo)
        {
            _BonusRegisterRepository = bonusRegisterRepo;
            _IHostingEnviroment = hostingEnvironment;
            _IAssesmentYearRepository = assesmentyearRepo;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                await PopulateViewBag();
                return await Task.Run(() => View(ViewHelper.GetViewPathDetails("BonusRegister", "_BonusRegisterIndex")));
            }
            catch (Exception ex)
            {
                string template = $"Controller name {nameof(BonusRegisterController)} action name {nameof(Index)} exception is {ex.Message}";
                Serilog.Log.Error(ex, template);
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DownloadBonusRegister(MediClaimSqlParams model, IFormFile UploadFile)
        {
            string empresponse = null;
            if (UploadFile != null) { empresponse = new ReadEmployeeCode().GetSalaryRegisterEmpCodeDetails(UploadFile); }
            var sqlParams = new BonusRegisterParams()
            {
                DateYear = model.DateYear,
                DateMonth = model.DateMonth,
                EmployeeCode = empresponse
            };
            var response = _BonusRegisterRepository.GetAll<BonusRegisterVM>(SqlQuery.GetBonusRegister, sqlParams);
            var sWebRootFolder = _IHostingEnviroment.WebRootPath;
            var sFileName = @"BonusRegister.xlsx";
            var URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            if (file.Exists)
            {
                file.Delete();
                file = new FileInfo(fileName: Path.Combine(sWebRootFolder, sFileName));
            }
            ExcelPackage Eps = new ExcelPackage();
            ExcelWorksheet Sheets = Eps.Workbook.Worksheets.Add("Bonus");
            Sheets.Cells["A1"].Value = "Employee Code";
            Sheets.Cells["B1"].Value = "Employee Name";
            Sheets.Cells["C1"].Value = "Moth";
            Sheets.Cells["D1"].Value = "Year";
            Sheets.Cells["E1"].Value = "Bonus Amount";

            int row = 2;
            foreach (var data in response)
            {
                Sheets.Cells[string.Format("A{0}", row)].Value = data.EmpCode;
                Sheets.Cells[string.Format("B{0}", row)].Value = data.EmployeeName;
                Sheets.Cells[string.Format("C{0}", row)].Value = data.MonthsName;
                Sheets.Cells[string.Format("D{0}", row)].Value = data.DateYear;
                Sheets.Cells[string.Format("E{0}", row)].Value = data.SalaryAmount;

                row++;
            }
            var stream = new MemoryStream(Eps.GetAsByteArray());
            return File(stream.ToArray(), "application/vnd.ms-excel", sFileName);
        }

        #region PrivateFields
        private async Task PopulateViewBag()
        {
            var assesmentyearResponse = await _IAssesmentYearRepository.GetAllEntities(x => x.IsActive && !x.IsDeleted);
            if (assesmentyearResponse.ResponseStatus == ResponseStatus.Success)
                ViewBag.AssesmentYearList = assesmentyearResponse.Entities;

        }
        #endregion
    }
}
