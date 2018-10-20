# Project_ressource_evaluation
Le projet a pour objet la réalisation d’une application d’évaluation des développeurs d’une entreprise.
L’évaluation des ressources sur les projets se fait grâce à un fichier Excel dans lequel sont répertoriées les tâches des collaborateurs sur une base quotidienne.
L’objectif de cet outil est de fournir une évaluation fiable sur la base du temps effectif de réalisation des tâches confiées, en prenant en compte les prolongations et les bruits sur la tâche.

REVUE DES TACHES
---
Le responsable hiérarchique se connectera de façon journalière pour ajouter les tâches et les attribuer à un collaborateur disponible, en indiquant le budget temps. Une tâche est rattachée à un projet.
La tâche sera identifiée par :
•	La date du jour
•	Le numéro d’ordre pour les taches créées pour ce même jour (Ex : la 1ère tache du 1er Janvier 2018 aura l’identifiant 01-01-2018/01). 
•	Un libellé
•	Un statut (créée, pause, annulée, clôturée)

Le développeur, à la fin de la tâche marque que celle-ci est terminée dans l’application. 
Le responsable hiérarchique fait la revue des tâches en spécifiant celles qui sont en cours ou achevées. Une tâche peut également être mise en pause ou annulée.

Si la tâche est terminée avant ou dans le budget temps, le responsable hiérarchique vérifiera l’effectivité de la tâche et validera que celle-ci est achevée. Il pourra voir automatique le temps restant et modifier l’heure ou la date de fin.

Si le budget temps alloué est épuisé sans que la tâche ne soit terminée, le responsable hiérarchique pourra attribuer une prolongation de temps en indiquant un motif. Il peut y avoir plusieurs prolongations à une tache.

Le responsable hiérarchique pourra également spécifier « les bruits ». Un bruit est ajouté à une tâche créée et a un impact sur la note de celle-ci. Il peut y avoir plusieurs bruits ajoutés à une tâche. Il faudra mentionner la description du bruit lors de son ajout.

De façon hebdomadaire, le responsable hiérarchique peut générer un rapport hebdomadaire qui lui donne un état de l’ensemble des taches de la semaine et des moyennes des ressources sur la même période.

LE COLLABORATEUR
---
Le collaborateur est la personne à qui la tâche est confiée. Il pourra consulter les tâches qui lui sont confiées.  Le collaborateur marquera le temps de réalisation de la tâche et ajoutera des remarques. Il pourra ensuite la soumettra au responsable pour validation. Il pourra voir à tout moment le rapport de ses activités.

L'ADMINISTRATION
---
L’administrateur de l’application gère les utilisateurs de l’application (création/modification/suppression d’utilisateur et gestion des habilitation).

FORMULES DE CALCUL
---
Formule de calcul de la note
Note = 10-[([(Temps Réalisé+Temps restant- Σ(Temps bruit))-(Budget Temps+Σ(Prolongations))]/(Budget Temps+ Σ(Prolongations) )*10]
Formule de calcul de la moyenne hebdomadaire
Moyenne = (Σ(Notes de la semaine))/(Nombre de notes de la semaine)



