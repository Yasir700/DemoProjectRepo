using UnityEngine;

namespace U.DemoProject.Map
{
    public class Gridd
    {
        #region Singleton
        private static Gridd _singleGridd;
        public static Gridd Instance
        {
            get
            {
                if (_singleGridd == null)
                    _singleGridd = new Gridd((int)(GameObject.Find("Main Camera").GetComponent<Camera>().pixelWidth * 17 / 34 / 32),
                        (int)(GameObject.Find("Main Camera").GetComponent<Camera>().pixelHeight / 32), GameObject.Find("GameBoardPanel").transform.GetChild(0).transform);

                return _singleGridd;
            }
        }
        #endregion

        static Gridd()
        {
            _singleGridd = new Gridd((int)(GameObject.Find("Main Camera").GetComponent<Camera>().pixelWidth * 17 / 34 / 32),
                        (int)(GameObject.Find("Main Camera").GetComponent<Camera>().pixelHeight / 32),
                        GameObject.Find("GameBoardPanel").transform.GetChild(0).transform);
        }

        public int HeightCellCount;
        public int WidthCellCount;
        public int CellSize;

        public int[,] GridArray;
        public PathNode[,] nodes;

        private TextMesh[,] debugTextArray;

        private Gridd(int width, int height, Transform parent)
        {
            CellSize = 32;
            WidthCellCount = width;
            HeightCellCount = height;

            GridArray = new int[WidthCellCount, HeightCellCount];
            nodes = new PathNode[WidthCellCount, HeightCellCount];
            debugTextArray = new TextMesh[WidthCellCount, HeightCellCount];

            CreateCells();

            void CreateCells()
            {
                for (int x = 0; x < GridArray.GetLength(0); x++)
                    for (int y = 0; y < GridArray.GetLength(1); y++)
                    {
                        debugTextArray[x, y] = CreateWorldText(GridArray[x, y].ToString(), parent, GetWorldPosition(x, y) + new Vector3(CellSize, CellSize) * .5f, 150, Color.white, TextAnchor.MiddleCenter);
                        nodes[x, y] = new PathNode(x, y);
                    }
                Vector3 GetWorldPosition(int x, int y) => new Vector3(x, y) * CellSize;
            }
        }


        public void SetValueOfACell(int x, int y, int value)
        {
            if (x < WidthCellCount && y < HeightCellCount && x >= 0 && y >= 0)
            {
                GridArray[x, y] = value;
                debugTextArray[x, y].text = GridArray[x, y].ToString();
            }
        }


        public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = 10)
        {
            if (color == null) color = Color.white;
            return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
        }

        public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
        {
            GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
            Transform transform = gameObject.transform;
            gameObject.AddComponent<BoxCollider2D>();

            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.fontSize = 1;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
            return textMesh;
        }

        public PathNode GetNodeObject(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < WidthCellCount && y < HeightCellCount)
                return nodes[x, y];

            else
                return default(PathNode);
        }
    }


}
