using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractiveMapButtons : MonoBehaviour
{
    [SerializeField] private GameObject _blurImageRef;

    public void OnBackFromProvince(InteractiveMapCameraController cameraRef)
    {
        cameraRef.ResetCameraValues();
        _blurImageRef.SetActive(false);
        //Ocultar boton de back, lo hago por editor
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }
}
