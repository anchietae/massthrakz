# <img src="https://git.anchietae.cc/repo-avatars/ae9d4e114ed8458fc02025c395cb97616f641f9262aebcf8c2737df494807174" width="100px"> MassTHrakz!? *[ejtsd: massztrakz]*
> ^ Mass, mert **masszív** request handlingra képes *kibaszott alacsony response timeval*...

*Kurva gyors* C# ASP.NET9.0 Coreban íródott API Szerver (kréta fejlesztők megirigyelnék)

Literálisan azért írodott .NETben mert nem fogok fölöslegesen túlkomplikált (valakinek ez a szó ismerős lehet) borrow meg faszom tudja rendszerrel szarakodni rustban.

## Építés
`dotnet build` - ez egy szimpla buildet hoz létre, ami nem *optimalizált*

ha jobb *teljesítmény* kell, akkor építsd *AOT*-val
```shell
dotnet publish -c Release /p:PublishAOT=true
```
^ ez jobban le*optimalizál*ja, ha a sima builder nem lenne elég *gyors* még neked

ha az kell h full buildet kapj ami fut barhol (ami linux) akkor hasznald ezt:
```shell
dotnet publish --self-contained true -r linux-x64 -c Release /p:PublishAOT=true
```

## Fejlesztés
megfogod és routesben csinálsz egy új .cs fájlt, és követed az egyik kész routeban lévő kódot, utánna Program.cs-be beimportálod ahogyan a többi is van.

ha új json objectet csinálsz, amit returnolni kéne, akkor modelt kell rá írnod, mivel trimming alatt a lehet működő kódod szétbaszódhat

shared mappában van pár service ami kell pl newsloader, ami becacheli startupnal a hireket, version cucc, stb.

ajánlott az ilyen letöltős/fs loaderes szarokat cachelni, hogy ne basszuk fölöslegesen a rezet.