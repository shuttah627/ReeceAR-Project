using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogueGenerator : MonoBehaviour {

    public GameObject _productListing;
    public GameObject _modelController;
    private List<GameObject> _products = new List<GameObject>();
	
    void Start()
    {
        Debug.Log("shdsad");
        foreach (ScriptableTemplate i in _modelController.GetComponent<ModelController>()._productList)
        {
            Debug.Log(i._productName);
            GameObject j = Instantiate(_productListing);
            j.transform.SetParent(this.transform);
            j.GetComponent<ProductListing>()._plName.text = i._productName;
            j.GetComponent<ProductListing>()._plImage.sprite = i._productImage;
            _products.Add(j);
        }
    }
}
