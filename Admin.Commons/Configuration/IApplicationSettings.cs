namespace Admin.Common.Configuration
{
    public interface IApplicationSettings
    {

        #region All
        string LoggerName { get; }

        string SiteUrl { get; }

        bool IsRelativeUrl { get; }

        string ListName { get; }

        string UserName { get; }

        string Password { get; }

        string FormatageDocument { get; }

        string Extension { get; }
        #endregion

        #region Sql

        string SqlQueryParamPrefix { get; }

        string Sgbd { get; }

        string CoreConnexionString { get; }

        #endregion

        #region Mail

        string ExpEmail { get; }

        string ExpFullName { get; }

        string ToMail { get; }

        string ToFullName { get; }

        string BccMail { get; }

        string BccFullName { get; }

        bool? SendEmailOrNo { get; }

        #endregion

        #region Active Directory

        string DomainName { get; }

        #endregion
    }
}