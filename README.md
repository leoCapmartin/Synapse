# Synapse

## ToDo List
Remplissez vos todo respectives
 
* Physique
    * [ ] Créer un controleur basique
* Enigmes
    * 
* IA
    * 
* Multi-joueur
    * [ ] Setup un server
* Modélisation 3D
    * 
* Interface / Menus
    *
* Son
    * 

## Tuto git :

* ### Push/Pull
    * Pour simplement push votre code utiliesez : ```$ git push origin <nom de la branche>```.
      Cette commande va siplement push votre branche sur l'origine (soit GitHub)
      
    * Pour push une branche innexistante sur GitHub : ```$ git push --set-upstream origin <nom de la branche>```
      Le parametre set-upstream indique juste a GitHub qu'il faut creer une nouvelle branche
      
    * Pour pull la branche courante : ```$ git pull```
    
    * Pour récuperer une branche sur gitHub qui n'existe pas sur votre pc : ```$ git checkout <le nom de la branche>```

* ### Commit
    Pour commit : 
    ```
    $ git add <les fichiers a add>
    $ git commit -m "votre message"
    ```
    on peut simplifier ces 2 lignes avec ```$ git commit -ma "votre message"``` mais tout les fichiers seront commit
    
* ### Les Branches
    * Pour lister toute les branches : ```$ git branch```
    * Pour se deplacer sur une branche : ```$ git checkout <le nom de la branche>```
    * Pour creer une nouvelle branche : ```$ git branch <nom de la nouvelle branche>```
    * Pour supprimer une branche : ```$ git branch -d <le nom de la branche à supprimer>```
