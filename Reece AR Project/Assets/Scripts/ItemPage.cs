using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemPage : MonoBehaviour {

    public ScriptableTemplate scriptTemplate;
    public GameObject pagePrefab;
    public GameObject pageParent;
    public GameObject listBase;
    public List<GameObject> menuComponents = new List<GameObject>();
    

	// Use this for initialization
	void Start () {
        ClearItemPage();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateItemPage()
    {
        ClearItemPage();
        GameObject x = Instantiate(pagePrefab);
        
        x.transform.SetParent(pageParent.transform);
        //x.GetComponentInChildren<Text>().text = scriptTemplate._productName;
       // x.transform.Find("img_Item").GetComponentInChildren<Image>().sprite = scriptTemplate._productImage;
        pageParent.SetActive(true);
        this.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false); // there is no god
        x.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    void ClearItemPage()
    {
        foreach (Transform child in pageParent.transform)
        {
            if(child.name == "item_selected(Clone)")
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
