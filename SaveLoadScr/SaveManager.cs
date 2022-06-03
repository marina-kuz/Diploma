using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveManager
{
    //Сохранение данных питомца в файл PetHeroData.gd
    public static void Save(Indicator indicator,MoneyScr money,TimeManager time, InventoryManager_ inventory) 
    {
        BinaryFormatter bf= new BinaryFormatter();
        string path = Application.persistentDataPath+"/PetHeroData.gd";
        FileStream stream = new FileStream(path, FileMode.Create);
        HeroStat data=new HeroStat(indicator,money,time,inventory);
        bf.Serialize(stream, data);
        stream.Close();
    }
    //Загрузка данных питомца из файла PetHeroData.gd
    public static HeroStat Load()
    {
        string path = Application.persistentDataPath+"/PetHeroData.gd"; 
        if(File.Exists(path))
        {
            BinaryFormatter bf= new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            HeroStat data=bf.Deserialize(stream) as HeroStat;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
    //Сохранение данных сцены в файл PetSceneData.gd
    public static void SaveScene(int x,string[] objNames,int[] objAmount,Pos[] objPosition,string[] objParent, int[] objScore)
    {
        BinaryFormatter bf= new BinaryFormatter();
        string path = Application.persistentDataPath+"/PetSceneData.gd";
        FileStream stream = new FileStream(path, FileMode.Create);
        SceneData data=new SceneData(x,objNames,objAmount,objPosition,objParent,objScore);
        bf.Serialize(stream, data);
        stream.Close();
    }
    //Загрузка данных сцены из файла PetSceneData.gd
    public static SceneData LoadScene()
    {
        string path = Application.persistentDataPath+"/PetSceneData.gd";
        if(File.Exists(path))
        {
            BinaryFormatter bf= new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SceneData data=bf.Deserialize(stream) as SceneData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
