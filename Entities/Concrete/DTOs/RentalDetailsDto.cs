using System;
using Core.Entities;

namespace Entities.Concrete.DTOs
{
    public class RentalDetailsDto:IDto
    {
        public int RentalId { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string CarName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
