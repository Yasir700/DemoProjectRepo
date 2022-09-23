using U.DemoProject.Model.StorageComunicatorComponents;
using UnityEngine;
using U.DemoProject.Model.DataBase;

namespace U.DemoProject.Model.DataType
{
    public class ProducibleItem : ACStoredInformationType
    {
        public string Name;
        public int Width;
        public int Height;
        public string Information;
        public Sprite ObjectImage;

        protected override void ConvertDataToObject()
        {
            Name = datas[0];
            Width = int.Parse(datas[1]);
            Height = int.Parse(datas[2]);
            Information = datas[3];
            ObjectImage = GameObject.Find("DataBase").GetComponent<ImagesDataBase>().ProduciblesImages[int.Parse(datas[4])];
        }
    }
}
