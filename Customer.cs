using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementPenjualan
{
    class Customer : MenuWarkop
    {
        public string NamaCustomer { get; set; }
        public int Pembayaran { get; set; }
        public bool Status { get; set; } 
        public List<MenuWarkop> MenuWarkops { get; set; }

        public Customer()
        {
            NamaCustomer = "";
            Pembayaran = 0;
            Status = false;
            MenuWarkops = new List<MenuWarkop>();
        }

        public int TotalHargaPembelian(List<MenuWarkop> menuWarkops)
        {
            int total = 0;
            foreach (var menu in menuWarkops)
            {
                total += menu.HargaMakanan;
            }
            return total;
        }

        public void ShowDetailTransaksi(List<Customer> customers)
        {
            Console.WriteLine("Detail Transaksi");
            for (int i = 0; i < customers.Count; i++) 
            {
                Console.WriteLine($"No.{(i+1)}");
                Console.WriteLine($"Nama: {customers[i].NamaCustomer}");
                Console.WriteLine($"Total Harga Pembelian: Rp.{TotalHargaPembelian(customers[i].MenuWarkops)}");
                if (customers[i].Status)
                {
                    Console.WriteLine($"Status: Sudah Bayar");
                }
                else
                {
                    Console.WriteLine($"Status: Belum Bayar");
                }
                
                Console.WriteLine("========Transaksi========");
                for(int j = 0; j < customers[i].MenuWarkops.Count; j++)
                {
                    Console.WriteLine($"{customers[i].MenuWarkops[j].MenuMakanan} : Rp.{customers[i].MenuWarkops[j].HargaMakanan}");
                }
            }
        }
    }
}
