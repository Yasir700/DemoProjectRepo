using System.Collections.Generic;

namespace U.DemoProject.Model.StorageComunicatorComponents
{
    public abstract class ACStoredInformationType
    {
        private List<string> _datas = new List<string>();
        public List<string> datas { set { _datas = value; ConvertDataToObject(); } get { return _datas; } }
        protected abstract void ConvertDataToObject();
    }
}
