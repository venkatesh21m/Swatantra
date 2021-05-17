using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Helpers;
using System;

namespace Swatantra.BuildingSystem
{
    public class Grid
    {
        private int width;
        private int height;
        private float cellSize;

        private Vector3 origin;
        private GridObject[,] GridArray;

        public float CellSize { get => cellSize; set => cellSize = value; }

        //public Action<OnGridObjetChangedArgs> OnGridObjectchanged;

        //public struct OnGridObjetChangedArgs
        //{
        //    public int x;
        //    public int z;
        //}

        public Grid(int width, int height, float cellSize, Vector3 origin , bool showGrid)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.origin = origin;

            GridArray = new GridObject[width, height];

            for (int x = 0; x < GridArray.GetLength(0); x++)
            {
                for (int z = 0; z < GridArray.GetLength(1); z++)
                {
                    // DebugHelper.CreateWorldText(GridArray[x, z].ToString(), Color.red, GetWorldPosition(x, z));
                    GridArray[x, z] = new GridObject(this, x, z);
                }
            }
            
            if(showGrid)
                ShowGrid();

        }


        private void ShowGrid()
        {
            for (int x = 0; x < GridArray.GetLength(0); x++)
            {
                for (int z = 0; z < GridArray.GetLength(1); z++)
                {
                    Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.red, 100f);
                    Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.red, 100f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height ), Color.red, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.red, 100f);
        }
                
        public Vector3 GetWorldPosition(int x, int z)
        {
            return new Vector3(x, 0, z) * cellSize + origin;
        }

        public GridObject GetGridObject(int x, int z)
        {
            return GridArray[x, z];
        }

        public GridObject GetGridObject(Vector3 pos)
        {
            GetXZ(pos, out int x, out int z);
            return GridArray[x, z];
        }

        public void GetXZ(Vector3 worldposition, out int x, out int z)
        {
            x = Mathf.FloorToInt((worldposition - origin).x / cellSize);
            z = Mathf.FloorToInt((worldposition - origin).z / cellSize);
        }

        public Vector3 GetGridSnapPosition(Vector3 worldpos )
        {
            GetXZ(worldpos, out int x, out int z);
            // return GetWorldPosition((int)worldpos.x, (int)worldpos.z);
            return new Vector3(x, 0, z) * cellSize + origin;
        }

        //public void TriggerGridObjectChanged(int x, int z)
        //{
        //    OnGridObjectchanged?.Invoke(new OnGridObjetChangedArgs { x = x, z = z });
        //}
    }

    [System.Serializable]
    public class GridObject
    {
        private Grid grid;
        private int x;
        private int z;
        private PlacedObject placedObject;

        public GridObject(Grid grid, int x, int z)
        {
            this.grid = grid;
            this.x = x;
            this.z = z;
        }

        public void SetPlacedObject(PlacedObject placedObject)
        {
            this.placedObject = placedObject;
          // grid.TriggerGridObjectChanged(x, z);
        }

        public void ClearPlacedObject()
        {
            placedObject = null;
            //grid.TriggerGridObjectChanged(x, z);
        }

        public bool canBuild()
        {
            return placedObject == null;
        }

        public PlacedObject GetPlacedObject()
        {
            return placedObject;
        }

    }
}
