using System;
using UnityEngine;
using UnityEngine.UI;
using U.DemoProject.Map;
using U.DemoProject.Model;
using U.DemoProject.Model.GameBoard.Soldier;
using U.DemoProject.Controller;
using U.DemoProject.Controller.GameBoard;
using U.DemoProject.Controller.GameBoard.Soldier;

namespace U.DemoProject.View.GameBoardView
{
    public class SoldierView : MonoBehaviour
    {

        [SerializeField] Transform _soldierParentTransform;
        ModelGeneral _modelGeneral;
        ControllerGeneral _controllerGeneral;

        Gridd gridd;

        int indexer;

        private void Start()
        {
            gridd = Gridd.Instance;
            indexer = GameBoardSoilderSpawnerController.id;
            _modelGeneral = ModelGeneral.Instance;
            _controllerGeneral = ControllerGeneral.Instance;
        }


        private void FixedUpdate()
        {
            if (indexer != GameBoardSoilderSpawnerController.id)
            {
                indexer = GameBoardSoilderSpawnerController.id;
                CreateSoldierObject();
            }

            //Observing soldier's pos
            UpdateSoldierPositions();
        }

        private void Update()
        {
            RunSelectionSystem();

            if (Input.GetMouseButtonDown(1) && GameBoardSelectionController.GetSelectedObject() != null)
            {
                GameObject selectedObj = GameBoardSelectionController.GetSelectedObject();
                SoldierModel model = _modelGeneral.SoldierPoolModel.Soldiers[int.Parse(selectedObj.name)];

                StartCoroutine(_controllerGeneral.CharacterMovementController.Move(_modelGeneral.SoldierPoolModel.Soldiers[int.Parse(selectedObj.name)],
                     (int)model.PositionInCell.x, (int)model.PositionInCell.y, (int)GameBoardInputController.MousePositionOnGameBoard_CellType.x,
                     (int)GameBoardInputController.MousePositionOnGameBoard_CellType.y));
            }
        }



        void CreateSoldierObject()
        {
            if (_soldierParentTransform.childCount == 10)
            {
                GameObject soldier1 = _soldierParentTransform.GetChild(GameBoardSoilderSpawnerController.id % SoldierPoolModel.PoolSize).gameObject;
                SoldierModel model1 = _modelGeneral.SoldierPoolModel.Soldiers[GameBoardSoilderSpawnerController.id % SoldierPoolModel.PoolSize];
                soldier1.GetComponent<RectTransform>().localPosition = new Vector3(model1.PositionInCell.x * gridd.CellSize - gridd.CellSize / 2 + gridd.CellSize * 3, model1.PositionInCell.y * gridd.CellSize - gridd.CellSize / 2);
            }
            else
            {
                GameObject soldier = new GameObject((GameBoardSoilderSpawnerController.id % SoldierPoolModel.PoolSize).ToString(), new Type[] { typeof(Image), typeof(RectTransform), typeof(CanvasRenderer), typeof(BoxCollider2D) });
                SoldierModel model = _modelGeneral.SoldierPoolModel.Soldiers[GameBoardSoilderSpawnerController.id];

                soldier.transform.SetParent(_soldierParentTransform);
                soldier.GetComponent<RectTransform>().sizeDelta = new Vector2(gridd.CellSize, gridd.CellSize);
                soldier.GetComponent<RectTransform>().localPosition = new Vector3(model.PositionInCell.x * gridd.CellSize - gridd.CellSize / 2, model.PositionInCell.y * gridd.CellSize - gridd.CellSize / 2);
                soldier.GetComponent<Image>().sprite = model.Image;
                soldier.GetComponent<RectTransform>().localScale = Vector3.one;
                soldier.transform.localScale = Vector3.one;
                soldier.GetComponent<BoxCollider2D>().size = new Vector2(30, 30);
                soldier.tag = "Selectable";
            }
        }

        void UpdateSoldierPositions()
        {
            for (int i = 0; i < _soldierParentTransform.childCount; i++)
            {
                _soldierParentTransform.GetChild(i).GetComponent<RectTransform>().localPosition = new Vector3(
                    _modelGeneral.SoldierPoolModel.Soldiers[i].PositionInCell.x * gridd.CellSize + (gridd.CellSize / 2),
                    _modelGeneral.SoldierPoolModel.Soldiers[i].PositionInCell.y * gridd.CellSize + (gridd.CellSize / 2), 0);
            }
        }

        void RunSelectionSystem()
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition).x,
              FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 200f);

            if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Selectable")
            {
                if (GameBoardSelectionController.GetSelectedObject() != null)
                    GameBoardSelectionController.GetSelectedObject().GetComponent<Image>().color = Color.white;

                GameBoardSelectionController.Select(hit.collider.gameObject);
                hit.collider.gameObject.GetComponent<Image>().color = Color.yellow;
            }

            else if (Input.GetMouseButtonDown(0) && hit.transform.tag != "Selectable")
            {
                if (GameBoardSelectionController.GetSelectedObject() != null)
                    GameBoardSelectionController.GetSelectedObject().GetComponent<Image>().color = Color.white;

                GameBoardSelectionController.Deselect();
            }


        }

    }
}
