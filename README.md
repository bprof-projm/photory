# photory
<br/>
<br/>

## Tartalom Jegyzék:

- [Projekt leírás](#projekt-leírás)
- [Csoport beosztás](#csoport-beosztás)
- [User Manual](#user-manual)
  - [Szoftver Beüzemelése](#szoftver-beüzemelése)
  - [Alapvető használati funkciók](#alapvető-használati-funkciók)
  - [Elkészített API-k](#elkészített-api-k)
- [Felhasználói jogosultsági szintek](#felhasználói-jogosultsági-szintek)
- [Probléma dokumentáció](#probléma-dokumentáció)
- [Használt technológiák](#használt-technológiák)


<br/>
<br/>
<br/>

## Projekt leírás
<br/>

Ezzel a  projekttel egy olyan  **Facebook** -hoz hasonló online közösségi platformot kívánunk szimulálni amelyen képesek vagyunk felhasználói fiókokat regisztrálni , csoportokat létrehozni és menedzselni.
A csoportokba képeket tudunk feltölteni , illteve az egyes képekhez hozzászólásokat tudunk írni.A csoportok moderálásért és a képek feltöltéséért a megfelelő felhasználói jogokkal rendelkező felhasználók felelősek , ezek egy későbbi pontban lesznek kifejtve.
<br/>
<br/>

# Csoport beosztás
<br/>

- Backend : **Gadácsi  Ákos** és **Hegedűs Máté** <br/>

- Frontend : **Schäffer Tamás** <br/>

- Csoport menedzser : **Veres Levente**





<br/>
# User Manual

<br/>

## Szoftver Beüzemelése 
  > Sajnos a projekt jelenlegi build-jében a frontend rész eléggé hiányos így a backend rész indítása nem lehetséges az .exe fájllal , mivel szükségünk van **Swagger** nevű fejlesztői eszközre a megjelenítésre és az endpointok eléréséhez
 
- Backend :
  * Először a Visual Studio segítségével megnyitjuk a Photory.sln solution fájlt  a Photory mappán belül 
	![Alt text](ReadmePictures/userman0.png?raw=true "Title")
  * A kezdő projekt végrehajtási assemblyjét átállítva WebApi-ra elstartoljuk a projektet az alábbi képek alapján 
	![Alt text](ReadmePictures/userman1.png?raw=true "Title")
	![Alt text](ReadmePictures/userman2.png?raw=true "Title")
	![Alt text](ReadmePictures/userman3.png?raw=true "Title")
  > továbbá a backend hostolva van a https://projectphotory.azurewebsites.net/index.html oldalon 
  
- Frontend :
  * Először a photoryapp mappát megnyitjuk a Visual Studio Code segítségével
	![Alt text](ReadmePictures/userman4.png?raw=true "Title")
	![Alt text](ReadmePictures/userman5.png?raw=true "Title")
  * Megnyitunk egy új terminált <br/>
	![Alt text](ReadmePictures/userman6.png?raw=true "Title")
  * Első indítás előtt futtassuk le az "npm install" parancsot <br/>
	![Alt text](ReadmePictures/userman7.png?raw=true "Title")
  * Majd indításhoz az "npm start" parancsot <br/>
	![Alt text](ReadmePictures/userman8.png?raw=true "Title")
  
  
## Alapvető használati funkciók
<br/>

- Az oldalra jelenleg 3 módon jelentkezhetünk be :
  * felhasználónév <> jelszó
  * emailcím <> jelszó
  * Facebook autentikáció segítségével , amennyiben rendelkezünk Facebook felhasználói fiókkal
  <br/>
-  3 felhasználó fiók előre szerepel a rendszerben a megrendelői használat megkönnyítése végett, ezen fiókok bejelntekezési adatai az alábbiak :
   <br/>
   - 1.
     *  Jogkör : Admin  
     *  Felhasználónév : HegedusMate
     *  Emailcím : hegedus.mate@nik.uni-obuda.hu
     *  Jelszó : Almafa123!
   <br/>
  
  
   - 2.
     *  Jogkör : Group Admin
     *  Felhasználónév : veres.levente@nik.uni-obuda.hu
     *  Emailcím : veres.levente@nik.uni-obuda.hu
     *  Jelszó : Almafa123!
   
   <br/>  
   
   - 3. 
     *  Jogkör : User
     *  Felhasználónév : gadacsi.akos@nik.uni-obuda.hu
     *  Emailcím : gadacsi.akos@nik.uni-obuda.hu
     *  Jelszó : Almafa123!
		
## Elkészített API-k :
  A rendelkezésre álló API-k 6 fő csoportra oszthatóak :
  1. **User API-k**
  -  Megtalálhatóak az User jogosultsághoz tartozó végpontok  :
     * [GET]     /User : egyszerű GET kéréssel megkapjuk az adatbázisban szereplő összes User-t
	 * [GET]     /User/{id} : személyes azonosítót megadva lekérhetjük egy specifikus User adatait
	 * [DELETE]  /User/{id} : személyes azonosítót megadva kitörölhetünk egy adott Usert az adatbázisból
	 * [DELETE]  /User/DeletePhoto/{id} : személyes azonosítót megadva kitörölhetünk egy adott User adott képét
	 * [DELETE]  /User/DeleteComment/{id} : személyes azonosítót megadva kitörölhetünk egy adott User adott hozzászólását
	 * [PUT]     /User/{oldid} : személyes azonosítót megadva frissíthetjük egy adott User adatait
	 * [POST]    /User/{userID}&{GroupID} : személyes azonosítót megadva frissíthetjük egy adott User adatait
	 * [POST]    /User/AddPhoto : egy fotót tölthetünk fel az adatbázisba 
	 * [POST]    /User/AddComment : egy hozzászólást tölthetünk fel az adatbázisba
	 * [POST]    /User/PhotoUpload/{groupID} : egy fotót tölthetünk fel az adatbázisba a saját számítógépünkről
  <br/>
	
  
  2. **GroupAdmin API-k**
  -  Megtalálhatóak az GroupAdmin jogosultsághoz tartozó végpontok :
     * [GET]     /GroupAdmin : egyszerű GET kéréssel megkapjuk az adatbázisban szereplő összes GroupAdmin-t
	 * [GET]     /GroupAdmin/{id} : személyes azonosítót megadva lekérhetjük egy specifikus GroupAdmin adatait
	 * [DELETE]  /GroupAdmin/{id} : személyes azonosítót megadva kitörölhetünk egy adott GroupAdmin az adatbázisból
	 * [PUT]     /GroupAdmin/{oldid} : személyes azonosítót megadva frissíthetjük egy adott GroupAdmin adatait
	 * [POST]    /GroupAdmin/AcceptUser/{userID}&{GroupID} : elfogadhatjuk egy User jelentkezését egy adott csoportba
	 * [POST]    /GroupAdmin/DenyUser/{userID}&{GroupID} : elutasíthatjuk egy User jelentkezését egy adott csoportba
  <br/>
 
  3. **Admin API-k**
  -  Megtalálhatóak az admin jogosultsághoz tartozó végpontok :
     * [GET]     /Admin : egyszerű GET kéréssel megkapjuk az adatbázisban szereplő összes Admin-t
	 * [GET]     /Admin/{id} : személyes azonosítót megadva lekérhetjük egy specifikus Admin adatait
	 * [DELETE]  /Admin/{id} : személyes azonosítót megadva kitörölhetünk egy adott Admin az adatbázisból
	 * [PUT]     /Admin/{oldid} : személyes azonosítót megadva frissíthetjük egy adott Admin adatait
	 * [POST]    /Admin/{userID}&{GroupID} : egy User személyes azonosítóját és egy csoport azonosítóját megadva adhatjuk hozzá az előbbit az utóbbihoz
	 * [POST]    /Admin/CreateGroup : létrehozatunk egy új csoportot
  <br/>	
	
  4. **Auth API-k**
  -  Az autentikációért felelős végpontok :
     * [GET]     /Auth : egyszerű GET kéréssel megkapjuk az adatbázisban szereplő összes felhasználót (fejlesztői használatra)
	 * [PUT]     /Auth/Login : bejeletkezhetünk az oldalra
	 * [POST]    /Auth/Register : beregisztrálhatunk az oldalra

  <br/>
  
  5. **Content API-k**
  -  A megjelenítéshez szükséges végpontok:
     * [GET]     /Content/GetAllCommentsFromPhoto/{photoID} : lekérhetjük egy adott fotóhoz tartozó kommenteket 
	 * [GET]     /GetAllGroup : visszakapjuk az adatbázisban szereplő összes csoportot
	 * [GET]     /GetOnePhoto/{photoid} : egy fotó azonosító alapján lekérhetjuk az adott fotó adatait
	 * [GET]     /GetPhotosFromGroup/{GroupID} : egy csoport azonosító alapján lekérhetjuk az adott csoportban szereplő képeket
	 * [GET]     /Content/GetUserFromGroup/{userID}&{GroupID} : egy csoport azonosító és egy személyes azonosító alapján lekérhetjük egy User adatait  

  <br/> 

  6. **External API**
  -  Facebook autentikációért felelős végpont:
     * [POST]     /ExternalAuth 
	 
 <br/> 
 <br/>

## Felhasználói felületek :	
   - **Főoldal**   <br/>
     ![Alt text](ReadmePictures/userman9.png?raw=true "Title")  <br/>  <br/>
 	Ezen a felületen jelentkezhetünk  be , illetve , ha még nem rendelkezünk felhasználói fiókkal , a **register** szóra kattintva átkerülünk a regisztrációs felületre , amely pedig így néz ki : <br/>
   - **Regisztráció**     
     ![Alt text](ReadmePictures/userman10.png?raw=true "Title")  <br/>  <br/> 
   - **Facebook bejelentkezés**
	 ![Alt text](ReadmePictures/userman11.png?raw=true "Title")  <br/>  <br/> 
	Ha rendelkezünk **Facebook** profillal, az ott használható bejelentkezési adatainkat megadva a **Photoryba** is beléphetünk   
   - Ahogy az feljebb említve volt, sajnos a weboldal megjelítése ,hiányos , viszont a backendhez kapcsolódó funkciókat tökéletesen ki tujuk próbálni a **Swagger** nevű fejlesztői eszközzel
 	 ![Alt text](ReadmePictures/userman14.png?raw=true "Title")  <br/>  

 
<br/>
<br/>
  
# Probléma dokumentáció
<br/>   
  
  A fejlesztés során több problémába is ütköztünk, de a megfelelő energia befektetéssel mindet sikerült megoldanunk

  - A táblák megfelelő felépítésének megtalálása egy visszatérő probléma volt számunkra 
    * Először az első elképzelések alapján történtek meg az oldal működéséhez szükségesnek vélt objektumok lemodellezése (user , photo , group)
    * Ezután a táblák közötti kapcsolatok létrehozásához beállítottuk a megfelelő adattagokat, viszont a felhasználók és a csoportok között egy many-to-many kapcsolat áll fent és ehhez egy új struktúrát hazsnáltunk : a két tábla közé bevezettünk egy UserOfGroup táblát ami egy user egy adott csoporthoz való kapcsolatát jelöli , ezzel áthidalva a many-to-many kapcsolat hátrányait ,elérve egy sokkal átláthatóbb és könnyebben karbantartható adatbázist
    * Végül többször is változtatni kellett a modelleken , mindig az új feature-ök implementálásakor
  - A facebook autentikáció azért volt nagy kihívás , mert egy olyan , számunkra új technológia volt , amelyhez nem tartozott egyértelmű és átfogó dokumentáció.Végül Kovács András segített az autentikációs folyamat részletes leírásával, ezzel megértettük az elméleti részét és így céltudatosan tudtunk dokumentációkat keresni a folyamat egyes elemeihez (pl. a facebook által visszaküldött  token felhasználása és a bejelentkezés szinkronizálása az adatbázisunkkal). 
    > Ezután rátaláltunk az OAuth2 protokollra amely még könnyebbé teszi a különleges engedélyezési folyamatok kiépítését , későbbi projektek során ezt ajánljuk
  - Alapvető félreértésbe ütköztünk a feltöltött képek tárolásával kapcsolatban. Tárolás után mi még tömöríteni szerettük volna képeket , viszont végül csak méretcsökkentett verzióban tároltuk el őket az adatbázisban.
  - Egy emaillel többször is be lehetett regisztrálni 	
    * ennek megoldásához az Asp.Net Users táblához a migrációkhoz megszorításokat kellett hozzáadni  <br/>
    ![Alt text](ReadmePictures/userman12.png?raw=true "Title")
  - Facebook autentikációnál a visszakapott responseban érdekes formátumban szerepelt datetime , ezért a json fájl convertálásánál ezt át kellett állítani
    ![Alt text](ReadmePictures/userman13.png?raw=true "Title")
<br/>   
<br/>   
  - A kommunikáció kifogástalan volt a backendért felelős csapattársainkkal, 1-2 naponta sikerült megbeszélést tartani és egymást segíteni , viszont a frontendünkért felelős csoporttársunk nem teljesítette ezeket a felelősségit , illetve a frontenden végzett munkája is hiányos 
  



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


