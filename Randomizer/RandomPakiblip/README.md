# Randomizer For Pakiblip

Randomizer pour Pakiblip Project en Ligne de commande avec .NET Framework
Affin d'effectuer les test de l'algorythme pour ensite l'implater dans le projet final

> Ce logiciel est en version 2.2 l'algorythme etant imparfait
le code sera surement modifier.

### Functionnality

Ce logiciel contien le code complet d'un algoritme qui gère un tableau suvant une règle
donné 

**La Règle :** On Choisi une cases au hazard dans le tableau, ensuite on choisi une direction au hazard (gauche, droite, haut, bas)
après avoir choisi la première direction on relance un choix de direction. On ne peut pas repasser sur une cases déjà visiter.
On est capable d'acceder a un historique de déplacement car si on est bloquer on pourra retourner en arrière jusqu'a on ne soit plus débloquer

>Le problème de cette règle c'est qu'elle ne fonctionne que jusqu'a 60% du tableau total et crée des grandes zone vide
non exploiter.