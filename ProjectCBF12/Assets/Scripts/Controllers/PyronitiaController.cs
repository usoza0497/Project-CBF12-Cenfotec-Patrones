using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PyronitiaController : MonoBehaviour
{
    public float speed;
    public bool esIzquierda = true;
    public float contadorT;
    public float tiempoParaCambiar = 4f;
    public Rigidbody2D rbd;
    public float fuerzaSalto = 4f;
    // Start is called before the first frame update
    void Start()
    {
        contadorT = tiempoParaCambiar;
    }

    // Update is called once per frame
    void Update()
    {
        if (esIzquierda == true)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (esIzquierda == false)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);
        }

        contadorT -= Time.deltaTime;

        if (contadorT <= 0)
        {
            esIzquierda = !esIzquierda;
            contadorT = tiempoParaCambiar;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbd.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
}
