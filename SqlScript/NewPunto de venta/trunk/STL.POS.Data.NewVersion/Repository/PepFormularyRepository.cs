﻿using Entity.Entities;
using STL.POS.Data.NewVersion.EdmxModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data.NewVersion.Repository
{
    public class PepFormularyRepository: BaseRepository
    {
        public PepFormularyRepository() { }

        #region Set
        public virtual BaseEntity SetPepFormulary(PepFormulary.Parameter parameter)
        {
            BaseEntity result;
            IEnumerable<SP_SET_PEP_FORMULARY_Result> temp;
            temp = PosContex.SP_SET_PEP_FORMULARY(
                                                    parameter.id,
                                                    parameter.personsID,
                                                    parameter.name,
                                                    parameter.relationshipId,
                                                    parameter.position,
                                                    parameter.fromYear,
                                                    parameter.toYear,
                                                    parameter.userId,
                                                    parameter.BeneficiaryId,
                                                    parameter.IsPepManagerCompany
                                                 );

            result = temp.Select(q => new BaseEntity()
            {
                EntityId = q.Id,
                Action = q.Action
            })
            .FirstOrDefault();
            
            return result;
        }

        #endregion
        #region Get

        #endregion
    }
}