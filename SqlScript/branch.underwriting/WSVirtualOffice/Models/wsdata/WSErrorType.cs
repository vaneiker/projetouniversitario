using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.wsdata
{
    public enum WSErrorType
    {
        IS_BLANK=1,
        IS_NULL=2,
        IS_LESS_THAN=3,
        IS_GREATER_THAN = 4,
        IS_A_VALUE=5,
        VALUE_NOT_IN=6,
        VALUE_NOT_IN_RANGE=7,
        VALUE_NOT_IN_LIST = 8,
        CALCULATION_ERROR=9

    }
}