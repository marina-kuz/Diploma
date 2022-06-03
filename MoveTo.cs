using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MoveTo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject livingRoom;
    public GameObject bathRoom;
    public GameObject kitchen;
    public GameObject playRoom;
    public GameObject garden;
    public GameObject cat;
    public MessageManager message;
    Button btn;
    string btnName;
    string txt;
    void Start()
    {
        btn=gameObject.GetComponent<Button>();
        if(btn.name!="ToUp")
        {
            btn.GetComponent<Image>().sprite=Resources.Load<Sprite>("Picture/nothing");
            btn.enabled =false;
        }
        btnName="";
        btn.onClick.AddListener(OnClick);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            btn.enabled =true;
            
            this.btnName=eventData.pointerCurrentRaycast.gameObject.name;
            if(btnName!="ToUp")
            {
                btn.GetComponent<Image>().sprite=Resources.Load<Sprite>("Picture/bg_butt");
            }

            if(btnName=="ToRight")
            {
                if(livingRoom.activeInHierarchy){
                    message.SetMessage(true,"В игровую!");
                }
                else if(kitchen.activeInHierarchy)
                {
                    message.SetMessage(true,"В гостинную!");
                }
                else if(bathRoom.activeInHierarchy)
                {
                    message.SetMessage(true,"На кухню!");
                }
                else
                {
                    btn.enabled =false;
                    btn.GetComponent<Image>().sprite=Resources.Load<Sprite>("Picture/nothing");
                }
            }
            else if(btnName=="ToLeft")
            {
                if(livingRoom.activeInHierarchy){
                    message.SetMessage(true,"На кухню!");
                }
                else if(kitchen.activeInHierarchy)
                {
                    message.SetMessage(true,"В ванную!");
                }
                else if(playRoom.activeInHierarchy)
                {
                    message.SetMessage(true,"В гостинную!");
                }
                else
                {
                    btn.enabled =false;
                    btn.GetComponent<Image>().sprite=Resources.Load<Sprite>("Picture/nothing");
                }
            }
            else if(btnName=="ToDown")
            {
                if(garden.activeInHierarchy){
                    message.SetMessage(true,"В кухню!");
                }
                else
                {
                    btn.enabled =false;
                    btn.GetComponent<Image>().sprite=Resources.Load<Sprite>("Picture/nothing");
                }
            }
            else if(btnName=="ToUp")
            {
                message.SetMessage(true,"В сад!");
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(btnName!="ToUp"){
            btn.GetComponent<Image>().sprite=Resources.Load<Sprite>("Picture/nothing");
            btn.enabled =false;
        }
        this.btnName="";
        message.SetMessage(false,"");
    }
    void OnClick()
    {
        if(btnName=="ToRight")
        {
            if(livingRoom.activeInHierarchy){
                livingRoom.SetActive(false);
                playRoom.SetActive(true);
                MovingPet(playRoom);
            }
            else if(kitchen.activeInHierarchy)
            {
                kitchen.SetActive(false);
                livingRoom.SetActive(true);
                MovingPet(livingRoom);
            }
            else if(bathRoom.activeInHierarchy)
            {
                bathRoom.SetActive(false);
                kitchen.SetActive(true);
                MovingPet(kitchen);
            }
        }
        else if(btnName=="ToLeft")
        {
            if(livingRoom.activeInHierarchy){
                livingRoom.SetActive(false);
                kitchen.SetActive(true);
                MovingPet(kitchen);
            }
            else if(kitchen.activeInHierarchy)
            {
                kitchen.SetActive(false);
                bathRoom.SetActive(true);
                MovingPet(bathRoom);
            }
            else if(playRoom.activeInHierarchy)
            {
                playRoom.SetActive(false);
                livingRoom.SetActive(true);
                MovingPet(livingRoom);
            }
        }
        else if(btnName=="ToDown")
        {
            garden.SetActive(false);
            kitchen.SetActive(true);
            MovingPet(kitchen);
        }
        else if(btnName=="ToUp")
        {
            kitchen.SetActive(false);
            garden.SetActive(true);
            MovingPet(garden);
        }
    }
    void MovingPet(GameObject obj)
    {
        cat.transform.SetParent(obj.GetComponent<Transform>());
    }
}
