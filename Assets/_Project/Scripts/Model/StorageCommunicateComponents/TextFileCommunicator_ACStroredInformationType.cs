using UnityEngine;
using System.Collections.Generic;

namespace U.DemoProject.Model.StorageComunicatorComponents
{
    public class TextFileCommunicator_ACStroredInformationType<T> : ITextFileCommunicator<T> where T : ACStoredInformationType, new()
    {
        TextAsset _textFile;

        public TextFileCommunicator_ACStroredInformationType(TextAsset textAsset)
        {
            _textFile = textAsset;
        }

        public List<T> GetAllDatas()
        {
            string[] allTextLineByLine = _textFile.text.Split("\n\r".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
            List<T> result = new List<T>();
            foreach (var a in allTextLineByLine)
            {
                T info = new T();
                List<string> objectDatas = new List<string>();
                for (int i = 0; i < a.Split(System.Convert.ToChar(",")).Length; i++)
                {
                    objectDatas.Add(a.Split(System.Convert.ToChar(","))[i]);
                }
                info.datas = objectDatas;
                result.Add(info);
            }
            return result;
        }
        public T GetTheData(int rowOrder)
        {
            rowOrder--;
            List<T> datas = GetAllDatas();
            return datas[rowOrder];
        }

    }
}
