using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Odev
{
    internal class Program
    {
        static Queue<string> birinciOncelik=new Queue<string>();
        static Queue<string> ikinciOncelik = new Queue<string>();
        static Queue<string> ucuncuOncelik = new Queue<string>();

        static void Main(string[] args)
        {
            
            Console.WriteLine("******BANKA SIRASI******");
            string kullaniciGirisi; //Kullanıcının girdiği ve seçtiği duruma göre öncelik durumunu belirtilecektir!

            do //Do While döngüsü kullanılır
            {
                // Kullanıcıya seçenekler sundum.Hangi işlemi nyapmak istiyorsun diye
                Console.WriteLine("\nBir İşlem Seçin:");
                Console.WriteLine("1. Yeni Müşteri Ekle:");
                Console.WriteLine("2. İşlem Yapın:");
                Console.WriteLine("3. Kuyruğu Göster");
                Console.WriteLine("4. Çıkış Yap!");
                kullaniciGirisi = Console.ReadLine(); // Kullanıcıdan giriş alınıyor

                switch (kullaniciGirisi)
                {
                    case "1":
                        // Yeni müşteri eklemek için
                        YeniMusteriEkle();
                        break;
                    case "2":
                        // İşlem yapma metodu
                        IslemYap();
                        break;
                    case "3":
                        // Kuyruğu gösterme metodu
                        SırayıGoster();
                        break;
                    case "4":
                        // Bir işlem yapılmazsa çıkılıyor desin
                        Console.WriteLine("Çıkılıyor...");
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            } while (kullaniciGirisi != "4"); // Kullanıcı "4" seçeneğini seçene kadar döngü devam eder.

            Console.ReadLine();
        }

        // Yeni müşteri ekleriz.
        static void YeniMusteriEkle()
        {
            Console.Write("Müşterinin İsmini Girin:");
            string musteriAdi = Console.ReadLine(); // Müşteri adı alınıyor
            Console.WriteLine("");

            Console.WriteLine("\nİşlem türünü seçin:");
            Console.WriteLine("1.Birincil Öncelik");
            Console.WriteLine("2.İkincil Öncelik");
            Console.WriteLine("3.Üçüncül Öncelik");
            string oncelikSecimi = Console.ReadLine(); // İşlem türü seçiliyor

            // İşlem türüne göre müşteri ekleniyor
            switch (oncelikSecimi)
            {
                case "1":
                    birinciOncelik.Enqueue(musteriAdi); // Birinci öncelikli sıraya müşteri ekleniyor
                    Console.WriteLine($"{musteriAdi} birinci öncelikli sıraya eklendi.");
                    break;
                case "2":
                    ikinciOncelik.Enqueue(musteriAdi); // İkinci öncelikli sıraya müşteri ekleniyor
                    Console.WriteLine($"{musteriAdi} ikinci öncelikli sıraya eklendi.");
                    break;
                case "3":
                    ucuncuOncelik.Enqueue(musteriAdi); // Üçüncü öncelikli sıray müşteri ekleniyor
                    Console.WriteLine($"{musteriAdi} üçüncü öncelikli sıraya eklendi.");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim."); // Geçersiz seçim yapıldığında uyarı verdim
                    break;
            }
        }

        // Bir banka sırasında müşteri işleme metodu kullanrak işlem önceliğini belirttim!
        static void IslemYap()
        {
            if (birinciOncelik.Count > 0) // Birincil öncelikli sıra boş değilse işlem yaparım
            {
                string musteri = birinciOncelik.Dequeue(); // Birincil öncelikli sıranın ilk elemanı işleme aldım
                Console.WriteLine($"İşlem yapılıyor: {musteri} (Birinci Öncelik)");
            }
            else if (ikinciOncelik.Count > 0) // Birincil öncelik sırası boşsa, ikincil öncelikli sıraya bak!
            {
                string musteri =ikinciOncelik.Dequeue(); // İkinci öncelikli sıranın ilk elemanı işleme al!!
                Console.WriteLine($"İşlem yapılıyor: {musteri} (İkinci Öncelik)");
            }
            else if (ucuncuOncelik.Count > 0) // İkincicil öncelikli sıra da boşsa, üçüncü öncelikli sıraya bakılır
            {
                string musteri = ucuncuOncelik.Dequeue(); // Düşük öncelikli kuyruğun ilk elemanı işleme alınır
                Console.WriteLine($"İşlem yapılıyor: {musteri} (Üçüncü Öncelik)");
            }
            else
            {
                Console.WriteLine("Kuyruklar boş."); // Tüm kuyruklar boşsa uyarı verilir
            }
        }

        // Önceliğe göre Müşteri Sırasını gösterme metodu
        static void SırayıGoster()
        {
            Console.WriteLine("\nSıra Durumları:");

            Console.Write("\nBirinci Öncelikli Sıra:");
            foreach (var musteri in birinciOncelik) // Birinci öncelikli sıradaki tüm müşteriler yazdırılır
            {
                Console.WriteLine(musteri);
            }

            Console.Write("\nİkinci Öncelikli Sıra:");
            foreach (var musteri in ikinciOncelik) // İkinci öncelikli sıradaki tüm müşteriler yazdırılır
            {
                Console.WriteLine(musteri);
            }

            Console.Write("\nÜçüncü Öncelikli Sıra:");
            foreach (var musteri in ucuncuOncelik) // Üçüncü öncelikli sıradaki tüm müşteriler yazdırılır
            {
                Console.WriteLine(musteri);
            }

        }
       
    }
    
}
