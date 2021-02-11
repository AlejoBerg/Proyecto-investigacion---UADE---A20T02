using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectProvince : MonoBehaviour
{
        void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}
// https://gamedev.stackexchange.com/questions/117542/picking-a-2d-box-collider-with-the-mouse-in-unity  Referencia para seguir probando