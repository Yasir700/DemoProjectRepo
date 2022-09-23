using System;
using UnityEngine;
using U.DemoProject.Model.GameBoard.Building;
using U.DemoProject.Model.GameBoard.Soldier;
using U.DemoProject.Model.GameBoard;
using U.DemoProject.Model.InformationPanel;
using U.DemoProject.Model.InformationPanel.ProduciblePanel;
using U.DemoProject.Model.ProductionPanel;

namespace U.DemoProject.Model
{
    public class ModelGeneral : MonoBehaviour
    {
        #region Singleton
        private static ModelGeneral _instance;

        public static ModelGeneral Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<ModelGeneral>();
                    if (_instance == null)
                        _instance = new GameObject("ModelGeneral").AddComponent<ModelGeneral>();
                }
                return _instance;
            }
        }
        #endregion


        [NonSerialized] public InformationPanelModel InformationPanelModel;
        [NonSerialized] public ProductionPanelModel ProductionPanelModel;
        [NonSerialized] public GameBoardSimulationModel GameBoardSimulationModel;
        [NonSerialized] public ProductionPanelProduceButtonModel ProductionPanelButtonModel;
        [NonSerialized] public GameBoardBuildingsModel GameBoardBuildingsModel;
        [NonSerialized] public InformationPanelProducablePanelButtonModel InformationPanelProducableButtonModel;
        [NonSerialized] public InformationPanelProducablePanelModel InformationPanelProducablePanelModel;
        [NonSerialized] public SoldierPoolModel SoldierPoolModel;

        private void Awake()
        {
            InformationPanelModel = new InformationPanelModel();
            ProductionPanelModel = new ProductionPanelModel();
            GameBoardSimulationModel = new GameBoardSimulationModel();
            ProductionPanelButtonModel = new ProductionPanelProduceButtonModel();
            GameBoardBuildingsModel = new GameBoardBuildingsModel();
            InformationPanelProducableButtonModel = new InformationPanelProducablePanelButtonModel();
            InformationPanelProducablePanelModel = new InformationPanelProducablePanelModel();
            SoldierPoolModel = new SoldierPoolModel();
        }
    }
}
