using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowExtraInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _objectDescriptionText;
    [SerializeField] private Transform _zoomCardParent;
    private GameObject _currentShowingObject;

    private void Awake()
    {
        IntializeDummyObject();
    }

    public void ChangeShowingObject(GameObject newObject)
    {
        _currentShowingObject.SetActive(false);
        _currentShowingObject = newObject;
        _currentShowingObject.transform.SetParent(transform, false);
        _currentShowingObject.transform.position = this.transform.position;
        print($"La posicion del showExtraInfo es {transform.position} y en el parent {transform.parent.name}");
        print($"zoomeando en la posicion {_currentShowingObject.transform.position} y en el parent {_currentShowingObject.transform.parent.name}");
        _currentShowingObject.SetActive(true);
    }
    
    public void ChangeObjectDescription(string newDescription)
    {
        _objectDescriptionText.text = newDescription;
    }

    private void IntializeDummyObject()
    {
        _currentShowingObject = new GameObject();
        _currentShowingObject.transform.SetParent(_zoomCardParent, false);
    }
}
