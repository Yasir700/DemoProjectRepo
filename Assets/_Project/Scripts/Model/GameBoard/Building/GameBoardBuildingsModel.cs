using System.Collections.Generic;
using U.DemoProject.ObserverSystem.Abstract;

namespace U.DemoProject.Model.GameBoard.Building
{
    public class GameBoardBuildingsModel:Subject
    {
        private List<GameBoardBuildingBlueprintModel> _buildings;

        public List<GameBoardBuildingBlueprintModel> Buildings
        {
            set
            {
                _buildings = value;
                Notify();
            }
            get { return _buildings; }
        }

        public GameBoardBuildingsModel() =>
            _buildings = new List<GameBoardBuildingBlueprintModel>();
    }
}
