// Data/Message.cs
namespace MyPortfolio.Data
{
    public class Message
    {
        public int MessageId { get; set; } // Birincil Anahtar
        public string Name { get; set; }    // Müşterinin Adı
        public string Email { get; set; }   // Müşterinin Email adresi
        public string Description { get; set; } // Mesajın içeriği
        public DateTime Date { get; set; }  // Mesajın gönderilme tarihi
        public bool IsRead { get; set; }    // Okundu bilgisi (Opsiyonel ama işine yarar)
    }
}