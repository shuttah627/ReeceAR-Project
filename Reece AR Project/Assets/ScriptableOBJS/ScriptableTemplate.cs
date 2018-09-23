using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Reece Product", menuName = "Reece/Reece Product", order = 1)]
public class ScriptableTemplate : ScriptableObject {

    public GameObject _productModel;
    public Sprite _productImage;
    public string _productName;
    public float _productPrice;
    public string _productCode;
    public Vector3 _productScale;
}
