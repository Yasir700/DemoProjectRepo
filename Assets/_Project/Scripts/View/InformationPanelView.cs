using UnityEngine;
using UnityEngine.UI;
using System;
using U.DemoProject.Model.DataType;
using U.DemoProject.Controller;

namespace U.DemoProject.View
{
    public class InformationPanelView : MonoBehaviour
    {
        public Text NameOfBuilding;
        public Image ImageOfBuilding;
        public Text InformationOfBuilding;
        public GameObject ContentField;

        public void CreateProducibleButton(ProducibleItem item)
        {
            GameObject obj = new GameObject("Button", new Type[] { typeof(Image), typeof(Button), typeof(CanvasRenderer) });
            obj.transform.SetParent(ContentField.transform);
            obj.GetComponent<Image>().sprite = item.ObjectImage;
            obj.GetComponent<RectTransform>().localScale = Vector3.one;
            obj.GetComponent<Button>().onClick.AddListener(ControllerGeneral.Instance.GameBoardSoilderSpawnerController.CreateSoldier);
        }
    }
}
