using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Core.Dto;
using TodoApi.Core.Entities;
using TodoApi.Core.Extensions;
using TodoApi.Core.Services;

namespace TodoApi.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        
        private readonly ITodoItemService _service;

        public TodoItemsController(ITodoItemService service)
        {
            _service = service;
        }

        // GET: api/TodoItems
        [HttpGet]
        [Route("GetTodoItems")]
        public async Task<IEnumerable<TodoItemDto>> GetTodoItems()
        {
	        var items = 
		        (await _service.GetItemsAsync())
		        .Select(x => x.ToDto());

	        return items;
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(long id)
        {
            var todoItem = await _service.GetItemAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem.ToDto();
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItemDto todoItemDto)
        {
            if (id != todoItemDto.Id)
            {
                return BadRequest();
            }
            var todoItem = await _service.GetItemAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            todoItem.Name = todoItemDto.Name;
            todoItem.IsComplete = todoItemDto.IsComplete;

            try
            {
	            await _service.UpdateItemAsync(todoItem);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        [Route("CreateItemAsync")]
        public async Task<ActionResult<TodoItem>> CreateItemAsync(TodoItemDto todoItemDto)
        {
	        var todoItem = new TodoItem
	        {
		        IsComplete = todoItemDto.IsComplete,
		        Name = todoItemDto.Name
                //,Id= todoItemDto.Id

            };

            await _service.CreateItemAsync(todoItem);

            var items =
               (await _service.GetItemsAsync())
               .Select(x => x.ToDto());

            if (items.ToList().Count > 0)
            { 
            }

                return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id}, todoItem.ToDto());
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _service.GetItemAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            await _service.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
