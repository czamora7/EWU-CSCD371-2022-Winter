using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestComedianDependencyRejectsNull()
    {
        Jester _Harlequin = new();
        _Harlequin.TellJoke(null!, new JokeService());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestJokeServiceDependencyRejectsNull()
    {
        Jester _Harlequin = new();
        _Harlequin.TellJoke(new Comedian(), null!);
    }

    [TestMethod]
    public void TestReturnedJokeIsNotNull()
    {
        Jester _Harlequin = new();
        string joke = _Harlequin.TellJoke(new Comedian(), new JokeService());
        Assert.IsNotNull(joke);
    }

    [TestMethod]
    public void TestReturnedJokeIsNotAChuckNorrisJoke()
    {
        Jester _Harlequin = new();
        string joke = _Harlequin.TellJoke(new Comedian(), new JokeService());
        Assert.AreEqual<bool>(false, joke.Contains("Chuck Norris"));
    }
}

