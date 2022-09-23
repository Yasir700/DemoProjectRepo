using UnityEngine;
using U.DemoProject.Model.DataType;
using U.DemoProject.Map;
using U.DemoProject.Model;
using U.DemoProject.Model.GameBoard;
using U.DemoProject.Model.GameBoard.Building;

namespace U.DemoProject.Controller.GameBoard
{
    public class GameBoardSimulationController
    {
        Gridd gridd;

        public static BuildingItem ActiveBuilding;
        public bool CanBuild;
        public int[] EdgesInCell;

        Transform _placedBuildingsParentsTransform;
        Transform _simulationParentTransform;
        ModelGeneral _modelGeneral;

        int topCell, bottomCell, veryLeftCell, veryRightCell; //Edges


        public GameBoardSimulationController(Transform placedBuildingsParentsTransform, Transform simulationParentTransform)
        {
            gridd = Gridd.Instance;
            _placedBuildingsParentsTransform = placedBuildingsParentsTransform;
            _modelGeneral = ModelGeneral.Instance;
            _simulationParentTransform = simulationParentTransform;
            GameBoardSimulationModel = _modelGeneral.GameBoardSimulationModel;
        }


        bool workOnce = true;
        public GameBoardSimulationModel GameBoardSimulationModel;
        public void SetSimulationModel()
        {
            if (ActiveBuilding != null) //If simulation is running
            {
                if (workOnce) //If the simulation is running for the first time
                {
                    workOnce = false;

                    GameBoardSimulationModel.Parent = _simulationParentTransform;
                    GameBoardSimulationModel.Image = ActiveBuilding.BuildsImage;
                    GameBoardSimulationModel.SizeDelta = new Vector2(32 * ActiveBuilding.Width, gridd.CellSize * ActiveBuilding.Height);
                    GameBoardSimulationModel.Name = ActiveBuilding.Name;
                    GameBoardSimulationModel.Active = true;

                }
                SetPosition(); //Constantly refreshes the position of the simulation
                SetColorAndCanBuild(); //Constantly refreshes "CanBuild" situation
            }
            else
            {
                workOnce = true;
                GameBoardSimulationModel.Active = false;
            }
            void SetPosition()
            {
                int xPos = 0;
                int yPos = 0;

                MainPositioning();
                EdgeLimitation();
                SetEdges();

                GameBoardSimulationModel.Position = new Vector3(xPos, yPos, 0);


                void MainPositioning()
                {
                    if (ActiveBuilding.Width % 2 == 0)
                        xPos = (int)GameBoardInputController.MousePositionOnGameBoard_CellType.x * gridd.CellSize;
                    else
                        xPos = (int)GameBoardInputController.MousePositionOnGameBoard_CellType.x * gridd.CellSize + (gridd.CellSize / 2);

                    if (ActiveBuilding.Height % 2 == 0)
                        yPos = (int)GameBoardInputController.MousePositionOnGameBoard_CellType.y * gridd.CellSize;
                    else
                        yPos = (int)GameBoardInputController.MousePositionOnGameBoard_CellType.y * gridd.CellSize + (gridd.CellSize / 2);
                }
                void EdgeLimitation()
                {
                    if (GameBoardSimulationModel.Active)
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            if (ActiveBuilding.Height == i)
                            {
                                if (GameBoardInputController.MousePositionOnGameBoard_CellType.y <= i / 2)
                                    yPos = gridd.CellSize * i / 2;
                                if (GameBoardInputController.MousePositionOnGameBoard_CellType.y + i / 2 >= gridd.HeightCellCount)
                                    yPos = gridd.HeightCellCount * gridd.CellSize - (gridd.CellSize * i / 2);
                            }

                            if (ActiveBuilding.Width == i)
                            {
                                if (GameBoardInputController.MousePositionOnGameBoard_CellType.x <= i / 2)
                                {
                                    xPos = gridd.CellSize * i / 2;
                                }
                                if (GameBoardInputController.MousePositionOnGameBoard_CellType.x + i / 2 >= gridd.WidthCellCount)
                                {
                                    xPos = gridd.WidthCellCount * gridd.CellSize - (gridd.CellSize * i / 2);
                                }
                            }
                        }
                    }
                }
                void SetEdges()
                {
                    if (ActiveBuilding.Height % 2 == 1)
                        topCell = (int)(yPos / gridd.CellSize) + (int)(ActiveBuilding.Height / 2);
                    if (ActiveBuilding.Height % 2 == 0)
                        topCell = (int)(yPos / gridd.CellSize) + (int)(ActiveBuilding.Height / 2) - 1;

                    bottomCell = (int)(yPos / gridd.CellSize) - (int)(ActiveBuilding.Height / 2);

                    veryLeftCell = (int)(xPos / gridd.CellSize) - (int)(ActiveBuilding.Width / 2);

                    if (ActiveBuilding.Width % 2 == 1)
                        veryRightCell = (int)(xPos / gridd.CellSize) + (int)(ActiveBuilding.Width / 2);
                    if (ActiveBuilding.Width % 2 == 0)
                        veryRightCell = (int)(xPos / gridd.CellSize) + (int)(ActiveBuilding.Width / 2) - 1;
                }
            }
            void SetColorAndCanBuild()
            {
                GameBoardSimulationModel.Color = Color.green;
                CanBuild = true;
                for (int y = 0; y <= (topCell - bottomCell); y++)
                {
                    for (int x = 0; x <= (veryRightCell - veryLeftCell); x++)
                    {
                        if (gridd.GridArray[veryLeftCell + x, bottomCell + y] == -1)
                        {
                            GameBoardSimulationModel.Color = Color.red;
                            CanBuild = false;
                            break;
                        }
                    }
                }
            }
        }

        public void StopSimulating()
        {
            if (ActiveBuilding != null) ActiveBuilding = null;
        }

        public void BuildSimulation()
        {
            EdgesInCell = new int[] { topCell, bottomCell, veryLeftCell, veryRightCell };
            SetGameBoardBuildingModel(SetGameBoardBuildingBlueprintModel(_placedBuildingsParentsTransform));
            StopSimulating();
        }

        GameBoardBuildingBlueprintModel SetGameBoardBuildingBlueprintModel(Transform parent)
        {
            GameBoardBuildingBlueprintModel gameBoardBuildingModel = new GameBoardBuildingBlueprintModel();

            gameBoardBuildingModel.Name = GameBoardSimulationModel.Name;
            gameBoardBuildingModel.Position = GameBoardSimulationModel.Position;
            gameBoardBuildingModel.Image = GameBoardSimulationModel.Image;
            gameBoardBuildingModel.SizeDelta = GameBoardSimulationModel.SizeDelta;
            gameBoardBuildingModel.Parent = parent;

            return gameBoardBuildingModel;
        }

        void SetGameBoardBuildingModel(GameBoardBuildingBlueprintModel model) => _modelGeneral.GameBoardBuildingsModel.Buildings.Add(model);

    }
}
