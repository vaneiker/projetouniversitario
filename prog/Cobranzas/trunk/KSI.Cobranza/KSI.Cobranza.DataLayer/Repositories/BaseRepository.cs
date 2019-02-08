using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSI.Cobranza.DataLayer.Interfaces;
using System.Data.Entity;
using KSI.Cobranza.EntityLayer;

namespace KSI.Cobranza.DataLayer.Repositories
{
    public class BaseRepository
    { 
        public readonly EFModel.LoansEntities _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = (dbContext as EFModel.LoansEntities);
        } 
        public IEnumerable<DropDown> GetDropDown(string DropDownName)
        {
            IEnumerable<DropDown> Result;
            var temp = _dbContext.FILL_DROP_DOWN(DropDownName);
            Result = temp.Select(r => new DropDown
            {
                Key=r.Key,
                Value = r.Value
            })
            .ToArray();

            return
                Result;
        }

    }
}
