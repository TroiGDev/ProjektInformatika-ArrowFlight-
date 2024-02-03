# Poročilo
## Opis naloge

Za svoj projekt bom naredil mobilno/računalniško igrico v razvijalnem stroju Unity GameEngine. V Unity-ju imam že kar nekaj izkušenj in znanja, ki bi ga rad nadgradil z rednim delom in uporabo.

Igrica bo simulacija Paintball bitke. Imela bo samostojni offline način, v katerem bo cilj preživeti čim dlje proti računalniško-kontroliranimi pošastmi, in večigralski online način, kjer bo cilj premagati nasprotnika.

## Načrt programa

Igrica bo zgrajena iz 4 glavnih scen. Prva bo namenjena izbiri offline/online načina, pri izbiri offline/singleplayer bo naložena offline scena, pri izbiri online/multiplayer pa v sceno, kjer bo lahko igralec naredil igro z lastno kodo ali pa se pridružil z kodo že narejene igre, ob pridružitvi/kreaciji se bo igralec naložil v novo online sceno, kjer mu bo naključno določena ekipa, s katero se bo bojeval proti drugi ekipi.

## Koraki do rešitve <br>
Unity je zelo dober program ki omogoča uporabo drugih podprogramov, ki niso naloženi v navaden Začetni Unity projekt. v temu projektu sem uporabil: <br>
TMP pro- za boljše input in text sisteme <br>
Joystick asset pack- za mobilne input kontrole <br>
URP universal render pipeline- za boljšo svetlobo <br>
DataPersistance sistem- ki sem ga ustvaril v drugem projektu za shranjevanje podatkov na napravi in sem ga za to uporabil tudi tokrat <br>
Photon Pun- za online večigralski način, ki je zelo pogost v Unity igricah z večigralskim načinom. <br>

### Česa še ne vem: <br>
-premikanje figure v večigralskem načinu <br>
-usmerjanje figure v večigralskem nalinu <br>
-streljanje v večigralskem načinu <br>
-slike namesto default oblik, vizualne spremembe/poboljšave pri končnem izdelku <br>
-ekipe v večigralskem načinu <br>
-način izgube/zmage <br>
-pošasti v večigralskem načinu <br>
-shranjevanje podatkov na napravi


### Kaj že vem / sem izdelal: <br>
-pošasti <br>
-vse 4 glavne scene in prehod med njimi <br>
-premikanje figure na pc <br>
-usmerjanje figure na pc <br>
-streljanje na pc <br>
-premikanje figure na mobile <br>
-usmerjanje figure na mobile <br>
-streljanje na mobile <br>
-vizualni effekti pri streljanju in splošni sceni <br>
-avtomatski preklop med mobile in pc  <br>

## Dokazila o naučenem

Koncept zaporednosti izvajanja ukazov: <br>
![](Slike%20v%20PNG/zaporedjedogodkov.png)

  -to je del programa, ki izračuna kot in usmeri figuro proti miški, kadar igralec igra na računalniku.
   Vrstni red je tu pomemben za pravi izračun kota.

Koncept vejitve (If stavek): <br>
![](Slike%20v%20PNG/vejedogodkov.png)

  -to je osnovna Unity datoteka ki ima Start() in Update() funkcijo. Start() se izvaja samo prvi okvir (frame), Update() pa vsak naslednji. Ta del programa najprej ugotovi, ali igra teče na mobilni napravi ali računalniku z miško in tipkovnico in nato nadaljuje z izračunom smeri v katero mora biti obrnjena figura. Če je pravilna/nepravilna (boolean) vrednost IsMobile, v katero smo nastavili prav/napačno v Start(), pravilna pomeni da igramo na telefonu, zato pri izračunu, ki se mora dogajaati vsak frame in je zato v Update(), ne uporabljamo pozicijo miške ampak input Joystick, drugače pa, kadar je trditev, da igramo na mobilni napravi napačna, uporabimo pozicijo miške.

Koncept zanke: <br>
![](Slike%20v%20PNG/.png)

Dogodkovno programiranje: <br>
![](Slike%20v%20PNG/interaktivnigumbi.png)

  -to je eden izmed delov figure, ki jo uporabljamo kot gumb, pri katerem se ob pritisku izvede funkcija ki smo jo podali v On Click z string parametrom "LobbySetup".

![](Slike%20v%20PNG/buttonclickevent.png)

  -v našem primeru je to funckija LoadNewScene(), ki nam naloži sceno, katere ime je enako kot parameter, ki smo ga nastavili v On Click klicu funckije.

Branje in izpisovanje: <br>
![](Slike%20v%20PNG/inputdogodki.png)

  -to je datoteka, ki je zadolžena za premikanje figure. Ker so možnosti vrste inputa drugačne na mobilnih napravah in tipkovnici, moramo spet razdeliti program na 2 dela, mobilnega in ne mobilnega. V ne mobilnem/pri uporabi tipkovnice vzamemo tipke "W", "A", "S" in "D" kot input in v določeno smer premaknemo figuro z neko hitrostjo, na mobilni napravi pa to naredimo z drugim input Joystickom.

Koncept spremenljivke: <br>
![](Slike%20v%20PNG/spremenljivke.png)

  -to je del programa, kjer ustvarimo spremenljivke. V tej sliki so vidne spremenljivke IsMobile, katero uporabimo za ugotovitev, ali smo na mobilni napravi ali računalniku, Rigidbody2D, ki je del figure, ki omogoča delovanje Unity-jevih vgrajenih fizik na figuro, float vrednost speed, za katero premaknemo figuro pri premikanju, Canvas, figura, ki je vedno v ospredju na ekranu, ter Joystick ,ki je način mobilnega inputa. Pomembno je vedeti, da Unity omogoča parent/child hierarhijo, kjer je lako več figur del ene figure, s tem je pozicija child figure relativna na parent figuro in ne na sceno/svet, tako je Joystick del Canvas figure in je s tem vedno na istem mestu na ekranu.

Koncept podprograma / funkcije: <br>
![](Slike%20v%20PNG/funkcija.png)

  -to je del programa, ki omogoča streljanje metkov iz figure, v njej je poleg drugih zadev tudi funkcija Shoot(), ki ustvari figuro metka in tej figuri nastavi določeno hitrost v neko določeno smer.

Tabelarična spremenljvka: <br>
![](Slike%20v%20PNG/.png)

## Zaključek

ker se tudi v prostem času ukvrajam s projekti, kakršen je ta, bom to igrico obdelal za splošno uporabo in poskusil svoje šanse na objavi na itch.io s katerim imam že izkušnje ali mogoče tudi google play, a je zelo odvisno od potenciala, ki ga vidim v temu projektu, kar je za moje ostale igrice velik izziv.
