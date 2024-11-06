using System;

class TicTacToe
{
    // Tahta, oyunun durumunu tutar (1-9 arasındaki sayılar veya X/O karakterleri)
    static char[] tahta = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static char mevcutOyuncu = 'X';

    static void Main()
    {
        int hamleSayisi = 0;
        bool oyunKazandi = false;

        // Oyun devam ederken ve 9 hamleden az yapılmışken döngü devam eder
        while (!oyunKazandi && hamleSayisi < 9)
        {
            Console.Clear();
            TahtayiGoster();
            Console.WriteLine($"Oyuncu {mevcutOyuncu}, pozisyonunu seç (1-9): ");
            string girdi = Console.ReadLine();

            // Girdi geçerliyse ve seçilen pozisyon boşsa
            if (int.TryParse(girdi, out int pozisyon) && pozisyon >= 1 && pozisyon <= 9 && tahta[pozisyon - 1] != 'X' && tahta[pozisyon - 1] != 'O')
            {
                tahta[pozisyon - 1] = mevcutOyuncu;// Seçilen pozisyona mevcut oyuncuyu yerleştir
                oyunKazandi = KazanmaKontrol(); // Kazanma durumu kontrol edilir

                // Oyun kazanılmadıysa, sıradaki oyuncuya geç ve hamle sayısını artır
                if (!oyunKazandi)
                {
                    mevcutOyuncu = (mevcutOyuncu == 'X') ? 'O' : 'X';// Oyuncu değiştir
                    hamleSayisi++;
                }
            }
            else
            {
                // Geçersiz hamle durumunda uyarı mesajı göster ve tekrar denemesi istenir
                Console.WriteLine("Geçersiz hamle! Tekrar dene.");
                Console.ReadLine();
            }
        }

        Console.Clear();
        TahtayiGoster();

        if (oyunKazandi)
        {
            Console.WriteLine($"Oyuncu {mevcutOyuncu} kazandı!");
        }
        else
        {
            Console.WriteLine("Berabere!");
        }
    }

    static void TahtayiGoster()
    {
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {tahta[0]}  |  {tahta[1]}  |  {tahta[2]}  ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {tahta[3]}  |  {tahta[4]}  |  {tahta[5]}  ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {tahta[6]}  |  {tahta[7]}  |  {tahta[8]}  ");
        Console.WriteLine("     |     |     ");
    }

    static bool KazanmaKontrol()
    {
        int[,] kazanmaPozisyonlari = new int[,]
        {
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // Yatay
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Dikey
            {0, 4, 8}, {2, 4, 6}             // Çapraz
        };

        // Aynı sembolle üçlü oluşturulmuşsa, kazanan vardır
        for (int i = 0; i < kazanmaPozisyonlari.GetLength(0); i++)
        {
            if (tahta[kazanmaPozisyonlari[i, 0]] == mevcutOyuncu &&
                tahta[kazanmaPozisyonlari[i, 1]] == mevcutOyuncu &&
                tahta[kazanmaPozisyonlari[i, 2]] == mevcutOyuncu)
            {
                return true;
            }
        }

        return false;// Kazanan yoksa false döner
    }
}
