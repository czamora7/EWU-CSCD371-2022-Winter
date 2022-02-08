using GenericsHomework;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomeworkTests;

[TestClass]
public class NodeTests
{
    public Node<object>? _Node;

    [TestInitialize]
    public void Init()
    {
        Node<object> nn = new Node<object>(1);
        _Node = nn;
    }

    [TestMethod]
    public void TestToStringReturnsCorrectly()
    {
        Assert.AreEqual<object>(_Node!.ToString(), "1");
    }

    [TestMethod]
    public void TestNextInitialisesCorrectly()
    {
        Assert.AreEqual<GenericsHomework.Node<object>>(_Node!.Next, _Node);
    }

    [TestMethod]
    public void TestAppendMethodAddsValueCorrectly()
    {
        _Node!.Append(2, _Node);

        Assert.AreEqual<object>(2, _Node.Next);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void TestAppendDuplicateThrowsException()
    {
        _Node!.Append(1, _Node);
    }

    [TestMethod]
    public void TestClearCorrectlyRemovesNodes()
    {
        _Node!.Append(2, _Node);
        _Node.Append(3, _Node);

        _Node.Clear();

        Assert.AreEqual(_Node.Next, _Node);
    }
}