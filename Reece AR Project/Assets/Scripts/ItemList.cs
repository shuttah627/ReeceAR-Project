using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    public GameObject pageParent;
    public GameObject listParent;
    public GameObject tlList;
    public GameObject listPrefab;
    public GameObject modelController;
    public GameObject menuCont; // menu container obj holder


    // Use this for initialization
    void Start()
    {
        ClearList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToList(string category)
    {
        ClearList();
        foreach (ScriptableTemplate i in modelController.GetComponent<ModelController>()._productList)
        {
            if (i._productCategory == category)
            {
                GameObject x = Instantiate(listPrefab);
                x.GetComponentInChildren<ItemPage>().scriptTemplate = i;
                x.GetComponent<ItemPage>().pageParent = pageParent;
                x.GetComponent<ItemPage>().modelControl = modelController;
                x.GetComponent<Image>().sprite = i._productImage;
                x.GetComponentInChildren<Text>().text = string.Format("<b>{0}</b>\n{1}\n{2,10}...", i._productName, ("<b>$"+i._productPrice+"</b>"), i._productDescription);
                x.transform.SetParent(listParent.transform);
                x.GetComponent<ItemPage>().menuContainer = menuCont; // pass menu cont
            }
        }
    }

    void ClearList()
    {
        foreach (Transform child in listParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    
}
