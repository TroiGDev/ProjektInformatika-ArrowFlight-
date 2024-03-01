# Poročilo
## Opis naloge

Za svoj projekt bom naredil mobilno igrico po imenu Arrow Flight v razvijalnem stroju Unity GameEngine z uporabo jezika C#. V Unity-ju imam že kar nekaj izkušenj in znanja, ki bi ga rad nadgradil z rednim delom in uporabo.

Igrica bo enostavna kjer bo igralec kontroliral glavnega junaka, ki bo z potegom na ekranu usmerjal in ustrelil puščico, kamorkoli pade puščica, tja se junak teleportira, colj bo da junak zadane čim več tarč dokler se omejeni čas preteče, z vsakim zadetkom tarče se tarča uniči in nekaj časa je dodanega na timer

## Načrt programa

Igrica je zgrajena v večih scenah, prva bo glavna scena v katero se postavimo na začetku, ko je igrica prižgana, iz nje lahko pritisnemo gumb in pridemo do scene z leveli, trenutno so v igri 3 leveli, vsak drugačen od prejšnjega, ko pritisnemo gumb za določen level se ta odpre in igra se prične

## Koraki do rešitve <br>
Unity je zelo dober program ki omogoča uporabo drugih podprogramov, ki niso naloženi v navaden Začetni Unity projekt. v temu projektu sem uporabil: <br>
TMP pro- za boljše input in text sisteme <br>
URP universal render pipeline- za boljšo svetlobo <br>
DataPersistance sistem- ki sem ga ustvaril v drugem projektu za shranjevanje podatkov na napravi in sem ga za to uporabil tudi tokrat <br>

### Česa še ne vem: <br>
-(trenutno je celotna igrica dokončana, vanjo bom še dodajal čeprav nimam nastavljenih ciljev)


### Kaj že vem / sem izdelal: <br>
-glavna scena<b>
-scena z nivoji<b>
-3 posebni nivoji<b>
-tarče<b>
-premikanje/teleportacija preko touch kontrol<b>
-shranjevanje podatkov<b>
-zvočni efekti<b>
-končna olepšava<b>

## Dokazila o naučenem

Koncept zaporednosti izvajanja ukazov: <br>
![](Slike%20v%20PNG/zaporedje.png)

  -eden izmed izzivov je bil kako ustvariti pike/indikatorje, kam bo junak istrelil puščico, to sem nareidl z postavljanjem pik na določene pozicije, ki se mjih dobil čez neko fizično formulo, tukaj je zaporedje programa zelo pomembno

Koncept vejitve (If stavek): <br>
![](Slike%20v%20PNG/vejitev.png)

  -to je del kode ki ugotovi/zazna pritisk igralca na ekran, vsak dotik ima več faz, prvi moment pritiska, premik in končni/zadnji moment pritiska, tukaj je vejitev pomembna ker se z vsako fazo zgodi nekaj drugega

Koncept zanke: <br>
![](Slike%20v%20PNG/zanka.png)

  -tukaj je del kode ki vsaki izmed teh pik določi in nastavi pozicijo, za to uporabimo zanko

Dogodkovno programiranje: <br>
![](Slike%20v%20PNG/dogodkovnoprogramiranje.png)

  -za nalaganje levelov so uporabljeni gumbi, vsakič ko je pritisnjen se izvede funkcija ki preveri če je ta nivo že odklenjen

Branje in izpisovanje: <br>
![](Slike%20v%20PNG/branjeinizpisovanje.png)

  -ko merimo za izstrelek puščice ji moramo najprej določiti moč/hitrost, to naredimo tako da izračunamo razdaljo med začetkom pritiska na ekran in koncem, na katerih sta 2 točki z katerima naredimo ta izračun

Koncept spremenljivke: <br>
![](Slike%20v%20PNG/spremenljivka.png)

  -vsaka datoteka z kodo ima tudi nekaj spremenljivk ki jih uporabljamo v tej datoteki, nekatere tudi v drugih skriptah

Koncept podprograma / funkcije: <br>
![](Slike%20v%20PNG/funkcija.png)

  -za nalaganje scen je porabljena funkcija ki vzame parameter kot ime scene, ki jo hočemo naložiti

Tabelarična spremenljvka: <br>
![](Slike%20v%20PNG/seznam.png)

  -ker za točke smeri puščice uporabljamo zanko jih moramo vstaviti v seznam čez katerega naredimo "sprehod" in vsaki točki nastavimo točno njeno pozicijo


## Zaključek

ker se tudi v prostem času ukvrajam s projekti, kakršen je ta, bom to igrico najverjetneje obdelal za splošno uporabo in poskusil svoje šanse na objavi na itch.io, s katerim imam že izkušnje, ali mogoče tudi google play, a je zelo odvisno od potenciala, ki ga vidim v temu projektu, kar je za moje ostale igrice velik izziv.
