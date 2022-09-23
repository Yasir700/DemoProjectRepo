using System.Collections.Generic;
using U.DemoProject.Model.StorageComunicatorComponents;
using U.DemoProject.Model.DataType;
using UnityEngine;

namespace U.DemoProject.Model.DataBase
{
    public class ProducableDataBase : MonoBehaviour
    {
        public List<ProducibleItem> producibles;
        TextFileCommunicator_ACStroredInformationType<ProducibleItem> communicator;

        [SerializeField] TextAsset _textFile;

        private void Awake()
        {
            communicator = new TextFileCommunicator_ACStroredInformationType<ProducibleItem>(_textFile);
            producibles = communicator.GetAllDatas();
        }

        public List<ProducibleItem> GetBarracksPackage()
        {
            List<ProducibleItem> result = new List<ProducibleItem>();
            result.Add(producibles[0]);
            return result;
        }

    }
}
