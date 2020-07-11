﻿using Entity.Entities;
using STL.POS.Data.NewVersion.EdmxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data.NewVersion.Repository
{
    public class ProductTypeBrochureRepository : BaseRepository
    {
        public ProductTypeBrochureRepository() { }

        public IEnumerable<ProductTypeBrochure> getProductTypeBrochure(int productTypeFamilyBrochure_Id)
        {
            IEnumerable<ProductTypeBrochure> result;
            IEnumerable<SP_GET_PRODUCT_TYPE_BROCHURE_Result> temp;
            temp = PosContex.SP_GET_PRODUCT_TYPE_BROCHURE(productTypeFamilyBrochure_Id);

            result = temp.Select(q => new ProductTypeBrochure
            {
                Id = q.Id,
                Name = q.Name,
                Coberturas = q.Coberturas,
                Deducible = q.Deducible,
                Elegibilidad = q.Elegibilidad,
                ProductTypeFamilyBrochure_Id = q.ProductTypeFamilyBrochure_Id.GetValueOrDefault()
            })
            .ToArray();

            return result;
        }

        public IEnumerable<Generic> getCoverageTypesBrochure(int productTypeBrochure_Id)
        {
            IEnumerable<Generic> result;
            IEnumerable<SP_GET_COVERAGE_TYPES_BROCHURE_Result> temp;
            temp = PosContex.SP_GET_COVERAGE_TYPES_BROCHURE(productTypeBrochure_Id);

            result = temp.Select(q => new Generic
            {
                Value = q.Id,
                name = q.Name
            })
            .ToArray();

            return result;
        }


        public IEnumerable<CoverageDetailBrochure> getCoverageDetailBrochure(int CoverageBrochure_Id)
        {
            IEnumerable<CoverageDetailBrochure> result;
            IEnumerable<SP_GET_COVERAGE_DETAIL_BROCHURE_Result> temp;
            temp = PosContex.SP_GET_COVERAGE_DETAIL_BROCHURE(CoverageBrochure_Id);

            result = temp.Select(q => new CoverageDetailBrochure
            {
                Id = q.Id,
                CoverageName = q.CoverageName,
                CoverageBrochureId = q.CoverageBrochure_Id,
                CoverageType = q.CoverageType,
                Value = q.Value
            })
            .ToArray();

            return result;
        }
        
    }
}