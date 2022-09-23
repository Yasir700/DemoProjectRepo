using U.DemoProject.Model.DataType;
using System.Collections.Generic;
using UnityEngine;
using U.DemoProject.Model.DataBase;
using U.DemoProject.Model;
using U.DemoProject.Model.ProductionPanel;

namespace U.DemoProject.Controller.ProductionPanel
{
    public class ProductionPanelController
    {
        List<BuildingItem> _buildings;
        Transform _contentFieldForProduceButton;
        ModelGeneral _modelGeneral;
        ControllerGeneral _controllerGeneral;


        public ProductionPanelController(Transform productionPanelProduceButtonModelParentTransform, BuildingDataBase buildingDataBase, ControllerGeneral controllerGeneral)
        {
            _contentFieldForProduceButton = productionPanelProduceButtonModelParentTransform;
            _buildings = buildingDataBase.Buildings;
            _modelGeneral = ModelGeneral.Instance;
            _controllerGeneral = controllerGeneral;

            SetProductionPanelModel();
        }


        public void SetProductionPanelModel()
        {
            _modelGeneral.ProductionPanelModel.Buttons = CreateAllButtonModels();

            List<ProductionPanelProduceButtonModel> CreateAllButtonModels()
            {
                List<ProductionPanelProduceButtonModel> result = new List<ProductionPanelProduceButtonModel>();
                for (int i = 0; i < _buildings.Count; i++)
                {
                    ProductionPanelProduceButtonModel productionPanelButtonModel = new ProductionPanelProduceButtonModel();
                    productionPanelButtonModel.Image = _buildings[i].BuildsImage;
                    productionPanelButtonModel.Name = _buildings[i].Name;
                    productionPanelButtonModel.Parent = _contentFieldForProduceButton;
                    productionPanelButtonModel.methodToTrigger = _controllerGeneral.ProductionPanelProduceButtonController.ButtonAction;

                    result.Add(productionPanelButtonModel);
                }
                return result;
            }
        }
    }
}
