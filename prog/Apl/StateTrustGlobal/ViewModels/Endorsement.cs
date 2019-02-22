using StateTrustGlobal.Data;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StateTrustGlobal.ViewModels
{
    public class Endorsement
    {
        public class Set
        {
            public class Parameters
            {
                public int? EndorsementId { get; set; }
                public string Name { get; set; }
                public string Rnc { get; set; }
                public int EndorsementStatus { get; set; }
                public string Direccion { get; set; }
                public string ContactName { get; set; }
                public string ContactTel { get; set; }
                public string ContactAdress { get; set; }
                public int? UsrId { get; set; }
            }

            public class Result
            {
                public string Action { get; set; }
                public int EndorsementId { get; set; }
                public string Name { get; set; }
                public string Rnc { get; set; }
                public string ContactName { get; set; }
                public string ContactTel { get; set; }
                public string ContactAdress { get; set; }
                public string Message { get; set; }
                public bool Error { get; set; }
                
            }
        }

        public class Get
        {
            public class Parameters
            {
                public string Name { get; set; }
                public string Rnc { get; set; }
            }

            public class Result
            {
                public int EndorsementId { get; set; }
                public string Name { get; set; }
                public string Rnc { get; set; }
                public bool EndorsementStatus { get; set; }
                public string Direccion { get; set; }
                public string ContactName { get; set; }
                public string ContactTel { get; set; }
                public string ContactAdress { get; set; }
                public string Message { get; set; }
                public bool Error { get; set; }
            }

            public static dynamic Data(Parameters parameters)
            {
                dynamic result = new Result { };
                try
                {
                    string name = !string.IsNullOrWhiteSpace(parameters.Name) ? parameters.Name : null,
                           rnc = !string.IsNullOrWhiteSpace(parameters.Rnc) ? parameters.Rnc : null;

                    List<Result> _result = new List<Result>() { };

                    using (STFGlobalEntities entity = new STFGlobalEntities())
                        _result = entity.SP_GET_ST_ENDORSEMENT(name, rnc).Select(e => new Result
                        {
                            ContactAdress = e.Contact_Adress,
                            ContactName = e.Contact_Name,
                            ContactTel = e.Contact_Tel,
                            EndorsementId = e.Endorsement_Id,
                            EndorsementStatus = e.Endorsement_Status,
                            Name = e.Name,
                            Rnc = e.Rnc
                        }).ToList();

                    if (_result.Count > 0)
                        if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(rnc))
                            result = _result;
                        else
                            result = _result.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    result = new Result
                    {
                        Message = ex.Message
                    };
                }

                return result;
            }

        }
    }
}
