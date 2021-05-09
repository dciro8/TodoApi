using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Test.Entities;

namespace TodoApi.Test.Services
{
	public class TodoItemService : ITodoItemService
	{
		private readonly TodoContext _context;

		public TodoItemService(TodoContext context)
		{
			_context = context;
		}

		public async Task CreateItemAsync(TodoItem todoItem)
		{
			_context.TodoItems.Add(todoItem);
			await _context.SaveChangesAsync();
		}


        public Task DeleteItemAsync(long id)
		{
			throw new NotImplementedException();
		}

		public async Task<TodoItem> GetItemAsync(long id)
		{
			var todoItem = await _context.TodoItems.FindAsync(id);
			return await Task.FromResult(todoItem);
		}

		public async Task<IList<TodoItem>> GetItemsAsync()
		{
			return await _context.TodoItems.ToListAsync();
		}

		public async Task UpdateItemAsync(TodoItem item)
		{
			_context.Entry(item).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException) when (!TodoItemExists(item.Id))
			
			{
				throw;
			}
		}
        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
