using Microsoft.AspNetCore.Mvc;
using Inventory.Data;
using Inventory.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // GET: <InventoryController>
        [HttpGet]
        public async Task<ActionResult<IList<Data.Models.Inventory>>> Get()
        {       
            var result = await _inventoryService.ReadAll().ConfigureAwait(false);
            return new JsonResult(result.ToList());
        }

        // GET: <InventoryController>/productName
        [HttpGet("{productName}")]
        public async Task<ActionResult<Data.Models.Inventory>> Get(string productName)
        {
            var result = await _inventoryService.GetByProductName(productName).ConfigureAwait(false);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // POST: <InventoryController>
        [HttpPost]
        public async Task<ActionResult<Data.Models.Inventory>> Post([FromBody] Data.Models.Inventory inventory)
        {
            await _inventoryService.Add(inventory).ConfigureAwait(false);
            return CreatedAtAction("Get", new { id = inventory.Id }, inventory);
        }

        // PUT: <InventoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Data.Models.Inventory inventory)
        {           
            if (id != inventory.Id)
            {
                return BadRequest();
            }            
            try
            {                
                await _inventoryService.Update(inventory).ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: <InventoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Data.Models.Inventory>> Delete(int id)
        {
            var inventory = await _inventoryService.GetById(id).ConfigureAwait(false);
            if (inventory == null)
            {
                return NotFound();
            }

            await _inventoryService.Delete(inventory).ConfigureAwait(false);
            return NoContent();
        }

    }
}
