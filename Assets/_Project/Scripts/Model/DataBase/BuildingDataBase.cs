using System.Collections.Generic;
using U.DemoProject.Model.StorageComunicatorComponents;
using U.DemoProject.Model.DataType;
using UnityEngine;


namespace U.DemoProject.Model.DataBase
{
    public class BuildingDataBase : MonoBehaviour
    {
        public List<BuildingItem> Buildings;
        TextFileCommunicator_ACStroredInformationType<BuildingItem> communicator;

        [SerializeField] TextAsset _textFile;

        private void Awake()
        {
            communicator = new TextFileCommunicator_ACStroredInformationType<BuildingItem>(_textFile);
            Buildings = communicator.GetAllDatas();
        }
    }
}
