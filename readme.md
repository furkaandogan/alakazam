
# Genel Bakış

Projede bağımlılıkları azaltmak için datalar **in-memory** çalışacak şekilde geliştirildi.

NOT: internal ip olarak kurgulandığı için auth yapısı yoktur expose edilen gateway üzerinden handle edilip bakcend pass edilecek kurgusu ile geliştirildi.



### Kullanılan Bazı Teknoloji ve Metodoloji

 - donet core 3.1 (c# lang)
 - xunit
 - swagger
 - RESTful web api
 - n-tier 
 - Domain Driven Design
 - Clean Architecture (onion)
 - Event Driven Architecture
 - CQRS Design Pattern
 - Command Design Pattern

### Çalıştırma
projeyi aşağıdaki komut ile build alıp çalıştırabilirsiniz.

    alakazam > make run 
    // look https://localhost:5001/swagger/index.html

### Test
projeye ait unit testleri aşağıdaki komut ile çalıştırabilirsiniz.

    alakazam > make test

  

### Dummy Tanımlı Ürünler

api isteklerini aşağıdaki dummy ürün bilgileri ile yapabilirsiniz.

  
  

    Id: c43e8047-7e39-4ed5-8465-8d41a556dd24
    Name: Mevye Sepeti
    SellingPrice: 50
    MaximumPurchasable: 1
    TaxRate: 18
    Stock: 10

 

    Id: d3d44267-d4ea-4df4-9857-eac75d59983b
    Name: Mevye Tabağı
    SellingPrice: 50
    MaximumPurchasable: 1
    TaxRate: 18
    Stock: 0

  

    Id: d3d44267-d4ea-4df4-9857-eac75d59983a
    Name: Papatya
    SellingPrice: 10
    MaximumPurchasable: 10
    TaxRate: 18
    Stock: 0
