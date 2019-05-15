using Entity.Entities;
using STL.POS.Data.NewVersion.EdmxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data.NewVersion.Repository
{
    public class ProductLimitsRepository : BaseRepository
    {
        public ProductLimitsRepository() { }

        #region Set
        public virtual BaseEntity SetProudctLimits(ProductLimits.Parameter parameter)
        {
            BaseEntity result;
            IEnumerable<SP_SET_PRODUCT_LIMITS_Result> temp;

            temp = PosContex.SP_SET_PRODUCT_LIMITS(
                                                     parameter.id,
                                                     parameter.isSelected,
                                                     parameter.sdPrime,
                                                     parameter.tpPrime,
                                                     parameter.servicesPrime,
                                                     parameter.iSC,
                                                     parameter.iSCPercentage,
                                                     parameter.totalPrime,
                                                     parameter.totalIsc,
                                                     parameter.totalDiscount,
                                                     parameter.selectedDeductibleCoreId,
                                                     parameter.selectedDeductibleName,
                                                     parameter.vehicleProduct_Id,
                                                     parameter.userId
                                                  );
            result = temp.Select(q => new BaseEntity()
            {
                EntityId = q.Id,
                Action = q.Action
            })
            .FirstOrDefault();

            return result;
        }
        #endregion

        #region Get

        public virtual IEnumerable<ProductsDataFromSysflex> GetProductsSysflex(int codRamo, int vehicleTypeCoreId, int? productID, int vehicleYear)
        {
            IEnumerable<ProductsDataFromSysflex> result;
            IEnumerable<SP_GET_PRODUCTS_SYSFLEX_Result> temp;
            temp = PosContex.SP_GET_PRODUCTS_SYSFLEX(codRamo, vehicleTypeCoreId, productID, vehicleYear);
            result = temp.Select(x => new ProductsDataFromSysflex()
            {
                Ramo = x.Ramo,
                SubRamo = x.SubRamo.GetValueOrDefault(),
                SubRamoName = x.SubRamoName,
                Year = x.Year,
                //TipoVehiculo = x.TipoVehiculo,
                ProductoId = x.ProductoId,
                //ProductoId2 = x.ProductoId2,
                Descripcion = x.Descripcion,
                PorcientoInicial = x.PorcientoInicial,
                PorcientoFinal = x.PorcientoFinal,
                MontoInicial = x.MontoInicial,
                MontoFinal = x.MontoFinal,
                Prima = x.Prima,
                Porciento = x.Porciento,
                Comentario = x.Comentario,
                Calculo = x.Calculo,
                Compania = x.Compania,
                TipoPoliza = x.TipoPoliza.GetValueOrDefault(),
                DescTipoPoliza = x.DescTipoPoliza,
                RequiereInspeccion = x.RequiereInspeccion,
                IdCapacidad = x.IdCapacidad,
                DescCapacidad = x.DescCapacidad,
                IdUso = x.IdUso,
                DescUso = x.DescUso
            })
            .ToArray();

            return result;
        }

        #endregion
    }
}
