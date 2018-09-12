namespace Web.SubmittedPolicies.Dal
{
    public partial class VW_GET_POLICY_PRINT
    {
        public string Is_Print_Image
        {
            get { return Is_Print ? "../../../images/icono/cotejo.png" : "../../../images/icono/equis.png"; }
        }
    }
}