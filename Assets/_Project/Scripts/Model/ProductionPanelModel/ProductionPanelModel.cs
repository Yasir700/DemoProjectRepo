using System.Collections.Generic;
using U.DemoProject.ObserverSystem.Abstract;
using U.DemoProject.ObserverSystem.Concrete.ProductionPanelModelObservers;
using UnityEngine;

namespace U.DemoProject.Model.ProductionPanel
{
    public class ProductionPanelModel : Subject
    {
        private List<ProductionPanelProduceButtonModel> _buttons;
        public List<ProductionPanelProduceButtonModel> Buttons
        {
            set
            {
                _buttons = value;
                Notify();
            }
            get { return _buttons; }
        }

        public ProductionPanelModel()
        {
            _buttons = new List<ProductionPanelProduceButtonModel>();
            RegisterObserver(new ByProductionPanelView(this, MonoBehaviour.FindObjectOfType<U.DemoProject.View.ProductionPanelView>()));
        }
    }
}
