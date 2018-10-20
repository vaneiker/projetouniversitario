using Entity.Entities;
using Entity.Entities.WSEntities;
using STL.POS.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace STL.POS.Frontend.Web.NewVersion.CustomCode
{
    public static class ProductsFromSysflex
    {
        public static IList<VehicleTypeWS> GetProductsSysflex(int vehicleTypeCoreId, int vehicleYear, int? productID, int codRamo, string AgentCode = null)
        {
            ProductLimitsManager oManager = new ProductLimitsManager();
            List<ProductsDataFromSysflex> prods = oManager.GetProductsSysflex(codRamo, vehicleTypeCoreId, productID, vehicleYear).ToList();
            var prodsAux = oManager.GetProductsSysflex(codRamo, vehicleTypeCoreId, productID, vehicleYear).ToList();
            var ExcludeCoverages = new List<Tuple<string, string>>(0);
            var output = new List<VehicleTypeWS>();

            try
            {
                //Filtrar prod segun los productos del agente
                var oQuotationManager = new QuotationManager();
                var ProductExclude = oQuotationManager.GetProductExcludeByAgent(AgentCode).Select(P => new
                {
                    P.ProductDesc,
                    P.SubramoDesc
                }).ToList();

                if (ProductExclude.Any())
                {
                    prodsAux = prods;

                    var UniqueProducts = prods.Select(x => x.DescTipoPoliza).Distinct().ToList();

                    //Proceso de exclusion de productos completos
                    foreach (var item in UniqueProducts)
                    {
                        var productName = item;
                        var ListProduct = ProductExclude.Where(x => x.ProductDesc == item);
                        var ExcludeAll = ListProduct.Any(p => string.IsNullOrEmpty(p.SubramoDesc));

                        if (ExcludeAll)
                            prodsAux.RemoveAll(x => x.DescTipoPoliza.Trim() == productName.Trim());
                        else
                            foreach (var itemProduct in ListProduct)
                                ExcludeCoverages.Add(new Tuple<string, string>(productName, itemProduct.SubramoDesc));
                    }

                    ////Proceso para excluir coberturas
                    foreach (var item in ExcludeCoverages)
                        prodsAux.RemoveAll(x => x.SubRamoName.Trim() == item.Item2.Trim());

                    prods = prodsAux; 
                }

                var vehicleTypes = (from p in prods
                                    orderby p.Descripcion
                                    select p.Descripcion.Trim()).Distinct().ToList();

                foreach (var vtId in vehicleTypes.OrderBy(t => t))
                {
                    var vehicleType = new VehicleTypeWS();
                    vehicleType.Name = vtId;

                    /*----------------------------------------------*/
                    vehicleType.NewUsages = new List<UsageByProductWS>();

                    var Usages = (from pr in prods
                                  where pr.Descripcion == vtId
                                  select new { IdUso = pr.IdUso, DescUso = pr.DescUso }).Distinct().ToList();

                    foreach (var u in Usages)
                    {
                        if (!string.IsNullOrEmpty(u.DescUso))
                        {
                            var us = new UsageByProductWS();
                            us.idUso = u.IdUso;
                            us.descUso = u.DescUso;
                            us.allowed = 1;
                            us.message = "";

                            vehicleType.NewUsages.Add(us);
                        }
                    }
                    /*----------------------------------------------*/

                    /*Uso por Producto*/
                    vehicleType.ProductByUsages = new List<ProductByUsageWS>();

                    var UsagesByProd = (from pr in prods
                                        where pr.Descripcion == vtId
                                        select new { UsoDescripcion = pr.DescUso, ProductoDescripcion = pr.DescTipoPoliza }).Distinct().ToList();

                    foreach (var u in UsagesByProd)
                    {
                        if (!string.IsNullOrEmpty(u.UsoDescripcion))
                        {
                            var us = new ProductByUsageWS();
                            us.UsoDescripcion = u.UsoDescripcion;
                            us.ProductoDescripcion = u.ProductoDescripcion;

                            vehicleType.ProductByUsages.Add(us);
                        }
                    }
                    /**/

                    /*Producto Cobertura por Uso */
                    vehicleType.CoveragesByUsages = new List<CoveragesByUsageWS>();

                    var CovsByUsages = (from pr in prods
                                        where pr.Descripcion == vtId
                                        //&& pr.TipoPoliza == p.TipoPoliza
                                        //select new { Id = pr.CoverageID, Name = pr.CoverageName, Type = pr.ProducttypeName, IsLaw = pr.RequiereInspeccion == false ? true : false }).Distinct().ToList();
                                        select new
                                        {
                                            Id = pr.SubRamo,
                                            Name = pr.SubRamoName,
                                            Type = pr.DescTipoPoliza,
                                            IsLaw = pr.RequiereInspeccion == false ? true : false,
                                            UsoDescripcion = pr.DescUso,
                                            ProductName = pr.DescTipoPoliza
                                        }).Distinct().ToList();

                    foreach (var c in CovsByUsages)
                    {
                        if (!string.IsNullOrEmpty(c.UsoDescripcion))
                        {
                            var cov = new CoveragesByUsageWS();
                            cov.Id = c.Id;
                            cov.Name = c.Name;
                            cov.IsLaw = c.IsLaw;
                            cov.UsoDescripcion = c.UsoDescripcion;
                            cov.ProductName = c.ProductName;

                            vehicleType.CoveragesByUsages.Add(cov);
                        }
                    }
                    /**/


                    vehicleType.Products = new List<ProductWS>();

                    var products = (from p in prods
                                    where p.Descripcion == vtId
                                    select new { p.TipoPoliza, p.IdCapacidad, p.DescCapacidad }).Distinct().ToList();
                    if (products.Count() <= 0) { continue; }

                    foreach (var p in products)
                    {
                        var prod = new ProductWS();
                        prod.Id = p.TipoPoliza;

                        var prodname = prods.FirstOrDefault(pd => pd.TipoPoliza == p.TipoPoliza);

                        if (prodname != null)
                        {
                            prod.Name = prodname.DescTipoPoliza;

                            prod.IdCapacidad = p.IdCapacidad.HasValue ? p.IdCapacidad.Value : (int?)null;
                            prod.DescCapacidad = p.DescCapacidad;
                        }
                        else
                        {
                            continue;
                        }

                        prod.Coverages = new List<CoverageWS>();

                        //Original 30-08-2017
                        /*
                        var cobs = (from pr in prods
                                    where pr.Descripcion == vtId
                                    && pr.TipoPoliza == p.TipoPoliza
                                    //select new { Id = pr.CoverageID, Name = pr.CoverageName, Type = pr.ProducttypeName, IsLaw = pr.RequiereInspeccion == false ? true : false }).Distinct().ToList();
                                    select new { Id = pr.SubRamo, Name = pr.SubRamoName, Type = pr.DescTipoPoliza, IsLaw = pr.RequiereInspeccion == false ? true : false }).Distinct().ToList();                        

                        foreach (var c in cobs)
                        {
                            var cov = new CoverageWS();
                            cov.Id = c.Id;
                            cov.Name = c.Name;
                            cov.IsLaw = c.IsLaw;

                            prod.Coverages.Add(cov);
                        }                        
                        */

                        prod.Coverages = prod.Coverages.OrderBy(c => c.Name).ToList();

                        vehicleType.Products.Add(prod);
                    }

                    vehicleType.Products = vehicleType.Products.OrderBy(p => p.Name).ToList();

                    vehicleType.NewUsages = vehicleType.NewUsages.OrderBy(c => c.descUso).ToList();

                    vehicleType.ProductByUsages = vehicleType.ProductByUsages.OrderBy(c => c.ProductoDescripcion).ToList();

                    vehicleType.CoveragesByUsages = vehicleType.CoveragesByUsages.OrderBy(c => c.Name).ToList();

                    output.Add(vehicleType);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return output;
        }

        public static IList<VehicleTypeWS> GetVehicleTypes_NewPV(WsProxy.SysflexService.PolicyProductSysFlexProductNew[] prods)
        {
            var output = new List<VehicleTypeWS>();

            var vehicleTypes = (from p in prods
                                orderby p.Descripcion //p.ProductName
                                select p.Descripcion.Trim() /*p.ProductName*/).Distinct().ToList();

            foreach (var vtId in vehicleTypes.OrderBy(t => t))
            {
                var vehicleType = new VehicleTypeWS();
                vehicleType.Name = vtId;

                /*----------------------------------------------*/
                vehicleType.NewUsages = new List<UsageByProductWS>();

                var Usages = (from pr in prods
                              where pr.Descripcion == vtId
                              //&& pr.TipoPoliza == p.TipoPoliza
                              select new { IdUso = pr.IdUso, DescUso = pr.DescUso }).Distinct().ToList();

                foreach (var u in Usages)
                {
                    var us = new UsageByProductWS();
                    us.idUso = u.IdUso;
                    us.descUso = u.DescUso;
                    us.allowed = 1;
                    us.message = "";

                    vehicleType.NewUsages.Add(us);
                }
                /*----------------------------------------------*/

                /*Uso por Producto*/
                vehicleType.ProductByUsages = new List<ProductByUsageWS>();

                var UsagesByProd = (from pr in prods
                                    where pr.Descripcion == vtId
                                    select new { UsoDescripcion = pr.DescUso, ProductoDescripcion = pr.DescTipoPoliza }).Distinct().ToList();

                foreach (var u in UsagesByProd)
                {
                    var us = new ProductByUsageWS();
                    us.UsoDescripcion = u.UsoDescripcion;
                    us.ProductoDescripcion = u.ProductoDescripcion;

                    vehicleType.ProductByUsages.Add(us);
                }
                /**/

                /*Producto Cobertura por Uso */
                vehicleType.CoveragesByUsages = new List<CoveragesByUsageWS>();

                var CovsByUsages = (from pr in prods
                                    where pr.Descripcion == vtId
                                    //&& pr.TipoPoliza == p.TipoPoliza
                                    //select new { Id = pr.CoverageID, Name = pr.CoverageName, Type = pr.ProducttypeName, IsLaw = pr.RequiereInspeccion == false ? true : false }).Distinct().ToList();
                                    select new
                                    {
                                        Id = pr.SubRamo,
                                        Name = pr.SubRamoName,
                                        Type = pr.DescTipoPoliza,
                                        IsLaw = pr.RequiereInspeccion == false ? true : false,
                                        UsoDescripcion = pr.DescUso,
                                        ProductName = pr.DescTipoPoliza
                                    }).Distinct().ToList();

                foreach (var c in CovsByUsages)
                {
                    var cov = new CoveragesByUsageWS();
                    cov.Id = c.Id;
                    cov.Name = c.Name;
                    cov.IsLaw = c.IsLaw;
                    cov.UsoDescripcion = c.UsoDescripcion;
                    cov.ProductName = c.ProductName;

                    vehicleType.CoveragesByUsages.Add(cov);
                }
                /**/

                vehicleType.Products = new List<ProductWS>();

                var products = (from p in prods
                                where p.Descripcion == vtId
                                //select p.TipoPoliza /*p.ProductTypeID.Value*/).Distinct().ToList();                                
                                select new { p.TipoPoliza, p.IdCapacidad, p.DescCapacidad/*, p.IdUso, p.DescUso*/ }/*p.ProductTypeID.Value*/).Distinct().ToList();
                if (products.Count() <= 0) { continue; }

                foreach (var p in products)
                {
                    var prod = new ProductWS();
                    prod.Id = p.TipoPoliza;

                    //var prodname = prods.FirstOrDefault(pd => pd.ProductTypeID.HasValue && pd.ProductTypeID.Value == p);
                    var prodname = prods.FirstOrDefault(pd => pd.TipoPoliza == p.TipoPoliza);

                    if (prodname != null)
                    {
                        prod.Name = prodname.DescTipoPoliza;

                        //Nuevos
                        prod.IdCapacidad = p.IdCapacidad.HasValue ? p.IdCapacidad.Value : (int?)null;
                        prod.DescCapacidad = p.DescCapacidad;

                        //prod.IdUso = p.IdUso.HasValue ? p.IdUso.Value : (int?)null;
                        //prod.DescUso = p.DescUso;
                        //
                    }
                    else
                    {
                        continue;
                    }

                    prod.Coverages = new List<CoverageWS>();

                    var cobs = (from pr in prods
                                where pr.Descripcion == vtId
                                && pr.TipoPoliza == p.TipoPoliza
                                //select new { Id = pr.CoverageID, Name = pr.CoverageName, Type = pr.ProducttypeName, IsLaw = pr.RequiereInspeccion == false ? true : false }).Distinct().ToList();
                                select new { Id = pr.SubRamo, Name = pr.SubRamoName, Type = pr.DescTipoPoliza, IsLaw = pr.RequiereInspeccion == false ? true : false }).Distinct().ToList();

                    /*
                     NOTA:
                     Si un producto requiere inspección, eso significa que no es de Ley, si no la requiere es un producto de ley.                     
                     pr.RequiereInspeccion == false ? true : false
                     */

                    foreach (var c in cobs)
                    {
                        var cov = new CoverageWS();
                        cov.Id = c.Id;
                        cov.Name = c.Name;
                        cov.IsLaw = c.IsLaw;

                        prod.Coverages.Add(cov);
                    }

                    prod.Coverages = prod.Coverages.OrderBy(c => c.Name).ToList();

                    vehicleType.Products.Add(prod);
                }

                vehicleType.Products = vehicleType.Products.OrderBy(p => p.Name).ToList();

                vehicleType.NewUsages = vehicleType.NewUsages.OrderBy(c => c.descUso).ToList();

                vehicleType.ProductByUsages = vehicleType.ProductByUsages.OrderBy(c => c.ProductoDescripcion).ToList();

                output.Add(vehicleType);
            }

            return output;
        }
    }
}