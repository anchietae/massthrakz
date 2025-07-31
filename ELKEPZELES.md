# elképzelés

## routes
- /api/legacy - legacy refilc compatible api
- /api/v1 - anything above refilc
- /api/web - weboldal apija, altalaban releasek mutatasara, ennyi.

magyaran ami kell a refilc appnak h menjen az legacyban van

## legacystuff

### theme handling
ugye a refilc ugy tolt fel temat h elsonek a jegy szineket, ami ad egy uuidt es utanna egy temat is feltolt, de igy kulon db kell a jegyszineknek es a temaknak\
ez helyett ugyan az lesz a guid-je a temanak es a jegy szineknek.

| GUID                                 | displayName | themeMode | fontFamily | creatorName | shadow | public | accentColor | panelColor | bgColor | gradeColors                                                         |
|--------------------------------------|-------------|-----------|------------|-------------|--------|--------|-------------|------------|---------|---------------------------------------------------------------------|
| aec82355-d6a7-4db8-a392-cfd71253f942 | Some Theme  | dark      | Figtree    | oled lover  | false  | true   | #fff        | #000       | #000    | { "5": "#fff", "4": "#fff", "3": "#fff", "2": "#fff", "1": "#fff" } |

> ^ not final look, de lehet hasonlo lesz, max a grade szinek kulon

na most ha ezt csinalom akkor van ra esely h az appot is modifikalnom kell ami szar ugy, mindegy, remelhetoleg nem kell semmit csinalnom csak az apit normalisan megcsinalni
