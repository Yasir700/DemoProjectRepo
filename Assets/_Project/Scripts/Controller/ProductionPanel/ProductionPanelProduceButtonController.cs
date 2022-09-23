using System.Collections.Generic;
using UnityEngine.EventSystems;
using U.DemoProject.Model.DataType;
using U.DemoProject.Model.DataBase;
using U.DemoProject.Controller.GameBoard;

namespace U.DemoProject.Controller.ProductionPanel
{
    public class ProductionPanelProduceButtonController
    {
        List<BuildingItem> buildings;

        public ProductionPanelProduceButtonController(BuildingDataBase buildingDataBase) =>
            buildings = buildingDataBase.Buildings;

        public void ButtonAction()
        {
            foreach (var x in buildings)
                if (x.Name == EventSystem.current.currentSelectedGameObject.name)
                    GameBoardSimulationController.ActiveBuilding = x;
        }
    }
}
