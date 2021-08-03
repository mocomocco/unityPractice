using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerKey : MonoBehaviour
{
    // Start is called before the first frame update


    public LockerMark[] MarkHolders;
    void Start()
    {   
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public bool unlocked(){
        bool status=true;
        int holderId = 0;
        
        foreach(LockerMark mark in MarkHolders){
            // currentNumber = currentNumber*10 + int.Parse(input.text);
            status = status & mark.isMatch();
            holderId++;
        }
        // return (keyNumber==currentNumber);
        return status;
    }

    public void Announce(){
        if(unlocked()){Debug.Log("can Open");}
    }
}
