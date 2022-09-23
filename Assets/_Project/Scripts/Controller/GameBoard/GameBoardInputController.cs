using UnityEngine;


namespace U.DemoProject.Controller.GameBoard
{
    public class GameBoardInputController
    {
        private int _pixelWidthOfScreen = 0;

        public static Vector2 MousePositionOnGameBoard_CellType;


        public GameBoardInputController(Camera camera)
        {
            MousePositionOnGameBoard_CellType = new Vector2();
            _pixelWidthOfScreen = camera.pixelWidth;
        }


        public void UpdateMousePositionOnGameBoard_CellType()
        {
            MousePositionOnGameBoard_CellType.x = (int)((Input.mousePosition.x - _pixelWidthOfScreen * .24609375f) / 32);
            MousePositionOnGameBoard_CellType.y = (int)(Input.mousePosition.y / 32);
        }
    }
}
