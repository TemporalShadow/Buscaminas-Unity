using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public bool juegoFinalizado = false;

    public bool modoTranposo = false;

    private int fallos=0;

    private int casillasBlancasPulsadas = 0;

    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(this);
        }
        else
        {
            gm = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (juegoFinalizado && Input.GetKeyDown(KeyCode.Space))
        {
            Generador.gen.reset();
            fallos = 0;
            casillasBlancasPulsadas = 0;
            juegoFinalizado=false;
        }
    }

    public void bombardeado()
    {
        fallos++;
        if (fallos >= Generador.gen.bombasPermitidas)
        {
            Debug.Log("Perdiste");
            Generador.gen.NoPulsable();
            juegoFinalizado = true;
        }
    }

    public void pulsadoBlanco()
    {
        casillasBlancasPulsadas++;
        if (casillasBlancasPulsadas >= (Generador.gen.width * Generador.gen.height - Generador.gen.bombsNumber))
        {
            Debug.Log("Felicidades!!! Ganaste!!!");
            Generador.gen.NoPulsable();
            juegoFinalizado = true;
        }
    }
}
