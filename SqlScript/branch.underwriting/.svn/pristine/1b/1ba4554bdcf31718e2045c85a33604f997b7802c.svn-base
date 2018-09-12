using DevExpress.Web;
using Entity.UnderWriting.Entities;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.VehicleInspectionForm
{
    public partial class Foto : UC, IUC
    {
        #region properties
        string titulo { set; get; }

        public string Titulo { set; get; }
        public string HRef { set; get; }
        public string Description { set; get; }
        public string AlternateText { set; get; }
        public string ImageUrl { set; get; }
        public string CommandArgument { set; get; }
        public string AbsoluteImagePath { set; get; }
        public string ImageCar { set; get; }
        public string documentDesc { set; get; }

        public bool? Enabled { get; set; }

        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AsignarPropiedades();
        }

        public void AsignarPropiedades()
        {
            lnkFoto.HRef = HRef;
            lnkFoto.Title = Description;
            lnkFoto.Attributes.Add("imageCar", ImageCar == "default" ? "car01.png" : ImageCar);

            imgFoto1.Src = ImageUrl;

            this.ExcecuteJScript("$('*[rel=\"prettyPhoto[pp_gal]\"]').prettyPhoto({ modal: true, theme: 'light_rounded', slideshow: 5000, autoplay_slideshow: false });");
        }

        public void Translator(string Lang)
        {
            if (!string.IsNullOrWhiteSpace(Titulo))
            {
                switch (Titulo.ToLower())
                {
                    case "frente": titulo = Resources.VehiclePhotoFront; break;
                    case "frente derecho": titulo = Resources.VehiclePhotoFrontRight; break;
                    case "frente izquierdo": titulo = Resources.VehiclePhotoFrontLeft; break;
                    case "trasera": titulo = Resources.VehiclePhotoRear; break;
                    case "trasera derecha": titulo = Resources.VehiclePhotoRearRight; break;
                    case "trasera izquierda": titulo = Resources.VehiclePhotoRearLeft; break;
                    case "baúl exterior": titulo = Resources.VehiclePhotoExteriorTrunk; break;
                    case "baúl interior": titulo = Resources.VehiclePhotoInteriorTrunk; break;
                    case "repuestos": titulo = Resources.VehiclePhotoParts; break;
                    case "motor exterior": titulo = Resources.VehiclePhotoExteriorEngine; break;
                    case "motor interior": titulo = Resources.VehiclePhotoInteriorEngine; break;
                    case "kilometraje": titulo = Resources.VehiclePhotoMileage; break;
                    case "chasis 1": titulo = string.Format("{0} 1", Resources.VehiclePhotoChassis); break;
                    case "chasis 2": titulo = string.Format("{0} 2", Resources.VehiclePhotoChassis); break;
                    case "techo": titulo = string.Format("{0}", Resources.VehiclePhotoRoof); break;
                    case "Selfie Inspector": titulo = string.Format("{0}", Resources.VehicleSelfieInspector); break;
                    default: titulo = Titulo; break;
                }

                lblTitulo.Text = titulo.ToUpper();

                bSelectImage.InnerText = Resources.VehicleSelectImage;
                bChange.InnerText = Resources.VehicleChangeImage;

                imgFoto1.Attributes.Add("imageCar", ImageCar == "default" ? "car01.png" : ImageCar);
                imgFoto1.Attributes.Add("documentDesc", Titulo);
                imgFoto1.Attributes.Add("documentName", CommandArgument);

                lblMessages.Attributes.Add("imageCar", CommandArgument);

                divThumbnail.Attributes.Add("documentDesc", Titulo);
                divThumbnail.Attributes.Add("documentName", CommandArgument);
            }
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
        }

        public void Initialize()
        {
        }

        public void ClearData()
        {
            throw new NotImplementedException();
        }
    }
}