using UnityEngine;


namespace BoldConjectures.Cartel.Utils
{
    /// <summary>
    /// Make sure to place GridGenerator prefab on an even integer X and Z value to prevent rounding that distorts road tile placements. Leave Y-axis rotation at 0 until after spawning!
    /// </summary>
    [ExecuteInEditMode]
    public class MapGen : MonoBehaviour
    {
        public GameObject CornerPiece;
        public GameObject StraightPiece;
        public GameObject IntersectionPiece;
        public GameObject TPiece;
        public int NumberOfSquareBlocks;
        public int DimensionsOfBlock;
        private Vector3 GeneratorPosition;
        private Quaternion GeneratorRotation;
        public GameObject GridGenPrefab;
        private int counter;


        void OnEnable()
        {
            GeneratorPosition = gameObject.transform.position;
            GenerateGrid(NumberOfSquareBlocks);
            counter = 0;
        }


        private void GenerateRows(GameObject TopSeparatorPiece, GameObject MiddleSeparatorPiece, GameObject BottomSeparatorPiece, int BottomSeparatorXPositionOffset, int BottomSeparatorZPositionOffset, int BottomSeparatorYRotationOffset, bool isFinalRun)
        {
            counter += 1;
            var currentXValue = GeneratorPosition.x;
            var currentZValue = GeneratorPosition.z;
            var straightXVal = currentXValue; // initialize straightXVal for road column placement
            var block = new GameObject("Block" + counter);

            SetAsParent(block, GridGenPrefab);

            SetAsParent(Instantiate(TopSeparatorPiece, GeneratorPosition, Quaternion.identity), block);
            for (var i = 0; i <= NumberOfSquareBlocks; i++)
            {
                // Horizontal Straight pieces for each block
                for (var j = 0; j < DimensionsOfBlock; j++)
                {
                    SetAsParent(Instantiate(StraightPiece, new Vector3(currentXValue, GeneratorPosition.y, currentZValue - 20), GeneratorRotation), block);
                    currentZValue -= 20;
                }

                currentZValue = GeneratorPosition.z;
                currentXValue -= (20 * (DimensionsOfBlock - 1));
                if (!isFinalRun)
                {
                    if (i == NumberOfSquareBlocks - 1)
                    {
                        SetAsParent(Instantiate(BottomSeparatorPiece, new Vector3(currentXValue + BottomSeparatorXPositionOffset, GeneratorPosition.y, currentZValue + BottomSeparatorZPositionOffset), Quaternion.Euler(GeneratorRotation.eulerAngles.x, GeneratorRotation.eulerAngles.y + BottomSeparatorYRotationOffset, GeneratorRotation.eulerAngles.z)), block);
                    }
                    else if (i != NumberOfSquareBlocks)
                    {
                        SetAsParent(Instantiate(MiddleSeparatorPiece, new Vector3(currentXValue + BottomSeparatorXPositionOffset, GeneratorPosition.y, currentZValue + BottomSeparatorZPositionOffset), Quaternion.Euler(GeneratorRotation.eulerAngles.x, GeneratorRotation.eulerAngles.y + BottomSeparatorYRotationOffset, GeneratorRotation.eulerAngles.z)), block);
                    }

                    // Vertical Straight Pieces
                    straightXVal = currentXValue + (20 * (DimensionsOfBlock - 2));
                    if (i < NumberOfSquareBlocks)
                    {
                        for (var o = 1; o < DimensionsOfBlock - 1; o++)
                        {
                            SetAsParent(Instantiate(StraightPiece, new Vector3(straightXVal - 20, GeneratorPosition.y, currentZValue), Quaternion.Euler(GeneratorRotation.eulerAngles.x, GeneratorRotation.eulerAngles.y - 90, GeneratorRotation.eulerAngles.z)), block);
                            straightXVal -= 20;
                        }
                    }
                }
            }

            if (isFinalRun)
            {
                // Final Column to Finish Grid
                SetAsParent(Instantiate(CornerPiece, new Vector3(straightXVal, GeneratorPosition.y, GeneratorPosition.z - 20 * (DimensionsOfBlock + 2)), Quaternion.Euler(GeneratorRotation.eulerAngles.x, GeneratorRotation.eulerAngles.y + 90, GeneratorRotation.eulerAngles.z)), block);
                var straightZVal = GeneratorPosition.z - 20 * (DimensionsOfBlock + 1);
                for (var i = 0; i <= NumberOfSquareBlocks; i++)
                {
                    if (i < NumberOfSquareBlocks)
                    {
                        for (var o = 1; o < DimensionsOfBlock - 1; o++)
                        {
                            SetAsParent(Instantiate(StraightPiece, new Vector3(straightXVal - 40f, GeneratorPosition.y, straightZVal), Quaternion.Euler(GeneratorRotation.eulerAngles.x, GeneratorRotation.eulerAngles.y - 90, GeneratorRotation.eulerAngles.z)), block);
                            straightXVal -= 20;
                        }
                    }
                    if (i != NumberOfSquareBlocks && i != NumberOfSquareBlocks - 1) {
                        SetAsParent(Instantiate(MiddleSeparatorPiece, new Vector3(straightXVal + BottomSeparatorXPositionOffset, GeneratorPosition.y, straightZVal + BottomSeparatorZPositionOffset), Quaternion.Euler(GeneratorRotation.eulerAngles.x, GeneratorRotation.eulerAngles.y + BottomSeparatorYRotationOffset, GeneratorRotation.eulerAngles.z)), block);
                        straightXVal -= 20;
                    }
                }
                SetAsParent(Instantiate(CornerPiece, new Vector3(straightXVal - 40, GeneratorPosition.y, straightZVal - 20), Quaternion.Euler(GeneratorRotation.eulerAngles.x, GeneratorRotation.eulerAngles.y + 180, GeneratorRotation.eulerAngles.z)), block);
            }
        }

        public void GenerateGrid(int NumberOfSquareBlocks)
        {
            GenerateRows(TPiece, TPiece, CornerPiece, -20, -20, 90, true);
            for (var i = 0; i <= NumberOfSquareBlocks; i++) {
                GenerateRows(TPiece, IntersectionPiece, TPiece, -20, -20, -180, false);
                GridGenPrefab.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (20 * (DimensionsOfBlock + 1)));
            }
            GenerateRows(CornerPiece, TPiece, CornerPiece, -20, 0, -90, false);
            GridGenPrefab.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (20 * (DimensionsOfBlock + 1)));
        }



        private void SetAsParent(GameObject childObj, GameObject parentObj)
        {
            childObj.transform.SetParent(parentObj.transform);
        }
    }
}
