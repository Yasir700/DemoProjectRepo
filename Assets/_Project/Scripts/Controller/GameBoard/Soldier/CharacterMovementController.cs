using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using U.DemoProject.Model.GameBoard.Soldier;
using U.DemoProject.Map;


namespace U.DemoProject.Controller.GameBoard.Soldier
{
    public class CharacterMovementController
    {

        List<PathNode> route = new List<PathNode>();

        PathFinding pathFinding;

        public CharacterMovementController() =>
            pathFinding = new PathFinding();


        public IEnumerator Move(SoldierModel model, int startX, int startY, int endX, int endY)
        {
            route = new List<PathNode>();
            route = pathFinding.FindPath(startX, startY, endX, endY);

            for (int i = 0; i < route.Count; i++)
            {
                model.PositionInCell = new Vector2(route[i].x, route[i].y);
                yield return new WaitForSeconds(.2f);
            }
        }
    }
}