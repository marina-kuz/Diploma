using UnityEngine;
using UnityEngine.UI;
public class FieldPrefabObj
{
    int _row;
    int _column;
    GameObject _instance;
    public int Row{get=>_row; set =>_row=value;}
    public int Column{get=>_column; set =>_column=value;}
    public bool IsChangeable=true;
    public int Number;
    public FieldPrefabObj(GameObject instance, int row, int column)
    {
        _instance=instance;
        _row=row;
        _column=column;
    }
    public void SetHoverMode()
    {
        _instance.GetComponent<Image>().color=new Color(0.46f,0.85f,0.91f);
    }
    public void UnSetHoverMode()
    {
        _instance.GetComponent<Image>().color=new Color(1f,1f,1f);
    }
    public bool TryGetTextByName(string name, out Text text)
    {
        text=null;
        Text[] texts=_instance.GetComponentsInChildren<Text>();
        foreach (var currText in texts)
        {
            if(currText.name.Equals(name))
            {
                text=currText;
                return true;
            }
        }
        return false;
    }
    //Обычное большое число
    public void SetNumber(int number)
    {
        if(TryGetTextByName("Value", out Text text))
        {
            Number=number;
            text.text=number.ToString();
            for (int i = 1; i < 10; i++)
            {
                if(TryGetTextByName($"Number_{i}", out Text textNumber))
                {
                    textNumber.text="";
                }
            }
        }
    }
    //Маленькое число
    public void SetSmallNumber(int number)
    {
        if(TryGetTextByName($"Number_{number}", out Text text))
        {
            text.text=number.ToString();
            for (int i = 1; i < 10; i++)
            {
                if(TryGetTextByName("Value", out Text textValue))
                {
                    textValue.text="";
                }
            }
        }
    }
    public void ChangeColorToGreen()
    {
        _instance.GetComponent<Image>().color=new Color(0.57f,0.93f,0.54f);
    }
    public void ChangeColorToRed()
    {
        _instance.GetComponent<Image>().color=new Color(0.93f,0.56f,0.54f);
    }
    ~FieldPrefabObj()
    {
        
    }
}
