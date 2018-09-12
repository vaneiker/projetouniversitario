using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DATA.UnderWriting.Repositories.Global;
using DATA.UnderWriting.UnitOfWork;
using Entity.UnderWriting.Entities;

namespace LOGIC.UnderWriting.Global
{
    public class DropDownManager
    {
        private DropDownRepository _dropDownRepository;
        private PropertyInfo[] _properties;
        private string _parta, _partb;
        private IEnumerable<string> _outProp;

        public DropDownManager()
        {
            _dropDownRepository = SingletonUnitOfWork.Instance.DropDownRepository;
            _properties = typeof(DropDown).GetProperties();
            _parta = "\"{0}\":{1}";
            _partb = "\"{0}\":\"{1}\"";
            _outProp = new string[] { "DeductibleCategoryValue" };
        }

        public virtual IEnumerable<DropDown> GetDropDownByType(DropDown.Parameter parameters)
        {
            IEnumerable<DropDown> result, temp;

            parameters.AbaNumber = !string.IsNullOrWhiteSpace(parameters.AbaNumber)
                                        ? parameters.AbaNumber.Trim()
                                        : null;

            temp = _dropDownRepository.GetByType(parameters);

            result = temp != null && temp.Any()
                        ? temp
                            .Select(dd => { return CreateJsonWithKey(dd); })
                            .ToArray()
                        : null;

            return
                result;
        }

        private DropDown CreateJsonWithKey(DropDown row)
        {
            string json, temp, value;
            object oTemp;
            temp = string.Empty;

            foreach (PropertyInfo prop in _properties)
            {
                if (prop.Name.Contains("ElementDesc"))
                {

                }
                if (!_outProp.Contains(prop.Name))
                {
                    if (prop.PropertyType.Name == "Nullable`1" || prop.Name == "GenderId")
                    {
                        oTemp = prop.GetValue(row);
                        value = oTemp != null ? oTemp.ToString().Trim().ToLower() : string.Empty;

                        if (!string.IsNullOrWhiteSpace(value))
                            temp += string.Format(prop.Name == "GenderId" ? _partb : _parta, prop.Name, value) + ",";
                    }
                }
            }

            json = temp.Length > 0 ? "{" + temp.Substring(0, temp.Length - 1) + "}" : string.Empty;

            row.ValueField = json;
            return
                row;
        }
    }
}
