using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using U.DemoProject.Model.DataType;


namespace U.DemoProject.Model.GameBoard.Building
{
    public class GameBoardBuildingBlueprintModel
    {
        public string Name;
        public Vector3 Position;
        public Sprite Image;
        public Vector2 SizeDelta;
        public Transform Parent;
        public Vector3 LocalScale;
        public Type[] types;
        public List<ProducibleItem> producibles;

        public GameBoardBuildingBlueprintModel()
        {
            LocalScale = Vector3.one;
            types = new Type[] { typeof(Image), typeof(CanvasRenderer), typeof(Button) };
        }
    }
}