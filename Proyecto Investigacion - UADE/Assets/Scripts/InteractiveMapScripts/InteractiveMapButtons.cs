using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractiveMapButtons : MonoBehaviour
{
    public void OnBackFromProvince(InteractiveMapCameraController cameraRef)
    {
        cameraRef.ResetCameraValues();
        //Ocultar boton de back, lo hago por editor
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }
}
