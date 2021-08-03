using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//矢印をクリックしたら特定のPanelを表示する
public class PanelChanger : MonoBehaviour
{
    static Vector2 leftPosition = new Vector2(0,0);
    static Vector2 rightPosition = new Vector2(-1000,0);
    static Vector2 lockerPosition = new Vector2(0,1500);
    static Vector2 bucketPosition = new Vector2(-1000,1500);
    static Vector2 insideLockerPosition = new Vector2(0,3000);

    public GameObject rightArrow;
    public GameObject leftArrow;
    public GameObject backArrow;

    enum Panel
    {Panel0,
      Panel1,
      Panel2,
      Panel3,
      Panel4
    };

    Panel currentPosition = Panel.Panel0;


    private Vector2 positionOf(Panel panel){
      switch(panel){
        case Panel.Panel0:
          return leftPosition;
        case Panel.Panel1:
          return rightPosition;
        case Panel.Panel2:
          return lockerPosition;
        case Panel.Panel3:
          return bucketPosition;
        case Panel.Panel4:
          return insideLockerPosition;
      }
      return leftPosition;
    }

    private Panel position2name(Vector2 position){
      if(position == leftPosition){return Panel.Panel0;}
      if(position == rightPosition){return Panel.Panel1;}
      if(position == lockerPosition){return Panel.Panel2;}
      if(position == bucketPosition){return Panel.Panel3;}
      if(position == insideLockerPosition){return Panel.Panel4;}
      return Panel.Panel0;
    }

    private void moveToLeft(){
      moveTo(leftPosition,false,true,false);
    }
    private void moveToRight(){
      moveTo(rightPosition,true,false,false);
    }

    private void moveToObjectUp(Vector2 p){
      Vector2 goal = p;
      if(p == lockerPosition){goal = lockerPosition;}
      if(p == bucketPosition){goal = bucketPosition;}
      if(p == insideLockerPosition){goal = insideLockerPosition;}
      moveTo(goal,false,false,true);
    }

   private void moveTo(Vector2 p,bool showLeftArrow,bool showRightArrow,bool showBackArrow){
        currentPosition = position2name(p);
        Debug.Log(currentPosition+"に移動");
        this.transform.localPosition = p;
        leftArrow.SetActive(showLeftArrow);
        rightArrow.SetActive(showRightArrow);
        backArrow.SetActive(showBackArrow);
    }

    private void Start(){
      moveToLeft();
    }

    public void onLeftArrow(){
      if(currentPosition == Panel.Panel1){moveToLeft();}
    }

    public void onRightArrow(){
      if(currentPosition == Panel.Panel0){moveToRight();}
    }

    public void onBackArrow(){
      if(currentPosition == Panel.Panel2){ moveToLeft();}
      if(currentPosition == Panel.Panel3){ moveToRight();}
      if(currentPosition == Panel.Panel4){ moveToLeft();}
    }

    public void onLocker(){
      if(currentPosition == Panel.Panel0){moveToObjectUp(lockerPosition);}
    }

    public void onLockerKey(){
      Debug.Log(currentPosition+"->"+Panel.Panel3);
      if(currentPosition == Panel.Panel2){moveToObjectUp(insideLockerPosition);}
    }

    public void onBucket(){
      if(currentPosition == Panel.Panel1){moveToObjectUp(bucketPosition);}
    }

}
