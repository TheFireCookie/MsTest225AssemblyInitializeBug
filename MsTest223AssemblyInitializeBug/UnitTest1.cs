using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTest223AssemblyInitializeBug
{
  [TestClass]
  public class UnitTest1
  {
    private static DummyClass _dummyClass;

    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext _)
    {
      _dummyClass = new DummyClass { DummyProp = "toto" };
    }

    [DataTestMethod]
    [DynamicData(nameof(GetDummyClass), DynamicDataSourceType.Method)]
    public void TestMethod1(DummyClass dummyClass)
    {
      Assert.IsNotNull(dummyClass);
    }

    private static IEnumerable<object[]> GetDummyClass()
    {
      return new List<object[]>
      {
        new object[] {_dummyClass}
      };
    }
  }
}
