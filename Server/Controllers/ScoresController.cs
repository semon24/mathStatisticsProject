﻿using MathStatisticsProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MathStatisticsProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoresController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostScore([FromBody] Score score)
        {
            // Логика обработки запроса POST на /api/score
            throw new NotImplementedException();
        }
    }
}