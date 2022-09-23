using UnityEngine;

namespace U.DemoProject.Controller.GameBoard
{
    public static class GameBoardSelectionController
    {
        private static GameObject _selectedObject;

        public static void Select(GameObject selectedObject) =>
            _selectedObject = selectedObject;


        public static void Deselect() =>
            _selectedObject = null;


        public static GameObject GetSelectedObject() => _selectedObject;
    }
}
