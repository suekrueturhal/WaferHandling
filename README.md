# WaferHandling Doku

## Einleitung
Ich hatte leider keine Zeit mehr herauszufinden, wie man eine schöne Roboterarm-Animation macht und dementsprechend auch keine Zeit mehr für die Bonus-Aufgaben.
Meistens ist der Code selbstverständlich (wenn auch teilweise bestimmt etwas ineffizient, vor allem mein XAML und Data Binding brauchen mehr Übung), an passenden Stellen wurden aber ergänzende Kommentare hinzugefügt.
Nach einer anfänglichen Phase der Einarbeitung ins Framework, hatte ich aber viel Spaß damit zu arbeiten.

## Architektur
Ich habe versucht mich bei der Architektur so gut ich konnte an das MVVM-Pattern zu halten.
Dabei kann es gut sein, dass ich es etwas übertrieben habe, aber ich wollte, dass es in der Theorie möglichst gut übertragbar auf ein hypothetisches großes Projekt wäre.
Nur, wenn ich keine Zeit mehr hatte, gab es Abweichungen.

Vier Ordner
- Commands
- Models
- ViewModels
- Views

Ich habe mich an die Standard Rollen der Elemente in diesen Ordnern gehalten.
Ich habe eine MainWindowViewModel Klasse erstellt, die als "übergeordnete" Klasse alle Funktionen zusammenführt und steuert.
Eine ViewModelBase mit boilerplate Code von der alle ViewModels inheriten, damit ich mir den sparen kann.

## Annahmen
Nach kurzer Recherche, habe ich angenommen, dass der Roboterarm einen Wafer aus dem untersten Slot von LP1 entnimmt und in den untersten Slot von LP2 legt.
