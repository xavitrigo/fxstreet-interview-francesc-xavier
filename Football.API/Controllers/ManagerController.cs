﻿using Football.API.Models;
using Football.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly ILogger<ManagerController> _logger;

        public ManagerController(
            IManagerService managerService, 
            ILogger<ManagerController> logger
        ) {
            _managerService = managerService;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Manager>>> Get()
        {
            var managers = await _managerService.GetAllManagers();
            return this.Ok(managers);
        }

        [HttpGet]
        [Route("{id}", Name = "GetManagerById")]
        public async Task<ActionResult> GetManagerById(int id)
        {
            var manager = await _managerService.GetManagerById(id);
            if (manager == default)
            {
                _logger.LogError($"Manager to get with ID ${id} not found");
                this.NotFound();
            }
                
            return this.Ok(manager);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ManagerDto manager)
        {
            var managerInDb = await _managerService.AddManager(manager);
            return this.CreatedAtAction(nameof(GetManagerById), new { managerInDb.Id }, managerInDb);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, ManagerDto manager)
        {
            var isManagerInDb = await _managerService.ManagerExistsInDb(id);
            if (!isManagerInDb)
            {
                _logger.LogError($"Manager to update with ID ${id} not found");
                return this.NotFound();
            }

            await _managerService.UpdateManager(id, manager);
            return this.Ok();
        }
    }
}
