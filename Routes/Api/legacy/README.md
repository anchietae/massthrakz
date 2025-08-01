# Legacy végpontok (um. reFilc kompatibilis végpontok)
> /api/legacy/*

## `/config`
example:
```json
{
  "refilc_uinid": "0bc4359d-9cb8-498d-9f3c-d3c3d83e2678",
  "user_agent": "hu.ekreta.student/$0/$1/$2"
}
```

## `/news` - hírek endpoint
example:
```json
[
  {
    "id": "832785791559087385",
    "title": "Ha olyan helyre költözök ami rosszhírű, sok a cigány akkor az a lebölcsebb cselekedet, hogy minél kevesebbet járkáljak ott?",
    "content": "Kijövök a lakásból elmegyek a villamoshoz vagy buszhoz és minél hamarabb be a városba. Még bevásárolni is bemegyek a városba. A villamos úgyis haza hozza amit veszek nem nekem kell cipelni. Szerintetek okos döntés? Ott egyáltalán nem sétálgatok. Egészségügyi sétára is bemegyek a városba.",
    "link": "https://www.gyakorikerdesek.hu/emberek__lakohely-szomszedok__12946717-ha-olyan-helyre-koltozok-ami-rosszhiru-sok-a-cigany-akkor-az-a-lebolcsebb-csele",
    "open_label": "Fórum link",
    "platform": "all",
    "expire_date": "2021-12-31T23:59:59Z"
  }
]
```
> ^ IDnek ugyan annak kell maradnia, különben az app másik hírnek veszi\
> elméletben az app támogatja mostmár az UTF8 encodingot

## `/version` - összes verzió endpoint
example:
```json
[
  {
    "download_url": {
      "android": "https://github.com/QwIT-Development/app-legacy/releases/download/v5.1.5patch1/app-arm64-v8a-release.apk",
      "ios": "https://github.com/QwIT-Development/app-legacy/releases/download/v5.1.5patch1/firkaapp.ipa"
    },
    "is_latest": true,
    "must_update": false,
    "new": [],
    "version": "v5.1.5patch1"
  },
  {
    "download_url": {
      "android": "https://github.com/QwIT-Development/app-legacy/releases/download/v5.1.5/app-arm64-v8a-release.apk",
      "ios": "https://github.com/QwIT-Development/app-legacy/releases/download/v5.1.5/firkaapp.ipa"
    },
    "is_latest": false,
    "must_update": true,
    "new": [],
    "version": "v5.1.5"
  }
]
```

## `/version/latest` - csak a legújabb verzió
example:
```json
{
  "download_url": {
    "android": "https://github.com/QwIT-Development/app-legacy/releases/download/v5.1.5patch1/app-arm64-v8a-release.apk",
    "ios": "https://github.com/QwIT-Development/app-legacy/releases/download/v5.1.5patch1/firkaapp.ipa"
  },
  "is_latest": true,
  "must_update": false,
  "new": [],
  "version": "v5.1.5patch1"
}
```