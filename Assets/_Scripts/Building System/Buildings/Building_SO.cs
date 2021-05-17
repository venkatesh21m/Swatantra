using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Swatantra.Stats.BuildingStats
{
    [CreateAssetMenu(fileName = "Building Data", menuName = "Swatantra/stats/Building stats",order = 2)]
    public class Building_SO : ScriptableObject
    {
        #region static methods
        public static Direction GetNextDirection(Direction direction)
        {
            switch (direction)
            {
                default:
                case Direction.Right:       return Direction.BackWard;
                case Direction.Left:        return Direction.Forward;
                case Direction.Forward:     return Direction.Right;
                case Direction.BackWard:    return Direction.Left;
            }

        }

        #endregion

        #region Variables

        public string BuildingName = string.Empty;
        
        public Transform Buildingvisual = default;
        public Transform BuildingBase = default;
        public Transform BuildingPrefab = default;

        public int NumberofcharacterNeeded = 1;
        
        [Space]
        public int width;
        public int length;

        #endregion

        #region Accessors
        public Vector2Int GetRotationOffset(Direction direction)
        {
            switch (direction)
            {
                default:
                case Direction.BackWard: return new Vector2Int(0,0);
                case Direction.Left: return new Vector2Int(0, width);
                case Direction.Forward: return new Vector2Int(width, length);
                case Direction.Right: return new Vector2Int(length,0);
            }
        }

        public int GetRotationAngle(Direction direction)
        {
            switch (direction)
            {
                default:
                case Direction.BackWard:    return 0;
                case Direction.Left:        return 90;
                case Direction.Forward:     return 180;
                case Direction.Right:       return 270;
            }
        }

        public List<Vector2Int> GetGridPositionList(Vector2Int offset, Direction direction)
        {
            List<Vector2Int> gridPositionList = new List<Vector2Int>();

            switch (direction)
            {
                case Direction.Left:
                case Direction.Right:
                    for (int x = 0; x < width; x++)
                    {
                        for (int z = 0; z < length; z++)
                        {
                            gridPositionList.Add(offset + new Vector2Int(x, z));
                        }
                    }
                    break;

                case Direction.Forward:
                case Direction.BackWard:
                    for (int x = 0; x < width; x++)
                    {
                        for (int z = 0; z < length; z++)
                        {
                            gridPositionList.Add(offset + new Vector2Int(x, z));
                        }
                    }
                    break;
                default:
                    break;
            }

            return gridPositionList;
        }
       
        #endregion

    }

    public enum Direction
    {
        Left,
        Right,
        Forward,
        BackWard
    }
}
