using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
  // アイテムをBoxに格納 : 画像を表示させる
  // 特定のアイテムを持っているかどうかを調べる
  // アイテムを使用する : 画像を非表示

  //static どのファイルからも参照できるように

  public SpriteRenderer[] item;
  public Sprite[] spriteArray;

  public static ItemBox belowBox;

  private int right;

  private Hashtable itemPlace = new Hashtable();

  private void Awake(){
    belowBox = this;
  }

  private void Start(){
    int itemboxId = 0;
    foreach(SpriteRenderer itemBox in item)
        {
            changeTo(itemboxId,Item.Type.Nothing,Item.Type.Nothing);
            itemboxId++;
        }
    right = 0;
  }

  public void SetItem(Item.Type itemType){
    changeTo(right,Item.Type.Nothing,itemType);
    right= right +1;
    Debug.Log(itemType+"を追加");
  }

  public bool CanUseItem(Item.Type itemType){
    return itemPlace.Contains(Item.itemToStr(itemType));
  }

  private string ItemFromPlace(int placeId){
    foreach(DictionaryEntry de in itemPlace){
      if((int)de.Value==placeId){return (string)de.Key;}
    }
    return "該当なし";
  }

  public void UseItem(Item.Type itemType){
    int changePlace = (int)itemPlace[Item.itemToStr(itemType)];
    changeTo(changePlace,itemType,Item.Type.Nothing);
    for (int i = changePlace + 1; i < right ; i++){
      Item.Type newType = Item.StrToItem(ItemFromPlace(i));
      changeTo(i,newType,Item.Type.Nothing);
      changeTo(i - 1,Item.Type.Nothing,newType);
    }
    right--;
    Debug.Log(itemType+"を削除");

  }

    void changeTo(int Id,Item.Type oldType,Item.Type newType)
    {
        // Debug.Log("左から"+(Id+1)+"番目の"+Item.itemToStr(oldType)+"を"+Item.itemToStr(newType)+"に変える");
        item[Id].sprite = spriteArray[Item.itemToInt(newType)]; 
        if(oldType != Item.Type.Nothing){
          itemPlace.Remove(Item.itemToStr(oldType));
        }
        if(newType != Item.Type.Nothing){
          itemPlace.Add(Item.itemToStr(newType),Id);
        }
    }
}
