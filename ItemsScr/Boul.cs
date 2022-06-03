using UnityEngine;
public class Boul : MonoBehaviour
{
    public Sprite empty;
    public Sprite almost_empty;
    public Sprite full;

    private void Update() {
        updateSprite();
    }
    public void AddFood(int x)
    {
        gameObject.GetComponent<Item>().score+=x;
        if(gameObject.GetComponent<Item>().score>100)
        {
            gameObject.GetComponent<Item>().score=100;
        }
        updateSprite();
    }

    public void updateSprite()
    {
        if(gameObject.GetComponent<Item>().score==0)
       {
           GetComponent<Item>().icon=empty;
           GetComponent<SpriteRenderer>().sprite=empty;
       }
       else if(gameObject.GetComponent<Item>().score>0 && gameObject.GetComponent<Item>().score<80)
       {
           GetComponent<Item>().icon=almost_empty;
           GetComponent<SpriteRenderer>().sprite=almost_empty;
       }
       else if(gameObject.GetComponent<Item>().score>=80 && gameObject.GetComponent<Item>().score<=100)
       {
           GetComponent<Item>().icon=full;
           GetComponent<SpriteRenderer>().sprite=full;
       }
    }
}
