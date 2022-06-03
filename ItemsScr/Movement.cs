using UnityEngine;
public class Movement : MonoBehaviour
{
    bool mouseD; //позиция мышки (зажата или нет)
    private Vector2 screenBounds; //границы экрана
    Vector2 viewPos;//позиция нашего объекта
    private float objWidth;
    private float objHeight;
    //максимальный y до которого можно перемещать объект
    private float maxY;
    private float minY;
    void Start()
    {
        mouseD=false;
        //objHeight=transform.GetComponent<Collider2D>().bounds.size.y/2;
        //objWidth=transform.GetComponent<Collider2D>().bounds.size.x/2;
        objHeight=transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
        objWidth=transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        maxY=50.0f-objHeight;
    }
    void Update()
    {
        if (mouseD)
        {   
            screenBounds=Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
            viewPos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objWidth, screenBounds.x - objWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objHeight, objHeight-80/*screenBounds.y - objHeight*/);
            if(gameObject.name!="carpet"){
                    transform.position=viewPos;
                    if((viewPos.y<=-50)&&(viewPos.y>=-100))
                    {
                        setLayer(2);
                    }
                    else if((viewPos.y<=-100)&&(viewPos.y>=-150))
                    {
                        setLayer(3);
                    }
                    else if((viewPos.y<=-150)&&(viewPos.y>=-200))
                    {
                        setLayer(4);
                    }
                    else if((viewPos.y<=-200)&&(viewPos.y>=-250))
                    {
                        setLayer(5);
                    }
                    else if((viewPos.y<=-250)&&(viewPos.y>=-300))
                    {
                        setLayer(6);
                    }
                    else{
                        setLayer(7);
                    }
            }
            else{
                if(viewPos.y<-25-objHeight)
                {
                    transform.position=viewPos;
                }
            }
        }
    }
    private void OnMouseDown() {
        mouseD=true;
    }
    private void OnMouseUp() {
        mouseD=false;
    }
    private void setLayer(int x){
        gameObject.GetComponent<SpriteRenderer>().sortingOrder=x;
    }
}
