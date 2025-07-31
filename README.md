# MassTHrakz!? [ejtsd: massztrakz]
> ^ mass, mert masszív. és tudjátok mi masszív még?...

C# ASP.NET9.0 Coreban íródott API Szerver (kréta fejlesztők megirigyelnék)

## Építés
`dotnet build` - ez egy szimpla buildet hoz létre, ami nem optimalizált

ha jobb teljesítmény kell, akkor építsd AOT-val
```shell
dotnet publish -c Release /p:PublishAOT=true
```
^ ez jobban leoptimalizálja, ha a sima builder nem lenne elég gyors még neked

ha az kell h full buildet kapj ami fut barhol akkor hasznald ezt:
```shell
dotnet publish --self-contained true -r linux-x64 -c Release /p:PublishAOT=true
```

ajanlott linuxon epiteni mert ott van crossos native compile, unlike on windows

## Fejlesztés
megfogod és routesben csinálsz egy új .cs fájlt, és követed az egyik kész routeban lévő kódot, utánna Program.cs-be beimportálod ahogyan a többi is van.

ha új json objectet csinálsz, amit returnolni kéne, akkor modelt kell rá írnod, mivel trimming alatt a lehet működő kódod szétbaszódhat

shared mappában van pár service ami kell pl newsloader, ami becacheli startupnal a hireket, version cucc, stb.