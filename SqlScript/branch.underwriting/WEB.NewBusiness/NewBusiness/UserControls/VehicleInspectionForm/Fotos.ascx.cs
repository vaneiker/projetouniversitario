using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Web.UI;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.VehicleInspectionForm
{
    public partial class Fotos : UC, IUC
    {        
        public static bool Inspection { get; set; }

        public static ControlCollection controls { get; set; }
        public static string serverMapPath { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            serverMapPath = Server.MapPath("~");

            controls = new ControlCollection(this);
            controls = this.Controls;

            foreach (var control in controls)
            {
                if (control is Foto)
                {
                    Foto foto = control as Foto;

                    foto.HRef =
                    foto.ImageUrl = ObjServices.DefaultImageCar;

                    foto.ImageCar = "default";

                    foto.documentDesc = foto.Titulo;
                }
            }
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }
    }
}