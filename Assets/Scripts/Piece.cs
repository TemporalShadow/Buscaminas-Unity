using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{

    public int x, y;
    public bool bomb = false;

    public bool pulsable = true;


    // Start is called before the first frame update
    void Start()
    {
        /*
         
         
         
         
         */
        //int numerobombas=Generador.gen.GetBombasAround(x, y);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (pulsable)
        {
            if (bomb)
            {
                Debug.Log("Es una bomba,rojo");
                this.GetComponent<SpriteRenderer>().color = Color.red;
                GameManager.gm.bombardeado();
            }
            else
            {
                int bombasAround = Generador.gen.GetBombasAround(x, y);
                transform.GetChild(0).GetChild(0).GetComponent<Text>().text = bombasAround.ToString();
                Debug.Log("Casilla normal");
                GameManager.gm.pulsadoBlanco(); 
            }
            pulsable = false;
        }
    }

}
