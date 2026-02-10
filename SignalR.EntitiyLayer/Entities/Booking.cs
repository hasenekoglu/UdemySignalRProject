namespace SignalR.EntitiyLayer.Entities;

public class Booking
{
    public int BookingId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int PersonCount { get; set; }
    public DateTime Time { get; set; }
}
