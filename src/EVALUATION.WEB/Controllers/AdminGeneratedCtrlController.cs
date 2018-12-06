using System;
using System.Web.Http;
using System.Threading.Tasks;
using INEXA.ERP.Service.Manager;
using INEXA.ERP.CORE.Dto;
using Inexa.Admin.Common.Domain;
using Inexa.Admin.Common.Helper;


namespace INEXA.ERP.Web.Controllers
{
   /* public class AdminGeneratedCtrlController : ApiController
    {
      

        #region Billetages
        [ActionName("GetBilletageById")]
        public async Task<BusinessResponse<BilletageDto>> GetBilletageById(int id)
        {
            var response = new BusinessResponse<BilletageDto>();

            try
            {
                response = await new BilletageManager().GetBilletageById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetBilletagesByCriteria")]
        public async Task<BusinessResponse<BilletageDto>> PostGetBilletagesByCriteria([FromBody]BusinessRequest<BilletageDto> request)
        {
            var response = new BusinessResponse<BilletageDto>();

            try
            {
                response = await new BilletageManager().GetBilletagesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveBilletages")]
        public async Task<BusinessResponse<BilletageDto>> PostSaveBilletages([FromBody]BusinessRequest<BilletageDto> request)
        {
            var response = new BusinessResponse<BilletageDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new BilletageManager().SaveBilletages(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteBilletages")]
        public async Task<BusinessResponse<Boolean>> PostDeleteBilletages([FromBody]BusinessRequest<BilletageDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new BilletageManager().DeleteBilletages(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Caisses
        [ActionName("GetCaisseById")]
        public async Task<BusinessResponse<CaisseDto>> GetCaisseById(int id)
        {
            var response = new BusinessResponse<CaisseDto>();

            try
            {
                response = await new CaisseManager().GetCaisseById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetCaissesByCriteria")]
        public async Task<BusinessResponse<CaisseDto>> PostGetCaissesByCriteria([FromBody]BusinessRequest<CaisseDto> request)
        {
            var response = new BusinessResponse<CaisseDto>();

            try
            {
                response = await new CaisseManager().GetCaissesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveCaisses")]
        public async Task<BusinessResponse<CaisseDto>> PostSaveCaisses([FromBody]BusinessRequest<CaisseDto> request)
        {
            var response = new BusinessResponse<CaisseDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CaisseManager().SaveCaisses(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteCaisses")]
        public async Task<BusinessResponse<Boolean>> PostDeleteCaisses([FromBody]BusinessRequest<CaisseDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CaisseManager().DeleteCaisses(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Coupures
        [ActionName("GetCoupureById")]
        public async Task<BusinessResponse<CoupureDto>> GetCoupureById(int id)
        {
            var response = new BusinessResponse<CoupureDto>();

            try
            {
                response = await new CoupureManager().GetCoupureById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetCoupuresByCriteria")]
        public async Task<BusinessResponse<CoupureDto>> PostGetCoupuresByCriteria([FromBody]BusinessRequest<CoupureDto> request)
        {
            var response = new BusinessResponse<CoupureDto>();

            try
            {
                response = await new CoupureManager().GetCoupuresByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveCoupures")]
        public async Task<BusinessResponse<CoupureDto>> PostSaveCoupures([FromBody]BusinessRequest<CoupureDto> request)
        {
            var response = new BusinessResponse<CoupureDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CoupureManager().SaveCoupures(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteCoupures")]
        public async Task<BusinessResponse<Boolean>> PostDeleteCoupures([FromBody]BusinessRequest<CoupureDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CoupureManager().DeleteCoupures(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Decaissements
        [ActionName("GetDecaissementById")]
        public async Task<BusinessResponse<DecaissementDto>> GetDecaissementById(int id)
        {
            var response = new BusinessResponse<DecaissementDto>();

            try
            {
                response = await new DecaissementManager().GetDecaissementById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetDecaissementsByCriteria")]
        public async Task<BusinessResponse<DecaissementDto>> PostGetDecaissementsByCriteria([FromBody]BusinessRequest<DecaissementDto> request)
        {
            var response = new BusinessResponse<DecaissementDto>();

            try
            {
                response = await new DecaissementManager().GetDecaissementsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveDecaissements")]
        public async Task<BusinessResponse<DecaissementDto>> PostSaveDecaissements([FromBody]BusinessRequest<DecaissementDto> request)
        {
            var response = new BusinessResponse<DecaissementDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DecaissementManager().SaveDecaissements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteDecaissements")]
        public async Task<BusinessResponse<Boolean>> PostDeleteDecaissements([FromBody]BusinessRequest<DecaissementDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DecaissementManager().DeleteDecaissements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ErreurImpressions
        [ActionName("GetErreurImpressionById")]
        public async Task<BusinessResponse<ErreurImpressionDto>> GetErreurImpressionById(int id)
        {
            var response = new BusinessResponse<ErreurImpressionDto>();

            try
            {
                response = await new ErreurImpressionManager().GetErreurImpressionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetErreurImpressionsByCriteria")]
        public async Task<BusinessResponse<ErreurImpressionDto>> PostGetErreurImpressionsByCriteria([FromBody]BusinessRequest<ErreurImpressionDto> request)
        {
            var response = new BusinessResponse<ErreurImpressionDto>();

            try
            {
                response = await new ErreurImpressionManager().GetErreurImpressionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveErreurImpressions")]
        public async Task<BusinessResponse<ErreurImpressionDto>> PostSaveErreurImpressions([FromBody]BusinessRequest<ErreurImpressionDto> request)
        {
            var response = new BusinessResponse<ErreurImpressionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ErreurImpressionManager().SaveErreurImpressions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteErreurImpressions")]
        public async Task<BusinessResponse<Boolean>> PostDeleteErreurImpressions([FromBody]BusinessRequest<ErreurImpressionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ErreurImpressionManager().DeleteErreurImpressions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region LotRecus
        [ActionName("GetLotRecuById")]
        public async Task<BusinessResponse<LotRecuDto>> GetLotRecuById(int id)
        {
            var response = new BusinessResponse<LotRecuDto>();

            try
            {
                response = await new LotRecuManager().GetLotRecuById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetLotRecusByCriteria")]
        public async Task<BusinessResponse<LotRecuDto>> PostGetLotRecusByCriteria([FromBody]BusinessRequest<LotRecuDto> request)
        {
            var response = new BusinessResponse<LotRecuDto>();

            try
            {
                response = await new LotRecuManager().GetLotRecusByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveLotRecus")]
        public async Task<BusinessResponse<LotRecuDto>> PostSaveLotRecus([FromBody]BusinessRequest<LotRecuDto> request)
        {
            var response = new BusinessResponse<LotRecuDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new LotRecuManager().SaveLotRecus(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteLotRecus")]
        public async Task<BusinessResponse<Boolean>> PostDeleteLotRecus([FromBody]BusinessRequest<LotRecuDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new LotRecuManager().DeleteLotRecus(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region NatureCaisses
        [ActionName("GetNatureCaisseById")]
        public async Task<BusinessResponse<NatureCaisseDto>> GetNatureCaisseById(int id)
        {
            var response = new BusinessResponse<NatureCaisseDto>();

            try
            {
                response = await new NatureCaisseManager().GetNatureCaisseById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetNatureCaissesByCriteria")]
        public async Task<BusinessResponse<NatureCaisseDto>> PostGetNatureCaissesByCriteria([FromBody]BusinessRequest<NatureCaisseDto> request)
        {
            var response = new BusinessResponse<NatureCaisseDto>();

            try
            {
                response = await new NatureCaisseManager().GetNatureCaissesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveNatureCaisses")]
        public async Task<BusinessResponse<NatureCaisseDto>> PostSaveNatureCaisses([FromBody]BusinessRequest<NatureCaisseDto> request)
        {
            var response = new BusinessResponse<NatureCaisseDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new NatureCaisseManager().SaveNatureCaisses(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteNatureCaisses")]
        public async Task<BusinessResponse<Boolean>> PostDeleteNatureCaisses([FromBody]BusinessRequest<NatureCaisseDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new NatureCaisseManager().DeleteNatureCaisses(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region NatureOperations
        [ActionName("GetNatureOperationById")]
        public async Task<BusinessResponse<NatureOperationDto>> GetNatureOperationById(int id)
        {
            var response = new BusinessResponse<NatureOperationDto>();

            try
            {
                response = await new NatureOperationManager().GetNatureOperationById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetNatureOperationsByCriteria")]
        public async Task<BusinessResponse<NatureOperationDto>> PostGetNatureOperationsByCriteria([FromBody]BusinessRequest<NatureOperationDto> request)
        {
            var response = new BusinessResponse<NatureOperationDto>();

            try
            {
                response = await new NatureOperationManager().GetNatureOperationsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveNatureOperations")]
        public async Task<BusinessResponse<NatureOperationDto>> PostSaveNatureOperations([FromBody]BusinessRequest<NatureOperationDto> request)
        {
            var response = new BusinessResponse<NatureOperationDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new NatureOperationManager().SaveNatureOperations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteNatureOperations")]
        public async Task<BusinessResponse<Boolean>> PostDeleteNatureOperations([FromBody]BusinessRequest<NatureOperationDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new NatureOperationManager().DeleteNatureOperations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region NatureReglements
        [ActionName("GetNatureReglementById")]
        public async Task<BusinessResponse<NatureReglementDto>> GetNatureReglementById(int id)
        {
            var response = new BusinessResponse<NatureReglementDto>();

            try
            {
                response = await new NatureReglementManager().GetNatureReglementById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetNatureReglementsByCriteria")]
        public async Task<BusinessResponse<NatureReglementDto>> PostGetNatureReglementsByCriteria([FromBody]BusinessRequest<NatureReglementDto> request)
        {
            var response = new BusinessResponse<NatureReglementDto>();

            try
            {
                response = await new NatureReglementManager().GetNatureReglementsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveNatureReglements")]
        public async Task<BusinessResponse<NatureReglementDto>> PostSaveNatureReglements([FromBody]BusinessRequest<NatureReglementDto> request)
        {
            var response = new BusinessResponse<NatureReglementDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new NatureReglementManager().SaveNatureReglements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteNatureReglements")]
        public async Task<BusinessResponse<Boolean>> PostDeleteNatureReglements([FromBody]BusinessRequest<NatureReglementDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new NatureReglementManager().DeleteNatureReglements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Operations
        [ActionName("GetOperationsById")]
        public async Task<BusinessResponse<OperationsDto>> GetOperationsById(int id)
        {
            var response = new BusinessResponse<OperationsDto>();

            try
            {
                response = await new OperationsManager().GetOperationsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetOperationsByCriteria")]
        public async Task<BusinessResponse<OperationsDto>> PostGetOperationsByCriteria([FromBody]BusinessRequest<OperationsDto> request)
        {
            var response = new BusinessResponse<OperationsDto>();

            try
            {
                response = await new OperationsManager().GetOperationsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveOperations")]
        public async Task<BusinessResponse<OperationsDto>> PostSaveOperations([FromBody]BusinessRequest<OperationsDto> request)
        {
            var response = new BusinessResponse<OperationsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new OperationsManager().SaveOperations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteOperations")]
        public async Task<BusinessResponse<Boolean>> PostDeleteOperations([FromBody]BusinessRequest<OperationsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new OperationsManager().DeleteOperations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Reglements
        [ActionName("GetReglementById")]
        public async Task<BusinessResponse<ReglementDto>> GetReglementById(int id)
        {
            var response = new BusinessResponse<ReglementDto>();

            try
            {
                response = await new ReglementManager().GetReglementById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetReglementsByCriteria")]
        public async Task<BusinessResponse<ReglementDto>> PostGetReglementsByCriteria([FromBody]BusinessRequest<ReglementDto> request)
        {
            var response = new BusinessResponse<ReglementDto>();

            try
            {
                response = await new ReglementManager().GetReglementsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveReglements")]
        public async Task<BusinessResponse<ReglementDto>> PostSaveReglements([FromBody]BusinessRequest<ReglementDto> request)
        {
            var response = new BusinessResponse<ReglementDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ReglementManager().SaveReglements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteReglements")]
        public async Task<BusinessResponse<Boolean>> PostDeleteReglements([FromBody]BusinessRequest<ReglementDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ReglementManager().DeleteReglements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region SessionCaisses
        [ActionName("GetSessionCaisseById")]
        public async Task<BusinessResponse<SessionCaisseDto>> GetSessionCaisseById(int id)
        {
            var response = new BusinessResponse<SessionCaisseDto>();

            try
            {
                response = await new SessionCaisseManager().GetSessionCaisseById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetSessionCaissesByCriteria")]
        public async Task<BusinessResponse<SessionCaisseDto>> PostGetSessionCaissesByCriteria([FromBody]BusinessRequest<SessionCaisseDto> request)
        {
            var response = new BusinessResponse<SessionCaisseDto>();

            try
            {
                response = await new SessionCaisseManager().GetSessionCaissesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveSessionCaisses")]
        public async Task<BusinessResponse<SessionCaisseDto>> PostSaveSessionCaisses([FromBody]BusinessRequest<SessionCaisseDto> request)
        {
            var response = new BusinessResponse<SessionCaisseDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SessionCaisseManager().SaveSessionCaisses(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteSessionCaisses")]
        public async Task<BusinessResponse<Boolean>> PostDeleteSessionCaisses([FromBody]BusinessRequest<SessionCaisseDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SessionCaisseManager().DeleteSessionCaisses(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Signatures
        [ActionName("GetSignatureById")]
        public async Task<BusinessResponse<SignatureDto>> GetSignatureById(int id)
        {
            var response = new BusinessResponse<SignatureDto>();

            try
            {
                response = await new SignatureManager().GetSignatureById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetSignaturesByCriteria")]
        public async Task<BusinessResponse<SignatureDto>> PostGetSignaturesByCriteria([FromBody]BusinessRequest<SignatureDto> request)
        {
            var response = new BusinessResponse<SignatureDto>();

            try
            {
                response = await new SignatureManager().GetSignaturesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveSignatures")]
        public async Task<BusinessResponse<SignatureDto>> PostSaveSignatures([FromBody]BusinessRequest<SignatureDto> request)
        {
            var response = new BusinessResponse<SignatureDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SignatureManager().SaveSignatures(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteSignatures")]
        public async Task<BusinessResponse<Boolean>> PostDeleteSignatures([FromBody]BusinessRequest<SignatureDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SignatureManager().DeleteSignatures(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region StatutCaisses
        [ActionName("GetStatutCaisseById")]
        public async Task<BusinessResponse<StatutCaisseDto>> GetStatutCaisseById(int id)
        {
            var response = new BusinessResponse<StatutCaisseDto>();

            try
            {
                response = await new StatutCaisseManager().GetStatutCaisseById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetStatutCaissesByCriteria")]
        public async Task<BusinessResponse<StatutCaisseDto>> PostGetStatutCaissesByCriteria([FromBody]BusinessRequest<StatutCaisseDto> request)
        {
            var response = new BusinessResponse<StatutCaisseDto>();

            try
            {
                response = await new StatutCaisseManager().GetStatutCaissesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveStatutCaisses")]
        public async Task<BusinessResponse<StatutCaisseDto>> PostSaveStatutCaisses([FromBody]BusinessRequest<StatutCaisseDto> request)
        {
            var response = new BusinessResponse<StatutCaisseDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutCaisseManager().SaveStatutCaisses(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteStatutCaisses")]
        public async Task<BusinessResponse<Boolean>> PostDeleteStatutCaisses([FromBody]BusinessRequest<StatutCaisseDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutCaisseManager().DeleteStatutCaisses(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region StatutDecaissements
        [ActionName("GetStatutDecaissementById")]
        public async Task<BusinessResponse<StatutDecaissementDto>> GetStatutDecaissementById(int id)
        {
            var response = new BusinessResponse<StatutDecaissementDto>();

            try
            {
                response = await new StatutDecaissementManager().GetStatutDecaissementById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetStatutDecaissementsByCriteria")]
        public async Task<BusinessResponse<StatutDecaissementDto>> PostGetStatutDecaissementsByCriteria([FromBody]BusinessRequest<StatutDecaissementDto> request)
        {
            var response = new BusinessResponse<StatutDecaissementDto>();

            try
            {
                response = await new StatutDecaissementManager().GetStatutDecaissementsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveStatutDecaissements")]
        public async Task<BusinessResponse<StatutDecaissementDto>> PostSaveStatutDecaissements([FromBody]BusinessRequest<StatutDecaissementDto> request)
        {
            var response = new BusinessResponse<StatutDecaissementDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutDecaissementManager().SaveStatutDecaissements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteStatutDecaissements")]
        public async Task<BusinessResponse<Boolean>> PostDeleteStatutDecaissements([FromBody]BusinessRequest<StatutDecaissementDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutDecaissementManager().DeleteStatutDecaissements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region StatutDecaissementDecaissements
        [ActionName("GetStatutDecaissementDecaissementById")]
        public async Task<BusinessResponse<StatutDecaissementDecaissementDto>> GetStatutDecaissementDecaissementById(int id)
        {
            var response = new BusinessResponse<StatutDecaissementDecaissementDto>();

            try
            {
                response = await new StatutDecaissementDecaissementManager().GetStatutDecaissementDecaissementById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetStatutDecaissementDecaissementsByCriteria")]
        public async Task<BusinessResponse<StatutDecaissementDecaissementDto>> PostGetStatutDecaissementDecaissementsByCriteria([FromBody]BusinessRequest<StatutDecaissementDecaissementDto> request)
        {
            var response = new BusinessResponse<StatutDecaissementDecaissementDto>();

            try
            {
                response = await new StatutDecaissementDecaissementManager().GetStatutDecaissementDecaissementsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveStatutDecaissementDecaissements")]
        public async Task<BusinessResponse<StatutDecaissementDecaissementDto>> PostSaveStatutDecaissementDecaissements([FromBody]BusinessRequest<StatutDecaissementDecaissementDto> request)
        {
            var response = new BusinessResponse<StatutDecaissementDecaissementDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutDecaissementDecaissementManager().SaveStatutDecaissementDecaissements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteStatutDecaissementDecaissements")]
        public async Task<BusinessResponse<Boolean>> PostDeleteStatutDecaissementDecaissements([FromBody]BusinessRequest<StatutDecaissementDecaissementDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutDecaissementDecaissementManager().DeleteStatutDecaissementDecaissements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypeReglements
        [ActionName("GetTypeReglementById")]
        public async Task<BusinessResponse<TypeReglementDto>> GetTypeReglementById(int id)
        {
            var response = new BusinessResponse<TypeReglementDto>();

            try
            {
                response = await new TypeReglementManager().GetTypeReglementById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypeReglementsByCriteria")]
        public async Task<BusinessResponse<TypeReglementDto>> PostGetTypeReglementsByCriteria([FromBody]BusinessRequest<TypeReglementDto> request)
        {
            var response = new BusinessResponse<TypeReglementDto>();

            try
            {
                response = await new TypeReglementManager().GetTypeReglementsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypeReglements")]
        public async Task<BusinessResponse<TypeReglementDto>> PostSaveTypeReglements([FromBody]BusinessRequest<TypeReglementDto> request)
        {
            var response = new BusinessResponse<TypeReglementDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeReglementManager().SaveTypeReglements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypeReglements")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypeReglements([FromBody]BusinessRequest<TypeReglementDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeReglementManager().DeleteTypeReglements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ViewBilletages
        [ActionName("GetViewBilletagesByCriteria")]
        public async Task<BusinessResponse<ViewBilletageDto>> PostGetViewBilletagesByCriteria([FromBody]BusinessRequest<ViewBilletageDto> request)
        {
            var response = new BusinessResponse<ViewBilletageDto>();

            try
            {
                response = await new ViewBilletageManager().GetViewBilletagesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewBilletages")]
        public async Task<BusinessResponse<ViewBilletageDto>> PostSaveViewBilletages([FromBody]BusinessRequest<ViewBilletageDto> request)
        {
            var response = new BusinessResponse<ViewBilletageDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewBilletageManager().SaveViewBilletages(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewCaisses
        [ActionName("GetViewCaissesByCriteria")]
        public async Task<BusinessResponse<ViewCaisseDto>> PostGetViewCaissesByCriteria([FromBody]BusinessRequest<ViewCaisseDto> request)
        {
            var response = new BusinessResponse<ViewCaisseDto>();

            try
            {
                response = await new ViewCaisseManager().GetViewCaissesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewCaisses")]
        public async Task<BusinessResponse<ViewCaisseDto>> PostSaveViewCaisses([FromBody]BusinessRequest<ViewCaisseDto> request)
        {
            var response = new BusinessResponse<ViewCaisseDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewCaisseManager().SaveViewCaisses(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewErreurImpressions
        [ActionName("GetViewErreurImpressionsByCriteria")]
        public async Task<BusinessResponse<ViewErreurImpressionDto>> PostGetViewErreurImpressionsByCriteria([FromBody]BusinessRequest<ViewErreurImpressionDto> request)
        {
            var response = new BusinessResponse<ViewErreurImpressionDto>();

            try
            {
                response = await new ViewErreurImpressionManager().GetViewErreurImpressionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewErreurImpressions")]
        public async Task<BusinessResponse<ViewErreurImpressionDto>> PostSaveViewErreurImpressions([FromBody]BusinessRequest<ViewErreurImpressionDto> request)
        {
            var response = new BusinessResponse<ViewErreurImpressionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewErreurImpressionManager().SaveViewErreurImpressions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region Ecritures
        [ActionName("GetEcritureById")]
        public async Task<BusinessResponse<EcritureDto>> GetEcritureById(int id)
        {
            var response = new BusinessResponse<EcritureDto>();

            try
            {
                response = await new EcritureManager().GetEcritureById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetEcrituresByCriteria")]
        public async Task<BusinessResponse<EcritureDto>> PostGetEcrituresByCriteria([FromBody]BusinessRequest<EcritureDto> request)
        {
            var response = new BusinessResponse<EcritureDto>();

            try
            {
                response = await new EcritureManager().GetEcrituresByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveEcritures")]
        public async Task<BusinessResponse<EcritureDto>> PostSaveEcritures([FromBody]BusinessRequest<EcritureDto> request)
        {
            var response = new BusinessResponse<EcritureDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new EcritureManager().SaveEcritures(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteEcritures")]
        public async Task<BusinessResponse<Boolean>> PostDeleteEcritures([FromBody]BusinessRequest<EcritureDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new EcritureManager().DeleteEcritures(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Exercices
        [ActionName("GetExerciceById")]
        public async Task<BusinessResponse<ExerciceDto>> GetExerciceById(int id)
        {
            var response = new BusinessResponse<ExerciceDto>();

            try
            {
                response = await new ExerciceManager().GetExerciceById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetExercicesByCriteria")]
        public async Task<BusinessResponse<ExerciceDto>> PostGetExercicesByCriteria([FromBody]BusinessRequest<ExerciceDto> request)
        {
            var response = new BusinessResponse<ExerciceDto>();

            try
            {
                response = await new ExerciceManager().GetExercicesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveExercices")]
        public async Task<BusinessResponse<ExerciceDto>> PostSaveExercices([FromBody]BusinessRequest<ExerciceDto> request)
        {
            var response = new BusinessResponse<ExerciceDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ExerciceManager().SaveExercices(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteExercices")]
        public async Task<BusinessResponse<Boolean>> PostDeleteExercices([FromBody]BusinessRequest<ExerciceDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ExerciceManager().DeleteExercices(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ExerciceHists
        [ActionName("GetExerciceHistById")]
        public async Task<BusinessResponse<ExerciceHistDto>> GetExerciceHistById(int id)
        {
            var response = new BusinessResponse<ExerciceHistDto>();

            try
            {
                response = await new ExerciceHistManager().GetExerciceHistById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetExerciceHistsByCriteria")]
        public async Task<BusinessResponse<ExerciceHistDto>> PostGetExerciceHistsByCriteria([FromBody]BusinessRequest<ExerciceHistDto> request)
        {
            var response = new BusinessResponse<ExerciceHistDto>();

            try
            {
                response = await new ExerciceHistManager().GetExerciceHistsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveExerciceHists")]
        public async Task<BusinessResponse<ExerciceHistDto>> PostSaveExerciceHists([FromBody]BusinessRequest<ExerciceHistDto> request)
        {
            var response = new BusinessResponse<ExerciceHistDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ExerciceHistManager().SaveExerciceHists(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteExerciceHists")]
        public async Task<BusinessResponse<Boolean>> PostDeleteExerciceHists([FromBody]BusinessRequest<ExerciceHistDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ExerciceHistManager().DeleteExerciceHists(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Journals
        [ActionName("GetJournalById")]
        public async Task<BusinessResponse<JournalDto>> GetJournalById(int id)
        {
            var response = new BusinessResponse<JournalDto>();

            try
            {
                response = await new JournalManager().GetJournalById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetJournalsByCriteria")]
        public async Task<BusinessResponse<JournalDto>> PostGetJournalsByCriteria([FromBody]BusinessRequest<JournalDto> request)
        {
            var response = new BusinessResponse<JournalDto>();

            try
            {
                response = await new JournalManager().GetJournalsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveJournals")]
        public async Task<BusinessResponse<JournalDto>> PostSaveJournals([FromBody]BusinessRequest<JournalDto> request)
        {
            var response = new BusinessResponse<JournalDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new JournalManager().SaveJournals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteJournals")]
        public async Task<BusinessResponse<Boolean>> PostDeleteJournals([FromBody]BusinessRequest<JournalDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new JournalManager().DeleteJournals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region JournalSaisies
        [ActionName("GetJournalSaisieById")]
        public async Task<BusinessResponse<JournalSaisieDto>> GetJournalSaisieById(int id)
        {
            var response = new BusinessResponse<JournalSaisieDto>();

            try
            {
                response = await new JournalSaisieManager().GetJournalSaisieById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetJournalSaisiesByCriteria")]
        public async Task<BusinessResponse<JournalSaisieDto>> PostGetJournalSaisiesByCriteria([FromBody]BusinessRequest<JournalSaisieDto> request)
        {
            var response = new BusinessResponse<JournalSaisieDto>();

            try
            {
                response = await new JournalSaisieManager().GetJournalSaisiesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveJournalSaisies")]
        public async Task<BusinessResponse<JournalSaisieDto>> PostSaveJournalSaisies([FromBody]BusinessRequest<JournalSaisieDto> request)
        {
            var response = new BusinessResponse<JournalSaisieDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new JournalSaisieManager().SaveJournalSaisies(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteJournalSaisies")]
        public async Task<BusinessResponse<Boolean>> PostDeleteJournalSaisies([FromBody]BusinessRequest<JournalSaisieDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new JournalSaisieManager().DeleteJournalSaisies(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Lettrages
        [ActionName("GetLettrageById")]
        public async Task<BusinessResponse<LettrageDto>> GetLettrageById(int id)
        {
            var response = new BusinessResponse<LettrageDto>();

            try
            {
                response = await new LettrageManager().GetLettrageById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetLettragesByCriteria")]
        public async Task<BusinessResponse<LettrageDto>> PostGetLettragesByCriteria([FromBody]BusinessRequest<LettrageDto> request)
        {
            var response = new BusinessResponse<LettrageDto>();

            try
            {
                response = await new LettrageManager().GetLettragesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveLettrages")]
        public async Task<BusinessResponse<LettrageDto>> PostSaveLettrages([FromBody]BusinessRequest<LettrageDto> request)
        {
            var response = new BusinessResponse<LettrageDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new LettrageManager().SaveLettrages(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteLettrages")]
        public async Task<BusinessResponse<Boolean>> PostDeleteLettrages([FromBody]BusinessRequest<LettrageDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new LettrageManager().DeleteLettrages(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Lettres
        [ActionName("GetLettreById")]
        public async Task<BusinessResponse<LettreDto>> GetLettreById(int id)
        {
            var response = new BusinessResponse<LettreDto>();

            try
            {
                response = await new LettreManager().GetLettreById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetLettresByCriteria")]
        public async Task<BusinessResponse<LettreDto>> PostGetLettresByCriteria([FromBody]BusinessRequest<LettreDto> request)
        {
            var response = new BusinessResponse<LettreDto>();

            try
            {
                response = await new LettreManager().GetLettresByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveLettres")]
        public async Task<BusinessResponse<LettreDto>> PostSaveLettres([FromBody]BusinessRequest<LettreDto> request)
        {
            var response = new BusinessResponse<LettreDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new LettreManager().SaveLettres(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteLettres")]
        public async Task<BusinessResponse<Boolean>> PostDeleteLettres([FromBody]BusinessRequest<LettreDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new LettreManager().DeleteLettres(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region LettreExercices
        [ActionName("GetLettreExerciceById")]
        public async Task<BusinessResponse<LettreExerciceDto>> GetLettreExerciceById(int id)
        {
            var response = new BusinessResponse<LettreExerciceDto>();

            try
            {
                response = await new LettreExerciceManager().GetLettreExerciceById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetLettreExercicesByCriteria")]
        public async Task<BusinessResponse<LettreExerciceDto>> PostGetLettreExercicesByCriteria([FromBody]BusinessRequest<LettreExerciceDto> request)
        {
            var response = new BusinessResponse<LettreExerciceDto>();

            try
            {
                response = await new LettreExerciceManager().GetLettreExercicesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveLettreExercices")]
        public async Task<BusinessResponse<LettreExerciceDto>> PostSaveLettreExercices([FromBody]BusinessRequest<LettreExerciceDto> request)
        {
            var response = new BusinessResponse<LettreExerciceDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new LettreExerciceManager().SaveLettreExercices(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteLettreExercices")]
        public async Task<BusinessResponse<Boolean>> PostDeleteLettreExercices([FromBody]BusinessRequest<LettreExerciceDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new LettreExerciceManager().DeleteLettreExercices(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PlanComptables
        [ActionName("GetPlanComptableById")]
        public async Task<BusinessResponse<PlanComptableDto>> GetPlanComptableById(int id)
        {
            var response = new BusinessResponse<PlanComptableDto>();

            try
            {
                response = await new PlanComptableManager().GetPlanComptableById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPlanComptablesByCriteria")]
        public async Task<BusinessResponse<PlanComptableDto>> PostGetPlanComptablesByCriteria([FromBody]BusinessRequest<PlanComptableDto> request)
        {
            var response = new BusinessResponse<PlanComptableDto>();

            try
            {
                response = await new PlanComptableManager().GetPlanComptablesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePlanComptables")]
        public async Task<BusinessResponse<PlanComptableDto>> PostSavePlanComptables([FromBody]BusinessRequest<PlanComptableDto> request)
        {
            var response = new BusinessResponse<PlanComptableDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PlanComptableManager().SavePlanComptables(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePlanComptables")]
        public async Task<BusinessResponse<Boolean>> PostDeletePlanComptables([FromBody]BusinessRequest<PlanComptableDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PlanComptableManager().DeletePlanComptables(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region SchemaEcritures
        [ActionName("GetSchemaEcritureById")]
        public async Task<BusinessResponse<SchemaEcritureDto>> GetSchemaEcritureById(int id)
        {
            var response = new BusinessResponse<SchemaEcritureDto>();

            try
            {
                response = await new SchemaEcritureManager().GetSchemaEcritureById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetSchemaEcrituresByCriteria")]
        public async Task<BusinessResponse<SchemaEcritureDto>> PostGetSchemaEcrituresByCriteria([FromBody]BusinessRequest<SchemaEcritureDto> request)
        {
            var response = new BusinessResponse<SchemaEcritureDto>();

            try
            {
                response = await new SchemaEcritureManager().GetSchemaEcrituresByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveSchemaEcritures")]
        public async Task<BusinessResponse<SchemaEcritureDto>> PostSaveSchemaEcritures([FromBody]BusinessRequest<SchemaEcritureDto> request)
        {
            var response = new BusinessResponse<SchemaEcritureDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SchemaEcritureManager().SaveSchemaEcritures(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteSchemaEcritures")]
        public async Task<BusinessResponse<Boolean>> PostDeleteSchemaEcritures([FromBody]BusinessRequest<SchemaEcritureDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SchemaEcritureManager().DeleteSchemaEcritures(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Tiers
        [ActionName("GetTiersById")]
        public async Task<BusinessResponse<TiersDto>> GetTiersById(int id)
        {
            var response = new BusinessResponse<TiersDto>();

            try
            {
                response = await new TiersManager().GetTiersById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTiersByCriteria")]
        public async Task<BusinessResponse<TiersDto>> PostGetTiersByCriteria([FromBody]BusinessRequest<TiersDto> request)
        {
            var response = new BusinessResponse<TiersDto>();

            try
            {
                response = await new TiersManager().GetTiersByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTiers")]
        public async Task<BusinessResponse<TiersDto>> PostSaveTiers([FromBody]BusinessRequest<TiersDto> request)
        {
            var response = new BusinessResponse<TiersDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TiersManager().SaveTiers(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTiers")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTiers([FromBody]BusinessRequest<TiersDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TiersManager().DeleteTiers(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypeJournals
        [ActionName("GetTypeJournalById")]
        public async Task<BusinessResponse<TypeJournalDto>> GetTypeJournalById(int id)
        {
            var response = new BusinessResponse<TypeJournalDto>();

            try
            {
                response = await new TypeJournalManager().GetTypeJournalById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypeJournalsByCriteria")]
        public async Task<BusinessResponse<TypeJournalDto>> PostGetTypeJournalsByCriteria([FromBody]BusinessRequest<TypeJournalDto> request)
        {
            var response = new BusinessResponse<TypeJournalDto>();

            try
            {
                response = await new TypeJournalManager().GetTypeJournalsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypeJournals")]
        public async Task<BusinessResponse<TypeJournalDto>> PostSaveTypeJournals([FromBody]BusinessRequest<TypeJournalDto> request)
        {
            var response = new BusinessResponse<TypeJournalDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeJournalManager().SaveTypeJournals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypeJournals")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypeJournals([FromBody]BusinessRequest<TypeJournalDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeJournalManager().DeleteTypeJournals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypeOperations
        [ActionName("GetTypeOperationById")]
        public async Task<BusinessResponse<TypeOperationDto>> GetTypeOperationById(int id)
        {
            var response = new BusinessResponse<TypeOperationDto>();

            try
            {
                response = await new TypeOperationManager().GetTypeOperationById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypeOperationsByCriteria")]
        public async Task<BusinessResponse<TypeOperationDto>> PostGetTypeOperationsByCriteria([FromBody]BusinessRequest<TypeOperationDto> request)
        {
            var response = new BusinessResponse<TypeOperationDto>();

            try
            {
                response = await new TypeOperationManager().GetTypeOperationsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypeOperations")]
        public async Task<BusinessResponse<TypeOperationDto>> PostSaveTypeOperations([FromBody]BusinessRequest<TypeOperationDto> request)
        {
            var response = new BusinessResponse<TypeOperationDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeOperationManager().SaveTypeOperations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypeOperations")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypeOperations([FromBody]BusinessRequest<TypeOperationDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeOperationManager().DeleteTypeOperations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypePlanComptables
        [ActionName("GetTypePlanComptableById")]
        public async Task<BusinessResponse<TypePlanComptableDto>> GetTypePlanComptableById(int id)
        {
            var response = new BusinessResponse<TypePlanComptableDto>();

            try
            {
                response = await new TypePlanComptableManager().GetTypePlanComptableById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypePlanComptablesByCriteria")]
        public async Task<BusinessResponse<TypePlanComptableDto>> PostGetTypePlanComptablesByCriteria([FromBody]BusinessRequest<TypePlanComptableDto> request)
        {
            var response = new BusinessResponse<TypePlanComptableDto>();

            try
            {
                response = await new TypePlanComptableManager().GetTypePlanComptablesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypePlanComptables")]
        public async Task<BusinessResponse<TypePlanComptableDto>> PostSaveTypePlanComptables([FromBody]BusinessRequest<TypePlanComptableDto> request)
        {
            var response = new BusinessResponse<TypePlanComptableDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypePlanComptableManager().SaveTypePlanComptables(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypePlanComptables")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypePlanComptables([FromBody]BusinessRequest<TypePlanComptableDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypePlanComptableManager().DeleteTypePlanComptables(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypeTiers
        [ActionName("GetTypeTiersById")]
        public async Task<BusinessResponse<TypeTiersDto>> GetTypeTiersById(int id)
        {
            var response = new BusinessResponse<TypeTiersDto>();

            try
            {
                response = await new TypeTiersManager().GetTypeTiersById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypeTiersByCriteria")]
        public async Task<BusinessResponse<TypeTiersDto>> PostGetTypeTiersByCriteria([FromBody]BusinessRequest<TypeTiersDto> request)
        {
            var response = new BusinessResponse<TypeTiersDto>();

            try
            {
                response = await new TypeTiersManager().GetTypeTiersByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypeTiers")]
        public async Task<BusinessResponse<TypeTiersDto>> PostSaveTypeTiers([FromBody]BusinessRequest<TypeTiersDto> request)
        {
            var response = new BusinessResponse<TypeTiersDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeTiersManager().SaveTypeTiers(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypeTiers")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypeTiers([FromBody]BusinessRequest<TypeTiersDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeTiersManager().DeleteTypeTiers(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Campagnes
        [ActionName("GetCampagneById")]
        public async Task<BusinessResponse<CampagneDto>> GetCampagneById(int id)
        {
            var response = new BusinessResponse<CampagneDto>();

            try
            {
                response = await new CampagneManager().GetCampagneById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetCampagnesByCriteria")]
        public async Task<BusinessResponse<CampagneDto>> PostGetCampagnesByCriteria([FromBody]BusinessRequest<CampagneDto> request)
        {
            var response = new BusinessResponse<CampagneDto>();

            try
            {
                response = await new CampagneManager().GetCampagnesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveCampagnes")]
        public async Task<BusinessResponse<CampagneDto>> PostSaveCampagnes([FromBody]BusinessRequest<CampagneDto> request)
        {
            var response = new BusinessResponse<CampagneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CampagneManager().SaveCampagnes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteCampagnes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteCampagnes([FromBody]BusinessRequest<CampagneDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CampagneManager().DeleteCampagnes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region CampagneLignes
        [ActionName("GetCampagneLigneById")]
        public async Task<BusinessResponse<CampagneLigneDto>> GetCampagneLigneById(int id)
        {
            var response = new BusinessResponse<CampagneLigneDto>();

            try
            {
                response = await new CampagneLigneManager().GetCampagneLigneById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetCampagneLignesByCriteria")]
        public async Task<BusinessResponse<CampagneLigneDto>> PostGetCampagneLignesByCriteria([FromBody]BusinessRequest<CampagneLigneDto> request)
        {
            var response = new BusinessResponse<CampagneLigneDto>();

            try
            {
                response = await new CampagneLigneManager().GetCampagneLignesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveCampagneLignes")]
        public async Task<BusinessResponse<CampagneLigneDto>> PostSaveCampagneLignes([FromBody]BusinessRequest<CampagneLigneDto> request)
        {
            var response = new BusinessResponse<CampagneLigneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CampagneLigneManager().SaveCampagneLignes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteCampagneLignes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteCampagneLignes([FromBody]BusinessRequest<CampagneLigneDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CampagneLigneManager().DeleteCampagneLignes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region CommercialExternes
        [ActionName("GetCommercialExterneById")]
        public async Task<BusinessResponse<CommercialExterneDto>> GetCommercialExterneById(int id)
        {
            var response = new BusinessResponse<CommercialExterneDto>();

            try
            {
                response = await new CommercialExterneManager().GetCommercialExterneById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetCommercialExternesByCriteria")]
        public async Task<BusinessResponse<CommercialExterneDto>> PostGetCommercialExternesByCriteria([FromBody]BusinessRequest<CommercialExterneDto> request)
        {
            var response = new BusinessResponse<CommercialExterneDto>();

            try
            {
                response = await new CommercialExterneManager().GetCommercialExternesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveCommercialExternes")]
        public async Task<BusinessResponse<CommercialExterneDto>> PostSaveCommercialExternes([FromBody]BusinessRequest<CommercialExterneDto> request)
        {
            var response = new BusinessResponse<CommercialExterneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CommercialExterneManager().SaveCommercialExternes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteCommercialExternes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteCommercialExternes([FromBody]BusinessRequest<CommercialExterneDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CommercialExterneManager().DeleteCommercialExternes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region HistoriqueStatutCRMs
        [ActionName("GetHistoriqueStatutCRMById")]
        public async Task<BusinessResponse<HistoriqueStatutCRMDto>> GetHistoriqueStatutCRMById(int id)
        {
            var response = new BusinessResponse<HistoriqueStatutCRMDto>();

            try
            {
                response = await new HistoriqueStatutCRMManager().GetHistoriqueStatutCRMById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetHistoriqueStatutCRMsByCriteria")]
        public async Task<BusinessResponse<HistoriqueStatutCRMDto>> PostGetHistoriqueStatutCRMsByCriteria([FromBody]BusinessRequest<HistoriqueStatutCRMDto> request)
        {
            var response = new BusinessResponse<HistoriqueStatutCRMDto>();

            try
            {
                response = await new HistoriqueStatutCRMManager().GetHistoriqueStatutCRMsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveHistoriqueStatutCRMs")]
        public async Task<BusinessResponse<HistoriqueStatutCRMDto>> PostSaveHistoriqueStatutCRMs([FromBody]BusinessRequest<HistoriqueStatutCRMDto> request)
        {
            var response = new BusinessResponse<HistoriqueStatutCRMDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new HistoriqueStatutCRMManager().SaveHistoriqueStatutCRMs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteHistoriqueStatutCRMs")]
        public async Task<BusinessResponse<Boolean>> PostDeleteHistoriqueStatutCRMs([FromBody]BusinessRequest<HistoriqueStatutCRMDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new HistoriqueStatutCRMManager().DeleteHistoriqueStatutCRMs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PropositionCommerciales
        [ActionName("GetPropositionCommercialeById")]
        public async Task<BusinessResponse<PropositionCommercialeDto>> GetPropositionCommercialeById(int id)
        {
            var response = new BusinessResponse<PropositionCommercialeDto>();

            try
            {
                response = await new PropositionCommercialeManager().GetPropositionCommercialeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPropositionCommercialesByCriteria")]
        public async Task<BusinessResponse<PropositionCommercialeDto>> PostGetPropositionCommercialesByCriteria([FromBody]BusinessRequest<PropositionCommercialeDto> request)
        {
            var response = new BusinessResponse<PropositionCommercialeDto>();

            try
            {
                response = await new PropositionCommercialeManager().GetPropositionCommercialesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePropositionCommerciales")]
        public async Task<BusinessResponse<PropositionCommercialeDto>> PostSavePropositionCommerciales([FromBody]BusinessRequest<PropositionCommercialeDto> request)
        {
            var response = new BusinessResponse<PropositionCommercialeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PropositionCommercialeManager().SavePropositionCommerciales(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePropositionCommerciales")]
        public async Task<BusinessResponse<Boolean>> PostDeletePropositionCommerciales([FromBody]BusinessRequest<PropositionCommercialeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PropositionCommercialeManager().DeletePropositionCommerciales(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PropositionLignes
        [ActionName("GetPropositionLigneById")]
        public async Task<BusinessResponse<PropositionLigneDto>> GetPropositionLigneById(int id)
        {
            var response = new BusinessResponse<PropositionLigneDto>();

            try
            {
                response = await new PropositionLigneManager().GetPropositionLigneById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPropositionLignesByCriteria")]
        public async Task<BusinessResponse<PropositionLigneDto>> PostGetPropositionLignesByCriteria([FromBody]BusinessRequest<PropositionLigneDto> request)
        {
            var response = new BusinessResponse<PropositionLigneDto>();

            try
            {
                response = await new PropositionLigneManager().GetPropositionLignesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePropositionLignes")]
        public async Task<BusinessResponse<PropositionLigneDto>> PostSavePropositionLignes([FromBody]BusinessRequest<PropositionLigneDto> request)
        {
            var response = new BusinessResponse<PropositionLigneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PropositionLigneManager().SavePropositionLignes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePropositionLignes")]
        public async Task<BusinessResponse<Boolean>> PostDeletePropositionLignes([FromBody]BusinessRequest<PropositionLigneDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PropositionLigneManager().DeletePropositionLignes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Relances
        [ActionName("GetRelanceById")]
        public async Task<BusinessResponse<RelanceDto>> GetRelanceById(int id)
        {
            var response = new BusinessResponse<RelanceDto>();

            try
            {
                response = await new RelanceManager().GetRelanceById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetRelancesByCriteria")]
        public async Task<BusinessResponse<RelanceDto>> PostGetRelancesByCriteria([FromBody]BusinessRequest<RelanceDto> request)
        {
            var response = new BusinessResponse<RelanceDto>();

            try
            {
                response = await new RelanceManager().GetRelancesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveRelances")]
        public async Task<BusinessResponse<RelanceDto>> PostSaveRelances([FromBody]BusinessRequest<RelanceDto> request)
        {
            var response = new BusinessResponse<RelanceDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new RelanceManager().SaveRelances(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteRelances")]
        public async Task<BusinessResponse<Boolean>> PostDeleteRelances([FromBody]BusinessRequest<RelanceDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new RelanceManager().DeleteRelances(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region StatutCommercials
        [ActionName("GetStatutCommercialById")]
        public async Task<BusinessResponse<StatutCommercialDto>> GetStatutCommercialById(int id)
        {
            var response = new BusinessResponse<StatutCommercialDto>();

            try
            {
                response = await new StatutCommercialManager().GetStatutCommercialById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetStatutCommercialsByCriteria")]
        public async Task<BusinessResponse<StatutCommercialDto>> PostGetStatutCommercialsByCriteria([FromBody]BusinessRequest<StatutCommercialDto> request)
        {
            var response = new BusinessResponse<StatutCommercialDto>();

            try
            {
                response = await new StatutCommercialManager().GetStatutCommercialsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveStatutCommercials")]
        public async Task<BusinessResponse<StatutCommercialDto>> PostSaveStatutCommercials([FromBody]BusinessRequest<StatutCommercialDto> request)
        {
            var response = new BusinessResponse<StatutCommercialDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutCommercialManager().SaveStatutCommercials(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteStatutCommercials")]
        public async Task<BusinessResponse<Boolean>> PostDeleteStatutCommercials([FromBody]BusinessRequest<StatutCommercialDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutCommercialManager().DeleteStatutCommercials(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region StatutCRMs
        [ActionName("GetStatutCRMById")]
        public async Task<BusinessResponse<StatutCRMDto>> GetStatutCRMById(int id)
        {
            var response = new BusinessResponse<StatutCRMDto>();

            try
            {
                response = await new StatutCRMManager().GetStatutCRMById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetStatutCRMsByCriteria")]
        public async Task<BusinessResponse<StatutCRMDto>> PostGetStatutCRMsByCriteria([FromBody]BusinessRequest<StatutCRMDto> request)
        {
            var response = new BusinessResponse<StatutCRMDto>();

            try
            {
                response = await new StatutCRMManager().GetStatutCRMsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveStatutCRMs")]
        public async Task<BusinessResponse<StatutCRMDto>> PostSaveStatutCRMs([FromBody]BusinessRequest<StatutCRMDto> request)
        {
            var response = new BusinessResponse<StatutCRMDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutCRMManager().SaveStatutCRMs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteStatutCRMs")]
        public async Task<BusinessResponse<Boolean>> PostDeleteStatutCRMs([FromBody]BusinessRequest<StatutCRMDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutCRMManager().DeleteStatutCRMs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypeRelances
        [ActionName("GetTypeRelanceById")]
        public async Task<BusinessResponse<TypeRelanceDto>> GetTypeRelanceById(int id)
        {
            var response = new BusinessResponse<TypeRelanceDto>();

            try
            {
                response = await new TypeRelanceManager().GetTypeRelanceById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypeRelancesByCriteria")]
        public async Task<BusinessResponse<TypeRelanceDto>> PostGetTypeRelancesByCriteria([FromBody]BusinessRequest<TypeRelanceDto> request)
        {
            var response = new BusinessResponse<TypeRelanceDto>();

            try
            {
                response = await new TypeRelanceManager().GetTypeRelancesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypeRelances")]
        public async Task<BusinessResponse<TypeRelanceDto>> PostSaveTypeRelances([FromBody]BusinessRequest<TypeRelanceDto> request)
        {
            var response = new BusinessResponse<TypeRelanceDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeRelanceManager().SaveTypeRelances(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypeRelances")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypeRelances([FromBody]BusinessRequest<TypeRelanceDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeRelanceManager().DeleteTypeRelances(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpAuditLogs
        [ActionName("GetAbpAuditLogsById")]
        public async Task<BusinessResponse<AbpAuditLogsDto>> GetAbpAuditLogsById(int id)
        {
            var response = new BusinessResponse<AbpAuditLogsDto>();

            try
            {
                response = await new AbpAuditLogsManager().GetAbpAuditLogsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpAuditLogsByCriteria")]
        public async Task<BusinessResponse<AbpAuditLogsDto>> PostGetAbpAuditLogsByCriteria([FromBody]BusinessRequest<AbpAuditLogsDto> request)
        {
            var response = new BusinessResponse<AbpAuditLogsDto>();

            try
            {
                response = await new AbpAuditLogsManager().GetAbpAuditLogsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpAuditLogs")]
        public async Task<BusinessResponse<AbpAuditLogsDto>> PostSaveAbpAuditLogs([FromBody]BusinessRequest<AbpAuditLogsDto> request)
        {
            var response = new BusinessResponse<AbpAuditLogsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpAuditLogsManager().SaveAbpAuditLogs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpAuditLogs")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpAuditLogs([FromBody]BusinessRequest<AbpAuditLogsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpAuditLogsManager().DeleteAbpAuditLogs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpEditions
        [ActionName("GetAbpEditionsById")]
        public async Task<BusinessResponse<AbpEditionsDto>> GetAbpEditionsById(int id)
        {
            var response = new BusinessResponse<AbpEditionsDto>();

            try
            {
                response = await new AbpEditionsManager().GetAbpEditionsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpEditionsByCriteria")]
        public async Task<BusinessResponse<AbpEditionsDto>> PostGetAbpEditionsByCriteria([FromBody]BusinessRequest<AbpEditionsDto> request)
        {
            var response = new BusinessResponse<AbpEditionsDto>();

            try
            {
                response = await new AbpEditionsManager().GetAbpEditionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpEditions")]
        public async Task<BusinessResponse<AbpEditionsDto>> PostSaveAbpEditions([FromBody]BusinessRequest<AbpEditionsDto> request)
        {
            var response = new BusinessResponse<AbpEditionsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpEditionsManager().SaveAbpEditions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpEditions")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpEditions([FromBody]BusinessRequest<AbpEditionsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpEditionsManager().DeleteAbpEditions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpFeatures
        [ActionName("GetAbpFeaturesById")]
        public async Task<BusinessResponse<AbpFeaturesDto>> GetAbpFeaturesById(int id)
        {
            var response = new BusinessResponse<AbpFeaturesDto>();

            try
            {
                response = await new AbpFeaturesManager().GetAbpFeaturesById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpFeaturesByCriteria")]
        public async Task<BusinessResponse<AbpFeaturesDto>> PostGetAbpFeaturesByCriteria([FromBody]BusinessRequest<AbpFeaturesDto> request)
        {
            var response = new BusinessResponse<AbpFeaturesDto>();

            try
            {
                response = await new AbpFeaturesManager().GetAbpFeaturesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpFeatures")]
        public async Task<BusinessResponse<AbpFeaturesDto>> PostSaveAbpFeatures([FromBody]BusinessRequest<AbpFeaturesDto> request)
        {
            var response = new BusinessResponse<AbpFeaturesDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpFeaturesManager().SaveAbpFeatures(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpFeatures")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpFeatures([FromBody]BusinessRequest<AbpFeaturesDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpFeaturesManager().DeleteAbpFeatures(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpNotifications
        [ActionName("GetAbpNotificationsById")]
        public async Task<BusinessResponse<AbpNotificationsDto>> GetAbpNotificationsById(int id)
        {
            var response = new BusinessResponse<AbpNotificationsDto>();

            try
            {
                response = await new AbpNotificationsManager().GetAbpNotificationsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpNotificationsByCriteria")]
        public async Task<BusinessResponse<AbpNotificationsDto>> PostGetAbpNotificationsByCriteria([FromBody]BusinessRequest<AbpNotificationsDto> request)
        {
            var response = new BusinessResponse<AbpNotificationsDto>();

            try
            {
                response = await new AbpNotificationsManager().GetAbpNotificationsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpNotifications")]
        public async Task<BusinessResponse<AbpNotificationsDto>> PostSaveAbpNotifications([FromBody]BusinessRequest<AbpNotificationsDto> request)
        {
            var response = new BusinessResponse<AbpNotificationsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpNotificationsManager().SaveAbpNotifications(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpNotifications")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpNotifications([FromBody]BusinessRequest<AbpNotificationsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpNotificationsManager().DeleteAbpNotifications(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpNotificationSubscriptions
        [ActionName("GetAbpNotificationSubscriptionsById")]
        public async Task<BusinessResponse<AbpNotificationSubscriptionsDto>> GetAbpNotificationSubscriptionsById(int id)
        {
            var response = new BusinessResponse<AbpNotificationSubscriptionsDto>();

            try
            {
                response = await new AbpNotificationSubscriptionsManager().GetAbpNotificationSubscriptionsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpNotificationSubscriptionsByCriteria")]
        public async Task<BusinessResponse<AbpNotificationSubscriptionsDto>> PostGetAbpNotificationSubscriptionsByCriteria([FromBody]BusinessRequest<AbpNotificationSubscriptionsDto> request)
        {
            var response = new BusinessResponse<AbpNotificationSubscriptionsDto>();

            try
            {
                response = await new AbpNotificationSubscriptionsManager().GetAbpNotificationSubscriptionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpNotificationSubscriptions")]
        public async Task<BusinessResponse<AbpNotificationSubscriptionsDto>> PostSaveAbpNotificationSubscriptions([FromBody]BusinessRequest<AbpNotificationSubscriptionsDto> request)
        {
            var response = new BusinessResponse<AbpNotificationSubscriptionsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpNotificationSubscriptionsManager().SaveAbpNotificationSubscriptions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpNotificationSubscriptions")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpNotificationSubscriptions([FromBody]BusinessRequest<AbpNotificationSubscriptionsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpNotificationSubscriptionsManager().DeleteAbpNotificationSubscriptions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpOrganizationUnits
        [ActionName("GetAbpOrganizationUnitsById")]
        public async Task<BusinessResponse<AbpOrganizationUnitsDto>> GetAbpOrganizationUnitsById(int id)
        {
            var response = new BusinessResponse<AbpOrganizationUnitsDto>();

            try
            {
                response = await new AbpOrganizationUnitsManager().GetAbpOrganizationUnitsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpOrganizationUnitsByCriteria")]
        public async Task<BusinessResponse<AbpOrganizationUnitsDto>> PostGetAbpOrganizationUnitsByCriteria([FromBody]BusinessRequest<AbpOrganizationUnitsDto> request)
        {
            var response = new BusinessResponse<AbpOrganizationUnitsDto>();

            try
            {
                response = await new AbpOrganizationUnitsManager().GetAbpOrganizationUnitsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpOrganizationUnits")]
        public async Task<BusinessResponse<AbpOrganizationUnitsDto>> PostSaveAbpOrganizationUnits([FromBody]BusinessRequest<AbpOrganizationUnitsDto> request)
        {
            var response = new BusinessResponse<AbpOrganizationUnitsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpOrganizationUnitsManager().SaveAbpOrganizationUnits(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpOrganizationUnits")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpOrganizationUnits([FromBody]BusinessRequest<AbpOrganizationUnitsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpOrganizationUnitsManager().DeleteAbpOrganizationUnits(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpPermissions
        [ActionName("GetAbpPermissionsById")]
        public async Task<BusinessResponse<AbpPermissionsDto>> GetAbpPermissionsById(int id)
        {
            var response = new BusinessResponse<AbpPermissionsDto>();

            try
            {
                response = await new AbpPermissionsManager().GetAbpPermissionsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpPermissionsByCriteria")]
        public async Task<BusinessResponse<AbpPermissionsDto>> PostGetAbpPermissionsByCriteria([FromBody]BusinessRequest<AbpPermissionsDto> request)
        {
            var response = new BusinessResponse<AbpPermissionsDto>();

            try
            {
                response = await new AbpPermissionsManager().GetAbpPermissionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpPermissions")]
        public async Task<BusinessResponse<AbpPermissionsDto>> PostSaveAbpPermissions([FromBody]BusinessRequest<AbpPermissionsDto> request)
        {
            var response = new BusinessResponse<AbpPermissionsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpPermissionsManager().SaveAbpPermissions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpPermissions")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpPermissions([FromBody]BusinessRequest<AbpPermissionsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpPermissionsManager().DeleteAbpPermissions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpRoles
        [ActionName("GetAbpRolesById")]
        public async Task<BusinessResponse<AbpRolesDto>> GetAbpRolesById(int id)
        {
            var response = new BusinessResponse<AbpRolesDto>();

            try
            {
                response = await new AbpRolesManager().GetAbpRolesById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpRolesByCriteria")]
        public async Task<BusinessResponse<AbpRolesDto>> PostGetAbpRolesByCriteria([FromBody]BusinessRequest<AbpRolesDto> request)
        {
            var response = new BusinessResponse<AbpRolesDto>();

            try
            {
                response = await new AbpRolesManager().GetAbpRolesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpRoles")]
        public async Task<BusinessResponse<AbpRolesDto>> PostSaveAbpRoles([FromBody]BusinessRequest<AbpRolesDto> request)
        {
            var response = new BusinessResponse<AbpRolesDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpRolesManager().SaveAbpRoles(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpRoles")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpRoles([FromBody]BusinessRequest<AbpRolesDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpRolesManager().DeleteAbpRoles(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpTenantNotifications
        [ActionName("GetAbpTenantNotificationsById")]
        public async Task<BusinessResponse<AbpTenantNotificationsDto>> GetAbpTenantNotificationsById(int id)
        {
            var response = new BusinessResponse<AbpTenantNotificationsDto>();

            try
            {
                response = await new AbpTenantNotificationsManager().GetAbpTenantNotificationsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpTenantNotificationsByCriteria")]
        public async Task<BusinessResponse<AbpTenantNotificationsDto>> PostGetAbpTenantNotificationsByCriteria([FromBody]BusinessRequest<AbpTenantNotificationsDto> request)
        {
            var response = new BusinessResponse<AbpTenantNotificationsDto>();

            try
            {
                response = await new AbpTenantNotificationsManager().GetAbpTenantNotificationsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpTenantNotifications")]
        public async Task<BusinessResponse<AbpTenantNotificationsDto>> PostSaveAbpTenantNotifications([FromBody]BusinessRequest<AbpTenantNotificationsDto> request)
        {
            var response = new BusinessResponse<AbpTenantNotificationsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpTenantNotificationsManager().SaveAbpTenantNotifications(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpTenantNotifications")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpTenantNotifications([FromBody]BusinessRequest<AbpTenantNotificationsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpTenantNotificationsManager().DeleteAbpTenantNotifications(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpTenants
        [ActionName("GetAbpTenantsById")]
        public async Task<BusinessResponse<AbpTenantsDto>> GetAbpTenantsById(int id)
        {
            var response = new BusinessResponse<AbpTenantsDto>();

            try
            {
                response = await new AbpTenantsManager().GetAbpTenantsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpTenantsByCriteria")]
        public async Task<BusinessResponse<AbpTenantsDto>> PostGetAbpTenantsByCriteria([FromBody]BusinessRequest<AbpTenantsDto> request)
        {
            var response = new BusinessResponse<AbpTenantsDto>();

            try
            {
                response = await new AbpTenantsManager().GetAbpTenantsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpTenants")]
        public async Task<BusinessResponse<AbpTenantsDto>> PostSaveAbpTenants([FromBody]BusinessRequest<AbpTenantsDto> request)
        {
            var response = new BusinessResponse<AbpTenantsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpTenantsManager().SaveAbpTenants(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpTenants")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpTenants([FromBody]BusinessRequest<AbpTenantsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpTenantsManager().DeleteAbpTenants(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpUserAccounts
        [ActionName("GetAbpUserAccountsById")]
        public async Task<BusinessResponse<AbpUserAccountsDto>> GetAbpUserAccountsById(int id)
        {
            var response = new BusinessResponse<AbpUserAccountsDto>();

            try
            {
                response = await new AbpUserAccountsManager().GetAbpUserAccountsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpUserAccountsByCriteria")]
        public async Task<BusinessResponse<AbpUserAccountsDto>> PostGetAbpUserAccountsByCriteria([FromBody]BusinessRequest<AbpUserAccountsDto> request)
        {
            var response = new BusinessResponse<AbpUserAccountsDto>();

            try
            {
                response = await new AbpUserAccountsManager().GetAbpUserAccountsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpUserAccounts")]
        public async Task<BusinessResponse<AbpUserAccountsDto>> PostSaveAbpUserAccounts([FromBody]BusinessRequest<AbpUserAccountsDto> request)
        {
            var response = new BusinessResponse<AbpUserAccountsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUserAccountsManager().SaveAbpUserAccounts(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpUserAccounts")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpUserAccounts([FromBody]BusinessRequest<AbpUserAccountsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUserAccountsManager().DeleteAbpUserAccounts(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpUserClaims
        [ActionName("GetAbpUserClaimsById")]
        public async Task<BusinessResponse<AbpUserClaimsDto>> GetAbpUserClaimsById(int id)
        {
            var response = new BusinessResponse<AbpUserClaimsDto>();

            try
            {
                response = await new AbpUserClaimsManager().GetAbpUserClaimsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpUserClaimsByCriteria")]
        public async Task<BusinessResponse<AbpUserClaimsDto>> PostGetAbpUserClaimsByCriteria([FromBody]BusinessRequest<AbpUserClaimsDto> request)
        {
            var response = new BusinessResponse<AbpUserClaimsDto>();

            try
            {
                response = await new AbpUserClaimsManager().GetAbpUserClaimsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpUserClaims")]
        public async Task<BusinessResponse<AbpUserClaimsDto>> PostSaveAbpUserClaims([FromBody]BusinessRequest<AbpUserClaimsDto> request)
        {
            var response = new BusinessResponse<AbpUserClaimsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUserClaimsManager().SaveAbpUserClaims(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpUserClaims")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpUserClaims([FromBody]BusinessRequest<AbpUserClaimsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUserClaimsManager().DeleteAbpUserClaims(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpUserLoginAttempts
        [ActionName("GetAbpUserLoginAttemptsById")]
        public async Task<BusinessResponse<AbpUserLoginAttemptsDto>> GetAbpUserLoginAttemptsById(int id)
        {
            var response = new BusinessResponse<AbpUserLoginAttemptsDto>();

            try
            {
                response = await new AbpUserLoginAttemptsManager().GetAbpUserLoginAttemptsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpUserLoginAttemptsByCriteria")]
        public async Task<BusinessResponse<AbpUserLoginAttemptsDto>> PostGetAbpUserLoginAttemptsByCriteria([FromBody]BusinessRequest<AbpUserLoginAttemptsDto> request)
        {
            var response = new BusinessResponse<AbpUserLoginAttemptsDto>();

            try
            {
                response = await new AbpUserLoginAttemptsManager().GetAbpUserLoginAttemptsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpUserLoginAttempts")]
        public async Task<BusinessResponse<AbpUserLoginAttemptsDto>> PostSaveAbpUserLoginAttempts([FromBody]BusinessRequest<AbpUserLoginAttemptsDto> request)
        {
            var response = new BusinessResponse<AbpUserLoginAttemptsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUserLoginAttemptsManager().SaveAbpUserLoginAttempts(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpUserLoginAttempts")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpUserLoginAttempts([FromBody]BusinessRequest<AbpUserLoginAttemptsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUserLoginAttemptsManager().DeleteAbpUserLoginAttempts(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpUserLogins
        [ActionName("GetAbpUserLoginsById")]
        public async Task<BusinessResponse<AbpUserLoginsDto>> GetAbpUserLoginsById(int id)
        {
            var response = new BusinessResponse<AbpUserLoginsDto>();

            try
            {
                response = await new AbpUserLoginsManager().GetAbpUserLoginsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpUserLoginsByCriteria")]
        public async Task<BusinessResponse<AbpUserLoginsDto>> PostGetAbpUserLoginsByCriteria([FromBody]BusinessRequest<AbpUserLoginsDto> request)
        {
            var response = new BusinessResponse<AbpUserLoginsDto>();

            try
            {
                response = await new AbpUserLoginsManager().GetAbpUserLoginsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpUserLogins")]
        public async Task<BusinessResponse<AbpUserLoginsDto>> PostSaveAbpUserLogins([FromBody]BusinessRequest<AbpUserLoginsDto> request)
        {
            var response = new BusinessResponse<AbpUserLoginsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUserLoginsManager().SaveAbpUserLogins(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpUserLogins")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpUserLogins([FromBody]BusinessRequest<AbpUserLoginsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUserLoginsManager().DeleteAbpUserLogins(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpUserNotifications
        [ActionName("GetAbpUserNotificationsById")]
        public async Task<BusinessResponse<AbpUserNotificationsDto>> GetAbpUserNotificationsById(int id)
        {
            var response = new BusinessResponse<AbpUserNotificationsDto>();

            try
            {
                response = await new AbpUserNotificationsManager().GetAbpUserNotificationsById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpUserNotificationsByCriteria")]
        public async Task<BusinessResponse<AbpUserNotificationsDto>> PostGetAbpUserNotificationsByCriteria([FromBody]BusinessRequest<AbpUserNotificationsDto> request)
        {
            var response = new BusinessResponse<AbpUserNotificationsDto>();

            try
            {
                response = await new AbpUserNotificationsManager().GetAbpUserNotificationsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpUserNotifications")]
        public async Task<BusinessResponse<AbpUserNotificationsDto>> PostSaveAbpUserNotifications([FromBody]BusinessRequest<AbpUserNotificationsDto> request)
        {
            var response = new BusinessResponse<AbpUserNotificationsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUserNotificationsManager().SaveAbpUserNotifications(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpUserNotifications")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpUserNotifications([FromBody]BusinessRequest<AbpUserNotificationsDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUserNotificationsManager().DeleteAbpUserNotifications(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpUserRoles
        [ActionName("GetAbpUserRolesById")]
        public async Task<BusinessResponse<AbpUserRolesDto>> GetAbpUserRolesById(int id)
        {
            var response = new BusinessResponse<AbpUserRolesDto>();

            try
            {
                response = await new AbpUserRolesManager().GetAbpUserRolesById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpUserRolesByCriteria")]
        public async Task<BusinessResponse<AbpUserRolesDto>> PostGetAbpUserRolesByCriteria([FromBody]BusinessRequest<AbpUserRolesDto> request)
        {
            var response = new BusinessResponse<AbpUserRolesDto>();

            try
            {
                response = await new AbpUserRolesManager().GetAbpUserRolesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpUserRoles")]
        public async Task<BusinessResponse<AbpUserRolesDto>> PostSaveAbpUserRoles([FromBody]BusinessRequest<AbpUserRolesDto> request)
        {
            var response = new BusinessResponse<AbpUserRolesDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUserRolesManager().SaveAbpUserRoles(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpUserRoles")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpUserRoles([FromBody]BusinessRequest<AbpUserRolesDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUserRolesManager().DeleteAbpUserRoles(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AbpUsers
        [ActionName("GetAbpUsersById")]
        public async Task<BusinessResponse<AbpUsersDto>> GetAbpUsersById(int id)
        {
            var response = new BusinessResponse<AbpUsersDto>();

            try
            {
                response = await new AbpUsersManager().GetAbpUsersById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAbpUsersByCriteria")]
        public async Task<BusinessResponse<AbpUsersDto>> PostGetAbpUsersByCriteria([FromBody]BusinessRequest<AbpUsersDto> request)
        {
            var response = new BusinessResponse<AbpUsersDto>();

            try
            {
                response = await new AbpUsersManager().GetAbpUsersByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAbpUsers")]
        public async Task<BusinessResponse<AbpUsersDto>> PostSaveAbpUsers([FromBody]BusinessRequest<AbpUsersDto> request)
        {
            var response = new BusinessResponse<AbpUsersDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUsersManager().SaveAbpUsers(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAbpUsers")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAbpUsers([FromBody]BusinessRequest<AbpUsersDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AbpUsersManager().DeleteAbpUsers(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Actes
        [ActionName("GetActeById")]
        public async Task<BusinessResponse<ActeDto>> GetActeById(int id)
        {
            var response = new BusinessResponse<ActeDto>();

            try
            {
                response = await new ActeManager().GetActeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetActesByCriteria")]
        public async Task<BusinessResponse<ActeDto>> PostGetActesByCriteria([FromBody]BusinessRequest<ActeDto> request)
        {
            var response = new BusinessResponse<ActeDto>();

            try
            {
                response = await new ActeManager().GetActesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveActes")]
        public async Task<BusinessResponse<ActeDto>> PostSaveActes([FromBody]BusinessRequest<ActeDto> request)
        {
            var response = new BusinessResponse<ActeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ActeManager().SaveActes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteActes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteActes([FromBody]BusinessRequest<ActeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ActeManager().DeleteActes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Affections
        [ActionName("GetAffectionById")]
        public async Task<BusinessResponse<AffectionDto>> GetAffectionById(int id)
        {
            var response = new BusinessResponse<AffectionDto>();

            try
            {
                response = await new AffectionManager().GetAffectionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAffectionsByCriteria")]
        public async Task<BusinessResponse<AffectionDto>> PostGetAffectionsByCriteria([FromBody]BusinessRequest<AffectionDto> request)
        {
            var response = new BusinessResponse<AffectionDto>();

            try
            {
                response = await new AffectionManager().GetAffectionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAffections")]
        public async Task<BusinessResponse<AffectionDto>> PostSaveAffections([FromBody]BusinessRequest<AffectionDto> request)
        {
            var response = new BusinessResponse<AffectionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AffectionManager().SaveAffections(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAffections")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAffections([FromBody]BusinessRequest<AffectionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AffectionManager().DeleteAffections(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ClasseTherapeutiques
        [ActionName("GetClasseTherapeutiqueById")]
        public async Task<BusinessResponse<ClasseTherapeutiqueDto>> GetClasseTherapeutiqueById(int id)
        {
            var response = new BusinessResponse<ClasseTherapeutiqueDto>();

            try
            {
                response = await new ClasseTherapeutiqueManager().GetClasseTherapeutiqueById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetClasseTherapeutiquesByCriteria")]
        public async Task<BusinessResponse<ClasseTherapeutiqueDto>> PostGetClasseTherapeutiquesByCriteria([FromBody]BusinessRequest<ClasseTherapeutiqueDto> request)
        {
            var response = new BusinessResponse<ClasseTherapeutiqueDto>();

            try
            {
                response = await new ClasseTherapeutiqueManager().GetClasseTherapeutiquesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveClasseTherapeutiques")]
        public async Task<BusinessResponse<ClasseTherapeutiqueDto>> PostSaveClasseTherapeutiques([FromBody]BusinessRequest<ClasseTherapeutiqueDto> request)
        {
            var response = new BusinessResponse<ClasseTherapeutiqueDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ClasseTherapeutiqueManager().SaveClasseTherapeutiques(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteClasseTherapeutiques")]
        public async Task<BusinessResponse<Boolean>> PostDeleteClasseTherapeutiques([FromBody]BusinessRequest<ClasseTherapeutiqueDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ClasseTherapeutiqueManager().DeleteClasseTherapeutiques(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region CodeMedicalActes
        [ActionName("GetCodeMedicalActeById")]
        public async Task<BusinessResponse<CodeMedicalActeDto>> GetCodeMedicalActeById(int id)
        {
            var response = new BusinessResponse<CodeMedicalActeDto>();

            try
            {
                response = await new CodeMedicalActeManager().GetCodeMedicalActeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetCodeMedicalActesByCriteria")]
        public async Task<BusinessResponse<CodeMedicalActeDto>> PostGetCodeMedicalActesByCriteria([FromBody]BusinessRequest<CodeMedicalActeDto> request)
        {
            var response = new BusinessResponse<CodeMedicalActeDto>();

            try
            {
                response = await new CodeMedicalActeManager().GetCodeMedicalActesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveCodeMedicalActes")]
        public async Task<BusinessResponse<CodeMedicalActeDto>> PostSaveCodeMedicalActes([FromBody]BusinessRequest<CodeMedicalActeDto> request)
        {
            var response = new BusinessResponse<CodeMedicalActeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CodeMedicalActeManager().SaveCodeMedicalActes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteCodeMedicalActes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteCodeMedicalActes([FromBody]BusinessRequest<CodeMedicalActeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CodeMedicalActeManager().DeleteCodeMedicalActes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Conditionnements
        [ActionName("GetConditionnementById")]
        public async Task<BusinessResponse<ConditionnementDto>> GetConditionnementById(int id)
        {
            var response = new BusinessResponse<ConditionnementDto>();

            try
            {
                response = await new ConditionnementManager().GetConditionnementById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetConditionnementsByCriteria")]
        public async Task<BusinessResponse<ConditionnementDto>> PostGetConditionnementsByCriteria([FromBody]BusinessRequest<ConditionnementDto> request)
        {
            var response = new BusinessResponse<ConditionnementDto>();

            try
            {
                response = await new ConditionnementManager().GetConditionnementsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveConditionnements")]
        public async Task<BusinessResponse<ConditionnementDto>> PostSaveConditionnements([FromBody]BusinessRequest<ConditionnementDto> request)
        {
            var response = new BusinessResponse<ConditionnementDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ConditionnementManager().SaveConditionnements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteConditionnements")]
        public async Task<BusinessResponse<Boolean>> PostDeleteConditionnements([FromBody]BusinessRequest<ConditionnementDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ConditionnementManager().DeleteConditionnements(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ConditionnementFormeGaleniqueMedicaments
        [ActionName("GetConditionnementFormeGaleniqueMedicamentById")]
        public async Task<BusinessResponse<ConditionnementFormeGaleniqueMedicamentDto>> GetConditionnementFormeGaleniqueMedicamentById(int id)
        {
            var response = new BusinessResponse<ConditionnementFormeGaleniqueMedicamentDto>();

            try
            {
                response = await new ConditionnementFormeGaleniqueMedicamentManager().GetConditionnementFormeGaleniqueMedicamentById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetConditionnementFormeGaleniqueMedicamentsByCriteria")]
        public async Task<BusinessResponse<ConditionnementFormeGaleniqueMedicamentDto>> PostGetConditionnementFormeGaleniqueMedicamentsByCriteria([FromBody]BusinessRequest<ConditionnementFormeGaleniqueMedicamentDto> request)
        {
            var response = new BusinessResponse<ConditionnementFormeGaleniqueMedicamentDto>();

            try
            {
                response = await new ConditionnementFormeGaleniqueMedicamentManager().GetConditionnementFormeGaleniqueMedicamentsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveConditionnementFormeGaleniqueMedicaments")]
        public async Task<BusinessResponse<ConditionnementFormeGaleniqueMedicamentDto>> PostSaveConditionnementFormeGaleniqueMedicaments([FromBody]BusinessRequest<ConditionnementFormeGaleniqueMedicamentDto> request)
        {
            var response = new BusinessResponse<ConditionnementFormeGaleniqueMedicamentDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ConditionnementFormeGaleniqueMedicamentManager().SaveConditionnementFormeGaleniqueMedicaments(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteConditionnementFormeGaleniqueMedicaments")]
        public async Task<BusinessResponse<Boolean>> PostDeleteConditionnementFormeGaleniqueMedicaments([FromBody]BusinessRequest<ConditionnementFormeGaleniqueMedicamentDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ConditionnementFormeGaleniqueMedicamentManager().DeleteConditionnementFormeGaleniqueMedicaments(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Dcis
        [ActionName("GetDciById")]
        public async Task<BusinessResponse<DciDto>> GetDciById(int id)
        {
            var response = new BusinessResponse<DciDto>();

            try
            {
                response = await new DciManager().GetDciById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetDcisByCriteria")]
        public async Task<BusinessResponse<DciDto>> PostGetDcisByCriteria([FromBody]BusinessRequest<DciDto> request)
        {
            var response = new BusinessResponse<DciDto>();

            try
            {
                response = await new DciManager().GetDcisByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveDcis")]
        public async Task<BusinessResponse<DciDto>> PostSaveDcis([FromBody]BusinessRequest<DciDto> request)
        {
            var response = new BusinessResponse<DciDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DciManager().SaveDcis(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteDcis")]
        public async Task<BusinessResponse<Boolean>> PostDeleteDcis([FromBody]BusinessRequest<DciDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DciManager().DeleteDcis(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region EmployeGarants
        [ActionName("GetEmployeGarantById")]
        public async Task<BusinessResponse<EmployeGarantDto>> GetEmployeGarantById(int id)
        {
            var response = new BusinessResponse<EmployeGarantDto>();

            try
            {
                response = await new EmployeGarantManager().GetEmployeGarantById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetEmployeGarantsByCriteria")]
        public async Task<BusinessResponse<EmployeGarantDto>> PostGetEmployeGarantsByCriteria([FromBody]BusinessRequest<EmployeGarantDto> request)
        {
            var response = new BusinessResponse<EmployeGarantDto>();

            try
            {
                response = await new EmployeGarantManager().GetEmployeGarantsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveEmployeGarants")]
        public async Task<BusinessResponse<EmployeGarantDto>> PostSaveEmployeGarants([FromBody]BusinessRequest<EmployeGarantDto> request)
        {
            var response = new BusinessResponse<EmployeGarantDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new EmployeGarantManager().SaveEmployeGarants(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteEmployeGarants")]
        public async Task<BusinessResponse<Boolean>> PostDeleteEmployeGarants([FromBody]BusinessRequest<EmployeGarantDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new EmployeGarantManager().DeleteEmployeGarants(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region EmployeGestionnaires
        [ActionName("GetEmployeGestionnaireById")]
        public async Task<BusinessResponse<EmployeGestionnaireDto>> GetEmployeGestionnaireById(int id)
        {
            var response = new BusinessResponse<EmployeGestionnaireDto>();

            try
            {
                response = await new EmployeGestionnaireManager().GetEmployeGestionnaireById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetEmployeGestionnairesByCriteria")]
        public async Task<BusinessResponse<EmployeGestionnaireDto>> PostGetEmployeGestionnairesByCriteria([FromBody]BusinessRequest<EmployeGestionnaireDto> request)
        {
            var response = new BusinessResponse<EmployeGestionnaireDto>();

            try
            {
                response = await new EmployeGestionnaireManager().GetEmployeGestionnairesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveEmployeGestionnaires")]
        public async Task<BusinessResponse<EmployeGestionnaireDto>> PostSaveEmployeGestionnaires([FromBody]BusinessRequest<EmployeGestionnaireDto> request)
        {
            var response = new BusinessResponse<EmployeGestionnaireDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new EmployeGestionnaireManager().SaveEmployeGestionnaires(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteEmployeGestionnaires")]
        public async Task<BusinessResponse<Boolean>> PostDeleteEmployeGestionnaires([FromBody]BusinessRequest<EmployeGestionnaireDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new EmployeGestionnaireManager().DeleteEmployeGestionnaires(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region FamilleActeRefs
        [ActionName("GetFamilleActeRefById")]
        public async Task<BusinessResponse<FamilleActeRefDto>> GetFamilleActeRefById(int id)
        {
            var response = new BusinessResponse<FamilleActeRefDto>();

            try
            {
                response = await new FamilleActeRefManager().GetFamilleActeRefById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetFamilleActeRefsByCriteria")]
        public async Task<BusinessResponse<FamilleActeRefDto>> PostGetFamilleActeRefsByCriteria([FromBody]BusinessRequest<FamilleActeRefDto> request)
        {
            var response = new BusinessResponse<FamilleActeRefDto>();

            try
            {
                response = await new FamilleActeRefManager().GetFamilleActeRefsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveFamilleActeRefs")]
        public async Task<BusinessResponse<FamilleActeRefDto>> PostSaveFamilleActeRefs([FromBody]BusinessRequest<FamilleActeRefDto> request)
        {
            var response = new BusinessResponse<FamilleActeRefDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new FamilleActeRefManager().SaveFamilleActeRefs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteFamilleActeRefs")]
        public async Task<BusinessResponse<Boolean>> PostDeleteFamilleActeRefs([FromBody]BusinessRequest<FamilleActeRefDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new FamilleActeRefManager().DeleteFamilleActeRefs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region FormeGaleniques
        [ActionName("GetFormeGaleniqueById")]
        public async Task<BusinessResponse<FormeGaleniqueDto>> GetFormeGaleniqueById(int id)
        {
            var response = new BusinessResponse<FormeGaleniqueDto>();

            try
            {
                response = await new FormeGaleniqueManager().GetFormeGaleniqueById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetFormeGaleniquesByCriteria")]
        public async Task<BusinessResponse<FormeGaleniqueDto>> PostGetFormeGaleniquesByCriteria([FromBody]BusinessRequest<FormeGaleniqueDto> request)
        {
            var response = new BusinessResponse<FormeGaleniqueDto>();

            try
            {
                response = await new FormeGaleniqueManager().GetFormeGaleniquesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveFormeGaleniques")]
        public async Task<BusinessResponse<FormeGaleniqueDto>> PostSaveFormeGaleniques([FromBody]BusinessRequest<FormeGaleniqueDto> request)
        {
            var response = new BusinessResponse<FormeGaleniqueDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new FormeGaleniqueManager().SaveFormeGaleniques(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteFormeGaleniques")]
        public async Task<BusinessResponse<Boolean>> PostDeleteFormeGaleniques([FromBody]BusinessRequest<FormeGaleniqueDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new FormeGaleniqueManager().DeleteFormeGaleniques(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Gestionnaires
        [ActionName("GetGestionnaireById")]
        public async Task<BusinessResponse<GestionnaireDto>> GetGestionnaireById(int id)
        {
            var response = new BusinessResponse<GestionnaireDto>();

            try
            {
                response = await new GestionnaireManager().GetGestionnaireById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetGestionnairesByCriteria")]
        public async Task<BusinessResponse<GestionnaireDto>> PostGetGestionnairesByCriteria([FromBody]BusinessRequest<GestionnaireDto> request)
        {
            var response = new BusinessResponse<GestionnaireDto>();

            try
            {
                response = await new GestionnaireManager().GetGestionnairesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveGestionnaires")]
        public async Task<BusinessResponse<GestionnaireDto>> PostSaveGestionnaires([FromBody]BusinessRequest<GestionnaireDto> request)
        {
            var response = new BusinessResponse<GestionnaireDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new GestionnaireManager().SaveGestionnaires(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteGestionnaires")]
        public async Task<BusinessResponse<Boolean>> PostDeleteGestionnaires([FromBody]BusinessRequest<GestionnaireDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new GestionnaireManager().DeleteGestionnaires(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Habilitations
        [ActionName("GetHabilitationById")]
        public async Task<BusinessResponse<HabilitationDto>> GetHabilitationById(int id)
        {
            var response = new BusinessResponse<HabilitationDto>();

            try
            {
                response = await new HabilitationManager().GetHabilitationById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetHabilitationsByCriteria")]
        public async Task<BusinessResponse<HabilitationDto>> PostGetHabilitationsByCriteria([FromBody]BusinessRequest<HabilitationDto> request)
        {
            var response = new BusinessResponse<HabilitationDto>();

            try
            {
                response = await new HabilitationManager().GetHabilitationsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveHabilitations")]
        public async Task<BusinessResponse<HabilitationDto>> PostSaveHabilitations([FromBody]BusinessRequest<HabilitationDto> request)
        {
            var response = new BusinessResponse<HabilitationDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new HabilitationManager().SaveHabilitations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteHabilitations")]
        public async Task<BusinessResponse<Boolean>> PostDeleteHabilitations([FromBody]BusinessRequest<HabilitationDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new HabilitationManager().DeleteHabilitations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region HabilitationProfils
        [ActionName("GetHabilitationProfilById")]
        public async Task<BusinessResponse<HabilitationProfilDto>> GetHabilitationProfilById(int id)
        {
            var response = new BusinessResponse<HabilitationProfilDto>();

            try
            {
                response = await new HabilitationProfilManager().GetHabilitationProfilById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetHabilitationProfilsByCriteria")]
        public async Task<BusinessResponse<HabilitationProfilDto>> PostGetHabilitationProfilsByCriteria([FromBody]BusinessRequest<HabilitationProfilDto> request)
        {
            var response = new BusinessResponse<HabilitationProfilDto>();

            try
            {
                response = await new HabilitationProfilManager().GetHabilitationProfilsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveHabilitationProfils")]
        public async Task<BusinessResponse<HabilitationProfilDto>> PostSaveHabilitationProfils([FromBody]BusinessRequest<HabilitationProfilDto> request)
        {
            var response = new BusinessResponse<HabilitationProfilDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new HabilitationProfilManager().SaveHabilitationProfils(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteHabilitationProfils")]
        public async Task<BusinessResponse<Boolean>> PostDeleteHabilitationProfils([FromBody]BusinessRequest<HabilitationProfilDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new HabilitationProfilManager().DeleteHabilitationProfils(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Medicaments
        [ActionName("GetMedicamentById")]
        public async Task<BusinessResponse<MedicamentDto>> GetMedicamentById(int id)
        {
            var response = new BusinessResponse<MedicamentDto>();

            try
            {
                response = await new MedicamentManager().GetMedicamentById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetMedicamentsByCriteria")]
        public async Task<BusinessResponse<MedicamentDto>> PostGetMedicamentsByCriteria([FromBody]BusinessRequest<MedicamentDto> request)
        {
            var response = new BusinessResponse<MedicamentDto>();

            try
            {
                response = await new MedicamentManager().GetMedicamentsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveMedicaments")]
        public async Task<BusinessResponse<MedicamentDto>> PostSaveMedicaments([FromBody]BusinessRequest<MedicamentDto> request)
        {
            var response = new BusinessResponse<MedicamentDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new MedicamentManager().SaveMedicaments(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteMedicaments")]
        public async Task<BusinessResponse<Boolean>> PostDeleteMedicaments([FromBody]BusinessRequest<MedicamentDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new MedicamentManager().DeleteMedicaments(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Molecules
        [ActionName("GetMoleculeById")]
        public async Task<BusinessResponse<MoleculeDto>> GetMoleculeById(int id)
        {
            var response = new BusinessResponse<MoleculeDto>();

            try
            {
                response = await new MoleculeManager().GetMoleculeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetMoleculesByCriteria")]
        public async Task<BusinessResponse<MoleculeDto>> PostGetMoleculesByCriteria([FromBody]BusinessRequest<MoleculeDto> request)
        {
            var response = new BusinessResponse<MoleculeDto>();

            try
            {
                response = await new MoleculeManager().GetMoleculesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveMolecules")]
        public async Task<BusinessResponse<MoleculeDto>> PostSaveMolecules([FromBody]BusinessRequest<MoleculeDto> request)
        {
            var response = new BusinessResponse<MoleculeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new MoleculeManager().SaveMolecules(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteMolecules")]
        public async Task<BusinessResponse<Boolean>> PostDeleteMolecules([FromBody]BusinessRequest<MoleculeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new MoleculeManager().DeleteMolecules(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region MoleculeMedicaments
        [ActionName("GetMoleculeMedicamentById")]
        public async Task<BusinessResponse<MoleculeMedicamentDto>> GetMoleculeMedicamentById(int id)
        {
            var response = new BusinessResponse<MoleculeMedicamentDto>();

            try
            {
                response = await new MoleculeMedicamentManager().GetMoleculeMedicamentById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetMoleculeMedicamentsByCriteria")]
        public async Task<BusinessResponse<MoleculeMedicamentDto>> PostGetMoleculeMedicamentsByCriteria([FromBody]BusinessRequest<MoleculeMedicamentDto> request)
        {
            var response = new BusinessResponse<MoleculeMedicamentDto>();

            try
            {
                response = await new MoleculeMedicamentManager().GetMoleculeMedicamentsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveMoleculeMedicaments")]
        public async Task<BusinessResponse<MoleculeMedicamentDto>> PostSaveMoleculeMedicaments([FromBody]BusinessRequest<MoleculeMedicamentDto> request)
        {
            var response = new BusinessResponse<MoleculeMedicamentDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new MoleculeMedicamentManager().SaveMoleculeMedicaments(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteMoleculeMedicaments")]
        public async Task<BusinessResponse<Boolean>> PostDeleteMoleculeMedicaments([FromBody]BusinessRequest<MoleculeMedicamentDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new MoleculeMedicamentManager().DeleteMoleculeMedicaments(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Pays
        [ActionName("GetPaysById")]
        public async Task<BusinessResponse<PaysDto>> GetPaysById(int id)
        {
            var response = new BusinessResponse<PaysDto>();

            try
            {
                response = await new PaysManager().GetPaysById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPaysByCriteria")]
        public async Task<BusinessResponse<PaysDto>> PostGetPaysByCriteria([FromBody]BusinessRequest<PaysDto> request)
        {
            var response = new BusinessResponse<PaysDto>();

            try
            {
                response = await new PaysManager().GetPaysByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePays")]
        public async Task<BusinessResponse<PaysDto>> PostSavePays([FromBody]BusinessRequest<PaysDto> request)
        {
            var response = new BusinessResponse<PaysDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PaysManager().SavePays(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePays")]
        public async Task<BusinessResponse<Boolean>> PostDeletePays([FromBody]BusinessRequest<PaysDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PaysManager().DeletePays(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Personnes
        [ActionName("GetPersonneById")]
        public async Task<BusinessResponse<PersonneDto>> GetPersonneById(int id)
        {
            var response = new BusinessResponse<PersonneDto>();

            try
            {
                response = await new PersonneManager().GetPersonneById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPersonnesByCriteria")]
        public async Task<BusinessResponse<PersonneDto>> PostGetPersonnesByCriteria([FromBody]BusinessRequest<PersonneDto> request)
        {
            var response = new BusinessResponse<PersonneDto>();

            try
            {
                response = await new PersonneManager().GetPersonnesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePersonnes")]
        public async Task<BusinessResponse<PersonneDto>> PostSavePersonnes([FromBody]BusinessRequest<PersonneDto> request)
        {
            var response = new BusinessResponse<PersonneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PersonneManager().SavePersonnes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePersonnes")]
        public async Task<BusinessResponse<Boolean>> PostDeletePersonnes([FromBody]BusinessRequest<PersonneDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PersonneManager().DeletePersonnes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PersonnelMedicals
        [ActionName("GetPersonnelMedicalById")]
        public async Task<BusinessResponse<PersonnelMedicalDto>> GetPersonnelMedicalById(int id)
        {
            var response = new BusinessResponse<PersonnelMedicalDto>();

            try
            {
                response = await new PersonnelMedicalManager().GetPersonnelMedicalById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPersonnelMedicalsByCriteria")]
        public async Task<BusinessResponse<PersonnelMedicalDto>> PostGetPersonnelMedicalsByCriteria([FromBody]BusinessRequest<PersonnelMedicalDto> request)
        {
            var response = new BusinessResponse<PersonnelMedicalDto>();

            try
            {
                response = await new PersonnelMedicalManager().GetPersonnelMedicalsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePersonnelMedicals")]
        public async Task<BusinessResponse<PersonnelMedicalDto>> PostSavePersonnelMedicals([FromBody]BusinessRequest<PersonnelMedicalDto> request)
        {
            var response = new BusinessResponse<PersonnelMedicalDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PersonnelMedicalManager().SavePersonnelMedicals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePersonnelMedicals")]
        public async Task<BusinessResponse<Boolean>> PostDeletePersonnelMedicals([FromBody]BusinessRequest<PersonnelMedicalDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PersonnelMedicalManager().DeletePersonnelMedicals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PersonneMorales
        [ActionName("GetPersonneMoraleById")]
        public async Task<BusinessResponse<PersonneMoraleDto>> GetPersonneMoraleById(int id)
        {
            var response = new BusinessResponse<PersonneMoraleDto>();

            try
            {
                response = await new PersonneMoraleManager().GetPersonneMoraleById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPersonneMoralesByCriteria")]
        public async Task<BusinessResponse<PersonneMoraleDto>> PostGetPersonneMoralesByCriteria([FromBody]BusinessRequest<PersonneMoraleDto> request)
        {
            var response = new BusinessResponse<PersonneMoraleDto>();

            try
            {
                response = await new PersonneMoraleManager().GetPersonneMoralesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePersonneMorales")]
        public async Task<BusinessResponse<PersonneMoraleDto>> PostSavePersonneMorales([FromBody]BusinessRequest<PersonneMoraleDto> request)
        {
            var response = new BusinessResponse<PersonneMoraleDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PersonneMoraleManager().SavePersonneMorales(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePersonneMorales")]
        public async Task<BusinessResponse<Boolean>> PostDeletePersonneMorales([FromBody]BusinessRequest<PersonneMoraleDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PersonneMoraleManager().DeletePersonneMorales(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PersonnePhysiques
        [ActionName("GetPersonnePhysiqueById")]
        public async Task<BusinessResponse<PersonnePhysiqueDto>> GetPersonnePhysiqueById(int id)
        {
            var response = new BusinessResponse<PersonnePhysiqueDto>();

            try
            {
                response = await new PersonnePhysiqueManager().GetPersonnePhysiqueById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPersonnePhysiquesByCriteria")]
        public async Task<BusinessResponse<PersonnePhysiqueDto>> PostGetPersonnePhysiquesByCriteria([FromBody]BusinessRequest<PersonnePhysiqueDto> request)
        {
            var response = new BusinessResponse<PersonnePhysiqueDto>();

            try
            {
                response = await new PersonnePhysiqueManager().GetPersonnePhysiquesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePersonnePhysiques")]
        public async Task<BusinessResponse<PersonnePhysiqueDto>> PostSavePersonnePhysiques([FromBody]BusinessRequest<PersonnePhysiqueDto> request)
        {
            var response = new BusinessResponse<PersonnePhysiqueDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PersonnePhysiqueManager().SavePersonnePhysiques(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePersonnePhysiques")]
        public async Task<BusinessResponse<Boolean>> PostDeletePersonnePhysiques([FromBody]BusinessRequest<PersonnePhysiqueDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PersonnePhysiqueManager().DeletePersonnePhysiques(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PlanComptableRefs
        [ActionName("GetPlanComptableRefById")]
        public async Task<BusinessResponse<PlanComptableRefDto>> GetPlanComptableRefById(int id)
        {
            var response = new BusinessResponse<PlanComptableRefDto>();

            try
            {
                response = await new PlanComptableRefManager().GetPlanComptableRefById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPlanComptableRefsByCriteria")]
        public async Task<BusinessResponse<PlanComptableRefDto>> PostGetPlanComptableRefsByCriteria([FromBody]BusinessRequest<PlanComptableRefDto> request)
        {
            var response = new BusinessResponse<PlanComptableRefDto>();

            try
            {
                response = await new PlanComptableRefManager().GetPlanComptableRefsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePlanComptableRefs")]
        public async Task<BusinessResponse<PlanComptableRefDto>> PostSavePlanComptableRefs([FromBody]BusinessRequest<PlanComptableRefDto> request)
        {
            var response = new BusinessResponse<PlanComptableRefDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PlanComptableRefManager().SavePlanComptableRefs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePlanComptableRefs")]
        public async Task<BusinessResponse<Boolean>> PostDeletePlanComptableRefs([FromBody]BusinessRequest<PlanComptableRefDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PlanComptableRefManager().DeletePlanComptableRefs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PrestataireMedicals
        [ActionName("GetPrestataireMedicalById")]
        public async Task<BusinessResponse<PrestataireMedicalDto>> GetPrestataireMedicalById(int id)
        {
            var response = new BusinessResponse<PrestataireMedicalDto>();

            try
            {
                response = await new PrestataireMedicalManager().GetPrestataireMedicalById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPrestataireMedicalsByCriteria")]
        public async Task<BusinessResponse<PrestataireMedicalDto>> PostGetPrestataireMedicalsByCriteria([FromBody]BusinessRequest<PrestataireMedicalDto> request)
        {
            var response = new BusinessResponse<PrestataireMedicalDto>();

            try
            {
                response = await new PrestataireMedicalManager().GetPrestataireMedicalsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePrestataireMedicals")]
        public async Task<BusinessResponse<PrestataireMedicalDto>> PostSavePrestataireMedicals([FromBody]BusinessRequest<PrestataireMedicalDto> request)
        {
            var response = new BusinessResponse<PrestataireMedicalDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestataireMedicalManager().SavePrestataireMedicals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePrestataireMedicals")]
        public async Task<BusinessResponse<Boolean>> PostDeletePrestataireMedicals([FromBody]BusinessRequest<PrestataireMedicalDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestataireMedicalManager().DeletePrestataireMedicals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PrestataireMedicalPersonnelMedicals
        [ActionName("GetPrestataireMedicalPersonnelMedicalById")]
        public async Task<BusinessResponse<PrestataireMedicalPersonnelMedicalDto>> GetPrestataireMedicalPersonnelMedicalById(int id)
        {
            var response = new BusinessResponse<PrestataireMedicalPersonnelMedicalDto>();

            try
            {
                response = await new PrestataireMedicalPersonnelMedicalManager().GetPrestataireMedicalPersonnelMedicalById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPrestataireMedicalPersonnelMedicalsByCriteria")]
        public async Task<BusinessResponse<PrestataireMedicalPersonnelMedicalDto>> PostGetPrestataireMedicalPersonnelMedicalsByCriteria([FromBody]BusinessRequest<PrestataireMedicalPersonnelMedicalDto> request)
        {
            var response = new BusinessResponse<PrestataireMedicalPersonnelMedicalDto>();

            try
            {
                response = await new PrestataireMedicalPersonnelMedicalManager().GetPrestataireMedicalPersonnelMedicalsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePrestataireMedicalPersonnelMedicals")]
        public async Task<BusinessResponse<PrestataireMedicalPersonnelMedicalDto>> PostSavePrestataireMedicalPersonnelMedicals([FromBody]BusinessRequest<PrestataireMedicalPersonnelMedicalDto> request)
        {
            var response = new BusinessResponse<PrestataireMedicalPersonnelMedicalDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestataireMedicalPersonnelMedicalManager().SavePrestataireMedicalPersonnelMedicals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePrestataireMedicalPersonnelMedicals")]
        public async Task<BusinessResponse<Boolean>> PostDeletePrestataireMedicalPersonnelMedicals([FromBody]BusinessRequest<PrestataireMedicalPersonnelMedicalDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestataireMedicalPersonnelMedicalManager().DeletePrestataireMedicalPersonnelMedicals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Profils
        [ActionName("GetProfilById")]
        public async Task<BusinessResponse<ProfilDto>> GetProfilById(int id)
        {
            var response = new BusinessResponse<ProfilDto>();

            try
            {
                response = await new ProfilManager().GetProfilById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetProfilsByCriteria")]
        public async Task<BusinessResponse<ProfilDto>> PostGetProfilsByCriteria([FromBody]BusinessRequest<ProfilDto> request)
        {
            var response = new BusinessResponse<ProfilDto>();

            try
            {
                response = await new ProfilManager().GetProfilsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveProfils")]
        public async Task<BusinessResponse<ProfilDto>> PostSaveProfils([FromBody]BusinessRequest<ProfilDto> request)
        {
            var response = new BusinessResponse<ProfilDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ProfilManager().SaveProfils(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteProfils")]
        public async Task<BusinessResponse<Boolean>> PostDeleteProfils([FromBody]BusinessRequest<ProfilDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ProfilManager().DeleteProfils(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Scopes
        [ActionName("GetScopeById")]
        public async Task<BusinessResponse<ScopeDto>> GetScopeById(int id)
        {
            var response = new BusinessResponse<ScopeDto>();

            try
            {
                response = await new ScopeManager().GetScopeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetScopesByCriteria")]
        public async Task<BusinessResponse<ScopeDto>> PostGetScopesByCriteria([FromBody]BusinessRequest<ScopeDto> request)
        {
            var response = new BusinessResponse<ScopeDto>();

            try
            {
                response = await new ScopeManager().GetScopesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveScopes")]
        public async Task<BusinessResponse<ScopeDto>> PostSaveScopes([FromBody]BusinessRequest<ScopeDto> request)
        {
            var response = new BusinessResponse<ScopeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ScopeManager().SaveScopes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteScopes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteScopes([FromBody]BusinessRequest<ScopeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ScopeManager().DeleteScopes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TrancheAges
        [ActionName("GetTrancheAgeById")]
        public async Task<BusinessResponse<TrancheAgeDto>> GetTrancheAgeById(int id)
        {
            var response = new BusinessResponse<TrancheAgeDto>();

            try
            {
                response = await new TrancheAgeManager().GetTrancheAgeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTrancheAgesByCriteria")]
        public async Task<BusinessResponse<TrancheAgeDto>> PostGetTrancheAgesByCriteria([FromBody]BusinessRequest<TrancheAgeDto> request)
        {
            var response = new BusinessResponse<TrancheAgeDto>();

            try
            {
                response = await new TrancheAgeManager().GetTrancheAgesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTrancheAges")]
        public async Task<BusinessResponse<TrancheAgeDto>> PostSaveTrancheAges([FromBody]BusinessRequest<TrancheAgeDto> request)
        {
            var response = new BusinessResponse<TrancheAgeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TrancheAgeManager().SaveTrancheAges(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTrancheAges")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTrancheAges([FromBody]BusinessRequest<TrancheAgeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TrancheAgeManager().DeleteTrancheAges(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypeAffections
        [ActionName("GetTypeAffectionById")]
        public async Task<BusinessResponse<TypeAffectionDto>> GetTypeAffectionById(int id)
        {
            var response = new BusinessResponse<TypeAffectionDto>();

            try
            {
                response = await new TypeAffectionManager().GetTypeAffectionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypeAffectionsByCriteria")]
        public async Task<BusinessResponse<TypeAffectionDto>> PostGetTypeAffectionsByCriteria([FromBody]BusinessRequest<TypeAffectionDto> request)
        {
            var response = new BusinessResponse<TypeAffectionDto>();

            try
            {
                response = await new TypeAffectionManager().GetTypeAffectionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypeAffections")]
        public async Task<BusinessResponse<TypeAffectionDto>> PostSaveTypeAffections([FromBody]BusinessRequest<TypeAffectionDto> request)
        {
            var response = new BusinessResponse<TypeAffectionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeAffectionManager().SaveTypeAffections(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypeAffections")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypeAffections([FromBody]BusinessRequest<TypeAffectionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeAffectionManager().DeleteTypeAffections(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypePlanComptable1s
        [ActionName("GetTypePlanComptable1ById")]
        public async Task<BusinessResponse<TypePlanComptable1Dto>> GetTypePlanComptable1ById(int id)
        {
            var response = new BusinessResponse<TypePlanComptable1Dto>();

            try
            {
                response = await new TypePlanComptable1Manager().GetTypePlanComptable1ById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypePlanComptable1sByCriteria")]
        public async Task<BusinessResponse<TypePlanComptable1Dto>> PostGetTypePlanComptable1sByCriteria([FromBody]BusinessRequest<TypePlanComptable1Dto> request)
        {
            var response = new BusinessResponse<TypePlanComptable1Dto>();

            try
            {
                response = await new TypePlanComptable1Manager().GetTypePlanComptable1sByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypePlanComptable1s")]
        public async Task<BusinessResponse<TypePlanComptable1Dto>> PostSaveTypePlanComptable1s([FromBody]BusinessRequest<TypePlanComptable1Dto> request)
        {
            var response = new BusinessResponse<TypePlanComptable1Dto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypePlanComptable1Manager().SaveTypePlanComptable1s(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypePlanComptable1s")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypePlanComptable1s([FromBody]BusinessRequest<TypePlanComptable1Dto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypePlanComptable1Manager().DeleteTypePlanComptable1s(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypePrestataires
        [ActionName("GetTypePrestataireById")]
        public async Task<BusinessResponse<TypePrestataireDto>> GetTypePrestataireById(int id)
        {
            var response = new BusinessResponse<TypePrestataireDto>();

            try
            {
                response = await new TypePrestataireManager().GetTypePrestataireById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypePrestatairesByCriteria")]
        public async Task<BusinessResponse<TypePrestataireDto>> PostGetTypePrestatairesByCriteria([FromBody]BusinessRequest<TypePrestataireDto> request)
        {
            var response = new BusinessResponse<TypePrestataireDto>();

            try
            {
                response = await new TypePrestataireManager().GetTypePrestatairesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypePrestataires")]
        public async Task<BusinessResponse<TypePrestataireDto>> PostSaveTypePrestataires([FromBody]BusinessRequest<TypePrestataireDto> request)
        {
            var response = new BusinessResponse<TypePrestataireDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypePrestataireManager().SaveTypePrestataires(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypePrestataires")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypePrestataires([FromBody]BusinessRequest<TypePrestataireDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypePrestataireManager().DeleteTypePrestataires(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypeUtilisateurs
        [ActionName("GetTypeUtilisateurById")]
        public async Task<BusinessResponse<TypeUtilisateurDto>> GetTypeUtilisateurById(int id)
        {
            var response = new BusinessResponse<TypeUtilisateurDto>();

            try
            {
                response = await new TypeUtilisateurManager().GetTypeUtilisateurById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypeUtilisateursByCriteria")]
        public async Task<BusinessResponse<TypeUtilisateurDto>> PostGetTypeUtilisateursByCriteria([FromBody]BusinessRequest<TypeUtilisateurDto> request)
        {
            var response = new BusinessResponse<TypeUtilisateurDto>();

            try
            {
                response = await new TypeUtilisateurManager().GetTypeUtilisateursByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypeUtilisateurs")]
        public async Task<BusinessResponse<TypeUtilisateurDto>> PostSaveTypeUtilisateurs([FromBody]BusinessRequest<TypeUtilisateurDto> request)
        {
            var response = new BusinessResponse<TypeUtilisateurDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeUtilisateurManager().SaveTypeUtilisateurs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypeUtilisateurs")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypeUtilisateurs([FromBody]BusinessRequest<TypeUtilisateurDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeUtilisateurManager().DeleteTypeUtilisateurs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Utilisateurs
        [ActionName("GetUtilisateurById")]
        public async Task<BusinessResponse<UtilisateurDto>> GetUtilisateurById(int id)
        {
            var response = new BusinessResponse<UtilisateurDto>();

            try
            {
                response = await new UtilisateurManager().GetUtilisateurById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetUtilisateursByCriteria")]
        public async Task<BusinessResponse<UtilisateurDto>> PostGetUtilisateursByCriteria([FromBody]BusinessRequest<UtilisateurDto> request)
        {
            var response = new BusinessResponse<UtilisateurDto>();

            try
            {
                response = await new UtilisateurManager().GetUtilisateursByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveUtilisateurs")]
        public async Task<BusinessResponse<UtilisateurDto>> PostSaveUtilisateurs([FromBody]BusinessRequest<UtilisateurDto> request)
        {
            var response = new BusinessResponse<UtilisateurDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new UtilisateurManager().SaveUtilisateurs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteUtilisateurs")]
        public async Task<BusinessResponse<Boolean>> PostDeleteUtilisateurs([FromBody]BusinessRequest<UtilisateurDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new UtilisateurManager().DeleteUtilisateurs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Villes
        [ActionName("GetVilleById")]
        public async Task<BusinessResponse<VilleDto>> GetVilleById(int id)
        {
            var response = new BusinessResponse<VilleDto>();

            try
            {
                response = await new VilleManager().GetVilleById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetVillesByCriteria")]
        public async Task<BusinessResponse<VilleDto>> PostGetVillesByCriteria([FromBody]BusinessRequest<VilleDto> request)
        {
            var response = new BusinessResponse<VilleDto>();

            try
            {
                response = await new VilleManager().GetVillesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveVilles")]
        public async Task<BusinessResponse<VilleDto>> PostSaveVilles([FromBody]BusinessRequest<VilleDto> request)
        {
            var response = new BusinessResponse<VilleDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new VilleManager().SaveVilles(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteVilles")]
        public async Task<BusinessResponse<Boolean>> PostDeleteVilles([FromBody]BusinessRequest<VilleDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new VilleManager().DeleteVilles(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ViewAbpUserPermissions
        [ActionName("GetViewAbpUserPermissionsByCriteria")]
        public async Task<BusinessResponse<ViewAbpUserPermissionsDto>> PostGetViewAbpUserPermissionsByCriteria([FromBody]BusinessRequest<ViewAbpUserPermissionsDto> request)
        {
            var response = new BusinessResponse<ViewAbpUserPermissionsDto>();

            try
            {
                response = await new ViewAbpUserPermissionsManager().GetViewAbpUserPermissionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewAbpUserPermissions")]
        public async Task<BusinessResponse<ViewAbpUserPermissionsDto>> PostSaveViewAbpUserPermissions([FromBody]BusinessRequest<ViewAbpUserPermissionsDto> request)
        {
            var response = new BusinessResponse<ViewAbpUserPermissionsDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewAbpUserPermissionsManager().SaveViewAbpUserPermissions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewActeMedicalFamilleActes
        [ActionName("GetViewActeMedicalFamilleActesByCriteria")]
        public async Task<BusinessResponse<ViewActeMedicalFamilleActeDto>> PostGetViewActeMedicalFamilleActesByCriteria([FromBody]BusinessRequest<ViewActeMedicalFamilleActeDto> request)
        {
            var response = new BusinessResponse<ViewActeMedicalFamilleActeDto>();

            try
            {
                response = await new ViewActeMedicalFamilleActeManager().GetViewActeMedicalFamilleActesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewActeMedicalFamilleActes")]
        public async Task<BusinessResponse<ViewActeMedicalFamilleActeDto>> PostSaveViewActeMedicalFamilleActes([FromBody]BusinessRequest<ViewActeMedicalFamilleActeDto> request)
        {
            var response = new BusinessResponse<ViewActeMedicalFamilleActeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewActeMedicalFamilleActeManager().SaveViewActeMedicalFamilleActes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewPersonnes
        [ActionName("GetViewPersonnesByCriteria")]
        public async Task<BusinessResponse<ViewPersonneDto>> PostGetViewPersonnesByCriteria([FromBody]BusinessRequest<ViewPersonneDto> request)
        {
            var response = new BusinessResponse<ViewPersonneDto>();

            try
            {
                response = await new ViewPersonneManager().GetViewPersonnesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewPersonnes")]
        public async Task<BusinessResponse<ViewPersonneDto>> PostSaveViewPersonnes([FromBody]BusinessRequest<ViewPersonneDto> request)
        {
            var response = new BusinessResponse<ViewPersonneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewPersonneManager().SaveViewPersonnes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewPersonnePhysiques
        [ActionName("GetViewPersonnePhysiquesByCriteria")]
        public async Task<BusinessResponse<ViewPersonnePhysiqueDto>> PostGetViewPersonnePhysiquesByCriteria([FromBody]BusinessRequest<ViewPersonnePhysiqueDto> request)
        {
            var response = new BusinessResponse<ViewPersonnePhysiqueDto>();

            try
            {
                response = await new ViewPersonnePhysiqueManager().GetViewPersonnePhysiquesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewPersonnePhysiques")]
        public async Task<BusinessResponse<ViewPersonnePhysiqueDto>> PostSaveViewPersonnePhysiques([FromBody]BusinessRequest<ViewPersonnePhysiqueDto> request)
        {
            var response = new BusinessResponse<ViewPersonnePhysiqueDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewPersonnePhysiqueManager().SaveViewPersonnePhysiques(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ActeMedicals
        [ActionName("GetActeMedicalById")]
        public async Task<BusinessResponse<ActeMedicalDto>> GetActeMedicalById(int id)
        {
            var response = new BusinessResponse<ActeMedicalDto>();

            try
            {
                response = await new ActeMedicalManager().GetActeMedicalById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetActeMedicalsByCriteria")]
        public async Task<BusinessResponse<ActeMedicalDto>> PostGetActeMedicalsByCriteria([FromBody]BusinessRequest<ActeMedicalDto> request)
        {
            var response = new BusinessResponse<ActeMedicalDto>();

            try
            {
                response = await new ActeMedicalManager().GetActeMedicalsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveActeMedicals")]
        public async Task<BusinessResponse<ActeMedicalDto>> PostSaveActeMedicals([FromBody]BusinessRequest<ActeMedicalDto> request)
        {
            var response = new BusinessResponse<ActeMedicalDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ActeMedicalManager().SaveActeMedicals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteActeMedicals")]
        public async Task<BusinessResponse<Boolean>> PostDeleteActeMedicals([FromBody]BusinessRequest<ActeMedicalDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ActeMedicalManager().DeleteActeMedicals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ActeTrancheAges
        [ActionName("GetActeTrancheAgeById")]
        public async Task<BusinessResponse<ActeTrancheAgeDto>> GetActeTrancheAgeById(int id)
        {
            var response = new BusinessResponse<ActeTrancheAgeDto>();

            try
            {
                response = await new ActeTrancheAgeManager().GetActeTrancheAgeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetActeTrancheAgesByCriteria")]
        public async Task<BusinessResponse<ActeTrancheAgeDto>> PostGetActeTrancheAgesByCriteria([FromBody]BusinessRequest<ActeTrancheAgeDto> request)
        {
            var response = new BusinessResponse<ActeTrancheAgeDto>();

            try
            {
                response = await new ActeTrancheAgeManager().GetActeTrancheAgesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveActeTrancheAges")]
        public async Task<BusinessResponse<ActeTrancheAgeDto>> PostSaveActeTrancheAges([FromBody]BusinessRequest<ActeTrancheAgeDto> request)
        {
            var response = new BusinessResponse<ActeTrancheAgeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ActeTrancheAgeManager().SaveActeTrancheAges(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteActeTrancheAges")]
        public async Task<BusinessResponse<Boolean>> PostDeleteActeTrancheAges([FromBody]BusinessRequest<ActeTrancheAgeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ActeTrancheAgeManager().DeleteActeTrancheAges(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Adherents
        [ActionName("GetAdherentById")]
        public async Task<BusinessResponse<AdherentDto>> GetAdherentById(int id)
        {
            var response = new BusinessResponse<AdherentDto>();

            try
            {
                response = await new AdherentManager().GetAdherentById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAdherentsByCriteria")]
        public async Task<BusinessResponse<AdherentDto>> PostGetAdherentsByCriteria([FromBody]BusinessRequest<AdherentDto> request)
        {
            var response = new BusinessResponse<AdherentDto>();

            try
            {
                response = await new AdherentManager().GetAdherentsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAdherents")]
        public async Task<BusinessResponse<AdherentDto>> PostSaveAdherents([FromBody]BusinessRequest<AdherentDto> request)
        {
            var response = new BusinessResponse<AdherentDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AdherentManager().SaveAdherents(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAdherents")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAdherents([FromBody]BusinessRequest<AdherentDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AdherentManager().DeleteAdherents(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AdherentHists
        [ActionName("GetAdherentHistById")]
        public async Task<BusinessResponse<AdherentHistDto>> GetAdherentHistById(int id)
        {
            var response = new BusinessResponse<AdherentHistDto>();

            try
            {
                response = await new AdherentHistManager().GetAdherentHistById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAdherentHistsByCriteria")]
        public async Task<BusinessResponse<AdherentHistDto>> PostGetAdherentHistsByCriteria([FromBody]BusinessRequest<AdherentHistDto> request)
        {
            var response = new BusinessResponse<AdherentHistDto>();

            try
            {
                response = await new AdherentHistManager().GetAdherentHistsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAdherentHists")]
        public async Task<BusinessResponse<AdherentHistDto>> PostSaveAdherentHists([FromBody]BusinessRequest<AdherentHistDto> request)
        {
            var response = new BusinessResponse<AdherentHistDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AdherentHistManager().SaveAdherentHists(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAdherentHists")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAdherentHists([FromBody]BusinessRequest<AdherentHistDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AdherentHistManager().DeleteAdherentHists(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AdherentReseauSoins
        [ActionName("GetAdherentReseauSoinById")]
        public async Task<BusinessResponse<AdherentReseauSoinDto>> GetAdherentReseauSoinById(int id)
        {
            var response = new BusinessResponse<AdherentReseauSoinDto>();

            try
            {
                response = await new AdherentReseauSoinManager().GetAdherentReseauSoinById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAdherentReseauSoinsByCriteria")]
        public async Task<BusinessResponse<AdherentReseauSoinDto>> PostGetAdherentReseauSoinsByCriteria([FromBody]BusinessRequest<AdherentReseauSoinDto> request)
        {
            var response = new BusinessResponse<AdherentReseauSoinDto>();

            try
            {
                response = await new AdherentReseauSoinManager().GetAdherentReseauSoinsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAdherentReseauSoins")]
        public async Task<BusinessResponse<AdherentReseauSoinDto>> PostSaveAdherentReseauSoins([FromBody]BusinessRequest<AdherentReseauSoinDto> request)
        {
            var response = new BusinessResponse<AdherentReseauSoinDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AdherentReseauSoinManager().SaveAdherentReseauSoins(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAdherentReseauSoins")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAdherentReseauSoins([FromBody]BusinessRequest<AdherentReseauSoinDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AdherentReseauSoinManager().DeleteAdherentReseauSoins(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Affection1s
        [ActionName("GetAffection1ById")]
        public async Task<BusinessResponse<Affection1Dto>> GetAffection1ById(int id)
        {
            var response = new BusinessResponse<Affection1Dto>();

            try
            {
                response = await new Affection1Manager().GetAffection1ById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAffection1sByCriteria")]
        public async Task<BusinessResponse<Affection1Dto>> PostGetAffection1sByCriteria([FromBody]BusinessRequest<Affection1Dto> request)
        {
            var response = new BusinessResponse<Affection1Dto>();

            try
            {
                response = await new Affection1Manager().GetAffection1sByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAffection1s")]
        public async Task<BusinessResponse<Affection1Dto>> PostSaveAffection1s([FromBody]BusinessRequest<Affection1Dto> request)
        {
            var response = new BusinessResponse<Affection1Dto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new Affection1Manager().SaveAffection1s(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAffection1s")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAffection1s([FromBody]BusinessRequest<Affection1Dto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new Affection1Manager().DeleteAffection1s(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AffectionExcluProduits
        [ActionName("GetAffectionExcluProduitById")]
        public async Task<BusinessResponse<AffectionExcluProduitDto>> GetAffectionExcluProduitById(int id)
        {
            var response = new BusinessResponse<AffectionExcluProduitDto>();

            try
            {
                response = await new AffectionExcluProduitManager().GetAffectionExcluProduitById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAffectionExcluProduitsByCriteria")]
        public async Task<BusinessResponse<AffectionExcluProduitDto>> PostGetAffectionExcluProduitsByCriteria([FromBody]BusinessRequest<AffectionExcluProduitDto> request)
        {
            var response = new BusinessResponse<AffectionExcluProduitDto>();

            try
            {
                response = await new AffectionExcluProduitManager().GetAffectionExcluProduitsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAffectionExcluProduits")]
        public async Task<BusinessResponse<AffectionExcluProduitDto>> PostSaveAffectionExcluProduits([FromBody]BusinessRequest<AffectionExcluProduitDto> request)
        {
            var response = new BusinessResponse<AffectionExcluProduitDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AffectionExcluProduitManager().SaveAffectionExcluProduits(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAffectionExcluProduits")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAffectionExcluProduits([FromBody]BusinessRequest<AffectionExcluProduitDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AffectionExcluProduitManager().DeleteAffectionExcluProduits(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Affilies
        [ActionName("GetAffilieById")]
        public async Task<BusinessResponse<AffilieDto>> GetAffilieById(int id)
        {
            var response = new BusinessResponse<AffilieDto>();

            try
            {
                response = await new AffilieManager().GetAffilieById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAffiliesByCriteria")]
        public async Task<BusinessResponse<AffilieDto>> PostGetAffiliesByCriteria([FromBody]BusinessRequest<AffilieDto> request)
        {
            var response = new BusinessResponse<AffilieDto>();

            try
            {
                response = await new AffilieManager().GetAffiliesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAffilies")]
        public async Task<BusinessResponse<AffilieDto>> PostSaveAffilies([FromBody]BusinessRequest<AffilieDto> request)
        {
            var response = new BusinessResponse<AffilieDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AffilieManager().SaveAffilies(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAffilies")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAffilies([FromBody]BusinessRequest<AffilieDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AffilieManager().DeleteAffilies(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AffilieHists
        [ActionName("GetAffilieHistById")]
        public async Task<BusinessResponse<AffilieHistDto>> GetAffilieHistById(int id)
        {
            var response = new BusinessResponse<AffilieHistDto>();

            try
            {
                response = await new AffilieHistManager().GetAffilieHistById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAffilieHistsByCriteria")]
        public async Task<BusinessResponse<AffilieHistDto>> PostGetAffilieHistsByCriteria([FromBody]BusinessRequest<AffilieHistDto> request)
        {
            var response = new BusinessResponse<AffilieHistDto>();

            try
            {
                response = await new AffilieHistManager().GetAffilieHistsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAffilieHists")]
        public async Task<BusinessResponse<AffilieHistDto>> PostSaveAffilieHists([FromBody]BusinessRequest<AffilieHistDto> request)
        {
            var response = new BusinessResponse<AffilieHistDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AffilieHistManager().SaveAffilieHists(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAffilieHists")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAffilieHists([FromBody]BusinessRequest<AffilieHistDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AffilieHistManager().DeleteAffilieHists(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AvenantAjoutTermeConvents
        [ActionName("GetAvenantAjoutTermeConventById")]
        public async Task<BusinessResponse<AvenantAjoutTermeConventDto>> GetAvenantAjoutTermeConventById(int id)
        {
            var response = new BusinessResponse<AvenantAjoutTermeConventDto>();

            try
            {
                response = await new AvenantAjoutTermeConventManager().GetAvenantAjoutTermeConventById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAvenantAjoutTermeConventsByCriteria")]
        public async Task<BusinessResponse<AvenantAjoutTermeConventDto>> PostGetAvenantAjoutTermeConventsByCriteria([FromBody]BusinessRequest<AvenantAjoutTermeConventDto> request)
        {
            var response = new BusinessResponse<AvenantAjoutTermeConventDto>();

            try
            {
                response = await new AvenantAjoutTermeConventManager().GetAvenantAjoutTermeConventsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAvenantAjoutTermeConvents")]
        public async Task<BusinessResponse<AvenantAjoutTermeConventDto>> PostSaveAvenantAjoutTermeConvents([FromBody]BusinessRequest<AvenantAjoutTermeConventDto> request)
        {
            var response = new BusinessResponse<AvenantAjoutTermeConventDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantAjoutTermeConventManager().SaveAvenantAjoutTermeConvents(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAvenantAjoutTermeConvents")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAvenantAjoutTermeConvents([FromBody]BusinessRequest<AvenantAjoutTermeConventDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantAjoutTermeConventManager().DeleteAvenantAjoutTermeConvents(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AvenantIncorporations
        [ActionName("GetAvenantIncorporationById")]
        public async Task<BusinessResponse<AvenantIncorporationDto>> GetAvenantIncorporationById(int id)
        {
            var response = new BusinessResponse<AvenantIncorporationDto>();

            try
            {
                response = await new AvenantIncorporationManager().GetAvenantIncorporationById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAvenantIncorporationsByCriteria")]
        public async Task<BusinessResponse<AvenantIncorporationDto>> PostGetAvenantIncorporationsByCriteria([FromBody]BusinessRequest<AvenantIncorporationDto> request)
        {
            var response = new BusinessResponse<AvenantIncorporationDto>();

            try
            {
                response = await new AvenantIncorporationManager().GetAvenantIncorporationsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAvenantIncorporations")]
        public async Task<BusinessResponse<AvenantIncorporationDto>> PostSaveAvenantIncorporations([FromBody]BusinessRequest<AvenantIncorporationDto> request)
        {
            var response = new BusinessResponse<AvenantIncorporationDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantIncorporationManager().SaveAvenantIncorporations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAvenantIncorporations")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAvenantIncorporations([FromBody]BusinessRequest<AvenantIncorporationDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantIncorporationManager().DeleteAvenantIncorporations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AvenantIntegrationConventions
        [ActionName("GetAvenantIntegrationConventionById")]
        public async Task<BusinessResponse<AvenantIntegrationConventionDto>> GetAvenantIntegrationConventionById(int id)
        {
            var response = new BusinessResponse<AvenantIntegrationConventionDto>();

            try
            {
                response = await new AvenantIntegrationConventionManager().GetAvenantIntegrationConventionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAvenantIntegrationConventionsByCriteria")]
        public async Task<BusinessResponse<AvenantIntegrationConventionDto>> PostGetAvenantIntegrationConventionsByCriteria([FromBody]BusinessRequest<AvenantIntegrationConventionDto> request)
        {
            var response = new BusinessResponse<AvenantIntegrationConventionDto>();

            try
            {
                response = await new AvenantIntegrationConventionManager().GetAvenantIntegrationConventionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAvenantIntegrationConventions")]
        public async Task<BusinessResponse<AvenantIntegrationConventionDto>> PostSaveAvenantIntegrationConventions([FromBody]BusinessRequest<AvenantIntegrationConventionDto> request)
        {
            var response = new BusinessResponse<AvenantIntegrationConventionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantIntegrationConventionManager().SaveAvenantIntegrationConventions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAvenantIntegrationConventions")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAvenantIntegrationConventions([FromBody]BusinessRequest<AvenantIntegrationConventionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantIntegrationConventionManager().DeleteAvenantIntegrationConventions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AvenantProrogations
        [ActionName("GetAvenantProrogationById")]
        public async Task<BusinessResponse<AvenantProrogationDto>> GetAvenantProrogationById(int id)
        {
            var response = new BusinessResponse<AvenantProrogationDto>();

            try
            {
                response = await new AvenantProrogationManager().GetAvenantProrogationById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAvenantProrogationsByCriteria")]
        public async Task<BusinessResponse<AvenantProrogationDto>> PostGetAvenantProrogationsByCriteria([FromBody]BusinessRequest<AvenantProrogationDto> request)
        {
            var response = new BusinessResponse<AvenantProrogationDto>();

            try
            {
                response = await new AvenantProrogationManager().GetAvenantProrogationsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAvenantProrogations")]
        public async Task<BusinessResponse<AvenantProrogationDto>> PostSaveAvenantProrogations([FromBody]BusinessRequest<AvenantProrogationDto> request)
        {
            var response = new BusinessResponse<AvenantProrogationDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantProrogationManager().SaveAvenantProrogations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAvenantProrogations")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAvenantProrogations([FromBody]BusinessRequest<AvenantProrogationDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantProrogationManager().DeleteAvenantProrogations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AvenantReintegrations
        [ActionName("GetAvenantReintegrationById")]
        public async Task<BusinessResponse<AvenantReintegrationDto>> GetAvenantReintegrationById(int id)
        {
            var response = new BusinessResponse<AvenantReintegrationDto>();

            try
            {
                response = await new AvenantReintegrationManager().GetAvenantReintegrationById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAvenantReintegrationsByCriteria")]
        public async Task<BusinessResponse<AvenantReintegrationDto>> PostGetAvenantReintegrationsByCriteria([FromBody]BusinessRequest<AvenantReintegrationDto> request)
        {
            var response = new BusinessResponse<AvenantReintegrationDto>();

            try
            {
                response = await new AvenantReintegrationManager().GetAvenantReintegrationsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAvenantReintegrations")]
        public async Task<BusinessResponse<AvenantReintegrationDto>> PostSaveAvenantReintegrations([FromBody]BusinessRequest<AvenantReintegrationDto> request)
        {
            var response = new BusinessResponse<AvenantReintegrationDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantReintegrationManager().SaveAvenantReintegrations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAvenantReintegrations")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAvenantReintegrations([FromBody]BusinessRequest<AvenantReintegrationDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantReintegrationManager().DeleteAvenantReintegrations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AvenantRetraits
        [ActionName("GetAvenantRetraitById")]
        public async Task<BusinessResponse<AvenantRetraitDto>> GetAvenantRetraitById(int id)
        {
            var response = new BusinessResponse<AvenantRetraitDto>();

            try
            {
                response = await new AvenantRetraitManager().GetAvenantRetraitById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAvenantRetraitsByCriteria")]
        public async Task<BusinessResponse<AvenantRetraitDto>> PostGetAvenantRetraitsByCriteria([FromBody]BusinessRequest<AvenantRetraitDto> request)
        {
            var response = new BusinessResponse<AvenantRetraitDto>();

            try
            {
                response = await new AvenantRetraitManager().GetAvenantRetraitsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAvenantRetraits")]
        public async Task<BusinessResponse<AvenantRetraitDto>> PostSaveAvenantRetraits([FromBody]BusinessRequest<AvenantRetraitDto> request)
        {
            var response = new BusinessResponse<AvenantRetraitDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantRetraitManager().SaveAvenantRetraits(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAvenantRetraits")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAvenantRetraits([FromBody]BusinessRequest<AvenantRetraitDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantRetraitManager().DeleteAvenantRetraits(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AvenantRetraitConventions
        [ActionName("GetAvenantRetraitConventionById")]
        public async Task<BusinessResponse<AvenantRetraitConventionDto>> GetAvenantRetraitConventionById(int id)
        {
            var response = new BusinessResponse<AvenantRetraitConventionDto>();

            try
            {
                response = await new AvenantRetraitConventionManager().GetAvenantRetraitConventionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAvenantRetraitConventionsByCriteria")]
        public async Task<BusinessResponse<AvenantRetraitConventionDto>> PostGetAvenantRetraitConventionsByCriteria([FromBody]BusinessRequest<AvenantRetraitConventionDto> request)
        {
            var response = new BusinessResponse<AvenantRetraitConventionDto>();

            try
            {
                response = await new AvenantRetraitConventionManager().GetAvenantRetraitConventionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAvenantRetraitConventions")]
        public async Task<BusinessResponse<AvenantRetraitConventionDto>> PostSaveAvenantRetraitConventions([FromBody]BusinessRequest<AvenantRetraitConventionDto> request)
        {
            var response = new BusinessResponse<AvenantRetraitConventionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantRetraitConventionManager().SaveAvenantRetraitConventions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAvenantRetraitConventions")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAvenantRetraitConventions([FromBody]BusinessRequest<AvenantRetraitConventionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantRetraitConventionManager().DeleteAvenantRetraitConventions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AvenantRetraitTermeConvents
        [ActionName("GetAvenantRetraitTermeConventById")]
        public async Task<BusinessResponse<AvenantRetraitTermeConventDto>> GetAvenantRetraitTermeConventById(int id)
        {
            var response = new BusinessResponse<AvenantRetraitTermeConventDto>();

            try
            {
                response = await new AvenantRetraitTermeConventManager().GetAvenantRetraitTermeConventById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAvenantRetraitTermeConventsByCriteria")]
        public async Task<BusinessResponse<AvenantRetraitTermeConventDto>> PostGetAvenantRetraitTermeConventsByCriteria([FromBody]BusinessRequest<AvenantRetraitTermeConventDto> request)
        {
            var response = new BusinessResponse<AvenantRetraitTermeConventDto>();

            try
            {
                response = await new AvenantRetraitTermeConventManager().GetAvenantRetraitTermeConventsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAvenantRetraitTermeConvents")]
        public async Task<BusinessResponse<AvenantRetraitTermeConventDto>> PostSaveAvenantRetraitTermeConvents([FromBody]BusinessRequest<AvenantRetraitTermeConventDto> request)
        {
            var response = new BusinessResponse<AvenantRetraitTermeConventDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantRetraitTermeConventManager().SaveAvenantRetraitTermeConvents(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAvenantRetraitTermeConvents")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAvenantRetraitTermeConvents([FromBody]BusinessRequest<AvenantRetraitTermeConventDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantRetraitTermeConventManager().DeleteAvenantRetraitTermeConvents(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AvenantSuspensions
        [ActionName("GetAvenantSuspensionById")]
        public async Task<BusinessResponse<AvenantSuspensionDto>> GetAvenantSuspensionById(int id)
        {
            var response = new BusinessResponse<AvenantSuspensionDto>();

            try
            {
                response = await new AvenantSuspensionManager().GetAvenantSuspensionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAvenantSuspensionsByCriteria")]
        public async Task<BusinessResponse<AvenantSuspensionDto>> PostGetAvenantSuspensionsByCriteria([FromBody]BusinessRequest<AvenantSuspensionDto> request)
        {
            var response = new BusinessResponse<AvenantSuspensionDto>();

            try
            {
                response = await new AvenantSuspensionManager().GetAvenantSuspensionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAvenantSuspensions")]
        public async Task<BusinessResponse<AvenantSuspensionDto>> PostSaveAvenantSuspensions([FromBody]BusinessRequest<AvenantSuspensionDto> request)
        {
            var response = new BusinessResponse<AvenantSuspensionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantSuspensionManager().SaveAvenantSuspensions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAvenantSuspensions")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAvenantSuspensions([FromBody]BusinessRequest<AvenantSuspensionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantSuspensionManager().DeleteAvenantSuspensions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AvenantSuspensionConventions
        [ActionName("GetAvenantSuspensionConventionById")]
        public async Task<BusinessResponse<AvenantSuspensionConventionDto>> GetAvenantSuspensionConventionById(int id)
        {
            var response = new BusinessResponse<AvenantSuspensionConventionDto>();

            try
            {
                response = await new AvenantSuspensionConventionManager().GetAvenantSuspensionConventionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAvenantSuspensionConventionsByCriteria")]
        public async Task<BusinessResponse<AvenantSuspensionConventionDto>> PostGetAvenantSuspensionConventionsByCriteria([FromBody]BusinessRequest<AvenantSuspensionConventionDto> request)
        {
            var response = new BusinessResponse<AvenantSuspensionConventionDto>();

            try
            {
                response = await new AvenantSuspensionConventionManager().GetAvenantSuspensionConventionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAvenantSuspensionConventions")]
        public async Task<BusinessResponse<AvenantSuspensionConventionDto>> PostSaveAvenantSuspensionConventions([FromBody]BusinessRequest<AvenantSuspensionConventionDto> request)
        {
            var response = new BusinessResponse<AvenantSuspensionConventionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantSuspensionConventionManager().SaveAvenantSuspensionConventions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAvenantSuspensionConventions")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAvenantSuspensionConventions([FromBody]BusinessRequest<AvenantSuspensionConventionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvenantSuspensionConventionManager().DeleteAvenantSuspensionConventions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region AvoirSpecialites
        [ActionName("GetAvoirSpecialiteById")]
        public async Task<BusinessResponse<AvoirSpecialiteDto>> GetAvoirSpecialiteById(int id)
        {
            var response = new BusinessResponse<AvoirSpecialiteDto>();

            try
            {
                response = await new AvoirSpecialiteManager().GetAvoirSpecialiteById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetAvoirSpecialitesByCriteria")]
        public async Task<BusinessResponse<AvoirSpecialiteDto>> PostGetAvoirSpecialitesByCriteria([FromBody]BusinessRequest<AvoirSpecialiteDto> request)
        {
            var response = new BusinessResponse<AvoirSpecialiteDto>();

            try
            {
                response = await new AvoirSpecialiteManager().GetAvoirSpecialitesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveAvoirSpecialites")]
        public async Task<BusinessResponse<AvoirSpecialiteDto>> PostSaveAvoirSpecialites([FromBody]BusinessRequest<AvoirSpecialiteDto> request)
        {
            var response = new BusinessResponse<AvoirSpecialiteDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvoirSpecialiteManager().SaveAvoirSpecialites(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteAvoirSpecialites")]
        public async Task<BusinessResponse<Boolean>> PostDeleteAvoirSpecialites([FromBody]BusinessRequest<AvoirSpecialiteDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new AvoirSpecialiteManager().DeleteAvoirSpecialites(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region BonPriseEnCharges
        [ActionName("GetBonPriseEnChargeById")]
        public async Task<BusinessResponse<BonPriseEnChargeDto>> GetBonPriseEnChargeById(int id)
        {
            var response = new BusinessResponse<BonPriseEnChargeDto>();

            try
            {
                response = await new BonPriseEnChargeManager().GetBonPriseEnChargeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetBonPriseEnChargesByCriteria")]
        public async Task<BusinessResponse<BonPriseEnChargeDto>> PostGetBonPriseEnChargesByCriteria([FromBody]BusinessRequest<BonPriseEnChargeDto> request)
        {
            var response = new BusinessResponse<BonPriseEnChargeDto>();

            try
            {
                response = await new BonPriseEnChargeManager().GetBonPriseEnChargesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveBonPriseEnCharges")]
        public async Task<BusinessResponse<BonPriseEnChargeDto>> PostSaveBonPriseEnCharges([FromBody]BusinessRequest<BonPriseEnChargeDto> request)
        {
            var response = new BusinessResponse<BonPriseEnChargeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new BonPriseEnChargeManager().SaveBonPriseEnCharges(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteBonPriseEnCharges")]
        public async Task<BusinessResponse<Boolean>> PostDeleteBonPriseEnCharges([FromBody]BusinessRequest<BonPriseEnChargeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new BonPriseEnChargeManager().DeleteBonPriseEnCharges(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Cartes
        [ActionName("GetCarteById")]
        public async Task<BusinessResponse<CarteDto>> GetCarteById(int id)
        {
            var response = new BusinessResponse<CarteDto>();

            try
            {
                response = await new CarteManager().GetCarteById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetCartesByCriteria")]
        public async Task<BusinessResponse<CarteDto>> PostGetCartesByCriteria([FromBody]BusinessRequest<CarteDto> request)
        {
            var response = new BusinessResponse<CarteDto>();

            try
            {
                response = await new CarteManager().GetCartesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveCartes")]
        public async Task<BusinessResponse<CarteDto>> PostSaveCartes([FromBody]BusinessRequest<CarteDto> request)
        {
            var response = new BusinessResponse<CarteDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CarteManager().SaveCartes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteCartes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteCartes([FromBody]BusinessRequest<CarteDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CarteManager().DeleteCartes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region CentreConventionnes
        [ActionName("GetCentreConventionneById")]
        public async Task<BusinessResponse<CentreConventionneDto>> GetCentreConventionneById(int id)
        {
            var response = new BusinessResponse<CentreConventionneDto>();

            try
            {
                response = await new CentreConventionneManager().GetCentreConventionneById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetCentreConventionnesByCriteria")]
        public async Task<BusinessResponse<CentreConventionneDto>> PostGetCentreConventionnesByCriteria([FromBody]BusinessRequest<CentreConventionneDto> request)
        {
            var response = new BusinessResponse<CentreConventionneDto>();

            try
            {
                response = await new CentreConventionneManager().GetCentreConventionnesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveCentreConventionnes")]
        public async Task<BusinessResponse<CentreConventionneDto>> PostSaveCentreConventionnes([FromBody]BusinessRequest<CentreConventionneDto> request)
        {
            var response = new BusinessResponse<CentreConventionneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CentreConventionneManager().SaveCentreConventionnes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteCentreConventionnes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteCentreConventionnes([FromBody]BusinessRequest<CentreConventionneDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CentreConventionneManager().DeleteCentreConventionnes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region CodeMedicauxs
        [ActionName("GetCodeMedicauxById")]
        public async Task<BusinessResponse<CodeMedicauxDto>> GetCodeMedicauxById(int id)
        {
            var response = new BusinessResponse<CodeMedicauxDto>();

            try
            {
                response = await new CodeMedicauxManager().GetCodeMedicauxById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetCodeMedicauxsByCriteria")]
        public async Task<BusinessResponse<CodeMedicauxDto>> PostGetCodeMedicauxsByCriteria([FromBody]BusinessRequest<CodeMedicauxDto> request)
        {
            var response = new BusinessResponse<CodeMedicauxDto>();

            try
            {
                response = await new CodeMedicauxManager().GetCodeMedicauxsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveCodeMedicauxs")]
        public async Task<BusinessResponse<CodeMedicauxDto>> PostSaveCodeMedicauxs([FromBody]BusinessRequest<CodeMedicauxDto> request)
        {
            var response = new BusinessResponse<CodeMedicauxDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CodeMedicauxManager().SaveCodeMedicauxs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteCodeMedicauxs")]
        public async Task<BusinessResponse<Boolean>> PostDeleteCodeMedicauxs([FromBody]BusinessRequest<CodeMedicauxDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new CodeMedicauxManager().DeleteCodeMedicauxs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Conventions
        [ActionName("GetConventionById")]
        public async Task<BusinessResponse<ConventionDto>> GetConventionById(int id)
        {
            var response = new BusinessResponse<ConventionDto>();

            try
            {
                response = await new ConventionManager().GetConventionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetConventionsByCriteria")]
        public async Task<BusinessResponse<ConventionDto>> PostGetConventionsByCriteria([FromBody]BusinessRequest<ConventionDto> request)
        {
            var response = new BusinessResponse<ConventionDto>();

            try
            {
                response = await new ConventionManager().GetConventionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveConventions")]
        public async Task<BusinessResponse<ConventionDto>> PostSaveConventions([FromBody]BusinessRequest<ConventionDto> request)
        {
            var response = new BusinessResponse<ConventionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ConventionManager().SaveConventions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteConventions")]
        public async Task<BusinessResponse<Boolean>> PostDeleteConventions([FromBody]BusinessRequest<ConventionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ConventionManager().DeleteConventions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Decomptes
        [ActionName("GetDecompteById")]
        public async Task<BusinessResponse<DecompteDto>> GetDecompteById(int id)
        {
            var response = new BusinessResponse<DecompteDto>();

            try
            {
                response = await new DecompteManager().GetDecompteById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetDecomptesByCriteria")]
        public async Task<BusinessResponse<DecompteDto>> PostGetDecomptesByCriteria([FromBody]BusinessRequest<DecompteDto> request)
        {
            var response = new BusinessResponse<DecompteDto>();

            try
            {
                response = await new DecompteManager().GetDecomptesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveDecomptes")]
        public async Task<BusinessResponse<DecompteDto>> PostSaveDecomptes([FromBody]BusinessRequest<DecompteDto> request)
        {
            var response = new BusinessResponse<DecompteDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DecompteManager().SaveDecomptes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteDecomptes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteDecomptes([FromBody]BusinessRequest<DecompteDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DecompteManager().DeleteDecomptes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region DecompteLignes
        [ActionName("GetDecompteLigneById")]
        public async Task<BusinessResponse<DecompteLigneDto>> GetDecompteLigneById(int id)
        {
            var response = new BusinessResponse<DecompteLigneDto>();

            try
            {
                response = await new DecompteLigneManager().GetDecompteLigneById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetDecompteLignesByCriteria")]
        public async Task<BusinessResponse<DecompteLigneDto>> PostGetDecompteLignesByCriteria([FromBody]BusinessRequest<DecompteLigneDto> request)
        {
            var response = new BusinessResponse<DecompteLigneDto>();

            try
            {
                response = await new DecompteLigneManager().GetDecompteLignesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveDecompteLignes")]
        public async Task<BusinessResponse<DecompteLigneDto>> PostSaveDecompteLignes([FromBody]BusinessRequest<DecompteLigneDto> request)
        {
            var response = new BusinessResponse<DecompteLigneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DecompteLigneManager().SaveDecompteLignes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteDecompteLignes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteDecompteLignes([FromBody]BusinessRequest<DecompteLigneDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DecompteLigneManager().DeleteDecompteLignes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region DemandeDuplicatas
        [ActionName("GetDemandeDuplicataById")]
        public async Task<BusinessResponse<DemandeDuplicataDto>> GetDemandeDuplicataById(int id)
        {
            var response = new BusinessResponse<DemandeDuplicataDto>();

            try
            {
                response = await new DemandeDuplicataManager().GetDemandeDuplicataById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetDemandeDuplicatasByCriteria")]
        public async Task<BusinessResponse<DemandeDuplicataDto>> PostGetDemandeDuplicatasByCriteria([FromBody]BusinessRequest<DemandeDuplicataDto> request)
        {
            var response = new BusinessResponse<DemandeDuplicataDto>();

            try
            {
                response = await new DemandeDuplicataManager().GetDemandeDuplicatasByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveDemandeDuplicatas")]
        public async Task<BusinessResponse<DemandeDuplicataDto>> PostSaveDemandeDuplicatas([FromBody]BusinessRequest<DemandeDuplicataDto> request)
        {
            var response = new BusinessResponse<DemandeDuplicataDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DemandeDuplicataManager().SaveDemandeDuplicatas(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteDemandeDuplicatas")]
        public async Task<BusinessResponse<Boolean>> PostDeleteDemandeDuplicatas([FromBody]BusinessRequest<DemandeDuplicataDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DemandeDuplicataManager().DeleteDemandeDuplicatas(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region DemandePriseEnCharges
        [ActionName("GetDemandePriseEnChargeById")]
        public async Task<BusinessResponse<DemandePriseEnChargeDto>> GetDemandePriseEnChargeById(int id)
        {
            var response = new BusinessResponse<DemandePriseEnChargeDto>();

            try
            {
                response = await new DemandePriseEnChargeManager().GetDemandePriseEnChargeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetDemandePriseEnChargesByCriteria")]
        public async Task<BusinessResponse<DemandePriseEnChargeDto>> PostGetDemandePriseEnChargesByCriteria([FromBody]BusinessRequest<DemandePriseEnChargeDto> request)
        {
            var response = new BusinessResponse<DemandePriseEnChargeDto>();

            try
            {
                response = await new DemandePriseEnChargeManager().GetDemandePriseEnChargesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveDemandePriseEnCharges")]
        public async Task<BusinessResponse<DemandePriseEnChargeDto>> PostSaveDemandePriseEnCharges([FromBody]BusinessRequest<DemandePriseEnChargeDto> request)
        {
            var response = new BusinessResponse<DemandePriseEnChargeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DemandePriseEnChargeManager().SaveDemandePriseEnCharges(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteDemandePriseEnCharges")]
        public async Task<BusinessResponse<Boolean>> PostDeleteDemandePriseEnCharges([FromBody]BusinessRequest<DemandePriseEnChargeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DemandePriseEnChargeManager().DeleteDemandePriseEnCharges(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region DemandePriseEnChargeLignes
        [ActionName("GetDemandePriseEnChargeLigneById")]
        public async Task<BusinessResponse<DemandePriseEnChargeLigneDto>> GetDemandePriseEnChargeLigneById(int id)
        {
            var response = new BusinessResponse<DemandePriseEnChargeLigneDto>();

            try
            {
                response = await new DemandePriseEnChargeLigneManager().GetDemandePriseEnChargeLigneById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetDemandePriseEnChargeLignesByCriteria")]
        public async Task<BusinessResponse<DemandePriseEnChargeLigneDto>> PostGetDemandePriseEnChargeLignesByCriteria([FromBody]BusinessRequest<DemandePriseEnChargeLigneDto> request)
        {
            var response = new BusinessResponse<DemandePriseEnChargeLigneDto>();

            try
            {
                response = await new DemandePriseEnChargeLigneManager().GetDemandePriseEnChargeLignesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveDemandePriseEnChargeLignes")]
        public async Task<BusinessResponse<DemandePriseEnChargeLigneDto>> PostSaveDemandePriseEnChargeLignes([FromBody]BusinessRequest<DemandePriseEnChargeLigneDto> request)
        {
            var response = new BusinessResponse<DemandePriseEnChargeLigneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DemandePriseEnChargeLigneManager().SaveDemandePriseEnChargeLignes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteDemandePriseEnChargeLignes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteDemandePriseEnChargeLignes([FromBody]BusinessRequest<DemandePriseEnChargeLigneDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DemandePriseEnChargeLigneManager().DeleteDemandePriseEnChargeLignes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Dirigeants
        [ActionName("GetDirigeantById")]
        public async Task<BusinessResponse<DirigeantDto>> GetDirigeantById(int id)
        {
            var response = new BusinessResponse<DirigeantDto>();

            try
            {
                response = await new DirigeantManager().GetDirigeantById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetDirigeantsByCriteria")]
        public async Task<BusinessResponse<DirigeantDto>> PostGetDirigeantsByCriteria([FromBody]BusinessRequest<DirigeantDto> request)
        {
            var response = new BusinessResponse<DirigeantDto>();

            try
            {
                response = await new DirigeantManager().GetDirigeantsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveDirigeants")]
        public async Task<BusinessResponse<DirigeantDto>> PostSaveDirigeants([FromBody]BusinessRequest<DirigeantDto> request)
        {
            var response = new BusinessResponse<DirigeantDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DirigeantManager().SaveDirigeants(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteDirigeants")]
        public async Task<BusinessResponse<Boolean>> PostDeleteDirigeants([FromBody]BusinessRequest<DirigeantDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DirigeantManager().DeleteDirigeants(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Documents
        [ActionName("GetDocumentById")]
        public async Task<BusinessResponse<DocumentDto>> GetDocumentById(int id)
        {
            var response = new BusinessResponse<DocumentDto>();

            try
            {
                response = await new DocumentManager().GetDocumentById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetDocumentsByCriteria")]
        public async Task<BusinessResponse<DocumentDto>> PostGetDocumentsByCriteria([FromBody]BusinessRequest<DocumentDto> request)
        {
            var response = new BusinessResponse<DocumentDto>();

            try
            {
                response = await new DocumentManager().GetDocumentsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveDocuments")]
        public async Task<BusinessResponse<DocumentDto>> PostSaveDocuments([FromBody]BusinessRequest<DocumentDto> request)
        {
            var response = new BusinessResponse<DocumentDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DocumentManager().SaveDocuments(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteDocuments")]
        public async Task<BusinessResponse<Boolean>> PostDeleteDocuments([FromBody]BusinessRequest<DocumentDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DocumentManager().DeleteDocuments(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region DocumentTypes
        [ActionName("GetDocumentTypeById")]
        public async Task<BusinessResponse<DocumentTypeDto>> GetDocumentTypeById(int id)
        {
            var response = new BusinessResponse<DocumentTypeDto>();

            try
            {
                response = await new DocumentTypeManager().GetDocumentTypeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetDocumentTypesByCriteria")]
        public async Task<BusinessResponse<DocumentTypeDto>> PostGetDocumentTypesByCriteria([FromBody]BusinessRequest<DocumentTypeDto> request)
        {
            var response = new BusinessResponse<DocumentTypeDto>();

            try
            {
                response = await new DocumentTypeManager().GetDocumentTypesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveDocumentTypes")]
        public async Task<BusinessResponse<DocumentTypeDto>> PostSaveDocumentTypes([FromBody]BusinessRequest<DocumentTypeDto> request)
        {
            var response = new BusinessResponse<DocumentTypeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DocumentTypeManager().SaveDocumentTypes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteDocumentTypes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteDocumentTypes([FromBody]BusinessRequest<DocumentTypeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DocumentTypeManager().DeleteDocumentTypes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region DupliquerCartes
        [ActionName("GetDupliquerCarteById")]
        public async Task<BusinessResponse<DupliquerCarteDto>> GetDupliquerCarteById(int id)
        {
            var response = new BusinessResponse<DupliquerCarteDto>();

            try
            {
                response = await new DupliquerCarteManager().GetDupliquerCarteById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetDupliquerCartesByCriteria")]
        public async Task<BusinessResponse<DupliquerCarteDto>> PostGetDupliquerCartesByCriteria([FromBody]BusinessRequest<DupliquerCarteDto> request)
        {
            var response = new BusinessResponse<DupliquerCarteDto>();

            try
            {
                response = await new DupliquerCarteManager().GetDupliquerCartesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveDupliquerCartes")]
        public async Task<BusinessResponse<DupliquerCarteDto>> PostSaveDupliquerCartes([FromBody]BusinessRequest<DupliquerCarteDto> request)
        {
            var response = new BusinessResponse<DupliquerCarteDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DupliquerCarteManager().SaveDupliquerCartes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteDupliquerCartes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteDupliquerCartes([FromBody]BusinessRequest<DupliquerCarteDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new DupliquerCarteManager().DeleteDupliquerCartes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ExclusionContrats
        [ActionName("GetExclusionContratById")]
        public async Task<BusinessResponse<ExclusionContratDto>> GetExclusionContratById(int id)
        {
            var response = new BusinessResponse<ExclusionContratDto>();

            try
            {
                response = await new ExclusionContratManager().GetExclusionContratById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetExclusionContratsByCriteria")]
        public async Task<BusinessResponse<ExclusionContratDto>> PostGetExclusionContratsByCriteria([FromBody]BusinessRequest<ExclusionContratDto> request)
        {
            var response = new BusinessResponse<ExclusionContratDto>();

            try
            {
                response = await new ExclusionContratManager().GetExclusionContratsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveExclusionContrats")]
        public async Task<BusinessResponse<ExclusionContratDto>> PostSaveExclusionContrats([FromBody]BusinessRequest<ExclusionContratDto> request)
        {
            var response = new BusinessResponse<ExclusionContratDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ExclusionContratManager().SaveExclusionContrats(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteExclusionContrats")]
        public async Task<BusinessResponse<Boolean>> PostDeleteExclusionContrats([FromBody]BusinessRequest<ExclusionContratDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ExclusionContratManager().DeleteExclusionContrats(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ExclusionTermes
        [ActionName("GetExclusionTermeById")]
        public async Task<BusinessResponse<ExclusionTermeDto>> GetExclusionTermeById(int id)
        {
            var response = new BusinessResponse<ExclusionTermeDto>();

            try
            {
                response = await new ExclusionTermeManager().GetExclusionTermeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetExclusionTermesByCriteria")]
        public async Task<BusinessResponse<ExclusionTermeDto>> PostGetExclusionTermesByCriteria([FromBody]BusinessRequest<ExclusionTermeDto> request)
        {
            var response = new BusinessResponse<ExclusionTermeDto>();

            try
            {
                response = await new ExclusionTermeManager().GetExclusionTermesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveExclusionTermes")]
        public async Task<BusinessResponse<ExclusionTermeDto>> PostSaveExclusionTermes([FromBody]BusinessRequest<ExclusionTermeDto> request)
        {
            var response = new BusinessResponse<ExclusionTermeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ExclusionTermeManager().SaveExclusionTermes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteExclusionTermes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteExclusionTermes([FromBody]BusinessRequest<ExclusionTermeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ExclusionTermeManager().DeleteExclusionTermes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region FamilleActes
        [ActionName("GetFamilleActeById")]
        public async Task<BusinessResponse<FamilleActeDto>> GetFamilleActeById(int id)
        {
            var response = new BusinessResponse<FamilleActeDto>();

            try
            {
                response = await new FamilleActeManager().GetFamilleActeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetFamilleActesByCriteria")]
        public async Task<BusinessResponse<FamilleActeDto>> PostGetFamilleActesByCriteria([FromBody]BusinessRequest<FamilleActeDto> request)
        {
            var response = new BusinessResponse<FamilleActeDto>();

            try
            {
                response = await new FamilleActeManager().GetFamilleActesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveFamilleActes")]
        public async Task<BusinessResponse<FamilleActeDto>> PostSaveFamilleActes([FromBody]BusinessRequest<FamilleActeDto> request)
        {
            var response = new BusinessResponse<FamilleActeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new FamilleActeManager().SaveFamilleActes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteFamilleActes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteFamilleActes([FromBody]BusinessRequest<FamilleActeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new FamilleActeManager().DeleteFamilleActes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Garants
        [ActionName("GetGarantById")]
        public async Task<BusinessResponse<GarantDto>> GetGarantById(int id)
        {
            var response = new BusinessResponse<GarantDto>();

            try
            {
                response = await new GarantManager().GetGarantById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetGarantsByCriteria")]
        public async Task<BusinessResponse<GarantDto>> PostGetGarantsByCriteria([FromBody]BusinessRequest<GarantDto> request)
        {
            var response = new BusinessResponse<GarantDto>();

            try
            {
                response = await new GarantManager().GetGarantsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveGarants")]
        public async Task<BusinessResponse<GarantDto>> PostSaveGarants([FromBody]BusinessRequest<GarantDto> request)
        {
            var response = new BusinessResponse<GarantDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new GarantManager().SaveGarants(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteGarants")]
        public async Task<BusinessResponse<Boolean>> PostDeleteGarants([FromBody]BusinessRequest<GarantDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new GarantManager().DeleteGarants(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Garanties
        [ActionName("GetGarantieById")]
        public async Task<BusinessResponse<GarantieDto>> GetGarantieById(int id)
        {
            var response = new BusinessResponse<GarantieDto>();

            try
            {
                response = await new GarantieManager().GetGarantieById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetGarantiesByCriteria")]
        public async Task<BusinessResponse<GarantieDto>> PostGetGarantiesByCriteria([FromBody]BusinessRequest<GarantieDto> request)
        {
            var response = new BusinessResponse<GarantieDto>();

            try
            {
                response = await new GarantieManager().GetGarantiesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveGaranties")]
        public async Task<BusinessResponse<GarantieDto>> PostSaveGaranties([FromBody]BusinessRequest<GarantieDto> request)
        {
            var response = new BusinessResponse<GarantieDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new GarantieManager().SaveGaranties(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteGaranties")]
        public async Task<BusinessResponse<Boolean>> PostDeleteGaranties([FromBody]BusinessRequest<GarantieDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new GarantieManager().DeleteGaranties(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region GenreEligibilites
        [ActionName("GetGenreEligibiliteById")]
        public async Task<BusinessResponse<GenreEligibiliteDto>> GetGenreEligibiliteById(int id)
        {
            var response = new BusinessResponse<GenreEligibiliteDto>();

            try
            {
                response = await new GenreEligibiliteManager().GetGenreEligibiliteById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetGenreEligibilitesByCriteria")]
        public async Task<BusinessResponse<GenreEligibiliteDto>> PostGetGenreEligibilitesByCriteria([FromBody]BusinessRequest<GenreEligibiliteDto> request)
        {
            var response = new BusinessResponse<GenreEligibiliteDto>();

            try
            {
                response = await new GenreEligibiliteManager().GetGenreEligibilitesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveGenreEligibilites")]
        public async Task<BusinessResponse<GenreEligibiliteDto>> PostSaveGenreEligibilites([FromBody]BusinessRequest<GenreEligibiliteDto> request)
        {
            var response = new BusinessResponse<GenreEligibiliteDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new GenreEligibiliteManager().SaveGenreEligibilites(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteGenreEligibilites")]
        public async Task<BusinessResponse<Boolean>> PostDeleteGenreEligibilites([FromBody]BusinessRequest<GenreEligibiliteDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new GenreEligibiliteManager().DeleteGenreEligibilites(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region GestionnaireMaladies
        [ActionName("GetGestionnaireMaladieById")]
        public async Task<BusinessResponse<GestionnaireMaladieDto>> GetGestionnaireMaladieById(int id)
        {
            var response = new BusinessResponse<GestionnaireMaladieDto>();

            try
            {
                response = await new GestionnaireMaladieManager().GetGestionnaireMaladieById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetGestionnaireMaladiesByCriteria")]
        public async Task<BusinessResponse<GestionnaireMaladieDto>> PostGetGestionnaireMaladiesByCriteria([FromBody]BusinessRequest<GestionnaireMaladieDto> request)
        {
            var response = new BusinessResponse<GestionnaireMaladieDto>();

            try
            {
                response = await new GestionnaireMaladieManager().GetGestionnaireMaladiesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveGestionnaireMaladies")]
        public async Task<BusinessResponse<GestionnaireMaladieDto>> PostSaveGestionnaireMaladies([FromBody]BusinessRequest<GestionnaireMaladieDto> request)
        {
            var response = new BusinessResponse<GestionnaireMaladieDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new GestionnaireMaladieManager().SaveGestionnaireMaladies(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteGestionnaireMaladies")]
        public async Task<BusinessResponse<Boolean>> PostDeleteGestionnaireMaladies([FromBody]BusinessRequest<GestionnaireMaladieDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new GestionnaireMaladieManager().DeleteGestionnaireMaladies(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Interlocuteurs
        [ActionName("GetInterlocuteurById")]
        public async Task<BusinessResponse<InterlocuteurDto>> GetInterlocuteurById(int id)
        {
            var response = new BusinessResponse<InterlocuteurDto>();

            try
            {
                response = await new InterlocuteurManager().GetInterlocuteurById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetInterlocuteursByCriteria")]
        public async Task<BusinessResponse<InterlocuteurDto>> PostGetInterlocuteursByCriteria([FromBody]BusinessRequest<InterlocuteurDto> request)
        {
            var response = new BusinessResponse<InterlocuteurDto>();

            try
            {
                response = await new InterlocuteurManager().GetInterlocuteursByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveInterlocuteurs")]
        public async Task<BusinessResponse<InterlocuteurDto>> PostSaveInterlocuteurs([FromBody]BusinessRequest<InterlocuteurDto> request)
        {
            var response = new BusinessResponse<InterlocuteurDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new InterlocuteurManager().SaveInterlocuteurs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteInterlocuteurs")]
        public async Task<BusinessResponse<Boolean>> PostDeleteInterlocuteurs([FromBody]BusinessRequest<InterlocuteurDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new InterlocuteurManager().DeleteInterlocuteurs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Localites
        [ActionName("GetLocaliteById")]
        public async Task<BusinessResponse<LocaliteDto>> GetLocaliteById(int id)
        {
            var response = new BusinessResponse<LocaliteDto>();

            try
            {
                response = await new LocaliteManager().GetLocaliteById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetLocalitesByCriteria")]
        public async Task<BusinessResponse<LocaliteDto>> PostGetLocalitesByCriteria([FromBody]BusinessRequest<LocaliteDto> request)
        {
            var response = new BusinessResponse<LocaliteDto>();

            try
            {
                response = await new LocaliteManager().GetLocalitesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveLocalites")]
        public async Task<BusinessResponse<LocaliteDto>> PostSaveLocalites([FromBody]BusinessRequest<LocaliteDto> request)
        {
            var response = new BusinessResponse<LocaliteDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new LocaliteManager().SaveLocalites(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteLocalites")]
        public async Task<BusinessResponse<Boolean>> PostDeleteLocalites([FromBody]BusinessRequest<LocaliteDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new LocaliteManager().DeleteLocalites(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region MedecinConseils
        [ActionName("GetMedecinConseilById")]
        public async Task<BusinessResponse<MedecinConseilDto>> GetMedecinConseilById(int id)
        {
            var response = new BusinessResponse<MedecinConseilDto>();

            try
            {
                response = await new MedecinConseilManager().GetMedecinConseilById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetMedecinConseilsByCriteria")]
        public async Task<BusinessResponse<MedecinConseilDto>> PostGetMedecinConseilsByCriteria([FromBody]BusinessRequest<MedecinConseilDto> request)
        {
            var response = new BusinessResponse<MedecinConseilDto>();

            try
            {
                response = await new MedecinConseilManager().GetMedecinConseilsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveMedecinConseils")]
        public async Task<BusinessResponse<MedecinConseilDto>> PostSaveMedecinConseils([FromBody]BusinessRequest<MedecinConseilDto> request)
        {
            var response = new BusinessResponse<MedecinConseilDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new MedecinConseilManager().SaveMedecinConseils(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteMedecinConseils")]
        public async Task<BusinessResponse<Boolean>> PostDeleteMedecinConseils([FromBody]BusinessRequest<MedecinConseilDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new MedecinConseilManager().DeleteMedecinConseils(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Payeurs
        [ActionName("GetPayeurById")]
        public async Task<BusinessResponse<PayeurDto>> GetPayeurById(int id)
        {
            var response = new BusinessResponse<PayeurDto>();

            try
            {
                response = await new PayeurManager().GetPayeurById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPayeursByCriteria")]
        public async Task<BusinessResponse<PayeurDto>> PostGetPayeursByCriteria([FromBody]BusinessRequest<PayeurDto> request)
        {
            var response = new BusinessResponse<PayeurDto>();

            try
            {
                response = await new PayeurManager().GetPayeursByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePayeurs")]
        public async Task<BusinessResponse<PayeurDto>> PostSavePayeurs([FromBody]BusinessRequest<PayeurDto> request)
        {
            var response = new BusinessResponse<PayeurDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PayeurManager().SavePayeurs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePayeurs")]
        public async Task<BusinessResponse<Boolean>> PostDeletePayeurs([FromBody]BusinessRequest<PayeurDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PayeurManager().DeletePayeurs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PersonnelMedical1s
        [ActionName("GetPersonnelMedical1ById")]
        public async Task<BusinessResponse<PersonnelMedical1Dto>> GetPersonnelMedical1ById(int id)
        {
            var response = new BusinessResponse<PersonnelMedical1Dto>();

            try
            {
                response = await new PersonnelMedical1Manager().GetPersonnelMedical1ById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPersonnelMedical1sByCriteria")]
        public async Task<BusinessResponse<PersonnelMedical1Dto>> PostGetPersonnelMedical1sByCriteria([FromBody]BusinessRequest<PersonnelMedical1Dto> request)
        {
            var response = new BusinessResponse<PersonnelMedical1Dto>();

            try
            {
                response = await new PersonnelMedical1Manager().GetPersonnelMedical1sByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePersonnelMedical1s")]
        public async Task<BusinessResponse<PersonnelMedical1Dto>> PostSavePersonnelMedical1s([FromBody]BusinessRequest<PersonnelMedical1Dto> request)
        {
            var response = new BusinessResponse<PersonnelMedical1Dto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PersonnelMedical1Manager().SavePersonnelMedical1s(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePersonnelMedical1s")]
        public async Task<BusinessResponse<Boolean>> PostDeletePersonnelMedical1s([FromBody]BusinessRequest<PersonnelMedical1Dto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PersonnelMedical1Manager().DeletePersonnelMedical1s(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PoolMedicals
        [ActionName("GetPoolMedicalById")]
        public async Task<BusinessResponse<PoolMedicalDto>> GetPoolMedicalById(int id)
        {
            var response = new BusinessResponse<PoolMedicalDto>();

            try
            {
                response = await new PoolMedicalManager().GetPoolMedicalById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPoolMedicalsByCriteria")]
        public async Task<BusinessResponse<PoolMedicalDto>> PostGetPoolMedicalsByCriteria([FromBody]BusinessRequest<PoolMedicalDto> request)
        {
            var response = new BusinessResponse<PoolMedicalDto>();

            try
            {
                response = await new PoolMedicalManager().GetPoolMedicalsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePoolMedicals")]
        public async Task<BusinessResponse<PoolMedicalDto>> PostSavePoolMedicals([FromBody]BusinessRequest<PoolMedicalDto> request)
        {
            var response = new BusinessResponse<PoolMedicalDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PoolMedicalManager().SavePoolMedicals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePoolMedicals")]
        public async Task<BusinessResponse<Boolean>> PostDeletePoolMedicals([FromBody]BusinessRequest<PoolMedicalDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PoolMedicalManager().DeletePoolMedicals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PrestataireDivers
        [ActionName("GetPrestataireDiversById")]
        public async Task<BusinessResponse<PrestataireDiversDto>> GetPrestataireDiversById(int id)
        {
            var response = new BusinessResponse<PrestataireDiversDto>();

            try
            {
                response = await new PrestataireDiversManager().GetPrestataireDiversById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPrestataireDiversByCriteria")]
        public async Task<BusinessResponse<PrestataireDiversDto>> PostGetPrestataireDiversByCriteria([FromBody]BusinessRequest<PrestataireDiversDto> request)
        {
            var response = new BusinessResponse<PrestataireDiversDto>();

            try
            {
                response = await new PrestataireDiversManager().GetPrestataireDiversByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePrestataireDivers")]
        public async Task<BusinessResponse<PrestataireDiversDto>> PostSavePrestataireDivers([FromBody]BusinessRequest<PrestataireDiversDto> request)
        {
            var response = new BusinessResponse<PrestataireDiversDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestataireDiversManager().SavePrestataireDivers(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePrestataireDivers")]
        public async Task<BusinessResponse<Boolean>> PostDeletePrestataireDivers([FromBody]BusinessRequest<PrestataireDiversDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestataireDiversManager().DeletePrestataireDivers(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PrestataireMedical1s
        [ActionName("GetPrestataireMedical1ById")]
        public async Task<BusinessResponse<PrestataireMedical1Dto>> GetPrestataireMedical1ById(int id)
        {
            var response = new BusinessResponse<PrestataireMedical1Dto>();

            try
            {
                response = await new PrestataireMedical1Manager().GetPrestataireMedical1ById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPrestataireMedical1sByCriteria")]
        public async Task<BusinessResponse<PrestataireMedical1Dto>> PostGetPrestataireMedical1sByCriteria([FromBody]BusinessRequest<PrestataireMedical1Dto> request)
        {
            var response = new BusinessResponse<PrestataireMedical1Dto>();

            try
            {
                response = await new PrestataireMedical1Manager().GetPrestataireMedical1sByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePrestataireMedical1s")]
        public async Task<BusinessResponse<PrestataireMedical1Dto>> PostSavePrestataireMedical1s([FromBody]BusinessRequest<PrestataireMedical1Dto> request)
        {
            var response = new BusinessResponse<PrestataireMedical1Dto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestataireMedical1Manager().SavePrestataireMedical1s(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePrestataireMedical1s")]
        public async Task<BusinessResponse<Boolean>> PostDeletePrestataireMedical1s([FromBody]BusinessRequest<PrestataireMedical1Dto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestataireMedical1Manager().DeletePrestataireMedical1s(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Prestatations
        [ActionName("GetPrestatationById")]
        public async Task<BusinessResponse<PrestatationDto>> GetPrestatationById(int id)
        {
            var response = new BusinessResponse<PrestatationDto>();

            try
            {
                response = await new PrestatationManager().GetPrestatationById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPrestatationsByCriteria")]
        public async Task<BusinessResponse<PrestatationDto>> PostGetPrestatationsByCriteria([FromBody]BusinessRequest<PrestatationDto> request)
        {
            var response = new BusinessResponse<PrestatationDto>();

            try
            {
                response = await new PrestatationManager().GetPrestatationsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePrestatations")]
        public async Task<BusinessResponse<PrestatationDto>> PostSavePrestatations([FromBody]BusinessRequest<PrestatationDto> request)
        {
            var response = new BusinessResponse<PrestatationDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestatationManager().SavePrestatations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePrestatations")]
        public async Task<BusinessResponse<Boolean>> PostDeletePrestatations([FromBody]BusinessRequest<PrestatationDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestatationManager().DeletePrestatations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PrestatationsProposees
        [ActionName("GetPrestatationsProposeesById")]
        public async Task<BusinessResponse<PrestatationsProposeesDto>> GetPrestatationsProposeesById(int id)
        {
            var response = new BusinessResponse<PrestatationsProposeesDto>();

            try
            {
                response = await new PrestatationsProposeesManager().GetPrestatationsProposeesById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPrestatationsProposeesByCriteria")]
        public async Task<BusinessResponse<PrestatationsProposeesDto>> PostGetPrestatationsProposeesByCriteria([FromBody]BusinessRequest<PrestatationsProposeesDto> request)
        {
            var response = new BusinessResponse<PrestatationsProposeesDto>();

            try
            {
                response = await new PrestatationsProposeesManager().GetPrestatationsProposeesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePrestatationsProposees")]
        public async Task<BusinessResponse<PrestatationsProposeesDto>> PostSavePrestatationsProposees([FromBody]BusinessRequest<PrestatationsProposeesDto> request)
        {
            var response = new BusinessResponse<PrestatationsProposeesDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestatationsProposeesManager().SavePrestatationsProposees(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePrestatationsProposees")]
        public async Task<BusinessResponse<Boolean>> PostDeletePrestatationsProposees([FromBody]BusinessRequest<PrestatationsProposeesDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestatationsProposeesManager().DeletePrestatationsProposees(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Prestations
        [ActionName("GetPrestationById")]
        public async Task<BusinessResponse<PrestationDto>> GetPrestationById(int id)
        {
            var response = new BusinessResponse<PrestationDto>();

            try
            {
                response = await new PrestationManager().GetPrestationById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPrestationsByCriteria")]
        public async Task<BusinessResponse<PrestationDto>> PostGetPrestationsByCriteria([FromBody]BusinessRequest<PrestationDto> request)
        {
            var response = new BusinessResponse<PrestationDto>();

            try
            {
                response = await new PrestationManager().GetPrestationsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePrestations")]
        public async Task<BusinessResponse<PrestationDto>> PostSavePrestations([FromBody]BusinessRequest<PrestationDto> request)
        {
            var response = new BusinessResponse<PrestationDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestationManager().SavePrestations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePrestations")]
        public async Task<BusinessResponse<Boolean>> PostDeletePrestations([FromBody]BusinessRequest<PrestationDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestationManager().DeletePrestations(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PrestationActes
        [ActionName("GetPrestationActeById")]
        public async Task<BusinessResponse<PrestationActeDto>> GetPrestationActeById(int id)
        {
            var response = new BusinessResponse<PrestationActeDto>();

            try
            {
                response = await new PrestationActeManager().GetPrestationActeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPrestationActesByCriteria")]
        public async Task<BusinessResponse<PrestationActeDto>> PostGetPrestationActesByCriteria([FromBody]BusinessRequest<PrestationActeDto> request)
        {
            var response = new BusinessResponse<PrestationActeDto>();

            try
            {
                response = await new PrestationActeManager().GetPrestationActesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePrestationActes")]
        public async Task<BusinessResponse<PrestationActeDto>> PostSavePrestationActes([FromBody]BusinessRequest<PrestationActeDto> request)
        {
            var response = new BusinessResponse<PrestationActeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestationActeManager().SavePrestationActes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePrestationActes")]
        public async Task<BusinessResponse<Boolean>> PostDeletePrestationActes([FromBody]BusinessRequest<PrestationActeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestationActeManager().DeletePrestationActes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PrestationAffections
        [ActionName("GetPrestationAffectionById")]
        public async Task<BusinessResponse<PrestationAffectionDto>> GetPrestationAffectionById(int id)
        {
            var response = new BusinessResponse<PrestationAffectionDto>();

            try
            {
                response = await new PrestationAffectionManager().GetPrestationAffectionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPrestationAffectionsByCriteria")]
        public async Task<BusinessResponse<PrestationAffectionDto>> PostGetPrestationAffectionsByCriteria([FromBody]BusinessRequest<PrestationAffectionDto> request)
        {
            var response = new BusinessResponse<PrestationAffectionDto>();

            try
            {
                response = await new PrestationAffectionManager().GetPrestationAffectionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePrestationAffections")]
        public async Task<BusinessResponse<PrestationAffectionDto>> PostSavePrestationAffections([FromBody]BusinessRequest<PrestationAffectionDto> request)
        {
            var response = new BusinessResponse<PrestationAffectionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestationAffectionManager().SavePrestationAffections(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePrestationAffections")]
        public async Task<BusinessResponse<Boolean>> PostDeletePrestationAffections([FromBody]BusinessRequest<PrestationAffectionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestationAffectionManager().DeletePrestationAffections(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region PrestationPrescriptions
        [ActionName("GetPrestationPrescriptionById")]
        public async Task<BusinessResponse<PrestationPrescriptionDto>> GetPrestationPrescriptionById(int id)
        {
            var response = new BusinessResponse<PrestationPrescriptionDto>();

            try
            {
                response = await new PrestationPrescriptionManager().GetPrestationPrescriptionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetPrestationPrescriptionsByCriteria")]
        public async Task<BusinessResponse<PrestationPrescriptionDto>> PostGetPrestationPrescriptionsByCriteria([FromBody]BusinessRequest<PrestationPrescriptionDto> request)
        {
            var response = new BusinessResponse<PrestationPrescriptionDto>();

            try
            {
                response = await new PrestationPrescriptionManager().GetPrestationPrescriptionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SavePrestationPrescriptions")]
        public async Task<BusinessResponse<PrestationPrescriptionDto>> PostSavePrestationPrescriptions([FromBody]BusinessRequest<PrestationPrescriptionDto> request)
        {
            var response = new BusinessResponse<PrestationPrescriptionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestationPrescriptionManager().SavePrestationPrescriptions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeletePrestationPrescriptions")]
        public async Task<BusinessResponse<Boolean>> PostDeletePrestationPrescriptions([FromBody]BusinessRequest<PrestationPrescriptionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new PrestationPrescriptionManager().DeletePrestationPrescriptions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Produits
        [ActionName("GetProduitById")]
        public async Task<BusinessResponse<ProduitDto>> GetProduitById(int id)
        {
            var response = new BusinessResponse<ProduitDto>();

            try
            {
                response = await new ProduitManager().GetProduitById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetProduitsByCriteria")]
        public async Task<BusinessResponse<ProduitDto>> PostGetProduitsByCriteria([FromBody]BusinessRequest<ProduitDto> request)
        {
            var response = new BusinessResponse<ProduitDto>();

            try
            {
                response = await new ProduitManager().GetProduitsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveProduits")]
        public async Task<BusinessResponse<ProduitDto>> PostSaveProduits([FromBody]BusinessRequest<ProduitDto> request)
        {
            var response = new BusinessResponse<ProduitDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ProduitManager().SaveProduits(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteProduits")]
        public async Task<BusinessResponse<Boolean>> PostDeleteProduits([FromBody]BusinessRequest<ProduitDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ProduitManager().DeleteProduits(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region RenouvelerCartes
        [ActionName("GetRenouvelerCarteById")]
        public async Task<BusinessResponse<RenouvelerCarteDto>> GetRenouvelerCarteById(int id)
        {
            var response = new BusinessResponse<RenouvelerCarteDto>();

            try
            {
                response = await new RenouvelerCarteManager().GetRenouvelerCarteById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetRenouvelerCartesByCriteria")]
        public async Task<BusinessResponse<RenouvelerCarteDto>> PostGetRenouvelerCartesByCriteria([FromBody]BusinessRequest<RenouvelerCarteDto> request)
        {
            var response = new BusinessResponse<RenouvelerCarteDto>();

            try
            {
                response = await new RenouvelerCarteManager().GetRenouvelerCartesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveRenouvelerCartes")]
        public async Task<BusinessResponse<RenouvelerCarteDto>> PostSaveRenouvelerCartes([FromBody]BusinessRequest<RenouvelerCarteDto> request)
        {
            var response = new BusinessResponse<RenouvelerCarteDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new RenouvelerCarteManager().SaveRenouvelerCartes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteRenouvelerCartes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteRenouvelerCartes([FromBody]BusinessRequest<RenouvelerCarteDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new RenouvelerCarteManager().DeleteRenouvelerCartes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ReseauSoins
        [ActionName("GetReseauSoinById")]
        public async Task<BusinessResponse<ReseauSoinDto>> GetReseauSoinById(int id)
        {
            var response = new BusinessResponse<ReseauSoinDto>();

            try
            {
                response = await new ReseauSoinManager().GetReseauSoinById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetReseauSoinsByCriteria")]
        public async Task<BusinessResponse<ReseauSoinDto>> PostGetReseauSoinsByCriteria([FromBody]BusinessRequest<ReseauSoinDto> request)
        {
            var response = new BusinessResponse<ReseauSoinDto>();

            try
            {
                response = await new ReseauSoinManager().GetReseauSoinsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveReseauSoins")]
        public async Task<BusinessResponse<ReseauSoinDto>> PostSaveReseauSoins([FromBody]BusinessRequest<ReseauSoinDto> request)
        {
            var response = new BusinessResponse<ReseauSoinDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ReseauSoinManager().SaveReseauSoins(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteReseauSoins")]
        public async Task<BusinessResponse<Boolean>> PostDeleteReseauSoins([FromBody]BusinessRequest<ReseauSoinDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ReseauSoinManager().DeleteReseauSoins(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ReseauSoinPrestataires
        [ActionName("GetReseauSoinPrestataireById")]
        public async Task<BusinessResponse<ReseauSoinPrestataireDto>> GetReseauSoinPrestataireById(int id)
        {
            var response = new BusinessResponse<ReseauSoinPrestataireDto>();

            try
            {
                response = await new ReseauSoinPrestataireManager().GetReseauSoinPrestataireById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetReseauSoinPrestatairesByCriteria")]
        public async Task<BusinessResponse<ReseauSoinPrestataireDto>> PostGetReseauSoinPrestatairesByCriteria([FromBody]BusinessRequest<ReseauSoinPrestataireDto> request)
        {
            var response = new BusinessResponse<ReseauSoinPrestataireDto>();

            try
            {
                response = await new ReseauSoinPrestataireManager().GetReseauSoinPrestatairesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveReseauSoinPrestataires")]
        public async Task<BusinessResponse<ReseauSoinPrestataireDto>> PostSaveReseauSoinPrestataires([FromBody]BusinessRequest<ReseauSoinPrestataireDto> request)
        {
            var response = new BusinessResponse<ReseauSoinPrestataireDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ReseauSoinPrestataireManager().SaveReseauSoinPrestataires(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteReseauSoinPrestataires")]
        public async Task<BusinessResponse<Boolean>> PostDeleteReseauSoinPrestataires([FromBody]BusinessRequest<ReseauSoinPrestataireDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ReseauSoinPrestataireManager().DeleteReseauSoinPrestataires(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region SanctionPrestataires
        [ActionName("GetSanctionPrestataireById")]
        public async Task<BusinessResponse<SanctionPrestataireDto>> GetSanctionPrestataireById(int id)
        {
            var response = new BusinessResponse<SanctionPrestataireDto>();

            try
            {
                response = await new SanctionPrestataireManager().GetSanctionPrestataireById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetSanctionPrestatairesByCriteria")]
        public async Task<BusinessResponse<SanctionPrestataireDto>> PostGetSanctionPrestatairesByCriteria([FromBody]BusinessRequest<SanctionPrestataireDto> request)
        {
            var response = new BusinessResponse<SanctionPrestataireDto>();

            try
            {
                response = await new SanctionPrestataireManager().GetSanctionPrestatairesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveSanctionPrestataires")]
        public async Task<BusinessResponse<SanctionPrestataireDto>> PostSaveSanctionPrestataires([FromBody]BusinessRequest<SanctionPrestataireDto> request)
        {
            var response = new BusinessResponse<SanctionPrestataireDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SanctionPrestataireManager().SaveSanctionPrestataires(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteSanctionPrestataires")]
        public async Task<BusinessResponse<Boolean>> PostDeleteSanctionPrestataires([FromBody]BusinessRequest<SanctionPrestataireDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SanctionPrestataireManager().DeleteSanctionPrestataires(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Souscripteurs
        [ActionName("GetSouscripteurById")]
        public async Task<BusinessResponse<SouscripteurDto>> GetSouscripteurById(int id)
        {
            var response = new BusinessResponse<SouscripteurDto>();

            try
            {
                response = await new SouscripteurManager().GetSouscripteurById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetSouscripteursByCriteria")]
        public async Task<BusinessResponse<SouscripteurDto>> PostGetSouscripteursByCriteria([FromBody]BusinessRequest<SouscripteurDto> request)
        {
            var response = new BusinessResponse<SouscripteurDto>();

            try
            {
                response = await new SouscripteurManager().GetSouscripteursByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveSouscripteurs")]
        public async Task<BusinessResponse<SouscripteurDto>> PostSaveSouscripteurs([FromBody]BusinessRequest<SouscripteurDto> request)
        {
            var response = new BusinessResponse<SouscripteurDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SouscripteurManager().SaveSouscripteurs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteSouscripteurs")]
        public async Task<BusinessResponse<Boolean>> PostDeleteSouscripteurs([FromBody]BusinessRequest<SouscripteurDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SouscripteurManager().DeleteSouscripteurs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Souscriptions
        [ActionName("GetSouscriptionById")]
        public async Task<BusinessResponse<SouscriptionDto>> GetSouscriptionById(int id)
        {
            var response = new BusinessResponse<SouscriptionDto>();

            try
            {
                response = await new SouscriptionManager().GetSouscriptionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetSouscriptionsByCriteria")]
        public async Task<BusinessResponse<SouscriptionDto>> PostGetSouscriptionsByCriteria([FromBody]BusinessRequest<SouscriptionDto> request)
        {
            var response = new BusinessResponse<SouscriptionDto>();

            try
            {
                response = await new SouscriptionManager().GetSouscriptionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveSouscriptions")]
        public async Task<BusinessResponse<SouscriptionDto>> PostSaveSouscriptions([FromBody]BusinessRequest<SouscriptionDto> request)
        {
            var response = new BusinessResponse<SouscriptionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SouscriptionManager().SaveSouscriptions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteSouscriptions")]
        public async Task<BusinessResponse<Boolean>> PostDeleteSouscriptions([FromBody]BusinessRequest<SouscriptionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SouscriptionManager().DeleteSouscriptions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region SouscriptionLignes
        [ActionName("GetSouscriptionLigneById")]
        public async Task<BusinessResponse<SouscriptionLigneDto>> GetSouscriptionLigneById(int id)
        {
            var response = new BusinessResponse<SouscriptionLigneDto>();

            try
            {
                response = await new SouscriptionLigneManager().GetSouscriptionLigneById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetSouscriptionLignesByCriteria")]
        public async Task<BusinessResponse<SouscriptionLigneDto>> PostGetSouscriptionLignesByCriteria([FromBody]BusinessRequest<SouscriptionLigneDto> request)
        {
            var response = new BusinessResponse<SouscriptionLigneDto>();

            try
            {
                response = await new SouscriptionLigneManager().GetSouscriptionLignesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveSouscriptionLignes")]
        public async Task<BusinessResponse<SouscriptionLigneDto>> PostSaveSouscriptionLignes([FromBody]BusinessRequest<SouscriptionLigneDto> request)
        {
            var response = new BusinessResponse<SouscriptionLigneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SouscriptionLigneManager().SaveSouscriptionLignes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteSouscriptionLignes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteSouscriptionLignes([FromBody]BusinessRequest<SouscriptionLigneDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SouscriptionLigneManager().DeleteSouscriptionLignes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region SouscriptionLigneHists
        [ActionName("GetSouscriptionLigneHistById")]
        public async Task<BusinessResponse<SouscriptionLigneHistDto>> GetSouscriptionLigneHistById(int id)
        {
            var response = new BusinessResponse<SouscriptionLigneHistDto>();

            try
            {
                response = await new SouscriptionLigneHistManager().GetSouscriptionLigneHistById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetSouscriptionLigneHistsByCriteria")]
        public async Task<BusinessResponse<SouscriptionLigneHistDto>> PostGetSouscriptionLigneHistsByCriteria([FromBody]BusinessRequest<SouscriptionLigneHistDto> request)
        {
            var response = new BusinessResponse<SouscriptionLigneHistDto>();

            try
            {
                response = await new SouscriptionLigneHistManager().GetSouscriptionLigneHistsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveSouscriptionLigneHists")]
        public async Task<BusinessResponse<SouscriptionLigneHistDto>> PostSaveSouscriptionLigneHists([FromBody]BusinessRequest<SouscriptionLigneHistDto> request)
        {
            var response = new BusinessResponse<SouscriptionLigneHistDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SouscriptionLigneHistManager().SaveSouscriptionLigneHists(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteSouscriptionLigneHists")]
        public async Task<BusinessResponse<Boolean>> PostDeleteSouscriptionLigneHists([FromBody]BusinessRequest<SouscriptionLigneHistDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SouscriptionLigneHistManager().DeleteSouscriptionLigneHists(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region SouscriptionPayes
        [ActionName("GetSouscriptionPayeById")]
        public async Task<BusinessResponse<SouscriptionPayeDto>> GetSouscriptionPayeById(int id)
        {
            var response = new BusinessResponse<SouscriptionPayeDto>();

            try
            {
                response = await new SouscriptionPayeManager().GetSouscriptionPayeById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetSouscriptionPayesByCriteria")]
        public async Task<BusinessResponse<SouscriptionPayeDto>> PostGetSouscriptionPayesByCriteria([FromBody]BusinessRequest<SouscriptionPayeDto> request)
        {
            var response = new BusinessResponse<SouscriptionPayeDto>();

            try
            {
                response = await new SouscriptionPayeManager().GetSouscriptionPayesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveSouscriptionPayes")]
        public async Task<BusinessResponse<SouscriptionPayeDto>> PostSaveSouscriptionPayes([FromBody]BusinessRequest<SouscriptionPayeDto> request)
        {
            var response = new BusinessResponse<SouscriptionPayeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SouscriptionPayeManager().SaveSouscriptionPayes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteSouscriptionPayes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteSouscriptionPayes([FromBody]BusinessRequest<SouscriptionPayeDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SouscriptionPayeManager().DeleteSouscriptionPayes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region SouscriptionPayeLignes
        [ActionName("GetSouscriptionPayeLigneById")]
        public async Task<BusinessResponse<SouscriptionPayeLigneDto>> GetSouscriptionPayeLigneById(int id)
        {
            var response = new BusinessResponse<SouscriptionPayeLigneDto>();

            try
            {
                response = await new SouscriptionPayeLigneManager().GetSouscriptionPayeLigneById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetSouscriptionPayeLignesByCriteria")]
        public async Task<BusinessResponse<SouscriptionPayeLigneDto>> PostGetSouscriptionPayeLignesByCriteria([FromBody]BusinessRequest<SouscriptionPayeLigneDto> request)
        {
            var response = new BusinessResponse<SouscriptionPayeLigneDto>();

            try
            {
                response = await new SouscriptionPayeLigneManager().GetSouscriptionPayeLignesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveSouscriptionPayeLignes")]
        public async Task<BusinessResponse<SouscriptionPayeLigneDto>> PostSaveSouscriptionPayeLignes([FromBody]BusinessRequest<SouscriptionPayeLigneDto> request)
        {
            var response = new BusinessResponse<SouscriptionPayeLigneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SouscriptionPayeLigneManager().SaveSouscriptionPayeLignes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteSouscriptionPayeLignes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteSouscriptionPayeLignes([FromBody]BusinessRequest<SouscriptionPayeLigneDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SouscriptionPayeLigneManager().DeleteSouscriptionPayeLignes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Specialites
        [ActionName("GetSpecialiteById")]
        public async Task<BusinessResponse<SpecialiteDto>> GetSpecialiteById(int id)
        {
            var response = new BusinessResponse<SpecialiteDto>();

            try
            {
                response = await new SpecialiteManager().GetSpecialiteById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetSpecialitesByCriteria")]
        public async Task<BusinessResponse<SpecialiteDto>> PostGetSpecialitesByCriteria([FromBody]BusinessRequest<SpecialiteDto> request)
        {
            var response = new BusinessResponse<SpecialiteDto>();

            try
            {
                response = await new SpecialiteManager().GetSpecialitesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveSpecialites")]
        public async Task<BusinessResponse<SpecialiteDto>> PostSaveSpecialites([FromBody]BusinessRequest<SpecialiteDto> request)
        {
            var response = new BusinessResponse<SpecialiteDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SpecialiteManager().SaveSpecialites(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteSpecialites")]
        public async Task<BusinessResponse<Boolean>> PostDeleteSpecialites([FromBody]BusinessRequest<SpecialiteDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new SpecialiteManager().DeleteSpecialites(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Standings
        [ActionName("GetStandingById")]
        public async Task<BusinessResponse<StandingDto>> GetStandingById(int id)
        {
            var response = new BusinessResponse<StandingDto>();

            try
            {
                response = await new StandingManager().GetStandingById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetStandingsByCriteria")]
        public async Task<BusinessResponse<StandingDto>> PostGetStandingsByCriteria([FromBody]BusinessRequest<StandingDto> request)
        {
            var response = new BusinessResponse<StandingDto>();

            try
            {
                response = await new StandingManager().GetStandingsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveStandings")]
        public async Task<BusinessResponse<StandingDto>> PostSaveStandings([FromBody]BusinessRequest<StandingDto> request)
        {
            var response = new BusinessResponse<StandingDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StandingManager().SaveStandings(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteStandings")]
        public async Task<BusinessResponse<Boolean>> PostDeleteStandings([FromBody]BusinessRequest<StandingDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StandingManager().DeleteStandings(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region StandingCentreConventionnes
        [ActionName("GetStandingCentreConventionneById")]
        public async Task<BusinessResponse<StandingCentreConventionneDto>> GetStandingCentreConventionneById(int id)
        {
            var response = new BusinessResponse<StandingCentreConventionneDto>();

            try
            {
                response = await new StandingCentreConventionneManager().GetStandingCentreConventionneById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetStandingCentreConventionnesByCriteria")]
        public async Task<BusinessResponse<StandingCentreConventionneDto>> PostGetStandingCentreConventionnesByCriteria([FromBody]BusinessRequest<StandingCentreConventionneDto> request)
        {
            var response = new BusinessResponse<StandingCentreConventionneDto>();

            try
            {
                response = await new StandingCentreConventionneManager().GetStandingCentreConventionnesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveStandingCentreConventionnes")]
        public async Task<BusinessResponse<StandingCentreConventionneDto>> PostSaveStandingCentreConventionnes([FromBody]BusinessRequest<StandingCentreConventionneDto> request)
        {
            var response = new BusinessResponse<StandingCentreConventionneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StandingCentreConventionneManager().SaveStandingCentreConventionnes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteStandingCentreConventionnes")]
        public async Task<BusinessResponse<Boolean>> PostDeleteStandingCentreConventionnes([FromBody]BusinessRequest<StandingCentreConventionneDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StandingCentreConventionneManager().DeleteStandingCentreConventionnes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region StatutDemandePECs
        [ActionName("GetStatutDemandePECById")]
        public async Task<BusinessResponse<StatutDemandePECDto>> GetStatutDemandePECById(int id)
        {
            var response = new BusinessResponse<StatutDemandePECDto>();

            try
            {
                response = await new StatutDemandePECManager().GetStatutDemandePECById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetStatutDemandePECsByCriteria")]
        public async Task<BusinessResponse<StatutDemandePECDto>> PostGetStatutDemandePECsByCriteria([FromBody]BusinessRequest<StatutDemandePECDto> request)
        {
            var response = new BusinessResponse<StatutDemandePECDto>();

            try
            {
                response = await new StatutDemandePECManager().GetStatutDemandePECsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveStatutDemandePECs")]
        public async Task<BusinessResponse<StatutDemandePECDto>> PostSaveStatutDemandePECs([FromBody]BusinessRequest<StatutDemandePECDto> request)
        {
            var response = new BusinessResponse<StatutDemandePECDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutDemandePECManager().SaveStatutDemandePECs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteStatutDemandePECs")]
        public async Task<BusinessResponse<Boolean>> PostDeleteStatutDemandePECs([FromBody]BusinessRequest<StatutDemandePECDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutDemandePECManager().DeleteStatutDemandePECs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region StatutProfils
        [ActionName("GetStatutProfilById")]
        public async Task<BusinessResponse<StatutProfilDto>> GetStatutProfilById(int id)
        {
            var response = new BusinessResponse<StatutProfilDto>();

            try
            {
                response = await new StatutProfilManager().GetStatutProfilById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetStatutProfilsByCriteria")]
        public async Task<BusinessResponse<StatutProfilDto>> PostGetStatutProfilsByCriteria([FromBody]BusinessRequest<StatutProfilDto> request)
        {
            var response = new BusinessResponse<StatutProfilDto>();

            try
            {
                response = await new StatutProfilManager().GetStatutProfilsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveStatutProfils")]
        public async Task<BusinessResponse<StatutProfilDto>> PostSaveStatutProfils([FromBody]BusinessRequest<StatutProfilDto> request)
        {
            var response = new BusinessResponse<StatutProfilDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutProfilManager().SaveStatutProfils(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteStatutProfils")]
        public async Task<BusinessResponse<Boolean>> PostDeleteStatutProfils([FromBody]BusinessRequest<StatutProfilDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new StatutProfilManager().DeleteStatutProfils(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TermeConventions
        [ActionName("GetTermeConventionById")]
        public async Task<BusinessResponse<TermeConventionDto>> GetTermeConventionById(int id)
        {
            var response = new BusinessResponse<TermeConventionDto>();

            try
            {
                response = await new TermeConventionManager().GetTermeConventionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTermeConventionsByCriteria")]
        public async Task<BusinessResponse<TermeConventionDto>> PostGetTermeConventionsByCriteria([FromBody]BusinessRequest<TermeConventionDto> request)
        {
            var response = new BusinessResponse<TermeConventionDto>();

            try
            {
                response = await new TermeConventionManager().GetTermeConventionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTermeConventions")]
        public async Task<BusinessResponse<TermeConventionDto>> PostSaveTermeConventions([FromBody]BusinessRequest<TermeConventionDto> request)
        {
            var response = new BusinessResponse<TermeConventionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TermeConventionManager().SaveTermeConventions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTermeConventions")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTermeConventions([FromBody]BusinessRequest<TermeConventionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TermeConventionManager().DeleteTermeConventions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TrancheAge1s
        [ActionName("GetTrancheAge1ById")]
        public async Task<BusinessResponse<TrancheAge1Dto>> GetTrancheAge1ById(int id)
        {
            var response = new BusinessResponse<TrancheAge1Dto>();

            try
            {
                response = await new TrancheAge1Manager().GetTrancheAge1ById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTrancheAge1sByCriteria")]
        public async Task<BusinessResponse<TrancheAge1Dto>> PostGetTrancheAge1sByCriteria([FromBody]BusinessRequest<TrancheAge1Dto> request)
        {
            var response = new BusinessResponse<TrancheAge1Dto>();

            try
            {
                response = await new TrancheAge1Manager().GetTrancheAge1sByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTrancheAge1s")]
        public async Task<BusinessResponse<TrancheAge1Dto>> PostSaveTrancheAge1s([FromBody]BusinessRequest<TrancheAge1Dto> request)
        {
            var response = new BusinessResponse<TrancheAge1Dto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TrancheAge1Manager().SaveTrancheAge1s(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTrancheAge1s")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTrancheAge1s([FromBody]BusinessRequest<TrancheAge1Dto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TrancheAge1Manager().DeleteTrancheAge1s(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypeAgents
        [ActionName("GetTypeAgentById")]
        public async Task<BusinessResponse<TypeAgentDto>> GetTypeAgentById(int id)
        {
            var response = new BusinessResponse<TypeAgentDto>();

            try
            {
                response = await new TypeAgentManager().GetTypeAgentById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypeAgentsByCriteria")]
        public async Task<BusinessResponse<TypeAgentDto>> PostGetTypeAgentsByCriteria([FromBody]BusinessRequest<TypeAgentDto> request)
        {
            var response = new BusinessResponse<TypeAgentDto>();

            try
            {
                response = await new TypeAgentManager().GetTypeAgentsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypeAgents")]
        public async Task<BusinessResponse<TypeAgentDto>> PostSaveTypeAgents([FromBody]BusinessRequest<TypeAgentDto> request)
        {
            var response = new BusinessResponse<TypeAgentDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeAgentManager().SaveTypeAgents(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypeAgents")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypeAgents([FromBody]BusinessRequest<TypeAgentDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeAgentManager().DeleteTypeAgents(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypePrestataireMedicals
        [ActionName("GetTypePrestataireMedicalById")]
        public async Task<BusinessResponse<TypePrestataireMedicalDto>> GetTypePrestataireMedicalById(int id)
        {
            var response = new BusinessResponse<TypePrestataireMedicalDto>();

            try
            {
                response = await new TypePrestataireMedicalManager().GetTypePrestataireMedicalById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypePrestataireMedicalsByCriteria")]
        public async Task<BusinessResponse<TypePrestataireMedicalDto>> PostGetTypePrestataireMedicalsByCriteria([FromBody]BusinessRequest<TypePrestataireMedicalDto> request)
        {
            var response = new BusinessResponse<TypePrestataireMedicalDto>();

            try
            {
                response = await new TypePrestataireMedicalManager().GetTypePrestataireMedicalsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypePrestataireMedicals")]
        public async Task<BusinessResponse<TypePrestataireMedicalDto>> PostSaveTypePrestataireMedicals([FromBody]BusinessRequest<TypePrestataireMedicalDto> request)
        {
            var response = new BusinessResponse<TypePrestataireMedicalDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypePrestataireMedicalManager().SaveTypePrestataireMedicals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypePrestataireMedicals")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypePrestataireMedicals([FromBody]BusinessRequest<TypePrestataireMedicalDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypePrestataireMedicalManager().DeleteTypePrestataireMedicals(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypeSanctions
        [ActionName("GetTypeSanctionById")]
        public async Task<BusinessResponse<TypeSanctionDto>> GetTypeSanctionById(int id)
        {
            var response = new BusinessResponse<TypeSanctionDto>();

            try
            {
                response = await new TypeSanctionManager().GetTypeSanctionById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypeSanctionsByCriteria")]
        public async Task<BusinessResponse<TypeSanctionDto>> PostGetTypeSanctionsByCriteria([FromBody]BusinessRequest<TypeSanctionDto> request)
        {
            var response = new BusinessResponse<TypeSanctionDto>();

            try
            {
                response = await new TypeSanctionManager().GetTypeSanctionsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypeSanctions")]
        public async Task<BusinessResponse<TypeSanctionDto>> PostSaveTypeSanctions([FromBody]BusinessRequest<TypeSanctionDto> request)
        {
            var response = new BusinessResponse<TypeSanctionDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeSanctionManager().SaveTypeSanctions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypeSanctions")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypeSanctions([FromBody]BusinessRequest<TypeSanctionDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeSanctionManager().DeleteTypeSanctions(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region TypeStatuts
        [ActionName("GetTypeStatutById")]
        public async Task<BusinessResponse<TypeStatutDto>> GetTypeStatutById(int id)
        {
            var response = new BusinessResponse<TypeStatutDto>();

            try
            {
                response = await new TypeStatutManager().GetTypeStatutById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetTypeStatutsByCriteria")]
        public async Task<BusinessResponse<TypeStatutDto>> PostGetTypeStatutsByCriteria([FromBody]BusinessRequest<TypeStatutDto> request)
        {
            var response = new BusinessResponse<TypeStatutDto>();

            try
            {
                response = await new TypeStatutManager().GetTypeStatutsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveTypeStatuts")]
        public async Task<BusinessResponse<TypeStatutDto>> PostSaveTypeStatuts([FromBody]BusinessRequest<TypeStatutDto> request)
        {
            var response = new BusinessResponse<TypeStatutDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeStatutManager().SaveTypeStatuts(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteTypeStatuts")]
        public async Task<BusinessResponse<Boolean>> PostDeleteTypeStatuts([FromBody]BusinessRequest<TypeStatutDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new TypeStatutManager().DeleteTypeStatuts(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region Zones
        [ActionName("GetZoneById")]
        public async Task<BusinessResponse<ZoneDto>> GetZoneById(int id)
        {
            var response = new BusinessResponse<ZoneDto>();

            try
            {
                response = await new ZoneManager().GetZoneById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetZonesByCriteria")]
        public async Task<BusinessResponse<ZoneDto>> PostGetZonesByCriteria([FromBody]BusinessRequest<ZoneDto> request)
        {
            var response = new BusinessResponse<ZoneDto>();

            try
            {
                response = await new ZoneManager().GetZonesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveZones")]
        public async Task<BusinessResponse<ZoneDto>> PostSaveZones([FromBody]BusinessRequest<ZoneDto> request)
        {
            var response = new BusinessResponse<ZoneDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ZoneManager().SaveZones(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteZones")]
        public async Task<BusinessResponse<Boolean>> PostDeleteZones([FromBody]BusinessRequest<ZoneDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ZoneManager().DeleteZones(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ZoneLocalites
        [ActionName("GetZoneLocaliteById")]
        public async Task<BusinessResponse<ZoneLocaliteDto>> GetZoneLocaliteById(int id)
        {
            var response = new BusinessResponse<ZoneLocaliteDto>();

            try
            {
                response = await new ZoneLocaliteManager().GetZoneLocaliteById(id);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        [ActionName("GetZoneLocalitesByCriteria")]
        public async Task<BusinessResponse<ZoneLocaliteDto>> PostGetZoneLocalitesByCriteria([FromBody]BusinessRequest<ZoneLocaliteDto> request)
        {
            var response = new BusinessResponse<ZoneLocaliteDto>();

            try
            {
                response = await new ZoneLocaliteManager().GetZoneLocalitesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveZoneLocalites")]
        public async Task<BusinessResponse<ZoneLocaliteDto>> PostSaveZoneLocalites([FromBody]BusinessRequest<ZoneLocaliteDto> request)
        {
            var response = new BusinessResponse<ZoneLocaliteDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ZoneLocaliteManager().SaveZoneLocalites(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("DeleteZoneLocalites")]
        public async Task<BusinessResponse<Boolean>> PostDeleteZoneLocalites([FromBody]BusinessRequest<ZoneLocaliteDto> request)
        {
            var response = new BusinessResponse<Boolean>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ZoneLocaliteManager().DeleteZoneLocalites(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }
        #endregion

        #region ViewAdherentPayeurs
        [ActionName("GetViewAdherentPayeursByCriteria")]
        public async Task<BusinessResponse<ViewAdherentPayeurDto>> PostGetViewAdherentPayeursByCriteria([FromBody]BusinessRequest<ViewAdherentPayeurDto> request)
        {
            var response = new BusinessResponse<ViewAdherentPayeurDto>();

            try
            {
                response = await new ViewAdherentPayeurManager().GetViewAdherentPayeursByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewAdherentPayeurs")]
        public async Task<BusinessResponse<ViewAdherentPayeurDto>> PostSaveViewAdherentPayeurs([FromBody]BusinessRequest<ViewAdherentPayeurDto> request)
        {
            var response = new BusinessResponse<ViewAdherentPayeurDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewAdherentPayeurManager().SaveViewAdherentPayeurs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewSouscripteurPayeurs
        [ActionName("GetViewSouscripteurPayeursByCriteria")]
        public async Task<BusinessResponse<ViewSouscripteurPayeurDto>> PostGetViewSouscripteurPayeursByCriteria([FromBody]BusinessRequest<ViewSouscripteurPayeurDto> request)
        {
            var response = new BusinessResponse<ViewSouscripteurPayeurDto>();

            try
            {
                response = await new ViewSouscripteurPayeurManager().GetViewSouscripteurPayeursByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewSouscripteurPayeurs")]
        public async Task<BusinessResponse<ViewSouscripteurPayeurDto>> PostSaveViewSouscripteurPayeurs([FromBody]BusinessRequest<ViewSouscripteurPayeurDto> request)
        {
            var response = new BusinessResponse<ViewSouscripteurPayeurDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewSouscripteurPayeurManager().SaveViewSouscripteurPayeurs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewSouscriptionAdherents
        [ActionName("GetViewSouscriptionAdherentsByCriteria")]
        public async Task<BusinessResponse<ViewSouscriptionAdherentDto>> PostGetViewSouscriptionAdherentsByCriteria([FromBody]BusinessRequest<ViewSouscriptionAdherentDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionAdherentDto>();

            try
            {
                response = await new ViewSouscriptionAdherentManager().GetViewSouscriptionAdherentsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewSouscriptionAdherents")]
        public async Task<BusinessResponse<ViewSouscriptionAdherentDto>> PostSaveViewSouscriptionAdherents([FromBody]BusinessRequest<ViewSouscriptionAdherentDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionAdherentDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewSouscriptionAdherentManager().SaveViewSouscriptionAdherents(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewSouscriptionAdherentPrimes
        [ActionName("GetViewSouscriptionAdherentPrimesByCriteria")]
        public async Task<BusinessResponse<ViewSouscriptionAdherentPrimeDto>> PostGetViewSouscriptionAdherentPrimesByCriteria([FromBody]BusinessRequest<ViewSouscriptionAdherentPrimeDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionAdherentPrimeDto>();

            try
            {
                response = await new ViewSouscriptionAdherentPrimeManager().GetViewSouscriptionAdherentPrimesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewSouscriptionAdherentPrimes")]
        public async Task<BusinessResponse<ViewSouscriptionAdherentPrimeDto>> PostSaveViewSouscriptionAdherentPrimes([FromBody]BusinessRequest<ViewSouscriptionAdherentPrimeDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionAdherentPrimeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewSouscriptionAdherentPrimeManager().SaveViewSouscriptionAdherentPrimes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewSouscriptionAssures
        [ActionName("GetViewSouscriptionAssuresByCriteria")]
        public async Task<BusinessResponse<ViewSouscriptionAssureDto>> PostGetViewSouscriptionAssuresByCriteria([FromBody]BusinessRequest<ViewSouscriptionAssureDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionAssureDto>();

            try
            {
                response = await new ViewSouscriptionAssureManager().GetViewSouscriptionAssuresByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewSouscriptionAssures")]
        public async Task<BusinessResponse<ViewSouscriptionAssureDto>> PostSaveViewSouscriptionAssures([FromBody]BusinessRequest<ViewSouscriptionAssureDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionAssureDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewSouscriptionAssureManager().SaveViewSouscriptionAssures(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewSouscriptionAssureCartes
        [ActionName("GetViewSouscriptionAssureCartesByCriteria")]
        public async Task<BusinessResponse<ViewSouscriptionAssureCarteDto>> PostGetViewSouscriptionAssureCartesByCriteria([FromBody]BusinessRequest<ViewSouscriptionAssureCarteDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionAssureCarteDto>();

            try
            {
                response = await new ViewSouscriptionAssureCarteManager().GetViewSouscriptionAssureCartesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewSouscriptionAssureCartes")]
        public async Task<BusinessResponse<ViewSouscriptionAssureCarteDto>> PostSaveViewSouscriptionAssureCartes([FromBody]BusinessRequest<ViewSouscriptionAssureCarteDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionAssureCarteDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewSouscriptionAssureCarteManager().SaveViewSouscriptionAssureCartes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewSouscriptionCarteActifs
        [ActionName("GetViewSouscriptionCarteActifsByCriteria")]
        public async Task<BusinessResponse<ViewSouscriptionCarteActifDto>> PostGetViewSouscriptionCarteActifsByCriteria([FromBody]BusinessRequest<ViewSouscriptionCarteActifDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionCarteActifDto>();

            try
            {
                response = await new ViewSouscriptionCarteActifManager().GetViewSouscriptionCarteActifsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewSouscriptionCarteActifs")]
        public async Task<BusinessResponse<ViewSouscriptionCarteActifDto>> PostSaveViewSouscriptionCarteActifs([FromBody]BusinessRequest<ViewSouscriptionCarteActifDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionCarteActifDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewSouscriptionCarteActifManager().SaveViewSouscriptionCarteActifs(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewSouscriptionCarteRenouvellers
        [ActionName("GetViewSouscriptionCarteRenouvellersByCriteria")]
        public async Task<BusinessResponse<ViewSouscriptionCarteRenouvellerDto>> PostGetViewSouscriptionCarteRenouvellersByCriteria([FromBody]BusinessRequest<ViewSouscriptionCarteRenouvellerDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionCarteRenouvellerDto>();

            try
            {
                response = await new ViewSouscriptionCarteRenouvellerManager().GetViewSouscriptionCarteRenouvellersByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewSouscriptionCarteRenouvellers")]
        public async Task<BusinessResponse<ViewSouscriptionCarteRenouvellerDto>> PostSaveViewSouscriptionCarteRenouvellers([FromBody]BusinessRequest<ViewSouscriptionCarteRenouvellerDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionCarteRenouvellerDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewSouscriptionCarteRenouvellerManager().SaveViewSouscriptionCarteRenouvellers(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewSouscriptionDemandeDuplicatas
        [ActionName("GetViewSouscriptionDemandeDuplicatasByCriteria")]
        public async Task<BusinessResponse<ViewSouscriptionDemandeDuplicataDto>> PostGetViewSouscriptionDemandeDuplicatasByCriteria([FromBody]BusinessRequest<ViewSouscriptionDemandeDuplicataDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionDemandeDuplicataDto>();

            try
            {
                response = await new ViewSouscriptionDemandeDuplicataManager().GetViewSouscriptionDemandeDuplicatasByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewSouscriptionDemandeDuplicatas")]
        public async Task<BusinessResponse<ViewSouscriptionDemandeDuplicataDto>> PostSaveViewSouscriptionDemandeDuplicatas([FromBody]BusinessRequest<ViewSouscriptionDemandeDuplicataDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionDemandeDuplicataDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewSouscriptionDemandeDuplicataManager().SaveViewSouscriptionDemandeDuplicatas(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewPrestationActes
        [ActionName("GetViewPrestationActesByCriteria")]
        public async Task<BusinessResponse<ViewPrestationActeDto>> PostGetViewPrestationActesByCriteria([FromBody]BusinessRequest<ViewPrestationActeDto> request)
        {
            var response = new BusinessResponse<ViewPrestationActeDto>();

            try
            {
                response = await new ViewPrestationActeManager().GetViewPrestationActesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewPrestationActes")]
        public async Task<BusinessResponse<ViewPrestationActeDto>> PostSaveViewPrestationActes([FromBody]BusinessRequest<ViewPrestationActeDto> request)
        {
            var response = new BusinessResponse<ViewPrestationActeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewPrestationActeManager().SaveViewPrestationActes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewPayeurPrimes
        [ActionName("GetViewPayeurPrimesByCriteria")]
        public async Task<BusinessResponse<ViewPayeurPrimeDto>> PostGetViewPayeurPrimesByCriteria([FromBody]BusinessRequest<ViewPayeurPrimeDto> request)
        {
            var response = new BusinessResponse<ViewPayeurPrimeDto>();

            try
            {
                response = await new ViewPayeurPrimeManager().GetViewPayeurPrimesByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewPayeurPrimes")]
        public async Task<BusinessResponse<ViewPayeurPrimeDto>> PostSaveViewPayeurPrimes([FromBody]BusinessRequest<ViewPayeurPrimeDto> request)
        {
            var response = new BusinessResponse<ViewPayeurPrimeDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewPayeurPrimeManager().SaveViewPayeurPrimes(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewSouscriptionPayers
        [ActionName("GetViewSouscriptionPayersByCriteria")]
        public async Task<BusinessResponse<ViewSouscriptionPayerDto>> PostGetViewSouscriptionPayersByCriteria([FromBody]BusinessRequest<ViewSouscriptionPayerDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionPayerDto>();

            try
            {
                response = await new ViewSouscriptionPayerManager().GetViewSouscriptionPayersByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewSouscriptionPayers")]
        public async Task<BusinessResponse<ViewSouscriptionPayerDto>> PostSaveViewSouscriptionPayers([FromBody]BusinessRequest<ViewSouscriptionPayerDto> request)
        {
            var response = new BusinessResponse<ViewSouscriptionPayerDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewSouscriptionPayerManager().SaveViewSouscriptionPayers(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion

        #region ViewGarants
        [ActionName("GetViewGarantsByCriteria")]
        public async Task<BusinessResponse<ViewGarantDto>> PostGetViewGarantsByCriteria([FromBody]BusinessRequest<ViewGarantDto> request)
        {
            var response = new BusinessResponse<ViewGarantDto>();

            try
            {
                response = await new ViewGarantManager().GetViewGarantsByCriteria(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        [ActionName("SaveViewGarants")]
        public async Task<BusinessResponse<ViewGarantDto>> PostSaveViewGarants([FromBody]BusinessRequest<ViewGarantDto> request)
        {
            var response = new BusinessResponse<ViewGarantDto>();
            
            try
            {
                request.CanApplyTransaction = true;
                response = await new ViewGarantManager().SaveViewGarants(request);
                if (response.HasError) throw new Exception(response.Message);
            }
            catch (Exception ex)
            {
                response.Items = null;
                CustomException.Write(response, ex);
            }

            return response;
        }

        #endregion
    }*/
}
