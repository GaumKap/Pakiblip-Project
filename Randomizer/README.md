# Randomizer For Pakiblip

command line external program of Randomizer for Pakiblip with .NET Framework
To test it before integration in final Program of Pakiplip Project
>This Source Code is in 2.3 version some things can be fixed or improved

### Source Code
This program is developed in C# with Visual Studio 2019, no additional  pakages is required.

### Features
Randomizer is additionnal program for the Game Pakiblip, this program is in command line
to test the algorithm used by Pakiblip.
The Algorthm respect some rules :
We set intial positon randomly in tab, then we start to choose a new position 1 case to the left, right, up or down.
after the first deplacment we start to choos again a new poisition, but we can't return to an posisition alredy
visited.

The algorthm will end only if we reach the numbers of cases is rechead (in percent of global tab)

exemple :
> 'IN' is the initial position
```
██|██|██|██|██|██|██|██|11|10|██|██|██|██|██|██|██|██|██|██|
██|██|██|██|██|17|16|13|12|9 |8 |██|██|██|██|██|██|██|██|██|
██|██|██|██|19|18|15|14|██|██|7 |6 |██|██|██|██|██|██|██|██|
██|██|██|21|20|██|██|██|██|██|██|5 |4 |██|██|██|██|██|██|██|
██|██|23|22|██|██|██|██|██|██|██|██|3 |2 |██|██|██|██|██|██|
██|25|24|██|76|77|██|██|██|██|██|██|IN|1 |██|██|██|██|██|██|
27|26|██|74|75|78|79|██|██|██|██|██|██|██|██|██|██|██|██|██|
28|29|72|73|██|██|80|██|██|██|██|██|██|██|██|██|██|██|██|██|
31|30|71|70|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|
32|33|68|69|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|
35|34|67|66|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|
36|37|██|65|64|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|
39|38|██|62|63|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|
40|41|60|61|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|
43|42|59|58|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|
44|45|56|57|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|
47|46|55|54|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|
48|49|52|53|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|
██|50|51|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|
██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|██|
size of tab : 400
Number of cases to reach : 20% -> 80
```

