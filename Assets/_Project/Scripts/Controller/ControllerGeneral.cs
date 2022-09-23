using UnityEngine;
using U.DemoProject.Model.DataBase;
using U.DemoProject.Controller.GameBoard.Soldier;
using U.DemoProject.Controller.GameBoard;
using U.DemoProject.Controller.InformationPanel;
using U.DemoProject.Controller.ProductionPanel;

namespace U.DemoProject.Controller
{
    public class ControllerGeneral : MonoBehaviour
    {
        #region Singleton
        private static ControllerGeneral _instance;

        public static ControllerGeneral Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ControllerGeneral>();
                    if (_instance == null)
                        _instance = new GameObject("ControllerGeneral").AddComponent<ControllerGeneral>();
                }
                return _instance;
            }
        }
        #endregion

        [SerializeField] Camera _camera;
        [SerializeField] BuildingDataBase _buildingDataBase;
        [SerializeField] Transform _productionPanelButtonModelTransform;
        [SerializeField] Transform _placedBuildingsTransform;
        [SerializeField] Transform _soldierParentTransform;
        [SerializeField] Transform _simulationParentTransform;

        public GameBoardSoilderSpawnerController GameBoardSoilderSpawnerController;
        public GameBoardInputController GameBoardInputController;
        public GameBoardSimulationController GameBoardSimulationController;
        public ProductionPanelController ProductionPanelController;
        public ProductionPanelProduceButtonController ProductionPanelProduceButtonController;
        public InformationPanelController InformationPanelController;
        public CharacterMovementController CharacterMovementController;

        private void Start()
        {
            GameBoardInputController = new GameBoardInputController(_camera);
            GameBoardSimulationController = new GameBoardSimulationController(_placedBuildingsTransform, _simulationParentTransform);
            InformationPanelController = new InformationPanelController(_buildingDataBase);
            ProductionPanelProduceButtonController = new ProductionPanelProduceButtonController(_buildingDataBase);
            ProductionPanelController = new ProductionPanelController(_productionPanelButtonModelTransform, _buildingDataBase, this);
            GameBoardSoilderSpawnerController = new GameBoardSoilderSpawnerController();
            CharacterMovementController = new CharacterMovementController();
        }

    }
}
