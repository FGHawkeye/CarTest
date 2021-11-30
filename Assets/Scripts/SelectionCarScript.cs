using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionCarScript : MonoBehaviour
{
    public void SelectShelby()
    {
        CrossScene.isFiatSelected = false;
        LoadTrackScene();
    }

    public void SelectFiat()
    {
        CrossScene.isFiatSelected = true;
        LoadTrackScene();
    }

    private void LoadTrackScene()
    {
        SceneManager.LoadScene("Track");
    }
}
