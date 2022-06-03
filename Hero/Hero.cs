using UnityEngine;
public class Hero : MonoBehaviour
{
    public MessageManager message;
    public Indicator indicator;
    bool moving=true;
    bool movingToItem=false;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform tr;
    private Vector3 direct;
    private Vector2 min,max;
    private float speed=50.0f;
    private float objWidth;
    private float objHeight;
    private GameObject bed;
    private GameObject boul;
    private string parent;
    private int temp_sleep, temp_happy, food;
    void Start()
    {
        tr=GetComponent<Transform>();
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
        max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
        objWidth=transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        objHeight=transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
        ChangeDirection(Random.Range(0,4));
    }

    void Update()
    {
        if(moving)
        {
            RandomMovement();
        }
        if(indicator._currSleep<=20)
        {
            FindItem("bed","Питомец хочет спать! Где его лежанка?");
        }
        if(indicator._currFood<=20)
        {
            FindItem("boul","Питомец хочет есть! Где его миска?");
        }
        if(indicator._currHappy<=20)
        {
            FindItem("kogtetocka","Питомец грустит!");
        }
    }
    void RandomMovement()
    {
        Vector3 temp=tr.position+direct*speed*Time.deltaTime;
        temp.z=0;
        if (temp.x > max.x-objWidth || temp.x < min.x+objWidth || temp.y > 25  || temp.y < min.y+objHeight){
            if(direct==Vector3.right)
            {
                ChangeDirection(2);
            }
            else if(direct==Vector3.left)
            {
                ChangeDirection(0);
            }
            else if(direct==Vector3.up)
            {
                ChangeDirection(3);
            }
            else if(direct==Vector3.down)
            {
                ChangeDirection(1);
            }
        }
        else
        {
            rb.MovePosition(temp);
        }
        int t = Random.Range(0,201);
        if(t==0)
        {
            ChangeDirection(Random.Range(0,4));
        }
        if((tr.position.y<=-50)&&(tr.position.y>=-100))
        {
            setLayer(2);
        }
        else if((tr.position.y<=-100)&&(tr.position.y>=-150))
        {
            setLayer(3);
        }
        else if((tr.position.y<=-150)&&(tr.position.y>=-200))
        {
            setLayer(4);
        }
        else if((tr.position.y<=-200)&&(tr.position.y>=-250))
        {
            setLayer(5);
        }
        else if((tr.position.y<=-250)&&(tr.position.y>=-300))
        {
            setLayer(6);
        }
        else{
            setLayer(7);
        }
    }
    private void FindItem(string item, string mess)
    {
        int x=0;
        for(int i=0;i<tr.parent.childCount;i++)
        {
            if(tr.parent.GetChild(i).name==item)
            {
                x=1;
                moving=false;
                movingToItem=true;
                MovementToItem(tr.parent.GetChild(i).transform.position);
            }
        }
        if(x==0)
        {
            message.SetTempMessage(mess);
        }
    }
    void ChangeDirection(int direction)
    {
        switch (direction)
        {
            case 0:
                direct=Vector3.right;
                break;
            case 1:
                direct=Vector3.up;
                break;
            case 2:
                direct=Vector3.left;
                break;
            case 3:
                direct=Vector3.down;
                break;
        }
        UpdateAnimation();
    }
    private void setLayer(int x){
        gameObject.GetComponent<SpriteRenderer>().sortingOrder=x;
    }
    void UpdateAnimation(){
        anim.SetFloat("MoveX",direct.x);
        anim.SetFloat("MoveY",direct.y);
    }
    private void MovementToItem(Vector3 targetPosition)
    {
        if(movingToItem==true)
        {
            Vector3 directionOfTravel = targetPosition - tr.position;
            directionOfTravel.Normalize();
            tr.Translate(
                (directionOfTravel.x+direct.x * speed * Time.deltaTime),
                (directionOfTravel.y+direct.y* speed * Time.deltaTime),
                (directionOfTravel.z+direct.z* speed * Time.deltaTime),
                Space.World);

            if(directionOfTravel.x<0 && directionOfTravel.y>0)
            {
                ChangeDirection(2);
            }
            else if(directionOfTravel.x>0 && directionOfTravel.y<0)
            {
                ChangeDirection(0);
            }
        }
     }
    private void StopAnimationSleep()
    {
        indicator.setSleep(temp_sleep);
        message.SetTempMessage("Шкала сна заполнена.");
        tr.SetParent(GameObject.Find(parent).GetComponent<Transform>());
        anim.SetBool("Rest",false);
        moving=true;
    }
    private void StopAnimationEat()
    {
        indicator.setHungry(food);
        message.SetTempMessage("Шкала сытости заполнена.");
        tr.SetParent(GameObject.Find(parent).GetComponent<Transform>());
        anim.SetBool("Eat",false);
        moving=true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Bed" && indicator._currSleep<=20)
        {
            temp_sleep=100;
            InteractionWithItem("bed", "Rest", new Vector3(0,40,0));
        }
        else if(other.tag=="Bed" && indicator._currSleep>20 && indicator._currSleep<=70)
        {
            if(Random.Range(0,11)==0)
            {
                temp_sleep=Random.Range(10,51);
                InteractionWithItem("bed", "Rest", new Vector3(0,40,0));
            }
        }
        if(other.tag=="Boul" && indicator._currFood<=20)
        {
            if(other.GetComponent<Item>().score!=0)
            {
                if(food<=50)
                {
                    if(food+other.GetComponent<Item>().score>100)
                    {
                        food=100;
                    }
                    else
                    {
                        food+=other.GetComponent<Item>().score;
                    }
                    other.GetComponent<Item>().score=0;
                }
                else
                {
                    int temp=Random.Range(1,other.GetComponent<Item>().score+1);
                    food+=temp;
                    other.GetComponent<Item>().score-=temp;
                }
                if(direct==Vector3.right || direct==Vector3.down)
                {
                    InteractionWithItem("boul", "Eat",new Vector3(-20,0,0));
                }
                else
                {
                    InteractionWithItem("boul", "Eat",new Vector3(20,0,0));
                }
            }
        }
        else if(other.tag=="Boul" && indicator._currFood>20 && indicator._currFood<=70)
        {
            if(other.GetComponent<Item>().score!=0)
            {
                if(food<=50)
                {
                    if(food+other.GetComponent<Item>().score>100)
                    {
                        food=100;
                    }
                    else
                    {
                        food+=other.GetComponent<Item>().score;
                    }
                    other.GetComponent<Item>().score=0;
                }
                else
                {
                    int temp=Random.Range(1,other.GetComponent<Item>().score+1);
                    food+=temp;
                    other.GetComponent<Item>().score-=temp;
                }
                if(Random.Range(0,11)==0)
                {
                    if(direct==Vector3.right || direct==Vector3.down)
                    {
                        InteractionWithItem("boul", "Eat",new Vector3(-20,0,0));
                    }
                    else
                    {
                        InteractionWithItem("boul", "Eat",new Vector3(20,0,0));
                    }
                }
            }
        }
        if(other.tag=="ScrPost" && indicator._currHappy<=20)
        {
            temp_happy=100;
            InteractionWithItem("kogtetocka", "Rip",new Vector3(20,0,0));
        }
        else if(other.tag=="ScrPost" && indicator._currHappy>20 && indicator._currHappy<=70)
        {
            if(Random.Range(0,31)==0)
            {
                temp_happy=Random.Range(10,51);
                InteractionWithItem("kogtetocka", "Rip",new Vector3(20,0,0));
            }
        }
        ChangeDirection(Random.Range(0,4));
    }
    private void InteractionWithItem(string item, string anim_parameter, Vector3 v)
    {
        parent=tr.parent.name;
        movingToItem=false;
        tr.SetParent(GameObject.Find(item).GetComponent<Transform>());
        tr.localPosition=v;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder=10;
        anim.SetBool(anim_parameter,true);
    }
    private void StopAnimationRip()
    {
        indicator.setHappy(temp_happy);
        message.SetTempMessage("Шкала радости заполнена.");
        tr.SetParent(GameObject.Find(parent).GetComponent<Transform>());
        anim.SetBool("Rip",false);
        moving=true;
    }

    private void OnMouseDown() {
        indicator.setHappy(1);
        message.SetTempMessage("Мур-мур-мур (=^･ｪ･^=)");
    }
}
