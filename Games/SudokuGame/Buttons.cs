using UnityEngine;
using UnityEngine.UI;
public class Buttons : MonoBehaviour
{
    public Button EasyBtn;
    public Button MiddleBtn;
    public Button HardBtn;
    public static int _btn=0;
    public static int cells=0;
    public static int coins=0;
    public void OnClick_Easy()
    {
        _btn=1;
        cells=11;
        coins=10;
    }
    public void OnClick_Middle()
    {
        _btn=2;
        cells=21;
        coins=35;
    }
    public void OnClick_Hard()
    {
        _btn=3;
        cells=41;
        coins=50;
    }
}
