using UnityEngine;
using U.DemoProject.Map;
using U.DemoProject.Controller;
using U.DemoProject.Controller.GameBoard;
using U.DemoProject.Model;
using U.DemoProject.Model.GameBoard.Building;
using U.DemoProject.Model.GameBoard;
using UnityEngine.UI;

namespace U.DemoProject.View.GameBoardView
{
    public class SimulationView : MonoBehaviour
    {
        Gridd gridd;

        ModelGeneral _modelGeneral;
        ControllerGeneral _controllerGeneral;

        GameBoardInputController _gameBoardInputController;
        GameBoardSimulationController _gameBoardSimulationController;

        private void Start()
        {
            gridd = Gridd.Instance;
            _modelGeneral = ModelGeneral.Instance;
            _controllerGeneral = ControllerGeneral.Instance;

            _gameBoardInputController = _controllerGeneral.GameBoardInputController;
            _gameBoardSimulationController = _controllerGeneral.GameBoardSimulationController;

            _simulationModel = _modelGeneral.GameBoardSimulationModel;

            _workOnce = true;
        }

        private void FixedUpdate()
        {
            _gameBoardSimulationController.SetSimulationModel();
            _gameBoardInputController.UpdateMousePositionOnGameBoard_CellType();

            if (Input.GetMouseButton(1) && GameBoardSimulationController.ActiveBuilding != null)
                _gameBoardSimulationController.StopSimulating();

            if (Input.GetMouseButton(0) && _gameBoardSimulationController.GameBoardSimulationModel.Active && _gameBoardSimulationController.CanBuild)
                _gameBoardSimulationController.BuildSimulation();

            ManageSimulationObject();

            if (_modelGeneral.GameBoardBuildingsModel.Buildings.Count != GameObject.Find("PlacedBuildings").transform.childCount)
            {
                CreateBuilding();
            }
            if (_simulation != null) _simulation.GetComponent<Image>().color = _simulationModel.Color;
        }



        bool _workOnce;
        GameObject _simulation;
        GameBoardSimulationModel _simulationModel;
        void ManageSimulationObject()
        {
            if (_simulationModel.Active)
            {
                if (_workOnce)
                {
                    _workOnce = false;

                    _simulation = new GameObject("Simulation", _simulationModel.types);
                    _simulation.transform.SetParent(_simulationModel.Parent);
                    _simulation.GetComponent<Image>().sprite = _simulationModel.Image;
                    _simulation.GetComponent<RectTransform>().sizeDelta = _simulationModel.SizeDelta;
                    _simulation.transform.localScale = _simulationModel.LocalScale;
                    _simulation.GetComponent<Image>().color = _simulationModel.Color;
                }
                _simulation.GetComponent<RectTransform>().localPosition = _simulationModel.Position;
            }
            else
            {
                _workOnce = true;
                if (_simulation != null) Destroy(_simulation);
            }
        }

        void CreateBuilding()
        {
            int order = _modelGeneral.GameBoardBuildingsModel.Buildings.Count;
            order--;
            GameBoardBuildingBlueprintModel buildingInfo = _modelGeneral.GameBoardBuildingsModel.Buildings[order];

            GameObject gameObject = new GameObject(buildingInfo.Name, buildingInfo.types);
            gameObject.GetComponent<Image>().sprite = buildingInfo.Image;
            gameObject.GetComponent<RectTransform>().sizeDelta = buildingInfo.SizeDelta;
            gameObject.transform.SetParent(buildingInfo.Parent);
            gameObject.transform.localScale = buildingInfo.LocalScale;
            gameObject.GetComponent<RectTransform>().localPosition = buildingInfo.Position;
            gameObject.GetComponent<Button>().onClick.AddListener(FindObjectOfType<ControllerGeneral>().InformationPanelController.RefreshInformationPanelModel);


            MarkOverprintedCells(_gameBoardSimulationController.EdgesInCell);

            void MarkOverprintedCells(int[] coveredAreaInCell)
            {
                for (int y = 0; y <= (coveredAreaInCell[0] - coveredAreaInCell[1]); y++)
                    for (int x = 0; x <= (coveredAreaInCell[3] - coveredAreaInCell[2]); x++)
                        gridd.SetValueOfACell(coveredAreaInCell[2] + x, coveredAreaInCell[1] + y, -1);
            }

        }
    }
}
