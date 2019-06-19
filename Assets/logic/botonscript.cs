using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class botonscript : MonoBehaviour
       {

    public Button reinicio;
    // Start is called before the first frame update
    void Start()
    {
        reinicio.onClick.AddListener(accionBoton);

    }

   public void accionBoton()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

        // Application.LoadLevel(0);

    }

}
