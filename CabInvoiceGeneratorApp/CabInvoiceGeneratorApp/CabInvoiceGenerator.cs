using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorApp
{
    public class CabInvoiceGenerator
    {
        private static readonly double COST_PER_KILOMETER = 10.0;
        private static readonly double COST_PER_MINUTE = 1.0;
        private static readonly double MINIMUM_FARE = 5.0;
        private double CAB_FARE = 0.0;

        private RideRepository rideRepository = new RideRepository();


        public double CalculateFare(double distance, double time)
        {
            this.CAB_FARE = (distance * COST_PER_KILOMETER) + (time * COST_PER_MINUTE);
            return Math.Max(this.CAB_FARE, MINIMUM_FARE);
        }
        //public double GetMultipleRideFare(Ride[] rides)
        //{
        //    double TOTAL_CAB_FARE = 0.0;
        //    foreach (var data in rides)
        //    {
        //        TOTAL_CAB_FARE += this.CalculateFare(data.distance, data.time);
        //    }
        //    return TOTAL_CAB_FARE;
        //}
        //Refactor the above method
        public InvoiceSummary GetMultipleRideFare(Ride[] rides)
        {
            double totalFare = 0.0;
            foreach (var data in rides)
            {
                totalFare += this.CalculateFare(data.distance, data.time);
            }
            return new InvoiceSummary(totalFare, rides.Length);
        }
        public void MapRidesToUser(string userID, Ride[] rides)
        {
            this.rideRepository.AddCabRides(userID, rides);
        }
        public InvoiceSummary GetEnhancedInvoiceSummary(string userID)
        {
            return this.GetMultipleRideFare(this.rideRepository.GetCabRides(userID));
        }
    }
}