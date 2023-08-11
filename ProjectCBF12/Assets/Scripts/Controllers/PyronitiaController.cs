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
    public Transform objetivo;
    public bool debePerseguirObjetivo;
    public float distanciaObjetivo;
    public float distanciaObjetivoAbsoluta;
    // Start is called before the first frame update
    void Start()
    {
        contadorT = tiempoParaCambiar;
        InvokeRepeating("Saltar", 2f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        distanciaObjetivo = objetivo.position.x - transform.position.x;
        distanciaObjetivoAbsoluta = Mathf.Abs(distanciaObjetivo);

        contadorT -= Time.deltaTime;

        if (contadorT <= 0)
        {
            esIzquierda = !esIzquierda;
            contadorT = tiempoParaCambiar;

        }

        if(debePerseguirObjetivo == true) 
        {
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, speed * Time.deltaTime);
        }

        if(distanciaObjetivo > 0) 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (distanciaObjetivo < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (distanciaObjetivoAbsoluta < 6)
        {
            debePerseguirObjetivo = true;
        } else
        {
            debePerseguirObjetivo = false;
        }
    }

    public void Saltar()
    {
        rbd.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
    }
}