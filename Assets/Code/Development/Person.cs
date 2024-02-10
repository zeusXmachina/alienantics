using UnityEngine;

/// <summary>
/// debugging tip, override the ToString method to print out the object in a readable format
/// </summary>
[System.Serializable]
public class Person : MonoBehaviour
{
    [SerializeField] private string personName;
    [SerializeField] private int personAge;
    [SerializeField] private string personJob;
    [SerializeField] private string personHobby;
    [SerializeField] private Sex personSex;
    private enum Sex
    {
        Male = 0,
        Female = 1
    }
    void Start()
    {
        //the below below is a global define , a special preporocessor that tells the compiler to only compile the code if the define is set to true
#if SHOW_DEBUG_MESSGAGES
        Debug.Log(this.ToString());
#endif
    }
    public override string ToString()
    {
        return string.Format("***Person Class*** PersonName:{0} | Person Age {1} | PersonJob {2} | PersonHobby:{3} | PersonSex:{4}", personName, personAge, personJob, personHobby, personSex);
    }
}
