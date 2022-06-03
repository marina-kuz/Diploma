using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoneyScr : MonoBehaviour
{
    [HideInInspector] public int money;

    private void Start() {
        this.money=0;
    }
    public void set(int m)
    {
        this.money+=m;
    }

    public int get()
    {
        return this.money;
    }
}
