

using TodoApi.Core.Entities;
using TodoApi.Core.Services;
using Xunit;

using Microsoft.AspNetCore.Hosting;
namespace Todo.Xunit
{ /// <summary>
  /// Alternatia mas poderosa, la mas moderna de las 2 alternativas del entorno .net (Nunit - Xunit), Xunt es una de las
  /// q mas potencial tienen, es la q mas orientada a TDD
  /// Se utiliza el atributo{Fact}
  /// </summary>
  /// 

    public class TestCrud
    {
        private readonly TodoContext _context;
        protected TestServer 
        [Fact]
        public void testCrud()
        {
            //Arrange
            //GetItemsAsync
            var todoItemService = new TodoItemService(_context);
            var getItemsAsync = todoItemService.GetItemsAsync();
            Assert.True(getItemsAsync.Result.Count > 0);
            //Act

            //Assert

        }
    }
}
