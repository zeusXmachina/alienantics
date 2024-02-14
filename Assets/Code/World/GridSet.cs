using UnityEngine;

namespace ZXM.World
{
    public class GridSet : MonoBehaviour
    {
        [SerializeField] private float size = 1f;

        public Vector3 GetNearestPointOnGrid(Vector3 position)
        {
            position -= transform.position;

            int xCount = Mathf.RoundToInt(position.x / size);
            // int yCount = Mathf.RoundToInt(position.y / size);
            // int yCount = 0;
            int zCount = Mathf.RoundToInt(position.z / size);

            Vector3 result = new Vector3(
                (float)xCount * size,
                //(float)yCount * size,
                (float)0.0f,
                (float)zCount * size);

            result += transform.position;

            return result;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            for (float x = 0; x < 40; x += size)
            {
                for (float z = 0; z < 40; z += size)
                {
                    var point = GetNearestPointOnGrid(new Vector3(x, 0.5f, z));
                    Gizmos.DrawSphere(point, 0.1f);
                }

            }
        }
    }
}