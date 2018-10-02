using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemPage : MonoBehaviour {

    public ScriptableTemplate scriptTemplate;
    public GameObject pagePrefab;
    public GameObject pageParent;
    public GameObject modelControl;
    public List<GameObject> menuComponents = new List<GameObject>();
    public GameObject menuContainer; // menu container
    

	// Use this for initialization
	void Start () {
        ClearItemPage();
        this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
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

        pageParent.SetActive(true);
        this.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.SetActive(false); // there is no god
        x.transform.Find("btn_Place").GetComponent<Button>().onClick.AddListener(delegate { place(); }); // further proof that there is no god
        // ******** ^^^^

        x.transform.Find("Text").GetComponent<Text>().text = string.Format("<b>{0}</b>\n{1}",scriptTemplate._productName, scriptTemplate._productDescription);
        x.transform.Find("img_Item").transform.Find("itempic").GetComponent<Image>().sprite = scriptTemplate._productImage;
        x.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

    }

    // place item button script
    void place()
    {
        modelControl.GetComponent<ModelController>().SpawnProductViaID(scriptTemplate._productCode);
        menuContainer.GetComponent<OCMController>().Close();
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
