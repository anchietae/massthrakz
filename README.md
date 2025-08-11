# <img src="https://git.anchietae.cc/repo-avatars/ae9d4e114ed8458fc02025c395cb97616f641f9262aebcf8c2737df494807174" width="100px"> MassTHrakz!? *[ejtsd: massztrakz]*
> ^ Mass, mert **masszív** request handlingra képes, figyelemre méltóan **alacsony válaszídővel**.

*Nagy teljesítményű* C# ASP.NET 9.0 Core API Szerver egy bizonyos projekt appjához és oldalához. *(Igen, az oldalhoz szükséges végpontokat is tartalmazza. Mint mondtam, nem szeretek várni.)*

Ez a szoftver *tudatosan* .NET-ben íródott, hogy elkerülje a feleslegesen *túlkomplikált* (valakinek ez a szó ismerős lehet) rendszerekkel való *időpazarlás*t. Az élet túl rövid ahhoz, hogy a fejlesztő a compilert elégítse ki. Ez a kód az irányításról szól, nem a compilerről.
> ^ Ez a verzió natívan, külső függőségek nélkül fut. Ellentétben más implementációkkal, ahol legalább 15 csomagra van szükség ugyanehhez az eredményhez (igen, megszámoltam).

## Filozófálás
Ez az egész egy *tudatos döntés* eredménye. Egy döntés a pragmatizmus (haszon) mellett a dogma (vakság) ellen, a hatékonyság mellett a szenvedés ellen.

- A cél egy működő termék, nem a tökéletes kód hajszolása. Epítünk, felmérünk, javítunk.
- A *haladás sebessége* a lényeg, nem a rituálé. Nem használunk bonyolult koncepciókat, ha létezik *egyszerűbb megoldás*.

## Építés
`dotnet run` - Futtatja az alkalmazást. (Változtatások után egy `dotnet clean` javasolt a build cache miatt.)

Ha a maximális *teljesítmény* a cél, építsd *AOT*-val:
```shell
dotnet publish --self-contained tru -c Release /p:PublishAOT=true
```
^ Ez natív kódra optimalizálja az alkalmazást, és a futtatókörnyezetet is tartalmazza. Specifikus rendszerhez add meg a `-r linux-x64` argumentumot.

## Fejlesztés
Új route hozzáadásához hozz létre egy .cs fájlt a routes mappában a meglévő minta alapján, majd importáld a `Program.cs`-ben.

JSON endpointokhoz mindig írj modellt, mivel a trimming (build-time optimalizáció) eltávolíthatja a dinamikusan felismert típusokat.

A `shared` mappában találhatók a service-ek (hírbetöltő, verziókezelő stb.). Javasolt minden hálózati vagy fájlrendszer-művelet eredményét cache-elni a felesleges terhelés elkerülése végett.