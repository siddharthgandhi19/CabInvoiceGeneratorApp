using CabInvoiceGeneratorApp;

namespace CabInvoiceGeneratorAppTest
{
    public class Tests
    {
        private CabInvoiceGenerator cabInvoiceGenerator;

        [SetUp]//For creating instance of class
        public void Setup()  
        {
            this.cabInvoiceGenerator = new CabInvoiceGenerator();
        }
        [Test]//Test to get total fare using given time and distance
        public void GivenProperDistanceAndTimeForSingleRide_ShouldReturnTotalFare()
        {
            double totalFare = cabInvoiceGenerator.CalculateFare(3.0, 5.0);
            Assert.AreEqual(35.0, totalFare);
        }
        [Test]//Test to get Mininum Fare when given less than minimum fare
        public void GivenProperDistanceAndTimeForSingleRide_LessThanMinFare_ShouldReturnMinimumFare()
        {
            double CabFare = cabInvoiceGenerator.CalculateFare(0.1, 0.5);
            Assert.AreEqual(5, CabFare);
        }        
    }
}