using System;
using UnityEngine.UI;
using UnityEngine;
using U.DemoProject.ObserverSystem.Abstract;

namespace U.DemoProject.Model.GameBoard
{
    public class GameBoardSimulationModel : Subject
    {
        public bool Active;
        public string Name;
        public Color Color;
        public Vector3 Position;
        public Vector3 LocalScale;
        public Vector2 SizeDelta;
        public Sprite Image;
        public Transform Parent;
        public Type[] types;


        public GameBoardSimulationModel()
        {
            types = new Type[] { typeof(Image), typeof(CanvasRenderer) };
            LocalScale = Vector3.one;
            Active = false;
        }
    }
}
