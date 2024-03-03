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
    }
}