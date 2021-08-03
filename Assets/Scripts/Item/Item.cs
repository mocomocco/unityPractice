using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  public enum Type{
    Leaf,
    Key,
    Dog,
    Sample,
    Nothing
  }

  public Type itemType;
  //クリックしたときにアイテムボックスに格納され非表示になる
  public void OnThis(){
    ItemBox.belowBox.SetItem(itemType);
    gameObject.SetActive(false);
  }

  public static int itemToInt(Type item){
    switch (item)
    {
        case Type.Leaf: 
          return 1;
        case Type.Key:
          return 2;
        case Type.Dog:
          return 3;
        default:
          return 0;
    }
  }

  public static string itemToStr(Type item){
    switch (item)
    {
        case Type.Leaf: 
          return "Leaf";
        case Type.Key:
          return "Key";
        case Type.Dog:
          return "Dog";
        default:
          return "空白";
    }
  }


  public static Type StrToItem(string item){
    switch (item)
    {
        case "Leaf": 
          return Type.Leaf;
        case "Key":
          return Type.Key;
        case "Dog":
          return Type.Dog;
        default:
          return Type.Nothing;
    }
  }
}
