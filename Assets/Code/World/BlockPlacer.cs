using UnityEngine;

namespace ZXM.World
{
    public class BlockPlacer : MonoBehaviour
    {
        [SerializeField] private GridSet grid;
        public GameObject block;
        /*Addition of validatin methods for placing a cube.*/
        //4 rays left, right , forward, backward 
        //if any hit with the specified distance place cube 
        //if no hits output block not placeable
        private void Awake()
        {
            grid = FindObjectOfType<GridSet>();
        }
        /*
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hitInfo))
                {
                    int layerMask = 1 << 9;
                    RaycastHit hit;
                    var raycheckorgin = grid.GetNearestPointOnGrid(hitInfo.point);
                    if (Physics.Raycast(raycheckorgin, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity, layerMask)) {
                        Debug.DrawRay(raycheckorgin, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
                        Debug.Log("Did Hit" + hit.distance);
                    }
                    else
                    {
                        Debug.DrawRay(raycheckorgin, transform.TransformDirection(Vector3.up) * 1000, Color.white);
                        Debug.Log("Did not Hit");
                        if (CreateRayandCheck(raycheckorgin))
                        {
                            PlaceCubeNear(hitInfo.point);
                        }
                        else {
                            Debug.Log("Cube can not be placed");
                        }
                    }
                    //PlaceCubeNear(hitInfo.point);
                }
            }
        }
        */
        public void PlaceCubeNear(Vector3 clickPoint)
        {
            var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
            var go = Instantiate(block, finalPosition, Quaternion.identity);
            BuildModeWorld.Instance.Blocks.Add(go);
        }
        /*This function casts 4 rays in 4 direction if it detects a block left that 1 away it will build
         this allows us to validate the click and ensure blocks are placed adjacent to eachother*/
        //placement validation code
        public bool CreateRayandCheck(Vector3 origin)
        {
            int layerMask = 1 << 9;
            //var origin = grid.GetNearestPointOnGrid(castOrigin);
            RaycastHit hitCheck;

            if (Physics.Raycast(origin, transform.TransformDirection(Vector3.left), out hitCheck, Mathf.Infinity, layerMask))
            {
                if (hitCheck.distance < 1.0f)
                {
                    Debug.Log("Block found left" + hitCheck.distance);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (Physics.Raycast(origin, transform.TransformDirection(Vector3.right), out hitCheck, Mathf.Infinity, layerMask))
            {
                if (hitCheck.distance < 1.0f)
                {
                    Debug.Log("Block found right" + hitCheck.distance);
                    return true;
                }
                else
                {

                    return false;
                }
            }
            else if (Physics.Raycast(origin, transform.TransformDirection(Vector3.forward), out hitCheck, Mathf.Infinity, layerMask))
            {
                if (hitCheck.distance < 1.0f)
                {
                    Debug.Log("Block found forward" + hitCheck.distance);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (Physics.Raycast(origin, transform.TransformDirection(Vector3.back), out hitCheck, Mathf.Infinity, layerMask))
            {
                if (hitCheck.distance < 1.0f)
                {
                    Debug.Log("Block found back" + hitCheck.distance);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else { return false; }
        }
        public bool isGridSpaceOccupied(Vector3 gridspace)
        {
            int layerMask = 1 << 9;
            RaycastHit hit;
            var raycheckorgin = grid.GetNearestPointOnGrid(gridspace);
            if (Physics.Raycast(raycheckorgin, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(raycheckorgin, transform.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
                Debug.Log("Did Hit" + hit.distance);
                return true;
            }
            else
            {
                Debug.DrawRay(raycheckorgin, transform.TransformDirection(Vector3.up) * 1000, Color.white);
                Debug.Log("Did not Hit");
                return false;
            }
        }
        //function to check amount of resources 
        public bool ResourceValidation()
        {
            return true;
        }

    }
}