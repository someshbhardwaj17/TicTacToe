using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] int sceneIndex;
    [SerializeField] Button btn;

    private void Start()
    {
        btn.onClick.AddListener(LoadSceneIndex);
    }
    public void LoadSceneIndex()
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
