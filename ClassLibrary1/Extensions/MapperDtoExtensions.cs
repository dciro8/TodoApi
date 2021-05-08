
using TodoApi.Test.Dto;
using TodoApi.Test.Entities;

namespace TodoApi.Test.Extensions
{
	public static class MapperDtoExtensions
	{
		public static TodoItemDto ToDto(this TodoItem todoItem)
		{
			return new TodoItemDto
			{
				Id = todoItem.Id,
				Name = todoItem.Name,
				IsComplete = todoItem.IsComplete
			};
		}
	}
}
