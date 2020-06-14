using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApp.Core;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ToDoContext context = new ToDoContext(Constants.DatabasePath);
            Constants.InitAsync(context);
        }
    }
}
