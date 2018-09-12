using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.NewBusiness.Common.Illustration.BusinessLogic
{
    public class Mortalityrates
    {
        public static double getMortalityrate(string productcode, bool isFixed, string ridertypecode, int age, string gendercode, string smoker, RulesService rulesService, IllustrationService illustrationService)
        {
            try
            {
                Entity.UnderWriting.IllusData.DropDown mort;
                if (productcode == Utility.EFamilyProductType.LifeInsurance.Code())
                {
                    mort = Utility
                    .GetIllusDropDownByType(Utility.DropDownType.Mortality,productcode, age, ridertypecode.ToString()).Single(); 
                    
                    if ((gendercode == "M") && (smoker == "Y"))
                        return mort.MaleSmoker.ToDouble();
                    else if ((gendercode == "M") && (smoker == "N"))
                        return mort.MaleNonSmoker.ToDouble();
                    else if ((gendercode == "F") && (smoker == "Y"))
                        return mort.FemaleSmoker.ToDouble();
                    else if ((gendercode == "F") && (smoker == "N"))
                        return mort.FemaleNonSmoker.ToDouble();
                }
                else if (productcode == Utility.EFamilyProductType.Education.Code() || productcode == Utility.EFamilyProductType.Retirement.Code())
                {
                    int offset = 0;
                    if (gendercode == "M")
                        offset = rulesService.GetValue(RulesService.Rules.MALE_MORTALITY_OFFSET).ToInt();

                    mort = Utility
                    .GetIllusDropDownByType(Utility.DropDownType.Mortality, productcode,(age + offset), ridertypecode.ToString()).Single(); 

                    if ((gendercode == "M") && (smoker == "Y"))
                        return mort.MaleSmoker.ToDouble() * 
                                (!isFixed ? (1.0 + rulesService.GetValue(RulesService.Rules.SMOKER_OVERAGE)) : 1);
                    else if ((gendercode == "M") && (smoker == "N"))
                        return mort.MaleNonSmoker.ToDouble() * 
                                (!isFixed ? (1.0 + rulesService.GetValue(RulesService.Rules.INSURANCE_OVERAGE)) : 1);
                    else if ((gendercode == "F") && (smoker == "Y"))      
                        return mort.FemaleSmoker.ToDouble() * 
                                (!isFixed ? (1.0 + rulesService.GetValue(RulesService.Rules.SMOKER_OVERAGE)) : 1);
                    else if ((gendercode == "F") && (smoker == "N"))
                        return mort.FemaleNonSmoker.ToDouble() * 
                                (!isFixed ? (1.0 + rulesService.GetValue(RulesService.Rules.INSURANCE_OVERAGE)) : 1);
                }
            }
            catch (Exception ex)
            {
                return 0.0;
            }
            return 0.0;
        }

        public static IMortalitydata[] getMortalitydata(string productcode, bool isFixed, string ridertypecode, int age, string gendercode, string smoker, RulesService rulesService, IllustrationService illustrationService)
        {
            List<Entity.UnderWriting.IllusData.DropDown> mortdata;
            if (illustrationService.FamilyProductCode == Utility.EFamilyProductType.LifeInsurance.Code())
            {
                mortdata = Utility
                       .GetIllusDropDownByType(Utility.DropDownType.Mortality, productcode, null, ridertypecode.ToString())
                       .Where(o => o.Age >= age).OrderBy(o =>o.Age).ToList(); 

                int sno = 0;
                IMortalitydata[] mdata = new IMortalitydata[mortdata.Count];
                foreach (Entity.UnderWriting.IllusData.DropDown item in mortdata)
                {
                    sno++;
                    mdata[sno - 1] = new IMortalitydata();
                    mdata[sno - 1].sno = sno;
                    mdata[sno - 1].age = item.Age.Value;

                    if ((gendercode == "M") && (smoker == "Y"))
                        mdata[sno - 1].mortalityvalue = item.MaleSmoker.ToDouble();
                    else if ((gendercode == "M") && (smoker == "N"))
                        mdata[sno - 1].mortalityvalue = item.MaleNonSmoker.ToDouble();
                    else if ((gendercode == "F") && (smoker == "Y"))
                        mdata[sno - 1].mortalityvalue = item.FemaleSmoker.ToDouble();
                    else if ((gendercode == "F") && (smoker == "N"))
                        mdata[sno - 1].mortalityvalue = item.FemaleNonSmoker.ToDouble();
                }

                return mdata;
            }
            else if (illustrationService.FamilyProductCode == Utility.EFamilyProductType.Education.Code() || productcode == Utility.EFamilyProductType.Retirement.Code())
            {
                int offset = 0;
                if (gendercode == "M")
                    offset = rulesService.GetValue(RulesService.Rules.MALE_MORTALITY_OFFSET).ToInt();

                mortdata = Utility
                       .GetIllusDropDownByType(Utility.DropDownType.Mortality, productcode, null, ridertypecode)
                       .Where(o => o.Age >= (age + offset)).OrderBy(o => o.Age).ToList(); 

                int sno = 0;
                IMortalitydata[] mdata = new IMortalitydata[mortdata.Count()];

                foreach (Entity.UnderWriting.IllusData.DropDown item in mortdata)
                {
                    sno++;
                    mdata[sno - 1] = new IMortalitydata();
                    mdata[sno - 1].sno = sno;
                    mdata[sno - 1].age = item.Age.Value - offset;

                    if ((gendercode == "M") && (smoker == "Y"))
                        mdata[sno - 1].mortalityvalue = item.MaleSmoker.ToDouble() *
                                (!isFixed ? (1.0 + rulesService.GetValue(RulesService.Rules.SMOKER_OVERAGE).ToDouble()) : 1);
                    else if ((gendercode == "M") && (smoker == "N"))
                        mdata[sno - 1].mortalityvalue = item.MaleNonSmoker.ToDouble() *
                                (!isFixed ? (1.0 + rulesService.GetValue(RulesService.Rules.INSURANCE_OVERAGE).ToDouble()) : 1);
                    else if ((gendercode == "F") && (smoker == "Y"))
                        mdata[sno - 1].mortalityvalue = item.FemaleSmoker.ToDouble() *
                                (!isFixed ? (1.0 + rulesService.GetValue(RulesService.Rules.SMOKER_OVERAGE).ToDouble()) : 1);
                    else if ((gendercode == "F") && (smoker == "N"))
                        mdata[sno - 1].mortalityvalue = item.FemaleNonSmoker.ToDouble() *
                                (!isFixed ? (1.0 + rulesService.GetValue(RulesService.Rules.INSURANCE_OVERAGE).ToDouble()) : 1);
                }
                return mdata;
            }
            return null;
        }

        public static IMortalityfixed[] getMortalitydatafixed(String productcode, string ridertypecode, double healthriskvalue, double countryriskvalue, RulesService rulesService, IllustrationService illustrationService)
        {

            var baseinterest = rulesService.GetValue(RulesService.Rules.BASE_INTEREST).ToDouble();

            var mortdata = Utility
                       .GetIllusDropDownByType(Utility.DropDownType.Mortality, productcode, null, ridertypecode).OrderBy(o => o.Age).ToList(); 

            int sno = 0;
            IMortalityfixed[] mdata = new IMortalityfixed[mortdata.Count + 1];
            mdata[sno] = new IMortalityfixed();
            mdata[sno].age = 0;
            mdata[sno].mortalityvalue = 0;
            mdata[sno].lx = 10000000;
            mdata[sno].dx = mdata[sno].lx * mdata[sno].mortalityvalue;
            mdata[sno].ddx = mdata[sno].lx * Math.Pow(1 + baseinterest, -1 * mdata[sno].age);

            foreach (Entity.UnderWriting.IllusData.DropDown item in mortdata)
            {
                sno++;
                mdata[sno] = new IMortalityfixed();
                mdata[sno].age = item.Age.Value;
                mdata[sno].mortalityvalue = item.FemaleNonSmoker.ToDouble() + healthriskvalue + countryriskvalue;
                mdata[sno].lx = mdata[sno - 1].lx - mdata[sno - 1].dx;
                mdata[sno].dx = mdata[sno].lx * mdata[sno].mortalityvalue * (1 / 1000.0);
                mdata[sno].ddx = mdata[sno].lx * Math.Pow(1 + baseinterest, -1 * mdata[sno].age);
            }

            for (int i = 99; i >= 0; i--)
            {
                sno = i;
                if (sno == 99)
                    mdata[sno].nx = 0 + mdata[sno].ddx;
                else
                    mdata[sno].nx = mdata[sno + 1].nx + mdata[sno].ddx;
            }
            return mdata;
        }

        public static IMortalityfixed[] getMortalitydatafixedterm(string productcode, string gendercode, string ridertypecode, string smokercode, double healthriskvalue, double activityriskvalue, double countryriskvalue, RulesService rulesService, IllustrationService illustrationService)
        {

            var baseinterest = rulesService.GetValue(RulesService.Rules.BASE_INTEREST).ToDouble();
            var insuranceoverage = rulesService.GetValue(RulesService.Rules.INSURANCE_OVERAGE).ToDouble();
            var smokeroverage = rulesService.GetValue(RulesService.Rules.SMOKER_OVERAGE).ToDouble();

            var mortdata = Utility
                   .GetIllusDropDownByType(Utility.DropDownType.Mortality, productcode, null, ridertypecode)
                   .Where(o => o.Age > 0).OrderBy(o => o.Age).ToList(); 

            int sno = 0;
            IMortalityfixed[] mdata = new IMortalityfixed[mortdata.Count() + 1];
            mdata[sno] = new IMortalityfixed();
            mdata[sno].age = 0;
            mdata[sno].mortalityvalue = 0;
            mdata[sno].lx = 10000000;
            mdata[sno].dx = mdata[sno].lx * mdata[sno].mortalityvalue;
            mdata[sno].ddx = mdata[sno].lx * Math.Pow(1 + baseinterest, -1 * mdata[sno].age);

            foreach (Entity.UnderWriting.IllusData.DropDown item in mortdata)
            {
                sno++;
                mdata[sno] = new IMortalityfixed();
                mdata[sno].age = item.Age.Value;
                if (smokercode == "N" & gendercode == "M")
                    mdata[sno].mortalityvalue = item.MaleNonSmoker.ToDouble() * (1 + activityriskvalue) * (1 + insuranceoverage) + healthriskvalue + countryriskvalue;
                else if (smokercode == "N" & gendercode == "F")
                    mdata[sno].mortalityvalue = item.FemaleNonSmoker.ToDouble() * (1 + activityriskvalue) * (1 + insuranceoverage) + healthriskvalue + countryriskvalue;
                else if (smokercode == "Y" & gendercode == "M")
                    mdata[sno].mortalityvalue = item.MaleSmoker.ToDouble() * (1 + activityriskvalue) * (1 + smokeroverage) + healthriskvalue + countryriskvalue;
                else if (smokercode == "Y" & gendercode == "F")
                    mdata[sno].mortalityvalue = item.FemaleSmoker.ToDouble() * (1 + activityriskvalue) * (1 + smokeroverage) + healthriskvalue + countryriskvalue;
                mdata[sno].lx = mdata[sno - 1].lx - mdata[sno - 1].dx;
                mdata[sno].dx = mdata[sno].lx * mdata[sno].mortalityvalue * (1 / 1000.0);
                mdata[sno].ddx = mdata[sno].lx * Math.Pow(1 + baseinterest, -1 * mdata[sno].age);
            }

            for (int i = 99; i >= 0; i--)
            {
                sno = i;
                if (sno == 99)
                    mdata[sno].nx = 0 + mdata[sno].ddx;
                else
                    mdata[sno].nx = mdata[sno + 1].nx + mdata[sno].ddx;
            }
            return mdata;
        }
    }
}