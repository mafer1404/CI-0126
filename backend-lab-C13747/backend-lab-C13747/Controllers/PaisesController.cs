﻿using backend_lab_C13747.Handlers;
using backend_lab_C13747.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_lab_C13747.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly PaisesHandler _paisesHandler;

        public PaisesController()
        {
            _paisesHandler = new PaisesHandler();
        }

        [HttpGet]
        public List<PaisModel> Get()
        {
            var paises = _paisesHandler.ObtenerPaises();
            return paises;
        }

    }
}
