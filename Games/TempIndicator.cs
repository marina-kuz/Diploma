using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempIndicator : MonoBehaviour
{
    int tempHappy;
    bool isChanged;

    private void Start() {
        tempHappy=0;
        isChanged=false;
    }

    public void setChangedHappiness(int temp)
    {
        isChanged=true;
        tempHappy=temp;
    }

    public int getChangedHappiness()
    {
        isChanged=false;
        return tempHappy;
    }

    public bool getAnswer()
    {
        return isChanged;
    }
}
