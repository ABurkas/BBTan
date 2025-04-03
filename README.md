# PO2-Kulki-Przeszkody
Programowanie obiektowe 2

Kulki i przeszkody - motor symulacji i gier z przykładem zastosowania

- BBTan, Bricks breaker, Arkanoid, bilardy itp.
- kulki/piłki poruszają się ruchem prostoliniowym i odbijają od przeszkód
- fizyka odbić
- akcja i wizualizacja w czasie rzeczywistym
- podpowiedzi obiektowe
  - motor gry/symulacji i wizualizacja to dwa różne światy
  - stan gry to stan kulek i przeszkód + czas najbliższego zdarzenia zmieniającego stan
  - stan kulki definiowany przez czas startu, położenie startowe i kierunek - nie zmienia się "co klatkę" (pojęcie klatki nie ma sensu w motorze)
  - ściany, przeszkody, nagrody - hierarchia
  - przeszkody odpowiedzialne za określenie punktu i kierunku odbicia
  - model fizyczny bez interfejsu graficznego
  - wizualizacja aktualnego stanu gry na zewnątrz motoru gry 
