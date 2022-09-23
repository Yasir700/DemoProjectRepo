
using System.Collections.Generic;

namespace U.DemoProject.Model.StorageComunicatorComponents
{
    public interface ITextFileCommunicator<T>
    {
        T GetTheData(int rowOrder);
        List<T> GetAllDatas();
    }
}
