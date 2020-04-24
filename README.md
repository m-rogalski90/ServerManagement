# ServerManagement
Całość składać się będzie z 3 bazowych komponentów:
1. MessagingServer - taki serwerek do ogarniania requestow z urządzeń podłączonych.
Idea jest taka, że mamy określony zestaw requestów i responsów dla każdej mozliwej akcji
całą komunikację będziemy musieli zaczynać od "PING-PONG" ( chyba ) żeby zobaczyć czy 
serwer jest alive. Jeżeli nie dostaniemy odpowiedzi PONG to znaczy że serwer zdechł i trzeba 
poczekać aż się znowu uruchomi.. taki health check dla tego serwera
Później trzeba by zrobic autentykację .. jak? chuj nie wiem i na razie mnie to jebie..

Po autentykacji użytkownik powinien dostać jakiś token, klucz, identyfikator czy inne coś
każdy request powinien zawierać ten klucz autentykacyjny i sam klucz powinien być odświeżany 
co jakiś czas albo nie wiem .. trzeba będzie śledzić czy przyszedł z tego samego socketa..? 

Requesty powinny zawierać coś co wymaga większych uprawnień coś jak "wystartujSerwisX_Request"
każde inne takie jak health check powinny być użyte w innym typie aplikacji :
HehKurwele.ServerManagement.MonitoringServer ( nazwa może ulec zmianie bo.. tak! )

2. MonitoringServer - taki serwerek do sprawdzania czy serwer w ogóle działa i co tam działa
co lata w tle i ile zjada zasobów. Raczej trzeba będzie to na jednym pajpie ogarnąć tak żeby
klient podłączony po prostu wysyłał jakiegoś ACK kiedy dostanie cały message i po sekundzie 
serwer powinien wysłać te dane na nowo ( albo klient żeby wysłał jakiś request o to .. chuj wie )
Tutaj trzeba będzie zintegrować to z systemem ( linux debian ) i wymyślić jak to opakować żeby 
można było to ładnie przesyłać. Dane o kilkuset procesach mogą trochę zajmować a że internet w Gdyni
ssie pałe to wolę to spakować jakoś :|

3. Client - noo .. tutaj chyba wszystko jase. Graficzny klient do zarządzania serwerem. Musi pokazywać 
dane monitoringowe z MonitoringServer'a , możliwość wysyłania i odbierania wiadomości z MessagingServer'em.
Jak to opakować .. na razie nie wiem i jebać.. wymyślę później
