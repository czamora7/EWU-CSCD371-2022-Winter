using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomeworkTests
{
    [TestClass]
    public class NodeTests
    {
        public Node<object>? _Node;

        [TestInitialize]
        public void Init()
        {
            Node<object> nn = new GenericsHomework.Node<object>(1);
            _Node = nn;
        }
    }
}