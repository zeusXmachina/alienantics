using UnityEngine;
namespace ZXM.World
{
    public class BuildMode : MonoBehaviour
    {
        public Vector3 mousePos;
        private GridSet grid;
        private BlockPlacer cubePlacer;
        public GameObject spawnObj;
        [SerializeField] private bool isBuild;
        // private LogicFunctions logicFunc;
        // private Inventory inventory;


        //Build UI Vars
        //[Header("Build UI ")]
        //public Text costValueText;
        //private Image buildResultImage;
        //public Text notEnoughText;
        //private Image notEnoughImage;
        //private Button swapButton;
        //public float plantBuildCost;
        //public float rockBuildCost;
        //public BuildMap buildMap;


        public enum BuildType { Plant, Rock }
        public BuildType buildType;
        private void Awake()
        {
            grid = FindObjectOfType<GridSet>();
            cubePlacer = FindObjectOfType<BlockPlacer>();
            //logicFunc = FindObjectOfType<LogicFunctions>();
            //inventory = FindObjectOfType<Inventory>();
            // buildMap = FindObjectOfType<BuildMap>();
        }
        void Start()
        {
            //buildType = BuildType.Plant;
            //buildResultImage = GameObject.Find("BuildResultImage").GetComponent<Image>();
            //costValueText = GameObject.Find("CostValueText").GetComponent<Text>();
            //notEnoughImage = GameObject.Find("NotEnoughImage").GetComponent<Image>();
            //notEnoughText = GameObject.Find("NotEnoughText").GetComponent<Text>();
            //swapButton = GameObject.Find("SwapButton").GetComponent<Button>();
            //swapButton.onClick.AddListener(SwapBuildType);
        }
        void Update()
        {
            if (isBuild)
            {
                spawnObj.SetActive(true);
                mousePos = Input.mousePosition;



            }


            //if (isBuild())
            //{
            //UpdateBuildUI();
            // spawnObj.SetActive(true);
            //mousePos = Input.mousePosition;
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
                    if (!cubePlacer.isGridSpaceOccupied(gridRef))
                    {
                    //    switch (buildType)
                    //    {
                    //        case BuildType.Plant:

                    //            if (inventory.resourcePlantMatter >= plantBuildCost)
                    //            {
                    //                //place a block of a certain type
                    //                buildMap.PlaceCubeTypeNear(gridRef, buildType);
                    //                inventory.RemoveResourcePlantMatter(plantBuildCost);
                    //            }
                    //            break;
                    //        case BuildType.Rock:

                    //            if (inventory.resourceRockMatter >= rockBuildCost)
                    //            {
                    //                //place a block of a certain type
                    //                buildMap.PlaceCubeTypeNear(gridRef, buildType);
                    //                inventory.RemoveResourceRockMatter(rockBuildCost);
                    //            }
                    //            break;
                    //    }
                     //place block
                     cubePlacer.PlaceCubeNear(gridRef);
                    }
                }
            }
            //}
            //else
            //{
            //    //build is false
            //    spawnObj.SetActive(false);
            //}
        }
        //public bool isBuild()
        //{
        //    return logicFunc.BuildMode;
        //}
        //public void UpdateBuildUI()
        //{
        //    switch (buildType)
        //    {
        //        case BuildType.Plant:
        //            buildResultImage.color = Color.green;

        //            costValueText.text = plantBuildCost.ToString() + " Plant Matter";
        //            if (inventory.resourcePlantMatter >= plantBuildCost)
        //            {
        //                notEnoughImage.enabled = false;
        //                notEnoughText.enabled = false;
        //            }
        //            else
        //            {
        //                //check how much is needed
        //                var x = CalculateAmountNeeded(inventory.resourcePlantMatter);
        //                //show panel and change text
        //                notEnoughImage.enabled = true;
        //                notEnoughText.enabled = true;
        //                notEnoughText.text = x.ToString() + " NEEDED";

        //            }
        //            break;
        //        case BuildType.Rock:
        //            buildResultImage.color = Color.magenta;
        //            costValueText.text = rockBuildCost.ToString() + " Rock Matter";
        //            break;
        //    }
        //}
        //use when we know cant afford
        //public float CalculateAmountNeeded(float amount)
        //{
        //    switch (buildType)
        //    {
        //        case BuildType.Plant:
        //            //cost - amount we have 
        //            return plantBuildCost - amount;

        //        case BuildType.Rock:
        //            return rockBuildCost - amount;

        //        default:
        //            return 0f;

        //    }

        //}
        public void SwapBuildType()
        {
            switch (buildType)
            {
                case BuildType.Plant:
                    buildType = BuildType.Rock;
                    break;
                case BuildType.Rock:
                    buildType = BuildType.Plant;
                    break;

            }
        }
    }
}