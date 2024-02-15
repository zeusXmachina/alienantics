using UnityEngine;
namespace ZXM.World
{
    public class BuildMode : MonoBehaviour
    {
        public Vector3 mousePos;
        [SerializeField]private GridSet grid;
        [SerializeField]private BlockPlacer cubePlacer;
        public GameObject spawnObj;
        [SerializeField] private bool isBuild;
        

        private void Awake()
        {
            isBuild = true;
        }
      
        void Update()
        {
            if (isBuild)
            {
                spawnObj.SetActive(true);
                mousePos = Input.mousePosition;
            }
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //hover effect for blueprint 
            if (Physics.Raycast(ray, out hitInfo))
            {
                var gridRef = grid.GetNearestPointOnGrid(hitInfo.point);
                spawnObj.transform.position = gridRef;
                Debug.DrawRay(gameObject.transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.yellow);
                //if we click 
                if (Input.GetMouseButtonDown(0))
                {
                    ////validate block 
                    
                    if (BuildModeWorld.Instance.CanPlaceBlock(gridRef))
                    {
                     //place block
                     cubePlacer.PlaceCubeNear(gridRef);
                    }
                }
            } 
        }
    }
}