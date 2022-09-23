using System;
using UnityEngine;
using UnityEngine.UI;


namespace U.DemoProject.Model.InformationPanel.ProduciblePanel
{
    public class InformationPanelProducablePanelButtonModel
    {
        public Sprite Image;
        public Transform Parent;
        public Vector3 LocalScale;
        public string Name;
        public Type[] types;

        public InformationPanelProducablePanelButtonModel()
        {
            LocalScale = Vector3.one;
            types = new Type[] { typeof(CanvasRenderer), typeof(Image), typeof(Button) };
        }

    }
}
