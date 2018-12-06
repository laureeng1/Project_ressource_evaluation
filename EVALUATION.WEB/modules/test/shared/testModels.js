define(['app', 'utilities'], function (app) {
    'use strict';

    app.service('crudModels', [
        'commonUtilities', function (commonUtilities) {
            var mainSelf = this;



            mainSelf.FsTypePartenaire = function (obj) {

                var self = this;

                obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

                self.IdTypePartenaire = obj.IdTypePartenaire;
                self.Libelle = obj.Libelle;
                self.IsDeleted = obj.IsDeleted;
                self.DateCreation = obj.DateCreation;
                self.DateMaj = obj.DateMaj;
                self.CreatedBy = obj.CreatedBy;
                self.ModifiedBy = obj.ModifiedBy;
                self.DataKey = obj.DataKey;
                self.IdStructure = obj.IdStructure;
            };

        }
            
    ]);

});