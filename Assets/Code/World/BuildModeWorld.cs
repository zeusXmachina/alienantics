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
        private void Awake()
        {
            Instance = this;
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
                else {
                    continue;
                }
            }
            return true;
        }
    }
}