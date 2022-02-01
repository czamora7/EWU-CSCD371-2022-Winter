using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CanHazFunny.Tests;

[TestClass]
public class JesterTests
{
    Jester _Harlequin;
    string _Joke;

    [TestInitialize]
    public void Init()
    {
        _Harlequin = new Jester();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestComedianDependencyRejectsNull()
    {
        _Harlequin.TellJoke(null, new JokeService());
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void TestJokeServiceDependencyRejectsNull()
    {
        _Harlequin.TellJoke(new Comedian(), null);
    }

    [TestMethod]
    public void TestReturnedJokeIsNotNull()
    {
        _Joke = _Harlequin.TellJoke(new Comedian(), new JokeService());
        Assert.IsNotNull(_Joke);
    }

    [TestMethod]
    public void TestReturnedJokeIsNotAChuckNorrisJoke()
    {
        _Joke = _Harlequin.TellJoke(new Comedian(), new JokeService());
        Assert.AreEqual(false, _Joke.Contains("Chuck Norris"));
    }
}

