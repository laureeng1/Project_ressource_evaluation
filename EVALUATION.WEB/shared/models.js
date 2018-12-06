
define(['definitions', 'utilities'], function () {
    'use strict';

    /* Models */

    modelGlobal.service('erpModels', [
        'commonUtilities', function (commonUtilities) {
            var mainSelf = this;

            mainSelf.TypeConventionEnum =
             {
                 COLLECTIF: "Collectif",
                 PARTICULIER: "Particulier"

             };


            mainSelf.OperatorEnum =
            {
                EQUAL: "EQUAL",
                NOTEQUAL: "NOT EQUAL",
                BETWEEN: "BETWEEN",
                STARSTWITH: "STARTS WITH",
                ENDSWITH: "ENDS WITH",
                CONTAINS: "CONTAINS",
                LESS: "LESS",
                LESSOREQUAL: "LESS OR EQUAL",
                MORE: "MORE",
                MOREOREQUAL: "MORE OR EQUAL"
            };


            //Ajout Enum de produit
            mainSelf.StatutProduitEnum =
         {
             CREE : "Créé",
             ENVALIDATION : "En validation",
             VALIDE : "Validé"
         };


            mainSelf.MySortOrder =
            {
                Ascending: "Ascending",
                Descending: "Descending"
            };

            mainSelf.IdEntiteCoreistrative =
            {
                NephrologieDialyse: 10
            };

            mainSelf.IdTypeStructure =
            {
                CentreDialyse: 6
            };


            mainSelf.TypePersonne = {
                PersonnePhysique: "Personne Physique",
                PersonneMorale: "Personne Morale"
            };

            mainSelf.dataSourceTypePersonne = function () {
                var lst = [
                    mainSelf.TypePersonne.PersonnePhysique,
                    mainSelf.TypePersonne.PersonneMorale,
                ];
                return angular.copy(lst);
            };

            mainSelf.PeriodeReglement = function () {

                var lst = ['HEBDOMADAIRE', 'MENSUEL', 'ANNUEL'];
                return angular.copy(lst);
            };

            mainSelf.dataSourcePays = function () {
                var lst = [
                    { name: "Côte d'ivoire" },
                    { name: "Ghana" },
                    { name: "Liberia" },
                    { name: "Burkina faso" },
                    { name: "Mali" },
                    { name: "Guinée" },
                    { name: "Nigeria" },
                    { name: "Cameroun" },
                    { name: "Bénin" }
                ];
                return Enumerable.From(lst).OrderBy('$.name').Select('$').ToArray();
            };

            mainSelf.dataSourceCommunes = function () {

                var lst = [
                    { name: "Port-Bouet" },
                    { name: "Koumassi" },
                    { name: "Marcory" },
                    { name: "Yopougon" },
                    { name: "Adjamé" },
                    { name: "Cocody" },
                    { name: "Plateau" },
                    { name: "Bingerville" },
                    { name: "Treicheville" },
                    { name: "Attécoubé" },
                    { name: "Abobo" }
                ];
                return Enumerable.From(lst).OrderBy('$.name').Select('$').ToArray();
            };

            mainSelf.dataSourceEthnies = function () {
                var lst = [
                    { name: "Abbey" },
                    { name: "Agni" },
                    { name: "Abouré" },
                    { name: "Abidji" },
                    { name: "Abron" },
                    { name: "Abouré" },
                    { name: "Ega" },
                    { name: "Ahizi" },
                    { name: "Adjoukrou" },
                    { name: "Alladian" },
                    { name: "Appolo" },
                    { name: "Attié" },
                    { name: "Avikam" },
                    { name: "Ayahou" },
                    { name: "Baoulé" },
                    { name: "Brignan" },
                    { name: "Ebrié" },
                    { name: "Ehotilé" },
                    { name: "Elomouin" },
                    { name: "Essouma" },
                    { name: "Gwa" },
                    { name: "M'batto" },
                    { name: "Yowrè" },
                    { name: "Bakwe" },
                    { name: "Bété" },
                    { name: "Dida" },
                    { name: "Gagou" },
                    { name: "Godié" },
                    { name: "Guéré" },
                    { name: "Kouzié" },
                    { name: "Kroumen" },
                    { name: "Neyo" },
                    { name: "Niaboua" },
                    { name: "Wobè" },
                    { name: "Gouro" },
                    { name: "Koyata" },
                    { name: "Mahou" },
                    { name: "Malinké" },
                    { name: "Mangoro" },
                    { name: "Nomou" },
                    { name: "Toura" },
                    { name: "Wan" },
                    { name: "Yacouba" },
                    { name: "Sénoufo" },
                    { name: "Lobi" },
                    { name: "Birifor" },
                    { name: "Camara" },
                    { name: "Degha" },
                    { name: "Djafolo" },
                    { name: "Djimini" },
                    { name: "Djamala" },
                    { name: "Gbin" },
                    { name: "Koulango" },
                    { name: "Lohon" },
                    { name: "Tagbana" },
                    { name: "Ténéwéré" },
                    { name: "Tiembara" },
                    { name: "Nafara" },
                    { name: "Niarafolo" },
                    { name: "Samassogo" },
                    { name: "Sénoufo" }
                ];
                return Enumerable.From(lst).OrderBy('$.name').Select('$').ToArray();
            };

            mainSelf.dataSourceGroupesSanguin = function () {
                return [
                    { name: "A+" },
                    { name: "A-" },
                    { name: "B+" },
                    { name: "B-" },
                    { name: "O+" },
                    { name: "O-" },
                    { name: "AB+" },
                    { name: "AB-" }
                ];
            };
               mainSelf.GetStatutsDemandeAccesDossierMedical = function () {

       var lst = ["Ajouté", "Validé", "Rejeté"];
       return angular.copy(lst);
           };


            mainSelf.dataSourceSituationMatrimoniale = function () {
                return [

                    { name: "Célibataire", value: "Célibataire" },
                    { name: "Marié(e)", value: "Marié(e)" },
                    { name: "Veuf(ve)", value: "Veuf(ve)" }
                ];
            };

            mainSelf.dataSourceTypeSouscription = function () {
                return [

                    { name: "Convention", value: "Convention" },
                    { name: "Individuelle", value: "Individuelle" }
                ];
            };


            mainSelf.dataSourceTypeAffilie = function () {
                return [

                    { name: "Conjoint", value: "Conjoint" },
                    { name: "Enfant", value: "Enfant" },
                    { name: "Ascendant", value: "Ascendant" }
                ];
            };

            mainSelf.StatutMaladieChronique =
            {
          AJOUTER: "Ajouté",
          VALIDE: "Validé",
          REJETER: "Rejeté",
           LEVE: "Levé"
            };

            mainSelf.StatutDemandeAccesDossier =
     {
         AJOUTER: "Ajouté",
         VALIDE: "Validé",
         REJETER: "Rejeté"
     };

            mainSelf.TypeDemandeAcces =
                     {
                         PRESTATAIREMEDICAL: "PrestataireMedical",
                         UTILISATEUR: "Utilisateur"
                     };

            mainSelf.StatutPrescriptionMaladieChronique =
         {
             ENCOURS: "En cours",
             ARRETE: "Arreté"
         };


            mainSelf.dataSourceTypePiece = function () {
                return [

                    { name: "CNI", value: "CNI" },
                    { name: "Passeport", value: "Passeport" },
                    { name: "Permis de conduire", value: "Permis de conduire" }
                ];
            };

            mainSelf.dataSourceAppareils = function () {
                return [
                    { name: "Appareil digestif" },
                    { name: "Appareil spléno-ganglionnaire" },
                    { name: "Appareil locomoteur" },
                    { name: "Appareil cardiovasculaire" },
                    { name: "Appareil respiratoire" },
                    { name: "Appareil uro-génital" },
                    { name: "Appareil neurologique" },
                    { name: "Appareil gynécologique" }
                ];
            };

            mainSelf.GetCivilites = function () {

                var lst = [
                    { name: "", sexe: "MF" },
                    { name: "Enfant", sexe: "MF" },
                    { name: "M.", sexe: "M" },
                    { name: "Mme", sexe: "F" },
                    { name: "Mlle", sexe: "F" },
                    { name: "Dr", sexe: "MF" },
                    { name: "Pr", sexe: "MF" }
                ];
                return angular.copy(lst);
            };


            mainSelf.dataSourceCivilite = function () {
                var lst = [

                    { name: "M", value: "M" },
                    { name: "Mme", value: "Mme" },
                    { name: "Mlle", value: "Mlle" },
                    { name: "Dr", value: "Dr" }
                ];
                return angular.copy(lst);
            };

            mainSelf.dataSourceCiviliteBySexe = function () {
                var lst = [

                    { sexe: "Masculin", name: "M", value: "M" },
                    { sexe: "Féminin", name: "Mme", value: "Mme" },
                    { sexe: "Féminin", name: "Mlle", value: "Mlle" },
                    { sexe: "Masculin", name: "Dr", value: "Dr" },
                    { sexe: "Masculin", name: "Prof", value: "Prof" },
                    { sexe: "Féminin", name: "Dr", value: "Dr" },
                    { sexe: "Féminin", name: "Prof", value: "Prof" }
                ];
                return angular.copy(lst);
            };

            mainSelf.dataSourceGroupeTypeTiers = function () {
                return [

                    { name: "Adhérent", value: "ADH" },
                    { name: "Prestataire", value: "PRT" },
                    { name: "Autres", value: "" }
                    //{ name: "Autre", value: "A" }
                ];
            };

            mainSelf.dataSourceSexe = function () {
                return [

                    { name: "Masculin", value: "Masculin" },
                    { name: "Féminin", value: "Féminin" }
                    //{ name: "Autre", value: "A" }
                ];
            };

            mainSelf.dataSourceSexeInt = function () {
                return [

                    { name: "Masculin", value: "1" },
                    { name: "Féminin", value: "0" }
                ];
            };


            mainSelf.dataSourceTypeContrat = function () {
                return [

                    { name: "Collectif", value: "1" },
                    { name: "Individuel", value: "0" }
                ];
            };


            mainSelf.dataSourceCivilite = function () {
                return [

                    { name: "M", value: "M" },
                    { name: "Mme", value: "Mme" },
                    { name: "Mlle", value: "Mlle" },
                    { name: "Dr", value: "Dr" }
                ];
            };

            mainSelf.dataSourceAffiliation = function () {
                return [
                    { name: "Père" },
                    { name: "Mère" },
                    { name: "Epoux" },
                    { name: "Epouse" },
                    { name: "Enfant" }
                ];
            };

            mainSelf.dataSourceTypePiece = function () {
                return [
                    { name: "CNI" },
                    { name: "Attestation" },
                    { name: "Permis conduire" },
                    { name: "Passport" }
                ];
            };

            mainSelf.dataSourceTypeIntervenant = function () {
                return [
                    { name: "Adhérent" },
                    { name: "Bénéficiaire" },
                    { name: "Démandeur" },
                    { name: "Epoux(se)" },
                    { name: "Défunt" }
                ];
            };


            mainSelf.EtatPrestationEnum =
            {
                CREEE: "Créée",
                EN_ETUDE: "En étude",
                VALIDEE: "Validée",
                PAYEE: "Payée",
                ANNULE: "Annulée",
                ARCHIVEE: "Archivée",
                REJETEE: "Rejetée",
                SUSPENDU: "Suspendue"
            };

            mainSelf.GetEtatsPrestation = function () {

                var lst = [
                    mainSelf.EtatPrestationEnum.CREEE,
                    mainSelf.EtatPrestationEnum.EN_ETUDE,
                    mainSelf.EtatPrestationEnum.VALIDEE,
                    mainSelf.EtatPrestationEnum.PAYEE,
                    mainSelf.EtatPrestationEnum.SUSPENDU
                ];
                return angular.copy(lst);
            };


            mainSelf.EtatValidationEnum =
            {
                VALIDER: "VALIDE",
                AJOURNER: "AJOURNE",
                REJETER: "REJETE"
            };

            mainSelf.StatutAssureEnum =
            {
                CREE: "Créé",
                ENVALIDATION: "En validation",
                VALIDE: "Validé",
                INCORPORER: "Incorporé",
                RADIER: "Radié",
                ARCHIVER: "Archivé",
                SUSPENDUE: "Suspendue"
            };
            mainSelf.StatutConventionEnum =
            {
                CREE: "Créé",
                ENVALIDATION: "En validation",
                VALIDE: "Validé",
                INCORPORER: "Incorporé",
                RADIER: "Radié",
                ARCHIVER: "Archivé",
                SUSPENDUE: "Suspendue",
            };


            mainSelf.TypeAssureEnum = {
                ADHERENT: "Adherent",
                CONJOINT: "Conjoint",
                ASCENDANT: "Ascendant",
                ENFANT: "Enfant"
            };

            mainSelf.TypePayeurEnum = {
                ADHERENT: "Adherent",
                Souscripteur: "Souscripteur"
             
            };

            mainSelf.CodeObjetDocumentEnum = {
                ADHERENT: "OBJ0001",
                CONJOINT: "OBJ0002",
                ASCENDANT: "OBJ0004",
                ENFANT: "OBJ0003",
                SINISTRE: "OBJ0005"
            };

            mainSelf.CodeNatureReglementEnum = {
                PRIME: "NA001",
                CARTE: "NA002",
                DUPLICATACARTE: "NA003",
                DROITADHESION: "NA004"
            };

            /* Enum treso */
            mainSelf.SensTreso = function () {
                return [
                    { name: "Encaissement" },
                    { name: "Décaissement" }
                ];
            };

            mainSelf.SensTresoList = function () {
                var lst = [
                    { name: "Encaissement", code: "E" },
                    { name: "Décaissement", code: "D" }
                ];
                return Enumerable.From(lst).OrderBy("$.code").Select("$").ToArray();
            };

            mainSelf.CodeSensTreso = {
                Encaissement: "E",
                Decaissement: "D"
            };

            mainSelf.CodeOperation = {
                Valider: "VALIDER",
                Annuler: "ANNULER",
                Supprimer: "SUPPRIMER"
            };

            mainSelf.Operation = {
                Save: "SAVE",
                Valider: "VALIDER",
                Annuler: "ANNULER",
                Actualiser: "ACTUALISER",
                Rechercher: "SEARCH",
                Activer: "ACTIVER",
                Lever: "LEVER",
                New: "NEW"
            };

            mainSelf.StatutDemandePECEnum = {
                CREE: "Créé",
                CLOTURE: "Cloturé",
                ACCORDPREALABLE: "En accord préalable",
                ENACCEPTATIONDEDETTE : "En acceptation de dette",
                ENATTENTECLOTURE: "En attente de cloture",
                REJETE: "Rejete",
                VALIDE: "Validé"
            };


            mainSelf.StatutPresouscriptionTaxeEnum = {
                LOCALITE: "Localite",
                SEXE: "Sexe",
                TYPECONTRAT: "TypeContrat",
                NBPERSONNE: "NBPersonne",
                AGE: "Age"
            };



            mainSelf.ReportNames = {
                BONPRISECHARGE: "BonPriseEnCharge",
                BORDEREAU: "Bordereau",
                PRODUITGARANT: "ProduitGarant",
                GRANDLIVRECPTS: "GrandLivreCompte",
                MEDICAMENT: "Medicament",
                GRANDLIVRETIERS: "GrandLivreTiers",
                PRESTATIONPRESTATAIRE: "PrestationPrestataire",
                BALANCECPTS: "BalanceCompte",
                PRISEENCHARGE: "PriseEnChargeLigne",
                BALANCETIERS: "BalanceTiers",
                SOUSCRIPTEUR: "Souscripteur",
                ACTESCONVENTIONNES: "ActesConventionnes",
                SINISTRERD: "SinistreRD",
                ETATSCAISSES: "EtatCaisses",
                ETATSOPERATIONSCAISSES: "EtatsOperationsCaisses",
                GARANTIES: "Garanties",
                REGLEMENTFACTUREPERSONNEMORALE: "ReglementFacturePersonneMorale",
                REGLEMENTFACTUREPERSONNEPHYSIQUE: "ReglementFacturePersonnePhysique",
                ECARTSPRESTATIONSPHARMACIE: "EcartsPrestationsPharmacies",
                SUSPENSIONPRESTATAIRE: "report_etat_sanction_prestataire",
                DEPENSEAGESEXE: "EtatsDepenseSexeTrancheAge",
                ASSURESUSPENSION: "AssureSuspension",
                ASSUREREMISEENVIGUEUR: "AssureRemiseEnVigueur",
                CRMRELANCETYPESMS: "report_relance_sms",
                ETATFACTUREPAIEMENT: "report_facture_typepaiement",
                ETATREMISEENVIGUEUR: "report_remise_envigueur",
                ETATFACTUREREJETE: "report_facturation_exclusion",
                ETATFACTUREEMIS: "report_facture_emis",
                ETATFACTURETRAITEE: "report_facture_traitee",
                POLICESASSURES: "report_polices_assures",
                SINISTREDEPENSEPARCONTRATASSURE: "EtatDepenseParContratAssure",
                SINISTREDEPENSEPARPERSONNEPARFAMILLE: "EtatDepenseParPersonneParFamille",
                SINISTREDEPENSEPARCENTREDESOINS: "EtatDepenseParCentreDeSoins",
                SINISTREDEPENSEPARPERIODE: "EtatDepenseParPeriode",
                SINISTREDEPENSEPARAFFECTION: "EtatDepenseParAffection",
                SINISTREDEPENSEPARACTE: "EtatDepenseParActe",
                SINISTREDEPENSEPARPRESCRIPTEUR: "EtatDepenseParPrescripteur",
                SINISTREDEPENSEPARPRESTATAIRE: "EtatDepenseParPrestataire",
                DEMANDECOTATION: "report_cotation_garant",
                ETATMALADESCHRONIQUESGARANT: "report_malades_chronique",
                ETATAFFECTIONCHRONIQUE: "report_affection_chronique",
                ETATMALADIECHRONIQUEMEDECINCONSEIL: "report_maladiechronique_medecinconseil",
                ETATCENTRECONVENTIONNEPRODUIT: "report_centreconventionne_produit",
                ETATLISTEMEDICAMENTS: "EtatListeMedicaments",
                CARTEASSURE: "report_carte_assure",
                
                ETATPOLICEASSUREPERIODE: "EtatPoliceAssurePeriode",
                ETATPOLICEPRODUITASSURE: "EtatPoliceProduitAssure",
                ETATCARTEPERIODE: "EtatCartePeriode",
                ETATCARTERETIRE: "EtatCarteRetire",
                ETATINCORPORATIONPERIODE: "EtatIncorporationPeriode",
                ETATCONVENTIONPERIODE: "EtatConventionPeriode",
                ETATPRISEENCHARGEFAMILLEACTE: "EtatPriseEnChargeTypeActe",
                ETATASSUREPARGARANT: "EtatAssureParGarant",
                ETATACTECONVENSIONNEPARPRESTATAIRE: "EtatActeConvensionneParPrestataire",
                ETATGARANTIECODEMEDICAL: "EtatGarantie",
                ETATPRODUITPARGARANT: "EtatProduitGarant",
                ETATPRESTATAIREMEDICAMENT: "EtatPrestataireAvecEcartDePrix",
                ETATPRISEENCHARGE: "EtatPriseEnCharge",
                ETATRESEAUSOIN: "EtatReseauSoin",
                ETATNBAFFECTION: "EtatNombreAffection",

                REGLEMENTLOTFACTUREPERSONNEPHYSIQUE: "ReglementLotFacturePersonnePhysique",
                REGLEMENTLOTFACTUREPERSONNEMORALE: "ReglementLotFacturePersonneMorale",

                ETATPRECOMPTERUBRIQUE: "report_precompte_rubrique",

                //
                ETATJOURNALDESECRITURES: "ComptaJournalEcritures",
                ETATGRANDLIVRE: "ComptaGrandLivre",
                ETATBALANCEGENERALE: "ComptaBalanceGenerale",

                ETATALERTEPRIMEIMPAYE: "report_alerte_prime_impaye",
                ETATALERTEPLAFONDBUDGET: "report_alerte_garant_plafond_budget",
                ETATRELANCEPLAFONDINDIVIDU: "report_relance_plafond_individu",
                ETATRELANCEPLAFONDFAMILLE:"report_relance_plafond_famille"

            };

            mainSelf.dataSourceTypeCompteGeneral = function () {
                return [
                    { name: "Collectif" }, //Total
                    { name: "Individuel" }//Détail
                ];
            };

            mainSelf.SensMouvementList = function () {
                var lst = [
                    { name: "Débit", code: "D" },
                    { name: "Crédit", code: "C" }
                ];
                return Enumerable.From(lst).OrderBy("$.code").Select("$").ToArray();
            };

            mainSelf.TypeContratPresouscription = {
                COLLECTIF: 1,
                INDIVIDUEL: 0
            };

            mainSelf.dataSourceTypeSouscripteur = function () {
                return [
                    { name: mainSelf.TypeAssureEnum.ADHERENT },
                    { name: "Tierce personne" }
                ];
            };

            mainSelf.SensMouvementEnum = {
                DEBIT: "D",
                CREDIT: "C"
            };
            //#endregion


        }
    ]);
});

