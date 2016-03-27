using UnityEngine;
using NUnit.Framework;

public class WorldTest {
    [SetUp]
    public void SetUp()
    {
        Assert.IsTrue(Resource.Data.Create());
        Assert.IsTrue(Global.InitializeRoot());
        Assert.IsTrue(Global.InitializeMap());
    }
    
    [Test]
    public void CreateActor()
    {
        Assert.IsTrue(Global.InitializeActor());
    }
    
    [Test]
    public void Login()
    {
        Assert.IsTrue(Util.CheckUserID("tertis"));
        Assert.IsFalse(Util.CheckUserID("tt"));
        Assert.IsTrue(Util.CheckUserPassword("12345678"));
        Assert.IsFalse(Util.CheckUserPassword("12"));
    }

    [TearDown]
    public void TearDown()
    {
        Assert.IsTrue(Global.Cleanup());
    }
}
