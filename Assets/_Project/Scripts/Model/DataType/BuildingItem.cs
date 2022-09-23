using System.Collections.Generic;
using UnityEngine;
using U.DemoProject.Model.StorageComunicatorComponents;
using U.DemoProject.Model.DataBase;

namespace U.DemoProject.Model.DataType
{
    public class BuildingItem : ACStoredInformationType
    {
        public string Name;
        public int Width;
        public int Height;
        public string Information;
        public Sprite BuildsImage;
        public List<ProducibleItem> Products;

        protected override void ConvertDataToObject()
        {
            Name = datas[0];
            Width = int.Parse(datas[1]);
            Height = int.Parse(datas[2]);
            Information = datas[3];
            BuildsImage = GameObject.Find("DataBase").GetComponent<ImagesDataBase>().BuildingsImages[int.Parse(datas[4])];
            if (datas[0] == "Barracks")
                Products = GameObject.Find("DataBase").GetComponent<ProducableDataBase>().GetBarracksPackage();
            else
                Products = new List<ProducibleItem>();
        }
    }
}
