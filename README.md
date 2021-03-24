# photory
<br/>
<br/>

## Tartalom Jegyzék:

- [Projekt leírás](#projekt-leírás)
- [Felhasználói jogosultsági szintek](#felhasználói-jogosultsági-szintek)
- [Használt technológiák](#használt-technológiák)
- [Csoport beosztás](#csoport-beosztás)

## Projekt leírás
<br/>

Ezzel a  projekttel egy olyan  **Facebook** -hoz hasonló online közösségi platformot kívánunk szimulálni amelyen képesek vagyunk felhasználói fiókokat regisztrálni , csoportokat létrehozni és menedzselni.
A csoportokba képeket tudunk feltölteni , illteve az egyes képekhez hozzászólásokat tudunk írni.A csoportok moderálásért és a képek feltöltéséért a megfelelő felhasználói jogokkal rendelkező felhasználók felelősek , ezek egy későbbi pontban lesznek kifejtve.
<br/>
<br/>

## Felhasználói jogosultsági szintek
<br/>

A projektben az RBAC elvet követve teljesen elkülönülő jogosultsági szinteket használunk   <br/>

1. **User**
- Általános felhasználó , regisztráció után az egyes csoportokba képes jelentkezni , majd ha ez elfogadásra került , a megtekintheti a csoportba feltöltött képeket , feltöltheti a sajátjait  és hozzászólásokat írhat hozzájuk.Ha már nem kíván egy csoport tagja lenni , kiléphet onnan.
2. **Group Admin**
- A csoportok moderálásért felel , a jelentkezéseket képes elfogadni , illetve elutasítani.Egy group-admin csak egy csoport jelenkezéseiért felelős. 
3. **Admin**
- A csoportokat képes létrehozni és törölni
<br/>
<br/>

## Használt technológiák
<br/>


 - Backend : **ASP.Net** <br/>

- Frontend : **REACT** <br/>
  * a ma használt egyik legelterjedtebb web-depelopment tool ,illetve komponens alapúsága miatt jó lehetőség számunkra , hogy jobban megismerjük a projekt alatt <br/>
      
- Adatbázis : **AZURE** <br/>
  * az Óbudai Egyetem diékjaiként ingyenes regisztrációhoz van hozzáférésünk  , így ez tűnt a legpraktikusabb megoldásnak

## Csoport beosztás
<br/>


 - Backend : **Gadácsi  Ákos** és **Hegedűs Máté** <br/>

- Frontend : **Schäffer Tamás** <br/>

- Csoport menedzser : **Veres Levente**
