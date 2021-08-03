using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanuki : MonoBehaviour
{
  public void OnThis(){
    bool hasItem = ItemBox.belowBox.CanUseItem(Item.Type.Leaf);
    if (hasItem){
     gameObject.SetActive(false);
     ItemBox.belowBox.UseItem(Item.Type.Leaf);
    }
  }
}
