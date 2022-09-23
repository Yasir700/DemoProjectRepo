using System;
using UnityEngine;
using U.DemoProject.ObserverSystem.Abstract;
using U.DemoProject.Model;
using U.DemoProject.View;
using U.DemoProject.Model.InformationPanel;

namespace U.DemoProject.ObserverSystem.Concrete.InformationPanelModelObservers
{
    public class ByInformationPanelView : IObserver
    {
        InformationPanelModel _subject;
        InformationPanelView _concrete;

        public ByInformationPanelView(InformationPanelModel informationPanelModel, InformationPanelView informationPanelView)
        {
            _subject = informationPanelModel;
            _concrete = informationPanelView;
        }

        public void OnNotify()
        {
            _concrete.NameOfBuilding.text = _subject.Header;
            _concrete.ImageOfBuilding.sprite = _subject.Image;
            _concrete.InformationOfBuilding.text = _subject.Information;

            for (int i = 0; i < _concrete.ContentField.transform.childCount; i++)
                MonoBehaviour.Destroy(_concrete.ContentField.transform.GetChild(i).gameObject);

            foreach (var a in _subject.producibles)
                _concrete.CreateProducibleButton(a);

        }
    }
}
