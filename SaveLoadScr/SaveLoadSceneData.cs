using UnityEngine;
public class SaveLoadSceneData : MonoBehaviour
{
    public MessageManager message;
    public GameObject inventory;
    public GameObject livingroom;
    public GameObject playroom;
    public GameObject garden;
    public GameObject bathroom;
    public GameObject kitchen;
    [HideInInspector] [SerializeField] private string[] objNames;
    [HideInInspector] [SerializeField] private int[] objAmount;
    [HideInInspector] [SerializeField] private Pos[] objPosition;
    [HideInInspector] [SerializeField] private string[] objParent;
    [HideInInspector] [SerializeField] private int[] objScore;
    public void SaveScene()
    {
        int x=0;
        x+=CountItemsForSaving(inventory);
        x+=CountItemsForSaving(livingroom);
        x+=CountItemsForSaving(playroom);
        x+=CountItemsForSaving(garden);
        x+=CountItemsForSaving(bathroom);
        x+=CountItemsForSaving(kitchen);
        
        objNames=new string[x];
        objAmount=new int[x];
        objPosition=new Pos[x];
        objParent=new string[x];
        objScore=new int[x];
        
        FullArrays(inventory);
        FullArrays(livingroom);
        FullArrays(playroom);
        FullArrays(garden);
        FullArrays(bathroom);
        FullArrays(kitchen);
        SaveManager.SaveScene(x,objNames,objAmount,objPosition,objParent,objScore);
        message.SetTempMessage("Данные сохранены!");
    }
    int CountItemsForSaving(GameObject parent)
    {
        int x=0;
        for(int i=0;i<parent.transform.childCount;i++)
        {
            if(parent.transform.GetChild(i).GetComponent<Item>())
            {
                x++;
            }
        }
        return x;
    }
    void FullArrays(GameObject parent)
    { 
        for(int i=0;i<parent.transform.childCount;i++)
        {
            if(parent.transform.GetChild(i).GetComponent<Item>())
            {
                Item child=parent.transform.GetChild(i).GetComponent<Item>();
                for(int j=0;j<objNames.Length;j++)
                {
                    if(objNames[j]==null)
                    {
                        objNames[j]=child.fileName;
                        objAmount[j]=child.countItem;
                        objParent[j]=parent.name;
                        objScore[j]=child.score;
                        objPosition[j]=new Pos(
                            parent.transform.GetChild(i).transform.position.x,
                            parent.transform.GetChild(i).transform.position.y,
                            parent.transform.GetChild(i).transform.position.z);
                        break;
                    }
                }     
            }
        }
    }
    public void LoadScene()
    {
        SceneData data = SaveManager.LoadScene();
        livingroom.SetActive(true);
        playroom.SetActive(true);
        garden.SetActive(true);
        bathroom.SetActive(true);
        kitchen.SetActive(true);
        if(data!=null)
        {
            for (int i = 0; i < data.objNames_.Length; i++)
            {
                LoadPrefabs(
                    data.objNames_[i],
                    data.objPosition_[i],
                    data.objAmount_[i],
                    data.objParent_[i],
                    data.objScore_[i]
                );
            }
        }
        else
        {
            LoadPrefabs(
                "carpet",
                new Pos(0,-192,0),
                1,
                "LivingRoom",
                0
            );
            LoadPrefabs(
                "flower",
                new Pos(482,-121,0),
                1,
                "LivingRoom",
                0
            );
            LoadPrefabs(
                "bed",
                new Pos(-427,-115,0),
                1,
                "LivingRoom",
                0
            );
            LoadPrefabs(
                "kogtetocka",
                new Pos(-440,-81,0),
                1,
                "PlayRoom",
                0
            );
            LoadPrefabs(
                "flower",
                new Pos(559,-114,0),
                1,
                "Kitchen",
                0
            );
            LoadPrefabs(
                "boul",
                new Pos(-90,-116,0),
                1,
                "Kitchen",
                0
            );
        }
        playroom.SetActive(false);
        garden.SetActive(false);
        bathroom.SetActive(false);
        kitchen.SetActive(false);
    }
    void LoadPrefabs(string name,Pos v, int amount, string parent, int score_)
    {
        GameObject obj=Resources.Load<GameObject>($"Prefabs/{name}");
        GameObject sceneObject=Instantiate(obj);
        sceneObject.transform.position=new Vector3(v.x,v.y,v.z);
        sceneObject.GetComponent<Item>().countItem=amount;
        sceneObject.GetComponent<Item>().score=score_;
        sceneObject.transform.SetParent(FindParent(parent));
        sceneObject.name=name;
    }
    Transform FindParent(string str)
    {
        return GameObject.Find(str).GetComponent<Transform>();
    }
}
