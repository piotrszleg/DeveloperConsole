# Zadanie Rekrutacyjne Robocik/Symulator Wariant 1

Stw�rz konsol� dewelopersk� przy u�yciu atrybut�w.

Argumenty mog� oddzielone spacj�

Przyk�adowe polecenia:
```
Move 1 5 0 
SetTitle Test 
GetTitle
```
Istotne jest tak�e komunikowanie b��d�w w konsoli.

Dopuszczone uproszczenia (ni�sza ocena ale projekt nadal jest sprawdzany)
- rejestracja funkcji bez u�ycia atrybut�w 
- ograniczenie si� do argument�w typu integer 

Dodatkowe punkty 
- polecenie *Help* wpisuj�ce wszystkie dost�pne polecenia 
- nawiasy i zagnie�d�anie wyra�e�
- definiowanie w�asnych parser�w dla niestandardowych typ�w jak wektor czy quaternion 
- zmienne 

W repozytorium znajduje si� ju� scena z interfejsem konsoli i przyk�adowe obiekty.

Wszytkie pliki w repozytorium mo�na dowolnie zmienia�, zosta�y stworzone tylko dla uproszczenia zadania.

Niekt�re linie skrypt�w zosta�y zakomentowane tak aby projekt kompilowa� si� bez jeszcze nieistniej�cych klas.

Przydatne linki:
- [Events in Unity](https://docs.unity3d.com/ScriptReference/Events.UnityEvent_1.html)
- [Creating Custom Attributes](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/creating-custom-attributes)
- [Getting Runtime Type of an Object](https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype?view=netcore-3.1)
- [Getting Type Methods](https://docs.microsoft.com/en-us/dotnet/api/system.type.getmethods?view=netcore-3.1)
- [Getting Custom Attributes (works with MethodInfo)](https://docs.microsoft.com/en-us/dotnet/api/system.reflection.customattributeextensions.getcustomattributes?view=netcore-3.1)
- [Dictionary Type](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netcore-3.1)
- [Dynamic Method Invocation](https://stackoverflow.com/questions/2202381/reflection-how-to-invoke-method-with-parameters)
- [Runtime Type Conversion](https://stackoverflow.com/questions/4010144/convert-variable-to-type-only-known-at-run-time)