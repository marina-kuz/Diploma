using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ProductsManager : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image boulImage;
    public Text boulDescr_;
    public Text descr_;
    public Text money_txt;
    Item item;
    Boul boul;
    MoneyScr money;
    void Start()
    {
        boul = GameObject.FindGameObjectWithTag("Boul").GetComponent<Boul>();
        money = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyScr>();
        money_txt.text=money.get().ToString();
        boulImage.sprite=boul.GetComponent<SpriteRenderer>().sprite;
        boulDescr_.text=boul.GetComponent<Item>().score.ToString();
    }
    /*private void Update() {
        money.text=m.get().ToString();
    }*/
    public void setItem(Item item) {
        this.item=item;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //по нажатию левой кнопки мыши
        //Срабатывание кастомного события предмета
        if(eventData.button==PointerEventData.InputButton.Left)
        {
            boul.AddFood(item.score);
            if(money.get()>=item.price)
            {
                money.set(-item.price);
                money_txt.text=money.get().ToString();
            }
            boulImage.sprite=boul.GetComponent<SpriteRenderer>().sprite;
            boulDescr_.text=boul.GetComponent<Item>().score.ToString();
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        descr_.text=item.description;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        descr_.text="";
    }
}
