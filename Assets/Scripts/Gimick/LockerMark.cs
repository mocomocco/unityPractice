using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerMark : MonoBehaviour
{

    private int markid;

    public Sprite[] marks;

    public SpriteRenderer markholder;

    public LockerKey lockerKey;

    public int correctMarkId; 

    // Start is called before the first frame update

    void Start()
    {
        markid = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void before(){
        change(-1);
    }

    public void after(){
        change(1);
    }

    public bool isMatch(){
        return (markid==correctMarkId);
    }

    public void change(int d){
        markid = (markid + d + marks.GetLength(0)) % (marks.GetLength(0));
        Debug.Log(markid);
        markholder.sprite = marks[markid];
        if(markid==correctMarkId){Debug.Log("OK");}
        lockerKey.Announce();
    }
}
