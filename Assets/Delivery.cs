using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

  [SerializeField] float deleyOfDestroy = 0.5f;
  [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
  [SerializeField] Color32 hasPackageColor = new Color32(219, 18, 18, 255);
  bool hasPackage;
  SpriteRenderer spriteRenderer;
  void Start() 
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void OnCollisionEnter2D(Collision2D other) 
  {
    Debug.Log("Bump");
  }

  void OnTriggerEnter2D(Collider2D other) 
  {
    if (other.tag == "Package" && !hasPackage)
    {
      Debug.Log("Package Picked Up");
      hasPackage = true;
      Destroy(other.gameObject, deleyOfDestroy);
      spriteRenderer.color = hasPackageColor;
      
    }
    else if (other.tag == "Customer" && hasPackage)
    {
      Debug.Log("Delivered");
      hasPackage = false;
      spriteRenderer.color = noPackageColor;
    }
    
  }
}
