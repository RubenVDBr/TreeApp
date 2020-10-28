Maak eerst een library aan om je klasses in te zetten. (rechtermuisklik op je solution, add -> new project -> tik library in en selecteer Class Library (.Net Core), maak zeker dat het c# zegt en niet 
Visual Basic.). Een library is een plaats buiten je wpf solution. Dit is om alles net en ordelijk te houden, het mag technisch gezien aangemaakt worden in je wpf app, maar we zullen het meestal apart doen.
Noem het Prb.ForestGame.Core

Je ziet dat de library automatisch een Class1.cs geeft, delete die maar. Om een nieuwe klasse te maken doe je een rechtermuisklik op je library, kies add -> class. Noem die altijd hoe je object zal noemen.
In dit geval noemen we het Tree.cs

WTF is een klasse nu en waarom hebben we da nodig? Een klasse is simpelweg gwn een soort blueprint. Stel dat je 30 autos moet programmeren en elke auto heeft een prijs, kleur, topsnelheid etc.. 
Hoe je dit normaal zou doen is mss het makkelijkst met alles in arrays te steken. Een array voor de kleur van elke auto. Dan zou je 30 instanties hebben in je array met allemaal kleuren. 
AutoKleuren[5] zou bvb het kleur van auto #5 geven. Uiteindelijk is da nie ideaal als je programma complexer begint te worden. Dus introduceren we klasses. Da zijn eigenlijk lege objecten met parameters.
Bvb: Een auto heeft een string kleur, een dec prijs, een int topsnelheid etc. We kunnen die veel gemakkelijker oproepen later in onze code via auto.prijs bvb. De uitleg van William op zn filmpje is 
fantastisch en veel uitgebreider dus als dit als bs klinkt, bekijk dan zeker eens het filmpje vanaf: 18:20  (https://web.microsoftstream.com/video/22d34f4f-38c2-41e6-99d5-a3fb0e8e30f7)


Ga nu naar 1.0 in Tree.cs