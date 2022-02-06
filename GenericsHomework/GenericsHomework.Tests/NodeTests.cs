using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Node_ReturnsNode()
        {
            Node node = new(null);
            Assert.IsNotNull(node);
        }
        [TestMethod]
        public void ToString_ProperlyParses()
        {
            Node node = new(null);
            Assert.AreEqual("null", node.ToString());
            node.Value = "test";
            Assert.AreEqual("test", node.ToString());
            node.Value = false;
            Assert.AreEqual("false", node.ToString());
            node.Value = 39;
            Assert.AreEqual("39", node.ToString());
            node.Value = (Int64)64;
            Assert.AreEqual("64", node.ToString());
            node.Value = 42.1;
            Assert.AreEqual("42.1", node.ToString());
            node.Value = new Node(null);
            Assert.AreEqual("Type unknown", node.ToString());
        }
        [TestMethod]
        public void Append_ProperlyAppends()
        {
            Node node = new("1st");
            node.Append("2nd");
            node.Append("3rd");
            Assert.AreEqual("1st", node.ToString());
            Assert.AreEqual("2nd", node.GetNext().ToString());
            Assert.AreEqual("3rd", node.GetNext().GetNext().ToString());
            Assert.AreEqual("1st", node.GetNext().GetNext().GetNext().ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]  
        public void Append_ItemExistsException()
        {
            Node node = new("null");
            node.Append(null);
        }
    }
}