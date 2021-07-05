using DevExpressGrid.network;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevExpressGrid.extensions {
    /* Return result after page pop-up */
    public interface IResultListener {
        void onPageResult(EmployeeItem item, ResultApiCodes arg);
    }

    public enum ResultApiCodes { Delete, Create }
}
