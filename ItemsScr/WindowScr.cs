using UnityEngine;

public class WindowScr : MonoBehaviour
{
    private TimeManager tm;
    private int hour;
    public Sprite day;
    public Sprite morning;
    public Sprite evening;
    public Sprite night;
    // Start is called before the first frame update
    void Start()
    {
        tm=GameObject.FindGameObjectWithTag("TimeManager_").GetComponent<TimeManager>();
        /*day=Resources.Load<Sprite>("Picture/window_day");
        morning=Resources.Load<Sprite>("Picture/window_morning");
        evening=Resources.Load<Sprite>("Picture/window_evening");
        night=Resources.Load<Sprite>("Picture/window_night");*/
    }

    // Update is called once per frame
    void Update()
    {
        hour=tm.getHours();
        if((hour>=5)&&(hour<=10))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite=morning;
        }
        else if((hour>=11)&&(hour<=16))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite=day;
        }
        else if((hour>=17)&&(hour<=22))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite=evening;
        }
        else if((hour>=1)&&(hour<=5))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite=night;
        }
        else if(hour==23)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite=night;
        }
    }
}
