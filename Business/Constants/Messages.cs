using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages //basit bir mesaj yazdıracağım için sürekli new'lenmesin diye static yaptık
    {
        public static string ProductAdded = "Ürün Eklendi.";   //public field olduğu için PascalCase yazıldı değişken isimleri.
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime="Sistem Bakımda...";
        public static string ProductListed="Ürünler Listelendi.";
    }
}
