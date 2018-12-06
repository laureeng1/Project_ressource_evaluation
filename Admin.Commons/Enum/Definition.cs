namespace Admin.Common.Enum
{

    #region Project architecture enum

    public class GlobalConstantes
    {
        public const byte MatriculeAssureLength = 11;

        public const string MsgErreurAuthentification = "Login/Mot de passe incorrect";

        public const string MsgErreurProfil =
            "Cet utilisateur n'a aucun profil valide. Veuillez contacter un administrateur pour plus d'information";

        public const string MsgErreurActif =
            "Votre compte utilisateur est désactivé. Veuillez contacter un administrateur pour plus d'information";

        public const string CustomException = @"-CUSTOM-EXCEPTION";
        public const string CustomRegleGestionException = @"-CUSTOM-REGLE-GESTION-EXCEPTION";
    }

    public class MySortOrder
    {
        public const string Ascending = "Ascending";
        public const string Descending = "Descending";
    }

    public class OperatorEnum
    {
        public const string EQUAL = "EQUAL";
        public const string NOTEQUAL = "NOT EQUAL";
        public const string BETWEEN = "BETWEEN";
        public const string STARSTWITH = "STARTS WITH";
        public const string ENDSWITH = "ENDS WITH";
        public const string CONTAINS = "CONTAINS";
        public const string LESS = "LESS";
        public const string LESSOREQUAL = "LESS OR EQUAL";
        public const string MORE = "MORE";
        public const string MOREOREQUAL = "MORE OR EQUAL";
    }

    #endregion
    public class TypeQuestionEnum
    {
        public const string TYPEAFFECTION = "TypeAffection";
        public const string AFFECTION = "Affection";

    };

    public class StatutDemandeAcces
    {
        public const string AJOUTER = "Ajouté";
        public const string VALIDER = "Validé";
        public const string REJETER = "Rejeté";
    };

    public class RoleVisiteurEnum
    {
        public const string Visiteur = "Visiteur";
    };
    public class TypeDemandeAcces
    {
        public const string UTILISATEUR = "Utilisateur";
        public const string PRESTATAIREMEDICAL = "PrestataireMedical";
    };

    public enum EntityTypeEnum
    {
        Gestionnaire,
        Garant,
        Prestataire
    }

    public class RoleUserEnum
    {
        public const string MEDECINCONSEIL = "Médecin conseil";
        public const string GARANT = "Garant";
        public const string ADMINGARANT = "Admin Garant";
        public const string GESTIONNAIRE = "Gestionnaire";
        public const string PHARMACIE = "Pharmacie";
       
    }

    public enum Statut
    {
        Existe = 0,
        Supprime = 1
    }

    public class StatutConnexionEnum
    {
        public const string Fail = "Echec";
        public const string Succes = "Succes";
    }


    public class TypeDocumentProductionEnum
    {
        public const string CONTRAT_SOUSCRIPTION = "Contrat de souscription";
        public const string CONTRAT_CONVENTION = "Contrat de convention";
        public const string GARANT_CONVENTION = "Convention du garant";
        public const string PRESTATAIRE_CONVENTION = "Convention du prestataire";
        public const string PRESOUSCRIPTION_DEMANDE_COTATION = "Demande de cotation";
        public const string PRESOUSCRIPTION_DEMANDE_COTATION_MORALE = "Demande de cotation morale";
        public const string AVENANT = "Avenant";
       
    }

    public class AlertesEnum
    {
     
    }
    public class DecaissementStatutEnum
    {
        public const string ENVALIDATION = "En validation";
    }

    public class TypeTaxeStatutEnum
    {
        public const string NBPERSONNE = "NBPersonne";
        public const string SEXE = "Sexe";
        public const string AGE = "Age";
        public const string LOCALITE = "Localité";
        public const string TYPECONTRAT = "TypeContrat";
    }
    public class TypeTaxeTypeContratStatutEnum
    {
       
        public const int COLLECTIF = 1;
        public const int INDIVIDUEL = 0;
    }

    public class MaladieChroniqueStatutEnum
    {
        public const string AJOUTER = "Ajouté";
        public const string VALIDE = "Validé";
        public const string REJETER = "Rejeté";
        public const string LEVE = "Levé";
    }
    public class PrescriptionMaladieChroniqueStatutEnum
    {
       
        public const string ENCOURS = "en cours";
        public const string ARRETEE = "arrètée";
    }

    public class TypeCourrierEnum
    {
        public const string COURRIER_RELANCE_IMPAYE = "Relance pour prime impayé";
        public const string COURRIER_DEMANDE_CARTE = "Courrier de demande de carte";
        public const string COURRIER_VALIDATION = "Courrier de validation";
        public const string COURRIER_RELANCE_PLAFONDINDIVIDU = "Relance pour plafond individuel atteint";
        public const string COURRIER_RELANCE_PLAFONDFAMILLE = "Relance pour plafond famille atteint";
        public const string COURRIER_RELANCE_PLAFONDBUDGET = "Relance pour plafond budget atteint";
        public const string COURRIER_RELANCE_CONTRATECHU = "Relance pour contrat échu";
    }
    
    public class IdComplexiteMdp
    {
        public const short MdpLibre = 1;
        public const short MdpAlphaNum = 2;
        public const short MdpAlphaNumSpe = 3;
    }

    public class ElementComplexiteEnum
    {
        public const string Letter = "LETTER";
        public const string Num = "NUM";
        public const string SpeChar = "SPE-CHAR";
        public const string Maj = "MAJ";
        public const string Min = "MIN";
    }

    public class EntiteNameCodification
    {
        public const string FsAdherent = "Fs-Adherent";
        public const string FsPrestation = "Fs-Prestation";
        public const string FsPret = "Fs-Pret";
    }

    public class PartieElmtCodificationEnum
    {
        public const string Racine = "Racine";
        public const string Prefixe = "Prefixe";
        public const string Suffixe = "Suffixe";
    }

    public class CodeObjetDocumentEnum
    {
        public const string ADHERENT = "OBJ0001";
        public const string CONJOINT = "OBJ0002";
        public const string ASCENDANT = "OBJ0004";
        public const string ENFANT = "OBJ0003";
        public const string SINISTRE = "OBJ0005";
    };

    public class ElementCodificationEnum
    {
        public const string Struct = "Struct";
        public const string NumOrdre = "NumOrdre";
        public const string Cste = "Cste";
        public const string Year = "Year";
        public const string Mois = "Mois";
        public const string Day = "Day";
        public const string AbrPtnaire = "AbrPtnaire";
        public const string TypePrest = "TypePrest";
    }

    public class SexeEnum
    {
        public const string MASCULIN = "Masculin";
        public const string FEMININ = "Féminin";
    }

    public class EntiteWorkflow
    {
        public const string SOUSCRIPTIONLIGNE = "SOUSCRIPTIONLIGNE";
        public const string DECAISSEMENT = "DECAISSEMENT";
        public const string SOUSCRIPTIONLIGNEARRET = "SOUSCRIPTIONLIGNEARRET";
        public const string CONVENTIONARRET = "CONVENTIONARRET";
    }

    public class CiviliteEnum
    {
        public const string MONSIEUR = "M";
        public const string MADAME = "Mme";
        public const string MADEMOISELLE = "Mlle";
        public const string DOCTEUR = "Dr";
    }
    public class OperateurEnum
    {
        public const string ND = "ND";
        public const string ADDITION = "+";
        public const string SOUSTRACTION = "-";
        public const string MULTIPLICATION = "*";
        public const string DIVISION = "/";

    }

    public class NumeroPreSouscription
    {
        public const string PRESOUSCRIPTION = "PRS";
    }

    public class CodeFormule
    {
        public const string PRIMEPRESOUSCRIPTION = "Prime_PreSouscription";
    }

    public class WfTypeCircuitEnum
    {
        public const string FsAdhesion = "Fs-Adhesion";
        public const string FsPret = "Fs-Pret";
        public const string FsPrestation = "Fs-Prestation";
    }




    public class ComptaTypeTierCode
    {
        public const string ADHERENT    =  "ADH";
        public const string PRESTATAIRE = "PRT";
  
    }


    public enum StatutsFamilleEnum
    {
        IdAdherent = 1,
        IdConjoint = 2,
        IdEnfant = 3
    }

    public class StatutsPecEnum
    {
        public const string CREEE = "Créée";
        public const string TRAITEE = "Traitée";
        public const string VALIDEE = "Validée";
        public const string REJETEE = "Rejetée";
    }


    public class Processus
    {
        public const int CreerAdherent = 3;
        public const int CreerConjoint = 4;
        public const int CreerEnfant = 5;
        public const int LeverSuspensionAdherent = 1005;
        public const int LeverSuspensionConjoint = 1006;
        public const int LeverSuspensionEnfant = 1007;
        public const int CreerUnePecAuto = 1008;
        public const int CreerPrestation = 1009;
        public const int FairePrescription = 2008;
        public const int FaireOrientation = 2009;
    }

    public class PrestataireActionErreur
    {
        public const string CreerPec = "Ce prestataire ne peut pas creer une prise en charge";
        public const string CreerAffection = "Ce prestataire ne peut creer une affection";
        public const string RealiserPrestation = "Ce prestataire ne peut pas realiser une prestation";
        public const string FaireOrientation = "Ce prestataire ne peut pas faire une orientation";
        public const string ExecuterOrientation = "Ce prestataire ne peut pas executer une orientation";
        public const string FairePrescription = "Ce prestataire ne peut pas faire une prescription";
        public const string DispenserMedicament = "Ce prestataire ne peut pas dispenser un medicament";
    }

    public class RoleVariableEnvEnum
    {
        public const string VariableAControler = "Variable à contrôler";
        public const string VariableDeReference = "Variable de référence";
    }

    public class StatutsDetPecEnum
    {
        public const string CREEE = "Créée";
        public const string TRAITEE = "Traitée";
        public const string VALIDEE = "Validée";
        public const string REJETEE = "Exclue";
    }

    public class StatutsAccordPrealableEnum
    {
        public const string MISEATTENTE = "Mise en attente";
        public const string VALIDEE = "Validée";
        public const string REJETEE = "Rejetée";
    }

    public class StatutsFactureEnum
    {
        public const string CREEE = "Créée";
        public const string TRAITEE = "Traitée";
        public const string VALIDEE = "Validée";
        public const string REJETEE = "Rejetée";
        public const string REGLEE = "Réglée";
    }





    public class StatutsCarteEnum
    {
        public const string ENVALIDATION = "En validation";
        public const string VALIDEE = "Validée";
        public const string IMPRIMEE = "Imprimée";
        public const string RETIREE = "Retirée";
    }

    public class TypeRenouvellementEnum
    {
        public const string DUPLICATA = "Duplicata";
        public const string INITIAL = "Initial";
        public const string RENOUVELLER = "Renouveller";
    }



    public class Sens
    {
        public const string DEBIT = "D";
        public const string CREDIT = "C";
    }

    public class EtatJournee
    {
        public const string Ouvert = "Ouvert";
        public const string Cloture = "Cloture";
    }

    public class ModeAmortissement
    {
        public const string INFINE = "IFN";
        public const string CONSTANTSURTITRE = "CTI";
        public const string CONSTANTSURCAPITAL = "CCA";
        public const string ANNUITESCONSTANTES = "ACS";

    }

    public class Periodicite
    {
        public const string MENSUELLE = "MEN"; //PR1
        public const string TRIMESTRIELLE = "TRI"; //PR2
        public const string SEMESTRIELLE = "SEM"; //PR3
        public const string ANNUELLE = "ANN"; //PR4

    }

    public class TypeReference
    {
        public const string TYPEDETITRE = "05";
        public const string TYPEDORDRE = "06";
        public const string NATUREDORDRE = "07";
        public const string TRANSFERT = "09";
        public const string MODEREGLEMENT = "13";
        public const string TYPEDETRANSACTION = "08";
        public const string ETATCOMPTE = "20";
        public const string DIVIDENDE = "21";
        public const string TYPEDEREMBOURSEMENT = "12";
    }

    public class CodeTypeMouvement
    {
        public const string PAIEMENTPRIME = "paiement_prime";
        public const string PAIEMENTCARTE = "paiement_carte";
        public const string REMBOURSEMENTDIRECT = "remboursement_direct";
        public const string REMBOURSEMENTPRESTATAIRE = "remboursement_prestataire";


    }

    public class TypeTitre
    {
        public const string ACTIONS = "ACT";
        public const string BONS = "BON";
        public const string OBLIGATIONS = "OBL";
    }

    public class TypeDordre
    {
        public const string AuMarche = "MAR";
        public const string CoursLimite = "CRL";
        public const string ToutOuRien = "TOR";
    }

    public class SensOrdre
    {
        public const string ACHAT = "ACH";
        public const string VENTE = "VET";
        public const string SOUSCRIPTION = "SOUSC";
    }

    public class EtatMouvement
    {
        public const string Comptabilise = "Comptabilisé";
        public const string Annule = "Annulé";
        public const string AucunEtat = "En Attente";
    }

    public class CodeTypeTransfert
    {
        public const string TransfertInterne = "TRI";
        public const string TransfertSortant = "TRES";
        public const string TransfertEntrant = "TREE";
    }

    public class EtatTransfert
    {
        public const string EnAttente = "En Attente";
        public const string Valide = "Validé";
        public const string Rejete = "Rejeté";
        public const string Annule = "Annulé";
    }

    public class ButtonsOrdreNames
    {
        public const string Ajourner = "Ajourner";
        public const string Annuler = "Annuler";
        public const string Executer = "Executer";
        public const string Forcer = "Forcer";
        public const string Nouveau = "Nouveau";
        public const string Rejeter = "Rejeter";
        public const string Valider = "Valider";
    }

    public class Origine
    {
        public const string Ordre = "ORDRE";
        public const string Transaction = "TRANSACTION";
        public const string Transfert = "TRANSFERT";
        public const string Ost = "OST";
        public const string Fractionnement = "FRACTIONNEMENT";
        public const string Dividende = "DIVIDENDES";
        public const string Remboursement = "REMBOURSEMENTECHEANCE";
        public const string Attribution = "ATTRIBUTION";
        public const string Mouvement = "MOUVEMENT";
    }


    public class TypeTransaction
    {
        public const string SystemeDebit = "SYS_DEBIT";
        public const string SystemeCredit = "SYS_CREDIT";
        public const string Debit = "DEBIT"; //TFD
        public const string Credit = "CREDIT"; //TFC
    }


    public class ModeReglement
    {
        public const string Espece = "Espèce";
        public const string Cheque = "Chèque";
        public const string Prelevement = "Prélèvement";
        public const string Virement = "Virement";
        public const string CodeEspece = "ESP";
    }


    public class EtatOrdre
    {
        public const string Nouveau = "Nouveau";
        public const string EnAttente = "En attente";
        public const string EnCours = "En cours";
        public const string Annule = "Annulé";
        public const string Cloture = "Cloturé";
        public const string Rejete = "Rejeté";
        public const string Ajourne = "Ajourné";
    }

    public class EtatCompte
    {
        public const string EN_ATTENTE = "00";
        public const string OPERATIONNEL = "01";
        public const string AJOURNE = "02";
        public const string REJETE = "03";
        public const string ENCOURS = "04";
        public const string SUSPENDU = "05";
        public const string CLOTURE = "06";
    }

    public class TempsHistorique
    {
        public const string AVANT = "AV";
        public const string APRES = "AP";
    }


    public class EtatOst
    {
        public const string Nouveau = "Nouveau";
        public const string EnAttente = "En Attente";
        public const string Valide = "Validé";
        public const string Rejete = "Rejeté";
        public const string Effectue = "Effectué";
        public const string Annule = "Annulé";
        //Etat de l'ost Paiement de dividendes
        public const string Annonce = "Annoncé";
        public const string Paye = "Payé";

    }

    public class TypeDividendes
    {
        public const string DividendeNouveau = "DIVIDENTE_NV";
        public const string DividendeAnnonce = "DIVIDENTE_AN";
        public const string DividendeValider = "DIVIDENTE_VAL";
    }

    public class TypeRemboursement
    {
        public const string CapitalUniquement = "PAIE_CAPITAL";
        public const string CapitalEtInterets = "CAPITAL_INTERET";
        public const string InteretsUniquement = "PAIE_INTERET";
    }

    public class CodeTypeTiers
    {
        public const string Mandataire = "Mandataire";
        public const string Beneficiaire = "Bénéficiaire";
        public const string Usufruitier = "Usufruitier";
    }

    public class EtatValidationEtude
    {
        public const string Rejete = "Rejeté";
        public const string Ajourne = "Ajourné";
        public const string Accepte = "Accepté";
        public const string EnAttente = "En Attente";
    }

    public class EtatPrestationSinistreRD
    {
        public const string SAISIE = "Saisie";
        public const string CREE = "Créé";
        public const string RATTACHEDECOMPTE = "Rattaché à un décompte";
        public const string SOLDE = "Soldé";

    }

    public class EtatPrestationSinistreTP
    {
        public const string CREE = "Créé";
        public const string RATTACHEBORDEREAU = "Rattaché à un bordereau";
        public const string SOLDE = "Soldé";

    }


    public class EtatPrestationDecompte
    {
        public const string CREE = "Créé";
        public const string VALIDE = "Validé";
        public const string SOLDE = "Soldé";
    }

    public class TypeDecompte
    {
        public const string SINISTRETP = "SinistreTP";
        public const string SINISTRERD = "SinistreRD";
    }

    public class EntiteMouvement
    {
        public const string PRESTATAIREMEDICAL = "PrestataireMedical";
        public const string PAYEUR = "Payeur";
    }

    public class OrigineMouvement
    {
        public const string DECOMPTE = "Decompte";
        public const string CARTE = "Carte";
        public const string PAYEURREGLEMENTPRIME = "PayeurReglementPrime";

    }

    public class CodeTypeCircuit
    {
        public const string OuvertureCompte = "6";
    }

    public class CodeTypeCompte
    {
        public const string Individuel = "Individuel";
        public const string Indivision = "Indivision";
        public const string Joint = "Joint";
        public const string MineursMajeurs = "MinMaj";
        public const string NuePropUsuf = "Usuf";
        public const string Conservation = "ConservExec";
    }

    public class CodeTypeActionFacturation
    {
        public const string EnConsultation = "CONSULTATION";
        public const string EnFacturation = "FACTURATION";
    }


    public class TypeEntiteInterlocuteur
    {
        public const string SOUSCRIPTEUR = "Souscripteur";
        public const string PRESTATAIREMEDICAL = "PrestataireMedical";
    }


    public class EtatFacturation
    {
        public const string NonFacture = "Non facturé";
        public const string Facture = "Facturé";
    }

    public class TypeFacturation
    {
        //JERED 
        //ces libellés doivent êtres paramétrés
        //07-04-2016
        public const string DroitsGarde = "DROIT_DE_GARDE"; //"Droits de garde due à la SGI";
        public const string ComDepositaire = "COM_DEPOSITAIRE"; //"Commission due au dépositaire";
        public const string ComRegulateur = "COM_REGULATEUR"; //"Commission due au régulateur";
    }

    public class GenerationCode
    {
        public const string Compte = "CPT";
        public const string Ordre = "ORD";
        public const string Transaction = "TRA";
        public const string Mouvement = "MVT";
    }

    public class CheckTransaction
    {
        public const string OUI = "OUI";
        public const string NON = "NON";
    }

    public class TypeAssureEnum
    {
        public const string ADHERENT = "Adherent";
        public const string CONJOINT = "Conjoint";
        public const string ENFANT = "Enfant";
        public const string ASCENDANT = "Ascendant";
    }

    public class StatutAssureEnum
    {
        public const string CREE = "Créé";
        public const string ENVALIDATION = "En validation";
        public const string VALIDE = "Validé";
        public const string INCORPORER = "Incorporé";
        public const string RADIER = "Radié";
        public const string ARCHIVER = "Archivé";
        public const string SUSPENDUE = "Suspendue";



    }
    public class StatutClientGarantEnum
    {
        public const string ECHU = "Echu";
    }
    public class StatutConventionEnum
    {
        public const string CREE = "Créé";
        public const string VALIDE = "Validé";
        public const string SUSPENDUE = "Suspendue";
        public const string ECHUE = "Echue";
        public const string RESILIER = "Résilié";
        public const string PRESOUSCRIPTION = "Presouscription";

    }

    //public class StatutBordereauEnum
    //{
    //    public const string CREE = "Créé";
    //    public const string VALIDENONRATTACHEDECOMPTE = "Validé non rattaché à un décompte";
    //    public const string VALIDERATTACHEDECOMPTE = "Validé rattaché à un décompte";
    //    public const string PAYER = "Payé";

    //}

    public class TypeConventionEnum
    {
        public const string COLLECTIF = "Collectif";
        public const string PARTICULIER = "Particulier";

    }

    public class SubMatriculeAssureEnum
    {
        public const string ADHERENT = "ADH";
        public const string AFFILIE = "AFF";


    }

    public class SubCaisse
    {
        public const string VALUE = "CAI";


    }

    public class SubPersonnelEnum
    {
        public const string PERSONNELMEDICAL = "PM";

    }


    public class NumeroBonDePriseEnCharge
    {
        public const string FACTURERD = "BRD";
        public const string FACTURETP = "PEC";
    }


    public class NumeroDecompte
    {
        public const string DECOMPTERD = "DRD";
        public const string DECOMPTETP = "DTP";
    }

    public class NumeroBordereau
    {
        public const string BORDEREAU = "BOR";
    }
    public class NumeroComptetiers
    {
        public const string COMPTETIERS = "CPT";
    }
    public class NumeroConvention
    {
        public const string CONVENTION = "COV";
    }

    public class NumeroSouscripteur
    {
        public const string SOUSCRIPTEUR = "SOU";
    }

    public class NumeroCarte
    {
        public const string CARTE = "CAR";
    }
    public class CodeNatureReglementEnum
    {
        public const string PRIME = "NA001";
        public const string CARTE = "NA002";
        public const string DUPLICATACARTE = "NA003";
        public const string DROITADHESION = "NA004";
        public const string REMBOURSEMENTDETTEASSURE = "NA005";

    }

    public class SubNumeroSouscripteurEnum
    {
        public const string VALUE = "SOU";

    }

    public class SubNumeroReglementEnum
    {
        public const string VALUE = "REG";

        public const string RECU = "REC";

    }

    public class TypePersonnEnum
    {
        public const string PHYSIQUE = "Physique";
        public const string MORALE = "Morale";

    }


    public class CodeTypePersonnelMedical
    {
        public const string MEDECIN = "C001";

    }
   
public class StatutSouscripteurEnum
    {
        public const string ACTIF = "Actif";
        public const string SUSPENDU = "Suspendu";


    }

    public class CodeDelaiCarenceEnum
    {
        public const string ADHERENT = "adh";

    }


    public class CaisseNatureOperation
    {
        public const string DEPOT = "NA001";
        public const string RETRAIT = "NA002";
    }

    public class StatutCaisse
    {
        public const string OUVERT = "SC001";
        public const string FERME = "SC002";
        public const string ARRETE = "SC003";
    }

    public class StatutBordereauEnum
    {
        public const string CREE = "Créé";
        public const string VALIDENONRATTACHEDECOMPTE = "Validé non rattaché à un décompte";
        public const string VALIDERATTACHEDECOMPTE = "Validé rattaché à un décompte";
        public const string VALIDE = "Validé";
        public const string PAYER = "Payé";

    }

    //public class CodeNatureReglementEnum
    //{
    //    public const string PRIME = "NA001";
    //    public const string CARTE = "NA002";
    //    public const string DUPLICATACARTE = "NA003";
    //    public const string DROITADHESION = "NA004";

    //}

    public class PeriodiciteEnum
    {
        public const string TRIMESTRIELLE = "Trimestrielle";
        public const string MENSUELLE = "Mensuelle";
        public const string SEMESTRIELLE = "Semestrielle";
        public const string ANNUELLE = "Annuelle";
    }

    public class StatutProduit
    {
        public const string CREE = "Créé";
        public const string ENVALIDATION = "En validation";
        public const string VALIDE = "Validé";

    }

    //public class StatutsCarteEnum
    //{
    //    public const string ENVALIDATION = "En validation";
    //    public const string VALIDEE = "Validée";
    //    public const string IMPRIMEE = "Imprimée";
    //    public const string RETIREE = "Retirée";
    //}

    //public class TypeRenouvellementEnum
    //{
    //    public const string DUPLICATA = "Duplicata";
    //    public const string INITIAL = "Initial";
    //    public const string RENOUVELLER = "Renouveller";
    //}


    //Hubert Statut du prestataire medical
    public class StatutCentreConventionne
    {
        public const string CREE = "Créé";
        public const string VALIDE = "Validé";
        public const string ENCOURS = "en cours";
        public const string RESILIE = "résilié";
        public const string SUSPENDU = "suspendu";

    }

    //Hubert Statut sanction prestataire
    public class StatutSanction
    {
        public const string LEVE = "levé";
        public const string ANNULE = "annulé";
        public const string ENCOURS = "en cours";

    }

    public class StatutMaladieChronique
    {
        public const string AJOUTE = "Ajouté";
        public const string VALIDE = "Validé par le médecin conseil";
        public const string REJETE = "Rejeté par le médecin conseil";
        public const string LEVE = "Levé";

    }

    public class TypeSanctionEnum
    {
        public const string SUSPENSIONUTILISATEUR = "SUSPENSION DU COMPTE UTILISATEUR";
        //Convention entre prestatataire et garant
        //Convention entre garant et gestionnaire
        public const string SUSPENSIONCONVENTION = "SUSPENSION DE LA CONVENTION";
        public const string ANNULATIONCONVENTION = "ANNULATION DE LA CONVENTION";

    }

    public class SubProduitEnum
    {
        public const string PRODUIT = "P";

    }



    public class StatutMotifExclusionPrestation
    {
        public const string FACTURATIONACTE = "Acte";
        public const string FACTURATIONMEDICAMENT = "Medicament";
    }

    public class EntitePayeurReglementPrime
    {
        public const string SOUSCRIPTION = "Souscription";
        public const string CONVENTION = "Convention";

    }

    public class StatutDemandePECEnum
    {
        public const string CREE = "Créé";
        public const string CLOTURE = "Cloturé";
        public const string ACCORDPREALABLE = "En accord préalable";
        public const string ENACCEPTATIONDEDETTE = "En acceptation de dette";
        public const string ENATTENTECLOTURE = "En attente de cloture";
        public const string REJETE = "Rejete";
        public const string VALIDE = "Validé";
    }
    public class EntiteBdDocument
    {
        public const string PRESTATION = "Prestation";
        public const string SOUSCRIPTIONLIGNE = "SouscriptionLigne";
    }

    public class SubNumeroBonPecEnum
    {
        public const string VALUE = "PEC";

    }

    public class SubNumeroFacturePrestationEnum
    {
        public const string VALUE = "FCT";

    }

    public class SubNumeroPrestationEnum
    {
        public const string VALUE = "PRE";

    }

    public class EntiteReglementEnum
    {
        public const string SOUSCRIPTIONLIGNE = "SouscriptionLigne";
        public const string CARTE = "Carte";
        public const string PAYEURREGLEMENTPRIME = "PayeurReglementPrime";
        public const string REMBOURSEMENTDETTEASSURE = "RemboursementDetteAssure";
    }


    public class SubActemedicalEnum
    {
        public const string ACTEMEDICAL = "PL";

    }


    public class SubCentreConventionneEnum
    {
        public const string REFERENCECENTRECONVENTION = "RC";

    }

    /// <summary>
    /// Le type de notification est utilisé en interne chez le gestionnaire
    /// </summary>
    public class TypeNotificationEnum
    {
        public const string SOUSCRIPTIONLIGNE = "SOUSCRIPTIONLIGNE";
        public const string ACCORDPREALABLEPRISEENCHARGE = "ACCORDPREALABLEPRISEENCHARGE";
        public const string DEMANDEACCORDPREALABLEPRISEENCHARGE = "DEMANDEACCORDPREALABLEPRISEENCHARGE";
        public const string DEMANDEACCEPTATIONDEDETTE = "DEMANDEACCEPTATIONDEDETTE";
    }

    public class SubAvenantContratClientGarant
    {
        public const string REFERENCEAVENANTCLIENTGARANT = "ACG";
    }
}
