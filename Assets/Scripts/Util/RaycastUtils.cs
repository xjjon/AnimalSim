using AnimalSim.Assets.Scripts.Core;
using UnityEngine;

namespace Util
{
    public static class RaycastUtils
    {

        public static float GetGroundHeight(Vector3 position, float maxDistance = 100f)
        {
            RaycastHit hit;
            if (Physics.Raycast(position + Vector3.up * maxDistance * 0.5f, Vector3.down, out hit, maxDistance, LayerManager.Instance.GroundLayerMask, QueryTriggerInteraction.Ignore))
            {
                return hit.point.y;
            }
            return position.y;
        }
    }
}