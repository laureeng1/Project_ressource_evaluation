define(['definitions', 'utilities'], function () {
    'use strict';

    /* Models */

    CoreModels.service('CoreModel', ['commonUtilities', function (commonUtilities) {
       
        var mainSelf = this;

        mainSelf.AbpUsers = function (obj) {

            var self = this;

            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.Id = obj.Id;
            self.AuthenticationSource = obj.AuthenticationSource;
            self.Name = obj.Name;
            self.Surname = obj.Surname;
            self.Password = obj.Password;
            self.IsEmailConfirmed = obj.IsEmailConfirmed;
            self.EmailConfirmationCode = obj.EmailConfirmationCode;
            self.PasswordResetCode = obj.PasswordResetCode;
            self.LockoutEndDateUtc = obj.LockoutEndDateUtc;
            self.AccessFailedCount = obj.AccessFailedCount;
            self.IsLockoutEnabled = obj.IsLockoutEnabled;
            self.PhoneNumber = obj.PhoneNumber;
            self.IsPhoneNumberConfirmed = obj.IsPhoneNumberConfirmed;
            self.SecurityStamp = obj.SecurityStamp;
            self.IsTwoFactorEnabled = obj.IsTwoFactorEnabled;
            self.IsActive = obj.IsActive;
            self.UserName = obj.UserName;
            self.EmailAddress = obj.EmailAddress;
            self.LastLoginTime = obj.LastLoginTime;
            self.IsDeleted = obj.IsDeleted;
            self.DeleterUserId = obj.DeleterUserId;
            self.LastModifierUserId = obj.LastModifierUserId;
            self.CreationTime = obj.CreationTime;
            self.CreatorUserId = obj.CreatorUserId;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };


        mainSelf.Notification = function (obj) {

            var self = this;

            obj = (commonUtilities.IsUndefinedOrNull(obj) ? new Object() : obj);

            self.NotificationId = obj.NotificationId;
            self.NotificationName = obj.NotificationName;
            self.Link = obj.Link;
            self.UserId = obj.UserId;
            self.IsClicked = obj.IsClicked;
            self.IsDeleted = obj.IsDeleted;
            self.DateCreation = obj.DateCreation;
            self.DateMaj = obj.DateMaj;
            self.CreatedBy = obj.CreatedBy;
            self.ModifiedBy = obj.ModifiedBy;
            self.DataKey = obj.DataKey;
            self.IdTenant = obj.IdTenant;
        };


       

    }]);

});


