# Application d'évaluation des ressources

## Équipe
GALA Laureen, SALADIN Baptiste, SEIGNETTE Thomas

## Organisation des fichiers
Le code source se situe dans le dossier ``src`` et la documentation dans le dossier ``doc`` (mini-SRS, diagramme de classe, diagramme des cas d'utilisation, schéma de la BDD, manuel d'utilisation).

## Lancement du système
Les logiciels Visual Studio (Community, Professional ou Enterprise) et Microsoft SQL Server Management Studio sont nécessaires au lancement de l'application.

### Création de la base de données
* Ouvrir SQL Server
* Restaurer la base de données avec le fichier ``src/DV_EVAL_DB.bak``
* Changer les paramètres de connexion dans ``src/EVALUATION.WEB/web.config`` ligne 15

### Lancement de l'application web
Ouvrir le projet ``src/EVALUATION.WEB/EVALUATION.WEB.sln`` dans Visual Studio et le lancer.