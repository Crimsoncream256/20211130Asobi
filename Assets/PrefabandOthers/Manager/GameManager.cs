using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject TitleButton;
    public GameObject RetlyButton;
    public GameObject SelectButton;
    public GameObject NextButton;

    void Start()
    {
        TitleButton.SetActive(false);
        RetlyButton.SetActive(false);
        SelectButton.SetActive(false);
        NextButton.SetActive(false);
    }

    public void ButtonRetly()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
}
