using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSVirtualOffice.Models.blinsurance;

namespace WSVirtualOffice.Models.businesslogic
{
    public class Mortalityrates
    {

        
        
        
        public static double getMortalityrate(String productcode,char ridertypecode, int age, char gendercode, char smoker,char classcode)
        {
            try
            {
                if (Productdata.getPlangroupcode(productcode) == Plangroups.LIFE)
                {
                    mortalityvaluesdet mort = (from item in Program.mortalitydata
                                           where (item.age == age) && (item.productcode.Equals(productcode)) && item.ridertypecode == ridertypecode
                                           select item).SingleOrDefault();
                
                    if ((gendercode == Genders.Male) && (smoker == 'Y'))
                    {
                        return Double.Parse(mort.malesmoker.ToString());
                    }
                    else if ((gendercode == Genders.Male) && (smoker == 'N'))
                    {
                        return Double.Parse(mort.malenonsmoker.ToString());
                    }
                    else if ((gendercode == Genders.Female) && (smoker == 'Y'))
                    {
                        return Double.Parse(mort.femalesmoker.ToString());
                    }
                    else if ((gendercode == Genders.Female) && (smoker == 'N'))
                    {
                        return Double.Parse(mort.femalenonsmoker.ToString());
                    }
                }
                else if (Productdata.getPlangroupcode(productcode) == Plangroups.EDUCATION||Productdata.getPlangroupcode(productcode) == Plangroups.RETIREMENT)
                {
                    Boolean isFixed = Productdata.isFixed(productcode);
                    int offset = 0;
                    if (gendercode == Genders.Male)
                    {
                        offset = Rules.getRulevalueint(Rules.MALE_MORTALITY_OFFSET, productcode, classcode);                        
                    }
                    mortalityvaluesdet mort = (from item in Program.mortalitydata
                                               where (item.age == (age+offset)) && (item.productcode.Equals(productcode)) && item.ridertypecode == ridertypecode
                                               select item).SingleOrDefault();

                    if ((gendercode == Genders.Male) && (smoker == 'Y'))
                    {
                        if (isFixed == false)
                        {
                            return Double.Parse((mort.femalenonsmoker).ToString()) * (1.0 + Rules.getRulevaluedouble(Rules.SMOKER_OVERAGE, productcode,classcode));
                        }
                        else
                        {
                            return Double.Parse((mort.femalenonsmoker).ToString()) ;
                        }                        
                    }
                    else if ((gendercode == Genders.Male) && (smoker == 'N'))
                    {
                        if (isFixed == false)
                        {
                            return Double.Parse((mort.femalenonsmoker).ToString()) * (1.0 + Rules.getRulevaluedouble(Rules.INSURANCE_OVERAGE, productcode,classcode));
                        }
                        else
                        {
                            return Double.Parse((mort.femalenonsmoker).ToString()) ;
                        }
                        
                    }
                    else if ((gendercode == Genders.Female) && (smoker == 'Y'))
                    {
                        if (isFixed == false)
                        {
                            return Double.Parse((mort.femalenonsmoker).ToString()) * (1.0 + Rules.getRulevaluedouble(Rules.SMOKER_OVERAGE, productcode,classcode));
                        }
                        else
                        {
                            return Double.Parse((mort.femalenonsmoker).ToString());
                        }
                        
                    }
                    else if ((gendercode == Genders.Female) && (smoker == 'N'))
                    {
                        if (isFixed == false)
                        {
                            return Double.Parse((mort.femalenonsmoker).ToString()) * (1.0 + Rules.getRulevaluedouble(Rules.INSURANCE_OVERAGE, productcode,classcode));
                        }
                        else
                        {
                            return Double.Parse((mort.femalenonsmoker).ToString()) ;
                        }                        
                    }
                }
                
            }
            catch (Exception ex)
            {
                return 0.0;
            }
            return 0.0;
            //return 0.0;
        }



        public static IMortalitydata[] getMortalitydata(String productcode, char ridertypecode, int age, char gendercode, char smoker,char classcode)
        {
            if (Productdata.getPlangroupcode(productcode) == Plangroups.LIFE)
            {
                var mortdata = from item in Program.mortalitydata
                               where ((item.age >= age) && (item.productcode.Equals(productcode)) && (item.ridertypecode == ridertypecode))
                               orderby item.age
                               select item;
                int sno = 0;
                IMortalitydata[] mdata = new IMortalitydata[mortdata.Count()];
                foreach (mortalityvaluesdet item in mortdata)
                {
                    sno++;
                    mdata[sno - 1] = new IMortalitydata();
                    mdata[sno - 1].sno = sno;
                    mdata[sno - 1].age = item.age.Value;

                    if ((gendercode == Genders.Male) && (smoker == 'Y'))
                    {
                        mdata[sno - 1].mortalityvalue = Double.Parse(item.malesmoker.ToString());
                    }
                    else if ((gendercode == Genders.Male) && (smoker == 'N'))
                    {
                        mdata[sno - 1].mortalityvalue = Double.Parse(item.malenonsmoker.ToString());
                    }
                    else if ((gendercode == Genders.Female) && (smoker == 'Y'))
                    {
                        mdata[sno - 1].mortalityvalue = Double.Parse(item.femalesmoker.ToString());
                    }
                    else if ((gendercode == Genders.Female) && (smoker == 'N'))
                    {
                        mdata[sno - 1].mortalityvalue = Double.Parse(item.femalenonsmoker.ToString());
                    }

                }

                return mdata;
            }
            else if (Productdata.getPlangroupcode(productcode) == Plangroups.EDUCATION || Productdata.getPlangroupcode(productcode) == Plangroups.RETIREMENT)
            {
                Boolean isFixed = Productdata.isFixed(productcode);
                int offset = 0;
                if (gendercode == Genders.Male)
                {
                    offset = Rules.getRulevalueint(Rules.MALE_MORTALITY_OFFSET, productcode,classcode);
                }
                var mortdata = from item in Program.mortalitydata
                               where (item.age >= (age + offset)) && (item.productcode.Equals(productcode)) && item.ridertypecode == ridertypecode
                               select item;

                int sno = 0;
                IMortalitydata[] mdata = new IMortalitydata[mortdata.Count()];

                foreach (mortalityvaluesdet item in mortdata)
                {
                    sno++;
                    mdata[sno - 1] = new IMortalitydata();
                    mdata[sno - 1].sno = sno;
                    mdata[sno - 1].age = item.age.Value - offset;

                    if ((gendercode == Genders.Male) && (smoker == 'Y'))
                    {
                        if (isFixed == false)
                        {
                            mdata[sno - 1].mortalityvalue = Double.Parse((item.femalenonsmoker).ToString()) * (1.0 + Rules.getRulevaluedouble(Rules.SMOKER_OVERAGE, productcode,classcode));
                        }
                        else
                        {
                            mdata[sno - 1].mortalityvalue = Double.Parse((item.femalenonsmoker).ToString()) ;
                        }
                        
                    }
                    else if ((gendercode == Genders.Male) && (smoker == 'N'))
                    {
                        if (isFixed == false)
                        {
                            mdata[sno - 1].mortalityvalue = Double.Parse((item.femalenonsmoker).ToString()) * (1.0 + Rules.getRulevaluedouble(Rules.INSURANCE_OVERAGE, productcode,classcode));
                        }
                        else
                        {
                            mdata[sno - 1].mortalityvalue = Double.Parse((item.femalenonsmoker).ToString()) ;
                        }
                        
                    }
                    else if ((gendercode == Genders.Female) && (smoker == 'Y'))
                    {
                        if (isFixed == false)
                        {
                            mdata[sno - 1].mortalityvalue = Double.Parse((item.femalenonsmoker).ToString()) * (1.0 + Rules.getRulevaluedouble(Rules.SMOKER_OVERAGE, productcode,classcode));
                        }
                        else
                        {
                            mdata[sno - 1].mortalityvalue = Double.Parse((item.femalenonsmoker).ToString()) ;
                        }
                        
                    }
                    else if ((gendercode == Genders.Female) && (smoker == 'N'))
                    {
                        if (isFixed == false)
                        {
                            mdata[sno - 1].mortalityvalue = Double.Parse((item.femalenonsmoker).ToString()) * (1.0 + Rules.getRulevaluedouble(Rules.INSURANCE_OVERAGE, productcode,classcode));
                        }
                        else
                        {
                            mdata[sno - 1].mortalityvalue = Double.Parse((item.femalenonsmoker).ToString()) ;
                        }
                        
                    }
                }
                return mdata;

            }
            return null;

        }



        public static IMortalityfixed[] getMortalitydatafixed(String productcode, char ridertypecode,double healthriskvalue,double countryriskvalue,char classcode)
        {

            double baseinterest=Rules.getRulevaluedouble(Rules.BASE_INTEREST,productcode,classcode);
            //double healthriskvvalue = health.getActivityriskvalue(


            
            var mortdata = from item in Program.mortalitydata
                           where ((item.productcode.Equals(productcode)) && (item.ridertypecode == ridertypecode))
                           orderby item.age
                           select item;
            int sno = 0;
            IMortalityfixed[] mdata = new IMortalityfixed[mortdata.Count()+1];
            mdata[sno] = new IMortalityfixed();
            mdata[sno].age = 0;
            mdata[sno].mortalityvalue = 0;
            mdata[sno].lx = 10000000;
            mdata[sno].dx = mdata[sno].lx * mdata[sno].mortalityvalue;
            mdata[sno].ddx=mdata[sno].lx*Math.Pow(1+baseinterest,-1*mdata[sno].age);

            foreach (mortalityvaluesdet item in mortdata)
            {
                sno++;
                mdata[sno] = new IMortalityfixed();                    
                mdata[sno].age = item.age.Value;
                mdata[sno].mortalityvalue = Double.Parse(item.femalenonsmoker.ToString())+healthriskvalue+countryriskvalue;                    
                mdata[sno].lx = mdata[sno-1].lx - mdata[sno-1].dx;
                mdata[sno].dx = mdata[sno].lx * mdata[sno].mortalityvalue*(1/1000.0);                    
                mdata[sno].ddx = mdata[sno].lx * Math.Pow(1 + baseinterest, -1 * mdata[sno].age);
            }

            for(int i=99;i>=0;i--)
            {
                sno = i;
                if (sno == 99)
                {
                    mdata[sno].nx = 0 + mdata[sno].ddx;
                }
                else
                {
                    mdata[sno].nx = mdata[sno+1].nx + mdata[sno].ddx;
                }
            }


            return mdata;            
        }


        public static IMortalityfixed[] getMortalitydatafixedterm(String productcode, char gendercode, char ridertypecode, char smokercode, double healthriskvalue, double activityriskvalue, double countryriskvalue, char classcode)
        {

            double baseinterest = Rules.getRulevaluedouble(Rules.BASE_INTEREST, productcode, classcode);
            //double healthriskvvalue = health.getActivityriskvalue(
            double insuranceoverage = Rules.getRulevaluedouble(Rules.INSURANCE_OVERAGE, productcode, classcode);
            double smokeroverage = Rules.getRulevaluedouble(Rules.SMOKER_OVERAGE, productcode, classcode);


            var mortdata = from item in Program.mortalitydata
                           where ((item.productcode.Equals(productcode)) && (item.ridertypecode == ridertypecode)) && (item.age > 0)
                           orderby item.age
                           select item;
            int sno = 0;
            IMortalityfixed[] mdata = new IMortalityfixed[mortdata.Count() + 1];
            mdata[sno] = new IMortalityfixed();
            mdata[sno].age = 0;
            mdata[sno].mortalityvalue = 0;
            mdata[sno].lx = 10000000;
            mdata[sno].dx = mdata[sno].lx * mdata[sno].mortalityvalue;
            mdata[sno].ddx = mdata[sno].lx * Math.Pow(1 + baseinterest, -1 * mdata[sno].age);

            foreach (mortalityvaluesdet item in mortdata)
            {
                sno++;
                mdata[sno] = new IMortalityfixed();
                mdata[sno].age = item.age.Value;
                if (smokercode == 'N' & gendercode == 'M')
                {
                    mdata[sno].mortalityvalue = Double.Parse(item.malenonsmoker.ToString()) * (1 + activityriskvalue) * (1 + insuranceoverage) + healthriskvalue + countryriskvalue;
                }
                else if (smokercode == 'N' & gendercode == 'F')
                {
                    mdata[sno].mortalityvalue = Double.Parse(item.femalenonsmoker.ToString()) * (1 + activityriskvalue) * (1 + insuranceoverage) + healthriskvalue + countryriskvalue;
                }
                else if (smokercode == 'Y' & gendercode == 'M')
                {
                    mdata[sno].mortalityvalue = Double.Parse(item.malesmoker.ToString()) * (1 + activityriskvalue) * (1 + smokeroverage) + healthriskvalue + countryriskvalue;
                }
                else if (smokercode == 'Y' & gendercode == 'F')
                {
                    mdata[sno].mortalityvalue = Double.Parse(item.femalesmoker.ToString()) * (1 + activityriskvalue) * (1 + smokeroverage) + healthriskvalue + countryriskvalue;
                }
                mdata[sno].lx = mdata[sno - 1].lx - mdata[sno - 1].dx;
                mdata[sno].dx = mdata[sno].lx * mdata[sno].mortalityvalue * (1 / 1000.0);
                mdata[sno].ddx = mdata[sno].lx * Math.Pow(1 + baseinterest, -1 * mdata[sno].age);
            }

            for (int i = 99; i >= 0; i--)
            {
                sno = i;
                if (sno == 99)
                {
                    mdata[sno].nx = 0 + mdata[sno].ddx;
                }
                else
                {
                    mdata[sno].nx = mdata[sno + 1].nx + mdata[sno].ddx;
                }
            }


            return mdata;
        }

        public static IMortalityfixed[] getMortalitydatafixedtermnew(String productcode, char gendercode, char ridertypecode, char smokercode, double healthriskvalue, double activityriskvalue, double countryriskvalue, char classcode)
        {

            double baseinterest = Rules.getRulevaluedouble(Rules.BASE_INTEREST, productcode,classcode);

            /*
            if (classcode == 'A')
            {
                baseinterest = 0.015;
            }*/

            //double healthriskvvalue = health.getActivityriskvalue(
            double insuranceoverage=Rules.getRulevaluedouble(Rules.INSURANCE_OVERAGE,productcode,classcode);
            double smokeroverage = Rules.getRulevaluedouble(Rules.SMOKER_OVERAGE, productcode, classcode);


            var mortdata = from item in Program.mortalitydata
                           where ((item.productcode.Equals(productcode)) && (item.ridertypecode == ridertypecode)) && (item.age>0)
                           orderby item.age
                           select item;
            int sno = 0;
            IMortalityfixed[] mdata = new IMortalityfixed[mortdata.Count() + 1];
            mdata[sno] = new IMortalityfixed();
            mdata[sno].age = 0;
            mdata[sno].mortalityvalue = 0;
            mdata[sno].lx = 10000000;
            mdata[sno].dx = mdata[sno].lx * mdata[sno].mortalityvalue;
            mdata[sno].ddx = mdata[sno].lx * Math.Pow(1 + baseinterest, -1 * mdata[sno].age);

            foreach (mortalityvaluesdet item in mortdata)
            {
                sno++;
                mdata[sno] = new IMortalityfixed();
                mdata[sno].age = item.age.Value;
                if (smokercode == 'N' & gendercode == 'M')
                {
                    mdata[sno].mortalityvalue = Double.Parse(item.malenonsmoker.ToString()) * 1 *(1 + activityriskvalue) + (item.age <= 99 ? countryriskvalue + healthriskvalue : 0);//* (1 + activityriskvalue) * (1 + insuranceoverage) + healthriskvalue + countryriskvalue;
                }
                else if (smokercode == 'N' & gendercode == 'F')
                {
                    mdata[sno].mortalityvalue = Double.Parse(item.femalenonsmoker.ToString()) * 1 * (1 + activityriskvalue) + (item.age <= 99 ? countryriskvalue + healthriskvalue : 0);// *(1 + activityriskvalue) * (1 + insuranceoverage) + healthriskvalue + countryriskvalue;
                }
                else if (smokercode == 'Y' & gendercode == 'M')
                {
                    mdata[sno].mortalityvalue = Double.Parse(item.malesmoker.ToString()) * 1.5 * (1 + activityriskvalue) + (item.age <= 99 ? countryriskvalue + healthriskvalue : 0);// *(1 + activityriskvalue) * (1 + smokeroverage) + healthriskvalue + countryriskvalue;
                }
                else if (smokercode == 'Y' & gendercode == 'F')
                {
                    mdata[sno].mortalityvalue = Double.Parse(item.femalesmoker.ToString()) * 1.5 * (1 + activityriskvalue )+ (item.age <= 99 ? countryriskvalue + healthriskvalue : 0);// *(1 + activityriskvalue) * (1 + smokeroverage) + healthriskvalue + countryriskvalue;
                }
                mdata[sno].lx = mdata[sno - 1].lx - mdata[sno - 1].dx;
                mdata[sno].dx = mdata[sno].lx *( mdata[sno].mortalityvalue)* (1 / 1000.0);
                mdata[sno].ddx = mdata[sno].lx * Math.Pow(1 + baseinterest, -1 * mdata[sno].age);
            }

            for (int i = 99; i >= 0; i--)
            {
                sno = i;
                if (sno == 99)
                {
                    mdata[sno].nx = 0 + mdata[sno].ddx;
                }
                else
                {
                    mdata[sno].nx = mdata[sno + 1].nx + mdata[sno].ddx;
                }
            }
            for (int i = 99; i >= 0; i--)
            {
                sno = i;
                if (sno == 99)
                {
                    mdata[sno].sx = 0 + mdata[sno].nx;
                }
                else
                {
                    mdata[sno].sx = mdata[sno + 1].sx + mdata[sno].nx;
                }
            }
            for (int i = 0; i <= 99; i++)
            {
                sno = i;
                mdata[sno].cx = mdata[sno].dx * Math.Pow(1 + baseinterest, -1 * (mdata[sno].age+1));               
            }
            for (int i = 99; i >= 0; i--)
            {
                sno = i;
                if (sno == 99)
                {
                    mdata[sno].mx = 0 + mdata[sno].cx;
                }
                else
                {
                    mdata[sno].mx = mdata[sno + 1].mx + mdata[sno].cx;
                }
            }
            for (int i = 99; i >= 0; i--)
            {
                sno = i;
                if (sno == 99)
                {
                    mdata[sno].rx = 0 + mdata[sno].mx;
                }
                else
                {
                    mdata[sno].rx = mdata[sno + 1].rx + mdata[sno].mx;
                }
            }


            return mdata;
        }


    }
}
