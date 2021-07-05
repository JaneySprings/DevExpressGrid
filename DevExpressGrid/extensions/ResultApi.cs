using DevExpressGrid.Network;

namespace DevExpressGrid.Extensions {

    public interface IResultListener {
        void OnPageResult(EmployeeItem item, ResultApiCodes arg);
    }

    public enum ResultApiCodes { Delete, Create }
}
