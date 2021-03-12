using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractiveMapButtons : MonoBehaviour
{
    [SerializeField] private GameObject _blurImageRef;
    [SerializeField] private GameManager _gameManagerRef;
    public event Action OnBackButtonPressed;

    public void OnBackFromProvince(InteractiveMapCameraController cameraRef)
    {
        cameraRef.ResetCameraValues();
        _blurImageRef.SetActive(false);
        OnBackButtonPressed?.Invoke();
        //Ocultar boton de back, lo hago por editor
    }

    public void OnStartGame()
    {
        //Completar la lista de cardsIDsToActivate del game manager
        SceneManager.LoadScene("GameScene");
    }
}
