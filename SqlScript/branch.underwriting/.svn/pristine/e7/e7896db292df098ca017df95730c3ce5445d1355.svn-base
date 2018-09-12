using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WSVirtualOffice.Models
{
    public class Langdata
    {
        public static String LANGUAGE_ENGLISH = "en";
        public static String LANGUAGE_SPANISH = "es";
        public static String LANGUAGE_FRENCH = "fr";
        public static String LANGUAGE_PORTUGESE = "pr";
        public static String LANGUAGE_CHINESE = "ch";

        public static List<Langdetaildata> englishlist = new List<Langdetaildata>();
        public static List<Langdetaildata> spanishlist = new List<Langdetaildata>();
        public static List<Langdetaildata> frenchlist = new List<Langdetaildata>();
        public static List<Langdetaildata> portugeselist = new List<Langdetaildata>();
        public static List<Langdetaildata> chineselist = new List<Langdetaildata>();


        public static void loadLangfiles(String apppath)
        {
            openFile(apppath + "/language/formdata_en.properties", englishlist);
            openFile(apppath + "/language/formdata_es.properties", spanishlist);
            openFile(apppath + "/language/formdata_fr.properties", frenchlist);
            openFile(apppath + "/language/formdata_pt.properties", portugeselist);
            openFile(apppath + "/language/formdata_zh.properties", chineselist);
        }        



        private static void openFile(String filepath,List<Langdetaildata> langlist)
        {
            //app.Server.MapPath("~/bin/
            // create reader & open file
            
            //TextReader tr1 = new StreamReader(filepath);
            TextReader tr1 = new StreamReader(filepath, System.Text.Encoding.Default);

            //TextWriter tr2 = new StreamWriter("d:\\abcd1.txt");
            // read a line of text
            String str = null;
            while ((str = tr1.ReadLine()) != null)
            {
                if (str.Contains(".Text"))
                {
                    String firstpart = str.Split('=')[0].Replace("\"", "");
                    String formname = firstpart.Split('.')[0];
                    String itemname = str.Split('.')[1];
                    String languagevalue = str.Split('=')[1].Replace("\"", "");

                    Langdetaildata l1 = new Langdetaildata(formname, itemname, languagevalue);
                    langlist.Add(l1);
                    
                }
            }
            //String str=tr1.ReadLine();

            // close the stream
            tr1.Close();
            //tr2.Close();
        }


        public static void changeLanguage(UserControl page1, String formfilename)
        {
            Sessionclass s = (Sessionclass)page1.Session[Sessionclass.SESSIONOBJECT];
            String language = s.language;

            if (language.Equals(Langdata.LANGUAGE_ENGLISH))
            {
                foreach (Langdetaildata det in Langdata.englishlist)
                {
                    if (det.formname.Equals(formfilename))
                    {
                        if (det.itemname.Substring(0, 3).Equals("lbl"))
                        {
                            Label l = (Label)page1.FindControl(det.itemname);
                            if (l != null)
                            {
                                l.Text = det.languagevalue;
                            }
                        }
                        else if (det.itemname.Substring(0, 3).Equals("btn"))
                        {
                            Button b = (Button)page1.FindControl(det.itemname);
                            if (b != null)
                            {
                                b.Text = det.languagevalue;
                            }
                        }
                    }

                }
            }
            else if (language.Equals(Langdata.LANGUAGE_SPANISH))
            {
                foreach (Langdetaildata det in Langdata.spanishlist)
                {
                    if (det.formname.Equals(formfilename))
                    {
                        if (det.itemname.Substring(0, 3).Equals("lbl") || det.itemname.Substring(0, 3).Equals("Lab"))
                        {
                            Label l = (Label)page1.FindControl(det.itemname);
                            
                            //l = (Label)FindControl1(page1, det.itemname);
                            if (l != null)
                            {
                                l.Text = det.languagevalue;
                            }
                        }
                        else if (det.itemname.Substring(0, 3).Equals("btn"))
                        {
                            Button b =  (Button)page1.FindControl(det.itemname);
                            
                            //b = (Button)FindControl1(page1, det.itemname);

                            if (b != null)
                            {
                                b.Text = det.languagevalue;
                            }
                        }
                    }

                }
            }
            else if (language.Equals(Langdata.LANGUAGE_FRENCH))
            {
                foreach (Langdetaildata det in Langdata.frenchlist)
                {
                    if (det.formname.Equals(formfilename))
                    {
                        if (det.itemname.Substring(0, 3).Equals("lbl") || det.itemname.Substring(0, 3).Equals("Lab"))
                        {
                            Label l = (Label)page1.FindControl(det.itemname);

                            //l = (Label)FindControl1(page1, det.itemname);
                            if (l != null)
                            {
                                l.Text = det.languagevalue;
                            }
                        }
                        else if (det.itemname.Substring(0, 3).Equals("btn"))
                        {
                            Button b = (Button)page1.FindControl(det.itemname);

                            //b = (Button)FindControl1(page1, det.itemname);

                            if (b != null)
                            {
                                b.Text = det.languagevalue;
                            }
                        }
                    }

                }
            }
            else if (language.Equals(Langdata.LANGUAGE_PORTUGESE))
            {
                foreach (Langdetaildata det in Langdata.portugeselist)
                {
                    if (det.formname.Equals(formfilename))
                    {
                        if (det.itemname.Substring(0, 3).Equals("lbl") || det.itemname.Substring(0, 3).Equals("Lab"))
                        {
                            Label l = (Label)page1.FindControl(det.itemname);

                            //l = (Label)FindControl1(page1, det.itemname);
                            if (l != null)
                            {
                                l.Text = det.languagevalue;
                            }
                        }
                        else if (det.itemname.Substring(0, 3).Equals("btn"))
                        {
                            Button b = (Button)page1.FindControl(det.itemname);

                            //b = (Button)FindControl1(page1, det.itemname);

                            if (b != null)
                            {
                                b.Text = det.languagevalue;
                            }
                        }
                    }

                }
            }
            else if (language.Equals(Langdata.LANGUAGE_CHINESE))
            {
                foreach (Langdetaildata det in Langdata.chineselist)
                {
                    if (det.formname.Equals(formfilename))
                    {
                        if (det.itemname.Substring(0, 3).Equals("lbl") || det.itemname.Substring(0, 3).Equals("Lab"))
                        {
                            Label l = (Label)page1.FindControl(det.itemname);

                            //l = (Label)FindControl1(page1, det.itemname);
                            if (l != null)
                            {
                                l.Text = det.languagevalue;
                            }
                        }
                        else if (det.itemname.Substring(0, 3).Equals("btn"))
                        {
                            Button b = (Button)page1.FindControl(det.itemname);

                            //b = (Button)FindControl1(page1, det.itemname);

                            if (b != null)
                            {
                                b.Text = det.languagevalue;
                            }
                        }
                    }

                }
            }
        }

        public static void changeLanguage(Page page1, String formfilename)
        {
            Sessionclass s = (Sessionclass)page1.Session[Sessionclass.SESSIONOBJECT];
            String language = s.language;

            if (language.Equals(Langdata.LANGUAGE_ENGLISH))
            {
                foreach (Langdetaildata det in Langdata.englishlist)
                {
                    if (det.formname.Equals(formfilename))
                    {
                        if (det.itemname.Substring(0, 3).Equals("lbl"))
                        {
                            Label l = (Label)page1.FindControl(det.itemname);
                            if (l != null)
                            {
                                l.Text = det.languagevalue;
                            }
                        }
                        else if (det.itemname.Substring(0, 3).Equals("btn"))
                        {
                            Button b = (Button)page1.FindControl(det.itemname);
                            if (b != null)
                            {
                                b.Text = det.languagevalue;
                            }
                        }
                    }

                }
            }
            else if (language.Equals(Langdata.LANGUAGE_SPANISH))
            {
                foreach (Langdetaildata det in Langdata.spanishlist)
                {
                    if (det.formname.Equals(formfilename))
                    {
                        if (det.itemname.Substring(0, 3).Equals("lbl") || det.itemname.Substring(0, 3).Equals("Lab"))
                        {
                            Label l = null;
                            if (page1.Master != null)
                            {
                                l = (Label)FindControlRecursive(page1.Master, det.itemname);
                            }
                            else
                            {
                                l = (Label)page1.FindControl(det.itemname);
                            }
                            l = (Label)FindControl1(page1, det.itemname);
                            if (l != null)
                            {
                                l.Text = det.languagevalue;
                            }
                        }
                        else if (det.itemname.Substring(0, 3).Equals("btn"))
                        {
                            Button b = null;
                            if (page1.Master != null)
                            {
                                b = (Button)FindControlRecursive(page1.Master, det.itemname);
                            }
                            else
                            {
                                b = (Button)page1.FindControl(det.itemname);
                            }

                            b = (Button)FindControl1(page1, det.itemname);

                            if (b != null)
                            {
                                b.Text = det.languagevalue;
                            }
                        }
                    }

                }
            }
            else if (language.Equals(Langdata.LANGUAGE_FRENCH))
            {
                foreach (Langdetaildata det in Langdata.frenchlist)
                {
                    if (det.formname.Equals(formfilename))
                    {
                        if (det.itemname.Substring(0, 3).Equals("lbl") || det.itemname.Substring(0, 3).Equals("Lab"))
                        {
                            Label l = null;
                            if (page1.Master != null)
                            {
                                l = (Label)FindControlRecursive(page1.Master, det.itemname);
                            }
                            else
                            {
                                l = (Label)page1.FindControl(det.itemname);
                            }
                            l = (Label)FindControl1(page1, det.itemname);
                            if (l != null)
                            {
                                l.Text = det.languagevalue;
                            }
                        }
                        else if (det.itemname.Substring(0, 3).Equals("btn"))
                        {
                            Button b = null;
                            if (page1.Master != null)
                            {
                                b = (Button)FindControlRecursive(page1.Master, det.itemname);
                            }
                            else
                            {
                                b = (Button)page1.FindControl(det.itemname);
                            }

                            b = (Button)FindControl1(page1, det.itemname);

                            if (b != null)
                            {
                                b.Text = det.languagevalue;
                            }
                        }
                    }

                }
            }
            else if (language.Equals(Langdata.LANGUAGE_PORTUGESE))
            {
                foreach (Langdetaildata det in Langdata.portugeselist)
                {
                    if (det.formname.Equals(formfilename))
                    {
                        if (det.itemname.Substring(0, 3).Equals("lbl") || det.itemname.Substring(0, 3).Equals("Lab"))
                        {
                            Label l = null;
                            if (page1.Master != null)
                            {
                                l = (Label)FindControlRecursive(page1.Master, det.itemname);
                            }
                            else
                            {
                                l = (Label)page1.FindControl(det.itemname);
                            }
                            l = (Label)FindControl1(page1, det.itemname);
                            if (l != null)
                            {
                                l.Text = det.languagevalue;
                            }
                        }
                        else if (det.itemname.Substring(0, 3).Equals("btn"))
                        {
                            Button b = null;
                            if (page1.Master != null)
                            {
                                b = (Button)FindControlRecursive(page1.Master, det.itemname);
                            }
                            else
                            {
                                b = (Button)page1.FindControl(det.itemname);
                            }

                            b = (Button)FindControl1(page1, det.itemname);

                            if (b != null)
                            {
                                b.Text = det.languagevalue;
                            }
                        }
                    }

                }
            }
            else if (language.Equals(Langdata.LANGUAGE_CHINESE))
            {
                foreach (Langdetaildata det in Langdata.chineselist)
                {
                    if (det.formname.Equals(formfilename))
                    {
                        if (det.itemname.Substring(0, 3).Equals("lbl") || det.itemname.Substring(0, 3).Equals("Lab"))
                        {
                            Label l = null;
                            if (page1.Master != null)
                            {
                                l = (Label)FindControlRecursive(page1.Master, det.itemname);
                            }
                            else
                            {
                                l = (Label)page1.FindControl(det.itemname);
                            }
                            l = (Label)FindControl1(page1, det.itemname);
                            if (l != null)
                            {
                                l.Text = det.languagevalue;
                            }
                        }
                        else if (det.itemname.Substring(0, 3).Equals("btn"))
                        {
                            Button b = null;
                            if (page1.Master != null)
                            {
                                b = (Button)FindControlRecursive(page1.Master, det.itemname);
                            }
                            else
                            {
                                b = (Button)page1.FindControl(det.itemname);
                            }

                            b = (Button)FindControl1(page1, det.itemname);

                            if (b != null)
                            {
                                b.Text = det.languagevalue;
                            }
                        }
                    }

                }
            }

        }
            

     
        public static Control FindControl1(Control page1, string ctrl)
        {
            foreach (Control c in page1.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    Control c1 = FindControl1(c, ctrl);
                    if (c1 != null)
                    {
                        return c1;
                    }
                }
                else
                {
                    Control c2 = c.FindControl(ctrl);
                    if (c2 != null)
                    {
                        return c2;
                    }
                }
            }
            return null;
        }
        public static Control FindControlRecursive(Control Root, string Id)
        {
            if (Root.ID == Id)
                return Root;

            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, Id);
                try
                {
                    Label l = (Label)FoundCtl;
                }
                catch (Exception e)
                {
                    return null;
                }
                if (FoundCtl != null)
                    return FoundCtl;
            }

            return null;
        }
    }
}
