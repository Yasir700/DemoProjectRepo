using System;
using System.Collections.Generic;
using U.DemoProject.ObserverSystem.Abstract;

namespace U.DemoProject.Model.InformationPanel.ProduciblePanel
{
    public class InformationPanelProducablePanelModel : Subject
    {
        private List<InformationPanelProducablePanelButtonModel> _buttons;
        public List<InformationPanelProducablePanelButtonModel> Buttons
        {
            set
            {
                _buttons = value;
                Notify();
            }
            get { return _buttons; }
        }

        public InformationPanelProducablePanelModel()
        {
            _buttons = new List<InformationPanelProducablePanelButtonModel>();
        }
    }
}
