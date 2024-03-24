namespace OgrenciBilgiSistemi.Interfaces
{
    public interface INotListesi
    {
        public string DersKodu { get; set; }
        public string DersAdi { get; set; }
        public string DersAKTS { get; set; }
        public string? VizeNotu { get; set; }
        public string? FinalNotu { get; set; }
    }
}
