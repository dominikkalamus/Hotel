using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHotel
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckDatabaseConnection()
        {
            Hotel.DBUtils.HotelDbContext hotelDb = new Hotel.DBUtils.HotelDbContext();
            Assert.AreEqual(true, hotelDb.Database.CanConnect());
        }
        [TestMethod]
        public void CheckDatabase()
        {
            Hotel.DBUtils.HotelDbContext hotelDb = new Hotel.DBUtils.HotelDbContext();
            Assert.AreEqual("Microsoft.EntityFrameworkCore.Sqlite", hotelDb.Database.ProviderName);
        }

    }
}