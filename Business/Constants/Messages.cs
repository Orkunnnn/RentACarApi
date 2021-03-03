using Core.Entities.Concrete;

namespace Business.Constants
{
    public class Messages
    {
        public static string CustomerAdded = "Müşteri başarıyla eklendi.";
        public static string CustomerUpdated = "Müşteri başarıyla güncellendi.";
        public static string CustomerDeleted = "Müşteri başarıyla silindi.";

        public static string BrandAdded = "Marka başarıyla eklendi.";
        public static string BrandUpdated = "Marka başarıyla güncellendi.";
        public static string BrandDeleted = "Marka başarıyla silindi.";

        public static string ColorAdded = "Renk başarıyla eklendi.";
        public static string ColorUpdated = "Renk başarıyla güncellendi.";
        public static string ColorDeleted = "Renk başarıyla silindi.";

        public static string UserAdded = "Kullanıcı başarıyla eklendi.";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi.";
        public static string UserDeleted = "Kullanıcı başarıyla silindi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string UserRegistered = "Kullanıcı başarıyla kayıt oldu.";

        public static string CarAdded = "Araba başarıyla eklendi.";
        public static string CarUpdated = "Araba başarıyla güncellendi.";
        public static string CarDeleted = "Araba başarıyla silindi.";
        public static string CarInvalid = "Araba açıklaması en az 2 karakter içermelidir ve günlük fiyat 0'ın altında olmamalıdır.";
        public static string CarNotAvailable = "Araba şu an kiralanamıyor.";

        public static string RentalAdded = "Araba kiralama işlemi başarıyla tamamlandı.";
        public static string RentalUpdated = "Araba kiralama işlemi başarıyla güncellendi.";
        public static string RentalDeleted = "Araba kiralama işlemi başarıyla silindi.";

        public static string CantAddMoreThanFiveImage = "Bir araba için 5'ten fazla resim eklenemez.";

        public static string PasswordError = "Hatalı şifre.";
        public static string AuthorizationDenied = "Yetki yok.";
        public static string SuccessfulLogin = "Kullanıcı başarıyla giriş yaptı.";
        public static string UserAlreadyExists = "Kullanıcı mevcut.";
        public static string AccessTokenCreated = "Token başarıyla oluşturuldu.";
    }
}
