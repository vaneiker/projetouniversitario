using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DI.UnderWriting.IllusData.Interfaces;

namespace WEB.NewBusiness.Common.Illustration.BusinessLogic
{

    public class IllustrationTableData
    {
        private long customerPlanNo;
        private IIllusData oIllusDataManager;
        public IllustrationTableData(long customerPlanNo, IIllusData oIllusDataManager)
        {
            this.customerPlanNo = customerPlanNo;
            this.oIllusDataManager = oIllusDataManager;
        }

        public void SaveLifeData(DataTable dt)
        {
            oIllusDataManager.DeleteCustomerPlanLife(customerPlanNo);

            foreach (DataRow dr in dt.Rows)
            {
                var data = new Entity.UnderWriting.IllusData.Illustrator.CustomerPlanLife();

                data.CustomerPlanNo = this.customerPlanNo;
                data.Age = Convert.ToInt32(dr["age"]);
                data.Year = Convert.ToInt32(dr["sno"]);

                if (dr["premium"].GetType().ToString() != "System.DBNull")
                    data.Premium = Convert.ToDecimal(dr["premium"]);

                if (dr["accountvalue1"].GetType().ToString() != "System.DBNull")
                    data.AccountValue1 = Convert.ToDecimal(dr["accountvalue1"]);
                if (dr["rescatevalue1"].GetType().ToString() != "System.DBNull")
                    data.SurrenderValue1 = Convert.ToDecimal(dr["rescatevalue1"]);
                if (dr["insuredamount1"].GetType().ToString() != "System.DBNull")
                    data.DeathBenefit1 = Convert.ToDecimal(dr["insuredamount1"]);

                if (dr["accountvalue2"].GetType().ToString() != "System.DBNull")
                    data.AccountValue2 = Convert.ToDecimal(dr["accountvalue2"]);
                if (dr["rescatevalue2"].GetType().ToString() != "System.DBNull")
                    data.SurrenderValue2 = Convert.ToDecimal(dr["rescatevalue2"]);
                if (dr["insuredamount2"].GetType().ToString() != "System.DBNull")
                    data.DeathBenefit2 = Convert.ToDecimal(dr["insuredamount2"]);

                if (dr["accountvalue3"].GetType().ToString() != "System.DBNull")
                    data.AccountValue3 = Convert.ToDecimal(dr["accountvalue3"]);
                if (dr["rescatevalue3"].GetType().ToString() != "System.DBNull")
                    data.SurrenderValue3 = Convert.ToDecimal(dr["rescatevalue3"]);
                if (dr["insuredamount3"].GetType().ToString() != "System.DBNull")
                    data.DeathBenefit3 = Convert.ToDecimal(dr["insuredamount3"]);

                oIllusDataManager.InsertCustomerPlanLife(data);
            }
        }

        public void SaveAnnuityData(DataTable dt, string productCode)
        {
            oIllusDataManager.DeleteCustomerPlanAnnuity(customerPlanNo);

            foreach (DataRow dr in dt.Rows)
            {
                var data = new Entity.UnderWriting.IllusData.Illustrator.CustomerPlanAnnuity();

                data.CustomerPlanNo = this.customerPlanNo;
                data.Age = Convert.ToInt32(dr["age"]);
                data.Year = Convert.ToInt32(dr["sno"]);

                if (dr["accumulatedpremium"].GetType().ToString() != "System.DBNull")
                    data.AccumulatedContributions = Convert.ToDecimal(dr["accumulatedpremium"]);

                if (dr["deathbenefit"].GetType().ToString() != "System.DBNull")
                    data.DeathBenefit = Convert.ToDecimal(dr["deathbenefit"]);

                if (dr["discbenefit"].GetType().ToString() != "System.DBNull")
                    data.BenefitExclusion = Convert.ToDecimal(dr["discbenefit"]);

                //for eduplan growth, scholar, horizon growth and axyz
                if (!productCode.Equals("EDU") && !productCode.Equals("HRZ"))
                {
                    if (dr["accountvalue"].GetType().ToString() != "System.DBNull")
                        data.AccountValue = Convert.ToDecimal(dr["accountvalue"]);
                }

                if (dr["rescatevalue"].GetType().ToString() != "System.DBNull")
                    data.SurrenderValue = Convert.ToDecimal(dr["rescatevalue"]);

                if (dr["partialretirementamount"].GetType().ToString() != "System.DBNull")
                    data.AnnualPartialWithDrawal = Convert.ToDecimal(dr["partialretirementamount"]);

                oIllusDataManager.InsertCustomerPlanAnnuity(data);
            }
        }

        public void SaveTermData(DataTable dt, DataTable dt2)
        {
            oIllusDataManager.DeleteCustomerPlanTerm(customerPlanNo);

            Action<int, DataRow> action = (tableNo, dr) =>
            {
                var data = new Entity.UnderWriting.IllusData.Illustrator.CustomerPlanTerm();
                data.CustomerPlanNo = this.customerPlanNo;
                data.TableNo = 1;
                data.Age = Convert.ToInt32(dr["age"]);
                data.Year = Convert.ToInt32(dr["sno"]);

                if (dr["regularpremium"].GetType().ToString() != "System.DBNull")
                    data.PrimaBasicCoverage = Convert.ToDecimal(dr["regularpremium"]);
                if (dr["riderpremium"].GetType().ToString() != "System.DBNull")
                    data.PremiumExtras = Convert.ToDecimal(dr["riderpremium"]);
                if (dr["totalpremium"].GetType().ToString() != "System.DBNull")
                    data.TotalPremium = Convert.ToDecimal(dr["totalpremium"]);
                if (dr["accumulatedpremium"].GetType().ToString() != "System.DBNull")
                    data.AccumulatedPremiums = Convert.ToDecimal(dr["accumulatedpremium"]);
                if (dr["deathbenefit"].GetType().ToString() != "System.DBNull")
                    data.DeathBenefit = Convert.ToDecimal(dr["deathbenefit"]);

                oIllusDataManager.InsertCustomerPlanTerm(data);
            };

            foreach (DataRow dr in dt.Rows)
                action(1, dr);

            foreach (DataRow dr in dt2.Rows)
                action(2, dr);
        }
    }
}