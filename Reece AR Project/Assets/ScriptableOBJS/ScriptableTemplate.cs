using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Reece Product", menuName = "Reece/Reece Product", order = 1)]
public class ScriptableTemplate : ScriptableObject {

    public GameObject _productModel;
    public string _productName;
    public float _productPrice;
}
