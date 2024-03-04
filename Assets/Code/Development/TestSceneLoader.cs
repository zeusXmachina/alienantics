using UnityEngine;
using ZXM.World;
using System.IO;

namespace ZXM.Development
{
    /// <summary>
    /// test loading a scene from stored json data
    /// check what is required and update the json data accordingly
    /// add a basic player 
    /// add a basic camera
    /// add a basic movement script
    /// </summary>
    public class TestSceneLoader : MonoBehaviour
    {
        [SerializeField] private BlockPlacer cubePlacer;
        [SerializeField] private BlockData blockData;
        private void Start()
        {
            var x = Resources.Load<TextAsset>("testData").ToString();
            LoadBlocks(x);
        }
        /// <summary>
        /// testing loading from json
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void LoadBlocks(string data)
        {
            //if (data == null)
            //{
            //    data = saveData;
            //}
            blockData = JsonUtility.FromJson<BlockData>(data);
            foreach (var block in blockData.blocks)
            {
                cubePlacer.PlaceCubeNear(new Vector3(block.positionX, block.positionY, block.positionZ));
            }
        }
    }
}