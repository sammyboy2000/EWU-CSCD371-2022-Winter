using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Node_ReturnsNode()
        {
            Node<string> node = new(null!);
            Assert.IsNotNull(node);
        }
        [TestMethod]
        public void ToString_ProperlyParses()
        {
            Node<string> node = new("test");
            Assert.AreEqual<string>("test", node.ToString()!);
            Node<bool> node2 = new Node<bool> (false);
            Assert.AreEqual<string>("False", node2.ToString()!);
            Node<int> node3 = new(39);
            Assert.AreEqual<string>("39", node3.ToString()!);
            Node<double> node4 = new(42.1);
            Assert.AreEqual<string>("42.1", node4.ToString()!);
        }
        [TestMethod]
        public void Append_ProperlyAppends()
        {
            Node<string> node = new("1st");
            node.Append("2nd");
            node.Append("3rd");
            Assert.AreEqual<string>("1st", node.ToString()!);
            Assert.AreEqual<string>("2nd", node.Next.ToString()!);
            Assert.AreEqual<string>("3rd", node.Next.Next.ToString()!);
            Assert.AreEqual<string>("1st", node.Next.Next.Next.ToString()!);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]  
        public void Append_ItemExistsException()
        {
            Node<string> node = new("null");
            node.Append("null");
        }
        [TestMethod]
        public void Clear_ClearsList()
        {
            Node<string> node = new("1st");
            node.Append("2nd");
            node.Append("3rd");
            node.Clear();  
            Assert.AreEqual(node, node.Next);
        }
    }
}