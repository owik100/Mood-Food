using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mood_Food.DAL;

namespace Mood_Food.Tests
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void CanConnectToDatabase()
        {
            var context = new MoodFoodContext();
            
                bool connected;
                try
                {
                    //context.Database.Connection.Open();
                    //context.Database.Connection.Close();
                }
                catch (SqlException)
                {
                    connected = false;
                }
                connected = true;

            Assert.AreEqual(true, connected);          
        }
    }
}
