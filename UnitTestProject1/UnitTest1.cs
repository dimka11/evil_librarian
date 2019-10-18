using System;
using System.Linq;
using System.Runtime.InteropServices;
using evil_librarian;
using evil_librarian.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        DataAccessLayer dal = new DataAccessLayer(@"..\..\evil.sqlite");

        [TestMethod]
        public void TestMethod1()
        {
            var dal = new DataAccessLayer(@"..\..\evil.sqlite");
            //dal.CreateDataBase(); // doesn't work
            var entities = dal.GetDataFromDataBase<Reader>("readers");

            Assert.AreEqual("Иван", entities[3].Name);

        }

        [TestMethod]
        public void TestMethod2()
        {
            MyContext db = dal.getDB();
            var reader = new Reader();
            reader.Name = "Дима";
            reader.Surname = "Соколов";
            reader.Patronimic = "Иосифович";
            reader.DateOfBirth = Convert.ToDateTime("1994.10.11");
            reader.Passport = "1234567890";
            reader.Phone = "1234567890";
            //db.Readers.Add(reader);
            //db.SaveChanges();
            var entity =  db.Readers.Where(f => f.Patronimic == "Иосифович");
            var en = entity.ToList();
            Assert.AreEqual("Иосифович", en[0].Patronimic);
        }

        [TestMethod]
        public void Testmethod3()
        {
            var reader = dal.getDB().Readers.FirstOrDefault(c => c.IdReader == 1);
            //Евгеньевич
            reader.Patronimic = "Евгеньевич123";
            dal.getDB().Entry(reader).State = System.Data.Entity.EntityState.Modified;
            dal.getDB().SaveChanges();
            //
            reader = dal.getDB().Readers.FirstOrDefault(c => c.IdReader == 1);
            Assert.AreEqual("Евгеньевич123", reader.Patronimic);
        }
    }
}
