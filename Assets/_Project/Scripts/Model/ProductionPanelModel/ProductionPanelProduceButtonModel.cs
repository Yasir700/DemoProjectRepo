using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace U.DemoProject.Model.ProductionPanel
{
    public class ProductionPanelProduceButtonModel
    {
        public Sprite Image;
        public Transform Parent;
        public Vector3 LocalScale;
        public string Name;
        public Type[] types;
        public UnityAction methodToTrigger;

        public ProductionPanelProduceButtonModel()
        {
            LocalScale = Vector3.one;
            types = new Type[] { typeof(CanvasRenderer), typeof(Image), typeof(Button) };
        }
    }
}
