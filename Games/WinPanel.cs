using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinPanel : MonoBehaviour
{
    private void Start() {
        gameObject.SetActive(true);
        gameObject.transform.position=new Vector2(0,5000);
    }
    public void SetText(string text_)
    {
        gameObject.transform.position=new Vector2(0,0);
        gameObject.transform.GetChild(0).GetComponent<Text>().text=text_;
    }
    public void Deactivate()
    {
        gameObject.transform.position=new Vector2(0,5000);
    }
}
