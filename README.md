# Stereograph-Tests

Quelques petits soucis à contourner tels que les headers du Csv qui sont en format snake case bien pénible pour l'import mais sinon pas de problème particulier.
J'ai pris la liberté de ne pas conteneuriser l'application étant donné que la DB est contenue dans le projet. Je pense que c'est OverKill et en toute franchise la mise en place d'une image Docker sur un projet nouveau n'est pas mon domaine d'expertise ^^

Je pense avoir résolu les problématiques demandées à savoir l'ajout d'opérations de CRUD ainsi que l'import des personnes via le Csv.
Pour ce faire, j'ai trouvé préférable d'utiliser un pattern repository permettant de mock le comportement lors des tests unitaires.

Ces derniers testent simplement le bon fonctionnement du controller en vérifiant l'obtention du status code HTTP souhaité. Je n'ai pas trouvé pertinent de tester tous les cas d'usage.

Enfin, pour ce qui est de l'architecture du projet (en termes de directory), j'ai utilisé un dossier 'fourre tout' nommé Utils regroupant plusieurs scripts à défaut de créer un dossier pour chaque étant donné qu'ils ne sont pas de même nature.
