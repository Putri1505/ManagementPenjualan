using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementPenjualan
{
    class Program
    {

        static void Main(string[] args)
        {
            List<MenuWarkop> menuWarkops = new List<MenuWarkop>();
            MenuWarkop menuWarkop = new MenuWarkop();
            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer();
            menuWarkops.Add(new MenuWarkop("Indomie Goreng", 6000));
            menuWarkops.Add(new MenuWarkop("Indomie Rebus", 6000));
            menuWarkops.Add(new MenuWarkop("Indomie Goreng  + Telor", 10000));    
            menuWarkops.Add(new MenuWarkop("Indomie Rebus + Telor", 10000));
            menuWarkops.Add(new MenuWarkop("Nasi Egg Roll", 20000));
            menuWarkops.Add(new MenuWarkop("Nasi Katsu", 20000));
            menuWarkops.Add(new MenuWarkop("Es Teh Manis", 5000));
            menuWarkops.Add(new MenuWarkop("Good Day", 7000));
            menuWarkops.Add(new MenuWarkop("Soda Gembira", 12000));
            menuWarkops.Add(new MenuWarkop("Milo", 7000));
            menuWarkops.Add(new MenuWarkop("Air Mineral", 5000));

            int pilih = 0;
            while (true)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("--Selamat Datanng di Warkop DUDUK-DUDUK--");
                Console.WriteLine("=========================================");
                Console.WriteLine("1. Pesan Menu");
                Console.WriteLine("2. Pembayaran ");
                Console.WriteLine("3. Detail Transaksi");
                Console.WriteLine("Pilih (1-3) ");
                pilih = Convert.ToInt32(Console.ReadLine());
                bool pilihMenuLagi = true;
                switch (pilih)
                {
                    case 1:
                        Console.Write("Masukkan Nama: ");
                        String namaCustomer = Console.ReadLine();
                        customer = new Customer();
                        customer.NamaCustomer = namaCustomer;
                        menuWarkop.ShowMenu(menuWarkops);
                        do
                        {
                            Console.Write("Pilih Menu: ");
                            int pilihMenu = Convert.ToInt32(Console.ReadLine());
                            menuWarkop = new MenuWarkop();
                            menuWarkop.MenuMakanan = menuWarkops[pilihMenu - 1].MenuMakanan;
                            menuWarkop.HargaMakanan = menuWarkops[pilihMenu - 1].HargaMakanan;
                            customer.MenuWarkops.Add(menuWarkop);
                            Console.WriteLine("Apakah Ingin Pesan Lagi? ");
                            Console.WriteLine("1. Ya ");
                            Console.WriteLine("2. Tidak ");
                            int pilihLagi = Convert.ToInt32(Console.ReadLine());
                            if (pilihLagi == 2)
                            {
                                pilihMenuLagi = false;
                            }
                        } while (pilihMenuLagi);
                        customers.Add(customer);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        customer.ShowDetailTransaksi(customers);
                        Console.Write("Pilih Nomor: ");
                        pilih = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Nama: {customers[pilih-1].NamaCustomer}");
                        for (int i = 0; i < customers[pilih-1].MenuWarkops.Count; i++)
                        {
                            Console.WriteLine($"{customers[pilih - 1].MenuWarkops[i].MenuMakanan}: Rp. {customers[pilih - 1].MenuWarkops[i].HargaMakanan}");
                        }
                        int totalHargaPembelian = customer.TotalHargaPembelian(customers[pilih - 1].MenuWarkops);
                        Console.WriteLine($"Total Harga: {totalHargaPembelian}");
                        int bayar = 0;
                        do
                        {
                            Console.Write("Bayar: ");
                            bayar = int.Parse(Console.ReadLine());
                            if (bayar < totalHargaPembelian)
                            {
                                Console.WriteLine("Uang Anda Tidak Cukup");
                            }
                        } while (bayar < totalHargaPembelian);
                        Console.WriteLine($"Kembalian : Rp. {(bayar - totalHargaPembelian)}");
                        Console.WriteLine("Terima Kasih Sudah Beli");
                        customers[pilih - 1].Status = true;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        customer.ShowDetailTransaksi(customers);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        
    }
}
