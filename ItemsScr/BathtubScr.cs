using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BathtubScr : MonoBehaviour
{
    public MessageManager message;
    public Indicator indicator;
    public GameObject soap;
    Animator anim;
    GameObject cat;
    Button btn;

    void Start()
    {
        cat=GameObject.FindGameObjectWithTag("Hero");
        btn=GetComponent<Button>();
        btn.onClick.AddListener(onClick);
        anim=soap.GetComponent<Animator>();
        soap.SetActive(false);
    }

    private void onClick()
    {
        cat.SetActive(false);
        soap.SetActive(true);
        
        anim.Play("soap");
        message.SetTempMessage("+30 ед. здоровья, -20 ед. счастья.");
        indicator.setHeart(30);
        indicator.setHappy(-20);
        StartCoroutine(washing());
    }

    IEnumerator washing()
    {
        yield return new WaitForSeconds(4);
        cat.SetActive(true);
        soap.SetActive(false);
    }
}
