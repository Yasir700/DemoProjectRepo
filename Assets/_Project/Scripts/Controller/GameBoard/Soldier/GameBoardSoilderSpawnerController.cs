using UnityEngine;
using U.DemoProject.Map;
using U.DemoProject.Model;
using U.DemoProject.Model.GameBoard.Soldier;
using U.DemoProject.Controller.InformationPanel;


namespace U.DemoProject.Controller.GameBoard.Soldier
{
    public class GameBoardSoilderSpawnerController
    {
        public static int id = -1;

        public void CreateSoldier()
        {
            SoldierModel model = new SoldierModel();
            int xPos = (int)(InformationPanelController.ActiveObjectInformation.GetComponent<RectTransform>().localPosition.x / Gridd.Instance.CellSize);
            int yPos = (int)(InformationPanelController.ActiveObjectInformation.GetComponent<RectTransform>().localPosition.y / Gridd.Instance.CellSize);
            model.PositionInCell = new Vector2(xPos + 3, yPos);
            id++;
            model.ID = (id % SoldierPoolModel.PoolSize);
            ModelGeneral.Instance.SoldierPoolModel.Soldiers[model.ID] = model;
        }
    }
}
