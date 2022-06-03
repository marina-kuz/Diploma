using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Grocery : MonoBehaviour
{
    List<Item> foods;
    public Item food1;
    public Item food2;
    public Item food3;
    public Item food4;
    public GameObject cellContainer;
    void Start()
    {
        foods=new List<Item>()
        {
            food1,
            food2,
            food3,
            food4
        };
        for (int i = 0; i < foods.Count; i++)
        {
            Transform cell=cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Transform price = icon.GetChild(0);
            Transform name = icon.GetChild(1);
            Image  img = icon.GetComponent<Image>();
            Text name_txt=name.GetComponent<Text>();
            Text price_txt=price.GetComponent<Text>();
            img.sprite=foods[i].icon;
            name_txt.text=foods[i].nameItem.ToString();
            price_txt.text=foods[i].price.ToString();
            cell.GetComponent<ProductsManager>().setItem(foods[i]);
        }
    }
}
