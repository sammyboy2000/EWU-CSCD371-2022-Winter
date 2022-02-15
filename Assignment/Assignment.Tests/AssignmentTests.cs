using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestClass]
    public class AssignmentTests
    {
        [DeploymentItem (People.csv)]
        [TestMethod]
        public void FileExists()
        {

        }

    }
}
