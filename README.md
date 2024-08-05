# Onion Mimarisi ile CQRS ve MediatR 

- Bu proje, Onion Architecture (Soğan Mimarisi) kullanılarak yapılandırılmıştır.
- Onion Architecture, yazılım projelerinde bağımlılıkların yönetilmesini kolaylaştıran, katmanlı bir mimari desenidir.
- Her katman, iç ve dış bağımlılıkları arasındaki ayrımı korur ve değişikliklerin etkisini minimize eder.
  
![image](https://github.com/user-attachments/assets/4e4833e0-ce49-40d3-816a-abf3e5433dfc)



Projeyi daha detaylı bir şekilde açıklamak için katmanları tek tek ele alalım:

- Core Katmanı

  ![image](https://github.com/user-attachments/assets/87fe26c7-3839-4787-bb3d-b818b9712b68)


- - Product.Application: Bu katman, uygulama mantığını içerir ve diğer katmanlarla doğrudan iletişime geçmez. Özellikle CQRS (Command Query Responsibility Segregation) desenine göre yapılandırılmıştır.

- - - Features: Uygulama özelliklerini içeren klasör. İçerisinde CQRS ve Mediator yapıları barındırır.


- - - Interfaces: Uygulama katmanının ihtiyaç duyduğu arayüzleri içerir.

- - Product.Domain: Bu katman, iş kurallarını ve varlıkları içerir.

- - - Entities: Uygulamanın ana varlıklarını içerir.


------------------------------------------------------------------------------------------------------------
    
- Infrastructure Katmanı
  
  ![image](https://github.com/user-attachments/assets/1d16ac95-2ec2-4158-9ca8-a9fd580f420c)


- - Product.Persistance: Bu katman, veri erişim ve kalıcılık işlemlerini içerir.
  - 
Context: Veri bağlamını (DbContext) içerir.

Migrations: Veri tabanı değişikliklerinin yönetimini içerir.

Repositories: Veri erişim katmanını içerir. Örneğin, ProductRepository.cs ve Repository.cs.



------------------------------------------------------------------------------------------------------------

- Presentation Katmanı

![image](https://github.com/user-attachments/assets/839fd89d-725f-48d8-87b0-046f11b3f93d)

- - Product.WebUI

Bu yapı, uygulamanın her katmanının bağımsız olarak geliştirilebilmesini ve test edilebilmesini sağlar. Ayrıca, her katman diğer katmanlara doğrudan bağımlı olmadığı için değişiklikler daha kolay yapılabilir ve bakım maliyeti düşer.
