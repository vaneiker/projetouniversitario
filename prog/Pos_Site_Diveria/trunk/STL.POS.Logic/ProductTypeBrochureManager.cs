using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STL.POS.Data.NewVersion.Repository;
using Entity.Entities;

namespace STL.POS.Logic
{
    public class ProductTypeBrochureManager: BaseManager
    {
        public readonly ProductTypeBrochureRepository productTypeBrochureRepository;

        public ProductTypeBrochureManager()
        {
            productTypeBrochureRepository = new ProductTypeBrochureRepository();
        }

        public IEnumerable<ProductTypeBrochure> getProductTypeBrochure(int productTypeFamilyBrochureId)
        {
            return
                productTypeBrochureRepository.getProductTypeBrochure(productTypeFamilyBrochureId);
        }

        public IEnumerable<Generic> getCoverageTypesBrochure(int productTypeBrochure_Id)
        {
            return
                productTypeBrochureRepository.getCoverageTypesBrochure(productTypeBrochure_Id);
        }

        public IEnumerable<CoverageDetailBrochure> getCoverageDetailBrochure(int CoverageBrochure_Id)
        {
            return
                productTypeBrochureRepository.getCoverageDetailBrochure(CoverageBrochure_Id);
        }
    }
}
