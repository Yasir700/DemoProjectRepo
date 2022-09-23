using UnityEngine;
using U.DemoProject.Map;
using U.DemoProject.Model.DataBase;

namespace U.DemoProject.Model.GameBoard.Soldier
{
    public class SoldierModel
    {
        public int ID;
        public Vector2 PositionInCell;
        public Vector2 SizeDelta;
        public Sprite Image;

        public SoldierModel()
        {
            SizeDelta = new Vector2(Gridd.Instance.CellSize, Gridd.Instance.CellSize);
            Image = MonoBehaviour.FindObjectOfType<ImagesDataBase>().ProduciblesImages[0];
        }
    }
}
