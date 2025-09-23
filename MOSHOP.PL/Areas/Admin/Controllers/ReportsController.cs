﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOSHOP.BLL.Services.Classes;
using QuestPDF.Fluent;

namespace MOSHOP.PL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ReportsController : ControllerBase
    {
        private readonly ReportService _reportService;
        public ReportsController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("GenerateProductReport")]
        public IResult GenerateProductReport()
        {
            // use any method to create a document, e.g.: injected service
            var document = _reportService.CreateDocument();

            // generate PDF file and return it as a response
            var pdf = document.GeneratePdf();
            return Results.File(pdf, "application/pdf", "MoProducts.pdf");
        }
    }
}
