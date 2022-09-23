using U.DemoProject.ObserverSystem.Abstract;
using U.DemoProject.Model.ProductionPanel;
using U.DemoProject.View;


namespace U.DemoProject.ObserverSystem.Concrete.ProductionPanelModelObservers
{
    public class ByProductionPanelView : IObserver
    {
        ProductionPanelModel _subject;
        ProductionPanelView _concrete;


        public ByProductionPanelView(ProductionPanelModel productionPanelModel,ProductionPanelView productionPanelView)
        {
            _subject = productionPanelModel;
            _concrete = productionPanelView;
        }

        public void OnNotify()
        {
            _concrete.CleanActiveButtons();
            _concrete.CreateButtons(_subject.Buttons);
        }
    }
}
