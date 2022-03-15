# Contact_Directory

Bu projede kişi rehberi uygulaması yapmaya çalıştım. Boş bir solution içerisinde Contact_Directory_API, Contact_Directory_API2 ve Contact_Directory_WEB projeleri oluşturdum. Contact_Directory_API2
web servisi Contact_Directory_API web servisi ile haberleşmektedir. Contact_Directory_API2 için gerekli doğrulama işlemleri Contact_Directory_API servisinden gelmektedir.

![image](https://user-images.githubusercontent.com/61107806/158446464-ae954953-a11b-4fdb-8341-1652c21d52d4.png)


***Contact_Directory_API***
<br/>
Contact_Directory_API web servisinde kişiler için gerekli CRUD işlemleri yapildi. Kişi ekleme , güncelleme, silme ve listeleme işlemleri bu web serviste gerçekleşiyor.
<br/>

***Contact_Directory_API2***
<br/>
Contact_Directory_API2 web servisinde kişiler için ek bilgilerin girilebileceği methodlar yazıldı. Kişiye ait ek bilgiler girilirken kişi doğrulaması için yani veritabanında bu 
kişi kayıtlı mi değilmi kontrol edilirlen Contact_Directory_API web servisi ile haberleşip gerekli get methodu burada çalıştırılıyor. Sonrasında detayları eklemek için gerekli post
methoduda bu serviste bulunuyor.
<br/>

***Contact_Directory_WEB***
<br/>
Web servisleri çalıştırmak için gerekli olan ön yüzü bu projede yaptım. Web Projesi açıldığı zaman adımın ve soyadımın yazılı olduğu boş bir sayfa açılacaktır.
![image](https://user-images.githubusercontent.com/61107806/158448348-688bd731-a224-4500-84a5-f73201a74772.png)

Persons List butonuna basarak veri tabanınızda kayıtlı olan kişileri görebilirsiniz. Bu sayfadan kişi ekleme, güncelleme, detay ekleme ve kişi silme işlemlerini yapabilirsiniz.
<br/>
![image](https://user-images.githubusercontent.com/61107806/158448570-df2b6f5c-563b-4103-b913-76bb0bd7f91d.png)

