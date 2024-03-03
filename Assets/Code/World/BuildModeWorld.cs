using System.Collections.Generic;
using UnityEngine;


namespace ZXM.World
{
    public class BuildModeWorld : MonoBehaviour
    {
        public static BuildModeWorld Instance;
        /// <summary>
        /// test container for blocks add during the scene
        /// will be used to check if we can place for now
        /// </summary>
        [SerializeField] private List<GameObject> blocks;
        public List<GameObject> Blocks { get => blocks; set => blocks = value; }
        [SerializeField] private Stack<GameObject> blockStack;
        public Stack<GameObject> BlockStack { get => blockStack; set => blockStack = value; }
        /// <summary>
        /// internal check of saved data loading
        /// </summary>
        [SerializeField] private string saveData;
        [SerializeField] private BlockData blockData;
        [SerializeField] private BlockPlacer cubePlacer;
        private void Awake()
        {
            Instance = this;
            blockStack = new Stack<GameObject>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanPlaceBlock(Vector3 suggestedPosition)
        {
            foreach (var block in Blocks)
            {
                if (block.transform.position == suggestedPosition)
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }
            return true;
        }
        public void RemoveBlock(GameObject go = null)
        {
            if (go == null)
            {
                if (BlockStack.Count != 0)
                {
                    var x = BlockStack.Pop();
                    if (x != null)
                    {
                        Blocks.Remove(x);
                        Destroy(x);
                    }
                }
                else
                {
                    Debug.Log("Stack empty - No blocks to remove");
                }
            }
        }
        /// <summary>
        /// Clear blocks using the stack
        /// </summary>
        public void ClearAllBlocks()
        {
            while (BlockStack.Count != 0)
            {
                var x = BlockStack.Pop();
                if (x != null)
                {
                    Blocks.Remove(x);
                    Destroy(x);
                }
            }
        }
        /// <summary>
        /// Test function for saving block data
        /// </summary>
        public string SaveBlocks()
        {
            BlockData blockData = new BlockData();
            blockData.blocks = new List<Block>();
            foreach (var block in Blocks)
            {
                Block b = new Block();
                b.type = "default";
                b.positionX = block.transform.position.x;
                b.positionY = block.transform.position.y;
                b.positionZ = block.transform.position.z;
                blockData.blocks.Add(b);
            }
            var x = JsonUtility.ToJson(blockData);
            Debug.Log(x);
            saveData = x;
            return x;
        }
        /// <summary>
        /// testing loading from json
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void LoadBlocks(string data = null)
        {
            if (data == null)
            {
                data = saveData;
            }
            blockData = JsonUtility.FromJson<BlockData>(data);
            foreach (var block in blockData.blocks)
            {
                cubePlacer.PlaceCubeNear(new Vector3(block.positionX, block.positionY, block.positionZ));
            }
        }
    }
}