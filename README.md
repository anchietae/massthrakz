# <img src="https://git.anchietae.cc/repo-avatars/ae9d4e114ed8458fc02025c395cb97616f641f9262aebcf8c2737df494807174" width="100px"> MassTHrakz!? *[ejtsd: massztrakz]*
> ^ Mass, mert **masszív** request handlingra képes *kibaszott alacsony response timeval*...

*Kurva gyors* C# ASP.NET9.0 Coreban íródott API Szerver (Kréta fejlesztők megirigyelnék) egy bizonyos projekt appjához és oldalához *(Igen, ez az oldalhoz kellő dolgokat is támogatja. Mondtam már párszor hogy nem várok...)*

Literálisan azért írodott .NETben mert nem fogok fölöslegesen túlkomplikált (valakinek ez a szó ismerős lehet) borrow meg faszom tudja rendszerrel szarakodni rustban. Az élet túl rövid ahhoz, hogy az ember a fordítót elégítse csak ki. Ez a kód az irányításról szól és nem a compilerröl.
> ^ Ja és ez dependency nélkül fut, ellentétben a rustos verzióval aminél 15 packaget kell használni hogy ugyanazt az élményt elérd (igen, megszámoltam)

## Filozófálás
Ez az egész egy tudatos döntés eredménye. Egy döntés a pragmatizmus (haszon) mellett a dogma (vakság) ellen, a hatékonyság mellett a szenvedés ellen.

- A cél egy működő szar, nem a tökéletes kód. Epítünk, felmérünk, javítunk.
- A sebesség a lényeg nem a rituálé, nem használunk bonyolult koncepciókat, ha van egyszerübb megoldás.

## Építés
`dotnet run` - Futtatja az alkalmazást építés nélkül (ha változtattál valami nagyobbat akkor `dotnet clean` elötte, mert cacheböl tölt vissza szarokat)

Ha jobb *teljesítmény* kell, akkor építsd *AOT*-val
```shell
dotnet publish --self-contained tru -c Release /p:PublishAOT=true
```
^ Ez jobban le*optimalizál*ja, ha a sima `dotnet build` nem lenne elég *gyors* még neked, valamint ebben benne lesz a dotnet runtime is. Ha kell specifikus rendszerre rakd bele a `-r linux-x64` argot a parancsba

## Fejlesztés
Megfogod és routesben csinálsz egy új .cs fájlt, és követed az egyik kész routeban lévő kódot, utánna Program.cs-be beimportálod ahogyan a többi is van.

Ha új json objectet csinálsz, amit returnolni kéne, akkor modelt kell rá írnod, mivel trimming alatt a lehet működő kódod szétbaszódhat

shared mappában van pár service ami kell pl newsloader, ami becacheli startupnal a hireket, version cucc, stb.

ajánlott az ilyen letöltős/fs loaderes szarokat cachelni, hogy ne basszuk fölöslegesen a rezet.