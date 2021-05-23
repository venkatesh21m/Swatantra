using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Events;
using Swatantra.Helpers;
using Swatantra.Stats.BuildingStats;
using System;

namespace Swatantra.BuildingSystem
{

    public class BuildingSystemManager : MonoBehaviour
    {
        
        [SerializeField] int GridWidth;
        [SerializeField] int GridHeight;
        [SerializeField] int CellSize;
        [Space]
        [SerializeField] bool DebugGrid;
        [Space]
        [SerializeField] List<Building_SO> Buildings;

        [Space]
        [SerializeField] Material CanBuildPReviewMat;
        [SerializeField] Material CanNotBuildPReviewMat;

        private Grid grid;
        private Building_SO CurrentBuildingtoPlace;
        private Direction direction = Direction.BackWard;

        Transform visualObject;
        
        Vector3 visualPos;
        Vector3 mousepos;
        
        Quaternion visualRotation;

        bool isConstructionModeOn = false;
        bool visualiseBuilding = false;
        bool canbuildOnThisGrid = false;

        // Start is called before the first frame update
        void Start()
        {
            grid = new Grid(GridWidth, GridHeight, CellSize, new Vector3(-50,0,-50), DebugGrid);
            CurrentBuildingtoPlace = Buildings[0];
            //visualObject = Instantiate(CurrentBuildingtoPlace.BuildingPrefab, SwatantraUtils.GetMouseWorldPosition(), Quaternion.identity);

            EventManager.BuildingButtonPressedEvent.AddListener(HandleBuildingButtopnPressedEvent);
        }

        private void HandleBuildingButtopnPressedEvent(int buildingTypeNumber)
        {
            visualObject = Buildings[buildingTypeNumber].BuildingPrefab;
            CurrentBuildingtoPlace = Buildings[buildingTypeNumber];
            isConstructionModeOn = true;
            visualiseBuilding = true;
        }

        private void Update()
        {
            if (!isConstructionModeOn) return;
            mousepos = SwatantraUtils.GetMouseWorldPosition();
            canbuildOnThisGrid = CanBuildOnPosition(mousepos);

            if (Input.GetMouseButtonDown(0))
            {
                grid.GetXZ(mousepos, out int x, out int z);
                List<Vector2Int> gridpositionList = CurrentBuildingtoPlace.GetGridPositionList(new Vector2Int(x, z), direction);
               
                if (canbuildOnThisGrid)
                {
                    Vector2Int rotationOffset = CurrentBuildingtoPlace.GetRotationOffset(direction);
                    Vector3 testObjectWorldPosition = grid.GetWorldPosition(x, z);

                    //new Vector3(rotationOffset.x, 0, rotationOffset.y) * grid.CellSize;
                    
                    //testObjectWorldPosition.x /*-= (CurrentBuildingtoPlace.length/2)*/; 
                    //testObjectWorldPosition.z -= (CurrentBuildingtoPlace.width/2); 

                    PlacedObject placedObject = PlacedObject.Create(testObjectWorldPosition, new Vector2Int(x, z), direction, CurrentBuildingtoPlace);

                    foreach (var gridposition in gridpositionList)
                    {
                        grid.GetGridObject(gridposition.x, gridposition.y).SetPlacedObject(placedObject);
                        isConstructionModeOn = false;
                        visualiseBuilding = false;
                    }

                   Tasks.CharacterTaskManager.AssignBUildingTaskToIdleCharacters(CurrentBuildingtoPlace.NumberofcharacterNeeded, placedObject.transform);
                }
                else
                {
                    Debug.LogError("can not build");
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                GridObject gridObject = grid.GetGridObject(mousepos);
                
                PlacedObject placedObject = gridObject.GetPlacedObject();
                
                if (placedObject != null)
                {
                    placedObject.DestroySelf();

                    List<Vector2Int> gridpositionList = placedObject.GetGridPositionList();
                    foreach (var gridposition in gridpositionList)
                    {
                        grid.GetGridObject(gridposition.x, gridposition.y).ClearPlacedObject();
                        isConstructionModeOn = false;
                        visualiseBuilding = false;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                direction = Building_SO.GetNextDirection(direction);
            }

        }

        private void LateUpdate()
        {
            if (!visualiseBuilding) return;

            Vector3 position = grid.GetGridSnapPosition(mousepos);

            visualPos = Vector3.Lerp(visualPos, new Vector3(position.x /*- (CurrentBuildingtoPlace.length/2)*/, 0.025f, position.z /*- (CurrentBuildingtoPlace.width/2)*/), Time.deltaTime * 15f);
            visualRotation = Quaternion.Lerp(visualRotation, Quaternion.Euler(0, CurrentBuildingtoPlace.GetRotationAngle(direction), 0), Time.deltaTime * 15f);
           
            if(canbuildOnThisGrid)
                Graphics.DrawMesh(visualObject.GetComponentInChildren<MeshFilter>().sharedMesh, visualPos, visualRotation, CanBuildPReviewMat, 0);
            else
                Graphics.DrawMesh(visualObject.GetComponentInChildren<MeshFilter>().sharedMesh, visualPos, visualRotation, CanNotBuildPReviewMat, 0);

        }

        bool CanBuildOnPosition(Vector3 pos)
        {
            grid.GetXZ(pos, out int x, out int z);
            List<Vector2Int> gridpositionList = CurrentBuildingtoPlace.GetGridPositionList(new Vector2Int(x, z), direction);
            bool canBuild = true;
            foreach (var gridposition in gridpositionList)
            {
                if (!grid.GetGridObject(gridposition.x, gridposition.y).canBuild())
                {
                    canBuild = false;
                    break;
                }
            }

            return canBuild;
        }
    }
}
