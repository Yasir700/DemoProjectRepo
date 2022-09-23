namespace U.DemoProject.Model.GameBoard.Soldier
{
    public class SoldierPoolModel
    {
        public static int PoolSize;

        public SoldierModel[] Soldiers;

        public SoldierPoolModel()
        {
            PoolSize = 10;
            Soldiers = new SoldierModel[PoolSize];
        }
    }
}