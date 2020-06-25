using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Develop;

namespace Test
{
    public class DevelopTest
    {
        [Test]
        public void TestDevelop()
        {
            var d = Develop.CurrentDirect;
            Console.WriteLine(d);
            Assert.IsTrue(d.Contains("template"));
            var entities = Develop.LoadEntities();
            foreach (var item in entities)
            {
                Console.WriteLine(item.FullName);
            }
        }
        [Test]
        public void TestCreateDevelop()
        {
            var entities = Develop.LoadEntities();
            foreach (var item in entities)
            {
                Develop.CreateRespositoryInterface(item);
                Develop.CreateRepositoryImplement(item);
                Develop.CreateEntityTypeConfig(item);
            }
            Assert.Pass();
        }

    }
}
