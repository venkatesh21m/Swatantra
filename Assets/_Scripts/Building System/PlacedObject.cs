using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Swatantra.Stats.BuildingStats;

namespace Swatantra.BuildingSystem 
{
    public class PlacedObject : MonoBehaviour
    {
        private Building_SO placedObjectType;
        private Vector2Int origin;
        private Direction direction;


        public static PlacedObject Create(Vector3 worldPosition, Vector2Int origin, Direction direction, Building_SO placedBuilding)
        {
            Transform placedObjectTransform =
                Instantiate(
                    placedBuilding.BuildingBase,
                    worldPosition,
                    Quaternion.Euler(0, placedBuilding.GetRotationAngle(direction), 0)
                    );

            PlacedObject placedObject = placedObjectTransform.GetComponent<PlacedObject>();
            placedObject.placedObjectType = placedBuilding;
            placedObject.origin = origin;
            placedObject.direction = direction;

            return placedObject;

        }

        public List<Vector2Int> GetGridPositionList()
        {
            return placedObjectType.GetGridPositionList(origin, direction);
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }

    }

}