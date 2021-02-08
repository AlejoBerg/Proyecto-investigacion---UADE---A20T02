using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowExtraInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _objectDescriptionText;
    private GameObject _currentShowingObject;

    private void Awake()
    {
        IntializeDummyObject();
    }

    public void ChangeShowingObject(GameObject newObject)
    {
        _currentShowingObject.SetActive(false);
        _currentShowingObject = newObject;
        _currentShowingObject.transform.position = this.transform.position;
        _currentShowingObject.transform.SetParent(transform, false);
        _currentShowingObject.SetActive(true);
    }
    
    public void ChangeObjectDescription(string newDescription)
    {
        _objectDescriptionText.text = newDescription;
    }

    private void IntializeDummyObject()
    {
        _currentShowingObject = new GameObject();
        _currentShowingObject.transform.SetParent(transform, false);
    }
}
