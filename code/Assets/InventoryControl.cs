using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{
    private List<laptopItem> laptopInventory;
    [SerializeField]
    private GameObject buttonTemplate;
    [SerializeField]
    private GridLayoutGroup gridGroup;
    [SerializeField]
    private Sprite[] iconSprites;


    void Start()
    {
        laptopInventory = new List<laptopItem>();
        for (int i = 1; i < 100; i++)
        {
            laptopItem newItem = new laptopItem();
            newItem.iconSprite = iconSprites[Random.Range(0, iconSprites.Length)];
            laptopInventory.Add(newItem);
        }
        GenInventory();
    }
    void GenInventory()
    {
        if (laptopInventory.Count < 11)
        {
            gridGroup.constraintCount = laptopInventory.Count;
        }
        else
        {
            gridGroup.constraintCount = 10;
        }
        foreach(laptopItem newItem in laptopInventory)
        {
            GameObject newButton = Instantiate(buttonTemplate) as GameObject;
            newButton.SetActive(true);

            newButton.GetComponent<InventoryButton>().SetIcon(newItem.iconSprite);
            newButton.transform.SetParent(buttonTemplate.transform.parent, false);
                
        }
    }

    public class laptopItem
    {
        public Sprite iconSprite;
    }

}
