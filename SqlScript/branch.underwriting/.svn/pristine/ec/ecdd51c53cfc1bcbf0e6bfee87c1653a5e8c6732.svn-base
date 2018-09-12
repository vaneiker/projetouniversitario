using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.businesslogic
{
    class DuplicateCustomerPlan
    {
        public static long duplicateRecord(long customerPlanno, int userid)
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();
            try
            {
                long newcustomerPlanno = 0;
                //Plan Info

                var insertquary = (from item in newdb.customerPlandets
                                   where item.customerPlanno == customerPlanno
                                   select item).SingleOrDefault();


                customerPlandet custplan = new customerPlandet();


                Linkcopy.CopyToAnother(insertquary, custplan);
                custplan.is_deleted = 'N';
                custplan.illustrationno = Program.getNewillustrationno();
                custplan.dispillustrationno = Program.getDispllustrationno(custplan.productcode, Program.systemno, Int32.Parse(custplan.illustrationno.ToString()));
                custplan.plancode = null;
                custplan.dispplancode = null;
                custplan.datecreated = DateTime.Now;
                custplan.createdby = userid;
                custplan.plandate = DateTime.Now;

                //  custplan.userid = userid;
                custplan.dateupdated = DateTime.Now;
                custplan.updatedby = userid;



                newdb.customerPlandets.InsertOnSubmit(custplan);
                newdb.SubmitChanges();
                //showAlert(Caption.showMessageBox(Sessionclass.getSessiondata(Session).language,"Saved successfully."));
                newcustomerPlanno = custplan.customerPlanno;

                //Rider Info

                customerplanpartnerinsurancedet partinsnew = new customerplanpartnerinsurancedet();

                customerplanpartnerinsurancedet partins = null;

                partins = (from partplan1 in newdb.customerplanpartnerinsurancedets
                           where partplan1.customerplanno == Convert.ToInt64(customerPlanno)
                           select partplan1).SingleOrDefault();

                if (partins != null)
                {
                    Linkcopy.CopyToAnother(partins, partinsnew);


                    partinsnew.customerplanno = newcustomerPlanno;

                    partinsnew.datecreated = DateTime.Now;
                    partinsnew.createdby = userid;
                    partinsnew.dateupdated = DateTime.Now;
                    partinsnew.updatedby = userid;
                    partinsnew.datesynced = null;

                    newdb.customerplanpartnerinsurancedets.InsertOnSubmit(partinsnew);
                    newdb.SubmitChanges();
                    //showAlert(Caption.showMessageBox(Sessionclass.getSessiondata(Session).language,"Saved successfully."));
                }


                //Plan Options

                // Varible InsuredAmount grid
                customerplanvarinsureddet planopnew = new customerplanvarinsureddet();

                var planiop = (from partplan1 in newdb.customerplanvarinsureddets
                               where partplan1.customerplanno == Convert.ToInt64(customerPlanno)
                               select partplan1);

                List<customerplanvarinsureddet> planioplist = new List<customerplanvarinsureddet>();
                foreach (customerplanvarinsureddet temp in planiop)
                {
                    planioplist.Add(temp);
                }

                foreach (customerplanvarinsureddet cp in planioplist)
                {
                    Linkcopy.CopyToAnother(cp, planopnew);


                    planopnew.customerplanno = newcustomerPlanno;

                    planopnew.datecreated = DateTime.Now;
                    planopnew.createdby = userid;
                    planopnew.dateupdated = DateTime.Now;
                    planopnew.updatedby = userid;
                    planopnew.datesynced = null;

                    newdb.customerplanvarinsureddets.InsertOnSubmit(planopnew);
                    newdb.SubmitChanges();
                    //showAlert(Caption.showMessageBox(Sessionclass.getSessiondata(Session).language,"Saved successfully."));
                    planopnew = new customerplanvarinsureddet();
                }

                //Variable Premiums grid
                customerplanvarpremiumdet planopprenew = new customerplanvarpremiumdet();

                var planoppre = (from partplan1 in newdb.customerplanvarpremiumdets
                                 where partplan1.customerplanno == Convert.ToInt64(customerPlanno)
                                 select partplan1);

                List<customerplanvarpremiumdet> planopprelist = new List<customerplanvarpremiumdet>();
                foreach (customerplanvarpremiumdet temp in planoppre)
                {
                    planopprelist.Add(temp);
                }

                foreach (customerplanvarpremiumdet cp in planopprelist)
                {
                    Linkcopy.CopyToAnother(cp, planopprenew);


                    planopprenew.customerplanno = newcustomerPlanno;

                    planopprenew.datecreated = DateTime.Now;
                    planopprenew.createdby = userid;
                    planopprenew.dateupdated = DateTime.Now;
                    planopprenew.updatedby = userid;
                    planopprenew.datesynced = null;

                    newdb.customerplanvarpremiumdets.InsertOnSubmit(planopprenew);

                    newdb.SubmitChanges();
                    //showAlert(Caption.showMessageBox(Sessionclass.getSessiondata(Session).language,"Saved successfully."));
                    planopprenew = new customerplanvarpremiumdet();
                }


                //Varible Investment Profile
                customerplanvarprofiledet planopvipnew = new customerplanvarprofiledet();

                var planopvip = (from partplan1 in newdb.customerplanvarprofiledets
                                 where partplan1.customerplanno == Convert.ToInt64(customerPlanno)
                                 select partplan1);

                List<customerplanvarprofiledet> planopviplist = new List<customerplanvarprofiledet>();
                foreach (customerplanvarprofiledet temp in planopvip)
                {
                    planopviplist.Add(temp);
                }

                foreach (customerplanvarprofiledet cp in planopviplist)
                {
                    Linkcopy.CopyToAnother(cp, planopvipnew);


                    planopvipnew.customerplanno = newcustomerPlanno;

                    planopvipnew.datecreated = DateTime.Now;
                    planopvipnew.createdby = userid;
                    planopvipnew.dateupdated = DateTime.Now;
                    planopvipnew.updatedby = userid;
                    planopvipnew.datesynced = null;

                    newdb.customerplanvarprofiledets.InsertOnSubmit(planopvipnew);
                    newdb.SubmitChanges();
                    //showAlert(Caption.showMessageBox(Sessionclass.getSessiondata(Session).language,"Saved successfully."));
                    planopvipnew = new customerplanvarprofiledet();
                }


                //Partial Surrender
                customerplanvarsurrenderdet planopvsdnew = new customerplanvarsurrenderdet();

                var planopvsd = (from partplan1 in newdb.customerplanvarsurrenderdets
                                 where partplan1.customerplanno == Convert.ToInt64(customerPlanno)
                                 select partplan1);

                List<customerplanvarsurrenderdet> planopvsdlist = new List<customerplanvarsurrenderdet>();
                foreach (customerplanvarsurrenderdet temp in planopvsd)
                {
                    planopvsdlist.Add(temp);
                }

                foreach (customerplanvarsurrenderdet cp in planopvsdlist)
                {
                    Linkcopy.CopyToAnother(cp, planopvsdnew);


                    planopvsdnew.customerplanno = newcustomerPlanno;

                    planopvsdnew.datecreated = DateTime.Now;
                    planopvsdnew.createdby = userid;
                    planopvsdnew.dateupdated = DateTime.Now;
                    planopvsdnew.updatedby = userid;
                    planopvsdnew.datesynced = null;

                    newdb.customerplanvarsurrenderdets.InsertOnSubmit(planopvsdnew);
                    newdb.SubmitChanges();
                    //showAlert(Caption.showMessageBox(Sessionclass.getSessiondata(Session).language,"Saved successfully."));
                    planopvsdnew = new customerplanvarsurrenderdet();
                }


                //Loan
                customerplanloandet planoploannew = new customerplanloandet();

                var planoplone = (from partplan1 in newdb.customerplanloandets
                                  where partplan1.customerplanno == Convert.ToInt64(customerPlanno)
                                  select partplan1);

                List<customerplanloandet> planoploanlist = new List<customerplanloandet>();
                foreach (customerplanloandet temp in planoplone)
                {
                    planoploanlist.Add(temp);
                }

                foreach (customerplanloandet cp in planoploanlist)
                {
                    Linkcopy.CopyToAnother(cp, planoploannew);


                    planoploannew.customerplanno = newcustomerPlanno;
                    planoploannew.datecreated = DateTime.Now;
                    planoploannew.createdby = userid;
                    planoploannew.dateupdated = DateTime.Now;
                    planoploannew.updatedby = userid;
                    planoploannew.datesynced = null;

                    newdb.customerplanloandets.InsertOnSubmit(planoploannew);
                    newdb.SubmitChanges();
                    //showAlert(Caption.showMessageBox(Sessionclass.getSessiondata(Session).language,"Saved successfully."));
                    planoploannew = new customerplanloandet();
                }


                //Loan Repayments
                customerplanloanrepaydet planoploanrenew = new customerplanloanrepaydet();

                var planoplonere = (from partplan1 in newdb.customerplanloanrepaydets
                                    where partplan1.customerplanno == Convert.ToInt64(customerPlanno)
                                    select partplan1);

                List<customerplanloanrepaydet> planoploanrelist = new List<customerplanloanrepaydet>();
                foreach (customerplanloanrepaydet temp in planoplonere)
                {
                    planoploanrelist.Add(temp);
                }

                foreach (customerplanloanrepaydet cp in planoploanrelist)
                {
                    Linkcopy.CopyToAnother(cp, planoploannew);


                    planoploanrenew.customerplanno = newcustomerPlanno;
                    planoploanrenew.datecreated = DateTime.Now;
                    planoploanrenew.createdby = userid;
                    planoploanrenew.dateupdated = DateTime.Now;
                    planoploanrenew.updatedby = userid;
                    planoploanrenew.datesynced = null;

                    newdb.customerplanloanrepaydets.InsertOnSubmit(planoploanrenew);
                    newdb.SubmitChanges();
                    //showAlert(Caption.showMessageBox(Sessionclass.getSessiondata(Session).language,"Saved successfully."));
                    planoploanrenew = new customerplanloanrepaydet();
                }



                //Plan Requirments

                customerplanotherinsurancedet planreqnew = new customerplanotherinsurancedet();


                var planreq = (from partplan1 in newdb.customerplanotherinsurancedets
                               where partplan1.customerplanno == Convert.ToInt64(customerPlanno)
                               select partplan1);

                List<customerplanotherinsurancedet> planreqlist = new List<customerplanotherinsurancedet>();
                foreach (customerplanotherinsurancedet temp in planreq)
                {
                    planreqlist.Add(temp);
                }

                foreach (customerplanotherinsurancedet cp in planreqlist)
                {
                    Linkcopy.CopyToAnother(cp, planreqnew);


                    planreqnew.customerplanno = newcustomerPlanno;
                    planreqnew.datecreated = DateTime.Now;
                    planreqnew.createdby = userid;
                    planreqnew.dateupdated = DateTime.Now;
                    planreqnew.updatedby = userid;
                    planreqnew.datesynced = null;

                    newdb.customerplanotherinsurancedets.InsertOnSubmit(planreqnew);

                    newdb.SubmitChanges();
                    //showAlert(Caption.showMessageBox(Sessionclass.getSessiondata(Session).language,"Saved successfully."));
                    planreqnew = new customerplanotherinsurancedet();
                }



                //Beneficiaries

                customerplanbeneficiarydet planbennew = new customerplanbeneficiarydet();


                var planben = (from partplan1 in newdb.customerplanbeneficiarydets
                               where partplan1.customerplanno == Convert.ToInt64(customerPlanno)
                               select partplan1);

                List<customerplanbeneficiarydet> planbenlist = new List<customerplanbeneficiarydet>();
                foreach (customerplanbeneficiarydet temp in planben)
                {
                    planbenlist.Add(temp);
                }

                foreach (customerplanbeneficiarydet cp in planbenlist)
                {
                    Linkcopy.CopyToAnother(cp, planbennew);


                    planbennew.customerplanno = newcustomerPlanno;
                    planbennew.datecreated = DateTime.Now;
                    planbennew.createdby = userid;
                    planbennew.dateupdated = DateTime.Now;
                    planbennew.updatedby = userid;
                    planbennew.datesynced = null;

                    newdb.customerplanbeneficiarydets.InsertOnSubmit(planbennew);

                    newdb.SubmitChanges();
                    //showAlert(Caption.showMessageBox(Sessionclass.getSessiondata(Session).language,"Saved successfully."));
                    planbennew = new customerplanbeneficiarydet();
                }

                return newcustomerPlanno;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //newdb.Dispose();
            }
            return 0;
        }

        

    }
}