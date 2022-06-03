using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MessageManager : MonoBehaviour
{
    public float tick=5;
    public GameObject panel;
    private Transform txt_;
    private Text txt;
    void Start()
    {
        panel.SetActive(false);
        txt_=panel.transform.GetChild(0);
        txt=txt_.GetComponent<Text>();
    }

    public void SetMessage(bool isMessage, string str){
        this.txt.text=str;
        panel.SetActive(isMessage);
    }

    public void SetTempMessage(string str)
    {
        this.txt.text=str;
        StartCoroutine(TempMessage());
    }

    IEnumerator TempMessage()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(tick);
        panel.SetActive(false);
    }
}
