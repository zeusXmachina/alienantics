using System.Collections.Generic;

[System.Serializable]
public class BlockData 
{
   public List<Block> blocks;
}
[System.Serializable]
public class Block
{
    public string type;
    public float positionX;
    public float positionY;
    public float positionZ;
}
