using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Test.Entities;

namespace TodoApi.Test.Services
{
	public interface ITodoItemService
	{
		Task<TodoItem> GetItemAsync(long id);
		Task<IList<TodoItem>> GetItemsAsync();
		Task CreateItemAsync(TodoItem item);
		Task UpdateItemAsync(TodoItem item);
		Task DeleteItemAsync(long id);
	}
}
