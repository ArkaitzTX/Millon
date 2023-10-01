using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemigo))]
[RequireComponent(typeof(Persona))]

public class IAEnem4 : MonoBehaviour
{

    private Enemigo enemigo;
    private Persona persona;
    private bool impacto;

    void Start()
    {
        enemigo = GetComponent<Enemigo>();
        persona = GetComponent<Persona>();

        Instanciar<Controles>.Coger("Controles").InicioTurno += Inicio;
    }

    void Update()
    {
        enemigo.Da�ar(transform, .32f, ref impacto);
    }

    private void Inicio() { 
    
    }

    //DESTRUIR
    private void OnDestroy()
    {
        Instanciar<Controles>.Coger("Controles").InicioTurno -= Inicio;
    }

    private void OnDisable()
    {
        Instanciar<Controles>.Coger("Controles").InicioTurno -= Inicio;
    }

}
