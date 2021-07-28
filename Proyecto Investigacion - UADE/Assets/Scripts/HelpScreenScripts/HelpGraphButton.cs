using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpGraphButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> _buttonCardsPrefabs = null;
    [SerializeField] private HelpCardsSlider _cardsSlider = null;

    private List<GameObject> _instantiatedCards = new List<GameObject>();
    public List<GameObject> InstantiatedCards { get => _instantiatedCards; set => _instantiatedCards = value; }

    private void Start()
    {
        InitButtonCards();
    }

    private void InitButtonCards()
    {//Instancio todas las cartas correspondientes a cada boton dentro de la pantalla de help
        for (int i = 0; i < _buttonCardsPrefabs.Count; i++)
        {
            print("Instanciando cartas del boton " + this.gameObject.name);

            var newCard = Instantiate(_buttonCardsPrefabs[i], this.transform.position, Quaternion.identity, this.transform);
            Destroy(newCard.GetComponent<Draggable>());

            newCard.SetActive(false);
            _instantiatedCards.Add(newCard);
        }
    }

    public void AssignCardsToSlider()
    {//El slider de la pantalla de help obtiene las instancias de las cartas para mostrar

        print("Pasandole la referencia de las cartas instanciadas al slider");

        _cardsSlider.SetNewCardsOnSlider(this);
    }
}
