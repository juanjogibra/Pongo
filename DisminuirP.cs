using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisminuirP : MonoBehaviour
{
    private IEnumerator rutina;
    // Start is called before the first frame update
    void Start()
    {
        rutina = disminuirPalas();
        StartCoroutine(rutina);
    }
    private IEnumerator disminuirPalas()
    {
        for (int i = 0; i < 10; i++) {
            yield return new WaitForSeconds(3);
            transform.localScale  += new Vector3(0, -0.1f, 0);

        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
