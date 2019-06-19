using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aleatorios : MonoBehaviour
{
    public GameObject enemy;
    float aleatorioX;
    float aleatorioY;
    private float secondsCounter = 0;
    public float tiempo = 3;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        secondsCounter += Time.deltaTime;
        if (secondsCounter >= tiempo)
        {
            tiempo = tiempo + 3;
            aleatorioX = Random.Range(-18F, 18F);
            aleatorioY = Random.Range(-15F, 15F);
            Instantiate(enemy);
            Vector3 a = new Vector3(aleatorioX, aleatorioY);
            Quaternion b = new Quaternion();
            enemy.transform.SetPositionAndRotation(a, b);
        }
    }
}
