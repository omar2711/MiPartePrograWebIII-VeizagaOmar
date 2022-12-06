namespace Integrador.Models
{
    public class Reservation_Service
    {
        public int IdReservation { get; set; }
        public int IdService { get; set; }
        public byte Status { get; set; }
        public DateTime RegisterDate { get; set; }
       
        public DateTime? UpdateDate { get; set; }
    }
}
