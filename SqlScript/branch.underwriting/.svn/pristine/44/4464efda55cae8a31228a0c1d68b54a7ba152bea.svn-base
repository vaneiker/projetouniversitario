using System;
using System.Collections.Generic;
using DI.UnderWriting.Interfaces;
using Entity.UnderWriting.Entities;
using LOGIC.UnderWriting.Global;

namespace DI.UnderWriting.Implementations
{
    public class DropDownBll : IDropDown
    {
        private DropDownManager _dropDownManager;

        public DropDownBll()
        {
            _dropDownManager = new DropDownManager();
        }

        IEnumerable<DropDown> IDropDown.GetDropDownByType(DropDown.Parameter parameters)
        {
            return
                _dropDownManager.GetDropDownByType(parameters);

        }
    }

    public class DropDownWS : IDropDown
    {
        IEnumerable<DropDown> IDropDown.GetDropDownByType(DropDown.Parameter parameters)
        {
            throw new NotImplementedException();
        }
    }
}
