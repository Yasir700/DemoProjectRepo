using UnityEngine;
using UnityEngine.EventSystems;
using U.DemoProject.Model.DataBase;
using U.DemoProject.Model;
using U.DemoProject.Model.InformationPanel;

namespace U.DemoProject.Controller.InformationPanel
{
    public class InformationPanelController
    {
        InformationPanelModel _informationPanelModel;
        BuildingDataBase _buildingDataBase;
        public static GameObject ActiveObjectInformation;

        public InformationPanelController(BuildingDataBase buildingDataBase)
        {
            _informationPanelModel = MonoBehaviour.FindObjectOfType<ModelGeneral>().InformationPanelModel;
            _buildingDataBase = buildingDataBase;
        }
        public void RefreshInformationPanelModel()
        {
            foreach (var a in _buildingDataBase.GetComponent<BuildingDataBase>().Buildings)
            {
                if (a.Name == EventSystem.current.currentSelectedGameObject.name)
                {
                    _informationPanelModel.Image = a.BuildsImage;
                    _informationPanelModel.Header = a.Name;
                    _informationPanelModel.producibles = a.Products;
                    _informationPanelModel.Information = a.Information;
                    ActiveObjectInformation = EventSystem.current.currentSelectedGameObject;
                }
            }
        }
    }
}
