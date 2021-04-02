using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorWithClick : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(ResetMousePosition());
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float midPoint = (transform.position - Camera.main.transform.position).magnitude * 0.5f;
        transform.LookAt((ray.origin + ray.direction * midPoint));
    }

    IEnumerator ResetMousePosition()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(0.1f);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
