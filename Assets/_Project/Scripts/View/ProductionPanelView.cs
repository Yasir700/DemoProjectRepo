using UnityEngine;
using U.DemoProject.Model;
using U.DemoProject.Model.ProductionPanel;
using System.Collections.Generic;
using UnityEngine.UI;

namespace U.DemoProject.View
{
    public class ProductionPanelView : MonoBehaviour
    {
        [SerializeField] Transform _contentField;
        [SerializeField] GameObject _dataBase;

        List<GameObject> _activeButtons;
        ModelGeneral _modelGeneral;


        void Start()
        {
            _modelGeneral = ModelGeneral.Instance;
            _activeButtons = new List<GameObject>();
            CreateButtons(_modelGeneral.ProductionPanelModel.Buttons);
        }


        public void CleanActiveButtons()
        {
            if (_activeButtons.Count > 0)
            {
                _activeButtons.ForEach(x => MonoBehaviour.Destroy(x));
                _activeButtons.Clear();
            }
        }

        public void CreateButtons(List<ProductionPanelProduceButtonModel> productionPanelButtonModels)
        {
            foreach (var a in productionPanelButtonModels)
            {
                GameObject theButton = new GameObject(a.Name, a.types);
                theButton.GetComponent<Image>().sprite = a.Image;
                theButton.transform.SetParent(a.Parent);
                theButton.name = a.Name;
                theButton.transform.localScale = Vector3.one;
                theButton.GetComponent<Button>().onClick.AddListener(a.methodToTrigger);
                _activeButtons.Add(theButton);
            }
        }
    }
}
