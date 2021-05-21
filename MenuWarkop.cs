using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementPenjualan
{
    class MenuWarkop
    {
        public string MenuMakanan { get; set; }
        public int HargaMakanan { get; set; }
        public MenuWarkop()
        {
            MenuMakanan = "";
            HargaMakanan = 0;
        }
        public MenuWarkop(string menumakanan, int hargamakanan)
        {
            MenuMakanan = menumakanan;
            HargaMakanan = hargamakanan;
        }
        public void ShowMenu(List<MenuWarkop> menuWarkops)
        {
            Console.WriteLine("=============Menu=============");
            for (int i = 0; i < menuWarkops.Count; i++)
            {
                Console.WriteLine($"{(i+1)}. {menuWarkops[i].MenuMakanan} Rp.{menuWarkops[i].HargaMakanan}");
            }
        }
    }
}
