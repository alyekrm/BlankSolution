﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constrants
{
    public class Messages
    {
        public static string CarAdded = "Araç eklendi";

        public static string CarNameInvalid = "Araç ismi geçersiz";
        public static string MaintenanceTime = "Bakım zamanı";
        public static string CarListed = "Araçlar listelendi";
        public static string CarUpdated = "Araç güncellendi";
        public static string CarDeleted = "Araç silindi";

        public static string CarRented = "Araç kiralandı";
        public static string RentRecordDeleted = "Araç kiralama kaydı silindi";
        public static string RentRecordUpdated = "Araç kiralama kaydı güncellendi";
        public static string RentOutFail = "Araç henüz iade edilmemiş";
        public static string ListRents = "Kiralama kayıtları listelendi";
        public static string CarReturn = "Araç iade edildi";
        public static string CarImageAdded = "Araç resmi eklendi";
        public static string CarImageDeleted = "Araç resmi silindi";
        public static string CarImageUpdated = "Araç resmi güncellendi";
        public static string MaxCarImageError="Bir araç için en fazla beş resim yüklenebilir";
    }
}
