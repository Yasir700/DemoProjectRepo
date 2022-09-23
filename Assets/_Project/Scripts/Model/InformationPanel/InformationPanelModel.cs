using UnityEngine;
using U.DemoProject.ObserverSystem.Abstract;
using System.Collections.Generic;
using U.DemoProject.Model.DataType;
using U.DemoProject.View;
using U.DemoProject.ObserverSystem.Concrete.InformationPanelModelObservers;

namespace U.DemoProject.Model.InformationPanel
{
    public class InformationPanelModel : Subject
    {
        private string _header;
        private Sprite _image;
        private string _information;
        public List<ProducibleItem> producibles;

        public string Header { set { _header = value; } get { return _header; } }
        public Sprite Image { set { _image = value; } get { return _image; } }
        public string Information { set { _information = value; Notify(); } get { return _information; } }

        public InformationPanelModel()
        {
            _header = "";
            _image = null;
            _information = "";
            producibles = new List<ProducibleItem>();
            RegisterObserver(new ByInformationPanelView(this, MonoBehaviour.FindObjectOfType<InformationPanelView>()));
        }
    }
}