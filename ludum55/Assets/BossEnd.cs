using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnd : MonoBehaviour
{
    private GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(instance != null)
        {
            SceneManager.LoadScene("3");
        }
    }
}
