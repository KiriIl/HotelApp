using System.Collections.Generic;

namespace HotelEntityFramework.Models
{
    public class User : BaseModel
    {
        public virtual List<Order> Orders { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}