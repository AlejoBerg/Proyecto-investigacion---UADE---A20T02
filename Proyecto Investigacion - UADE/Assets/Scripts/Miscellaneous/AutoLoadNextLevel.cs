using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoadNextLevel : MonoBehaviour
{
    [SerializeField] private string _nextLevelName = "MainMenu";

    void Start()
    {
        SceneManager.LoadScene(_nextLevelName);
    }
}
