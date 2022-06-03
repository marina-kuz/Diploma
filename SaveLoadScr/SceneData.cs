[System.Serializable] public class SceneData
{
    public string[] objNames_;
    public int[] objAmount_;
    public Pos[] objPosition_;
    public string[] objParent_;
    public int[] objScore_;
    //x - количество дочерних объектов, которые нужно сохранить
    public SceneData(int x,string[] objNames,int[] objAmount,Pos[] objPosition,string[] objParent, int[] objScore)
    {
        objNames_=new string[x];
        objAmount_=new int[x];
        objPosition_=new Pos[x];
        objParent_=new string[x];
        objScore_=new int[x];

        for(int i=0; i<objNames_.Length;i++)
        {
            objNames_[i]=objNames[i];
            objAmount_[i]=objAmount[i];
            objPosition_[i]=objPosition[i];
            objParent_[i]=objParent[i];
            objScore_[i]=objScore[i];
        }
    }
}
