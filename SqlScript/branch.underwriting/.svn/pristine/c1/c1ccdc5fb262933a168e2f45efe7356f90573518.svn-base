using System;
using System.Collections.Generic;
using System.Data;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class FormBll : IForm
    {
        private FormManager _formManager;

        public FormBll()
        {
            _formManager = new FormManager();
        }

        IEnumerable<Form.FieldValue> IForm.GetFormFieldValues(Form.FieldValue.Parameter parameters)
        {
            return
                _formManager.GetFormFieldValues(parameters);
        }

        DataTable IForm.GetFormDetailUddt()
        {
            return
                _formManager.GetFormDetailUddt();
        }

        void IForm.SetFormDetail(DataTable formDetail)
        {
            _formManager.SetFormDetail(formDetail);
        }
    }

    public class FormWS : IForm
    {
        IEnumerable<Form.FieldValue> IForm.GetFormFieldValues(Form.FieldValue.Parameter parameters)
        {
            throw new NotImplementedException();
        }

        DataTable IForm.GetFormDetailUddt()
        {
            throw new NotImplementedException();
        }

        void IForm.SetFormDetail(DataTable formDetail)
        {
            throw new NotImplementedException();
        }
    }
}
