# UrlConverter
This project will lengthen shortened urls, shorten extended urls. It has a manageable structure from config.

### Using
1. Hexagonal Architecture
2. Domain Driven Design
3. Mediator Pattern
4. CQRS
5. Event Sourcing
6. Adapter Pattern
7. Integration Test

### Data
1. Redis
2. Memory Cache

### Infrastructure
1. Asp.net 3.1
2. Mediatr
3. AutoMapper
4. CacheManager

### Support
1. Docker

# Rules

### Long to Short

| Request | Response |
| --- | --- |
| https://www.tufan.com/casio/saat-p-1925865?boutiqueId=439892&merchantId=105064 | tf://?Page=Product&ContentId=1925865&CampaignId=439892&MerchantId=105064 |
| https://www.tufan.com/casio/saat-p-1925865 | tf://?Page=Product&ContentId=1925865 |
| https://www.tufan.com/casio/saat-p-1925865?boutiqueId=439892 | tf://?Page=Product&ContentId=1925865&CampaignId=439892 |
| https://www.tufan.com/casio/saat-p-1925865?merchantId=105064 | tf://?Page=Product&ContentId=1925865&MerchantId=105064 |
| https://www.tufan.com/sr?q=elbise | tf://?Page=Search&Query=elbise |
| https://www.tufan.com/Hesabim/#/Favoriler | tf://?Page=Home |
