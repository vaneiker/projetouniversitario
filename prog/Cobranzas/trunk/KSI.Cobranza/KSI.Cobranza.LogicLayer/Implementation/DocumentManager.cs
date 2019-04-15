using KSI.Cobranza.DataLayer;
using KSI.Cobranza.DataLayer.Repositories;
using KSI.Cobranza.EntityLayer;
using KSI.Cobranza.LogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Implementation
{
    public class DocumentManager : BaseManager, IBaseLogic<Document>
    {
        private DocumentRepository _Repository;

        public DocumentManager()
        {
            _Repository = SingletonUnitOfWork.Instance.DocumentRepository;
        }

        /// <summary>
        /// vbarrera | 26 Feb 2019
        /// Inserta un documento
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Result Add(Document entity)
        {
            Result _Result;

            try
            {
                _Result = new Result
                {
                    Action = _Repository.Add(entity).Action,
                    entityId = 0
                };
            }
            catch (Exception ex)
            {
                _Result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return _Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Result Delete(Document entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// vbarrera | 26 Feb 2019
        /// Edita un documento
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Result Edit(Document entity)
        {
            Result _Result;

            try
            {
                _Result = new Result
                {
                    Action = _Repository.Edit(entity).Action,
                    entityId = 0
                };
            }
            catch (Exception ex)
            {
                _Result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

            return _Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BaseResultLogic<Document> FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public ResultLogic<Document> GetAll(long? entityId = default(long?))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// vbarrera | 06 Feb 2019
        /// Invoque para obtener la lista de documentos
        /// relacionados a un queue (QueueId)
        /// </summary>
        /// <param name="QueueId">Id del queue</param>
        /// <returns></returns>
        public ResultLogic<Document> Get(long QueueId)
        {
            ResultLogic<Document> _Result;

            try
            {
                _Result = new ResultLogic<Document>
                {
                    dataResult = _Repository.Get(QueueId),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Document>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }

        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Invoque para obtener un documento en especifico tomando en cuenta el queue/caso
        /// </summary>
        /// <param name="QueueId">Id del queue</param>
        /// <param name="IdRequirement">Id del documento requerido</param>
        /// <returns></returns>
        public ResultLogic<Document> Get(int IdRequirement, long? QueueId)
        {
            ResultLogic<Document> _Result;

            try
            {
                _Result = new ResultLogic<Document>
                {
                    SingleResult = _Repository.Get(IdRequirement, QueueId),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Document>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }

        /// <summary>
        /// vbarrera | 08 Feb 2019
        /// Invoque para obtener un documento en especifico sin considerar el queue/caso
        /// </summary>
        /// <param name="IdRequirement">Id del documento requerido</param>
        /// <returns></returns>
        public ResultLogic<Document> Get(int IdRequirement)
        {
            ResultLogic<Document> _Result;

            try
            {
                _Result = new ResultLogic<Document>
                {
                    SingleResult = _Repository.Get(IdRequirement),
                    result = new Result(null, null)
                };
            }
            catch (Exception ex)
            {
                _Result = new ResultLogic<Document>
                {
                    result = new Result(ex, System.Reflection.MethodBase.GetCurrentMethod().Name)
                };
            }

            return _Result;
        }
    }
}
