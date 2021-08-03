using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerDoor : MonoBehaviour
{
    public LockerKey key;
    public PanelChanger panelChanger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool canOpen(){
        return (key.unlocked() & ItemBox.belowBox.CanUseItem(Item.Type.Key));
    }

    public void onthis(){
        if(canOpen()){
            Debug.Log("open");
            ItemBox.belowBox.UseItem(Item.Type.Key);
            panelChanger.onLockerKey();
        }else{
            Debug.Log("not open");
        }
    }
}
