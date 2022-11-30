using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generador : MonoBehaviour
{
    public GameObject piece;
    public int width, height, bombsNumber;

    public GameObject[][] map;


    public static Generador gen;

    public int bombasPermitidas;
    

    

    private GameObject padre;


    private void Awake()
    {
        if(gen !=null && gen != this)
        {
            Destroy(this);
        }
        else
        {
            gen = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(bombsNumber<1)
            bombsNumber = 1;
        if(bombsNumber>(width*height))
            bombsNumber = (width*height-1);
        if(bombasPermitidas>bombsNumber)
            bombasPermitidas=bombsNumber;


        Camera.main.transform.position =
              new Vector3(((float)width / 2) - 0.5f, ((float)height / 2) - 0.5f, -10);


        map = new GameObject[width][];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = new GameObject[height];
        }
        

        CrearMapa();

        /*for (int i = 0; i < bombsNumber; i++)
        {
            map[Random.Range(0, width)][Random.Range(0, height)].GetComponent<SpriteRenderer>().material.color = Color.red;
        }*/

        
        /*for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i][j].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = GetBombasAround(i, j).ToString();
            }
        }*/
        //Debug.Log(GetBombasAround(1, 1));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void reset()
    {
        Destroy(padre);
        CrearMapa();
    }


    private void CrearMapa()
    {
        padre = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //padre.transform.GetComponent<SpriteRenderer>().enabled = false;

        Destroy(padre.transform.GetComponent<MeshRenderer>());
        Destroy(padre.transform.GetComponent<MeshFilter>());
        Destroy(padre.transform.GetComponent<SphereCollider>());
        padre.name = "Padre";
        padre.transform.SetParent(this.transform);


        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {

                map[i][j] = Instantiate(piece, new Vector2(i, j), Quaternion.identity);
                map[i][j].GetComponent<Piece>().x = i;
                map[i][j].GetComponent<Piece>().y = j;
                map[i][j].transform.SetParent(padre.transform);
                
            }
        }

        for (int i = 0; i < bombsNumber;)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            //Debug.Log("Map de " + map[x][y].GetComponent<Piece>().bomb);
            //map[x][y].GetComponent<SpriteRenderer>().material.color = Color.red;
            if (map[x][y].GetComponent<Piece>().bomb == false)
            {
                map[x][y].GetComponent<Piece>().bomb = true;
                if (GameManager.gm.modoTranposo)
                    map[x][y].GetComponent<SpriteRenderer>().color = Color.cyan;
                i++;
            }
        }
    }

    public int GetBombasAround(int x, int y)
    {
        int cont = 0;
        //Debug.Log("Empiezo");
        for (int i = (x - 1); i <= (x + 1); i++)
        {
         
            for (int j = (y - 1); j <= (y + 1); j++)
            {
                if (i != x || j != y)
                {
                    if ((i>=0 && i<=width-1)&&(j>=0 && j <= height-1))
                    {
                        if (map[i][j].GetComponent<Piece>().bomb)
                        {
                            //Debug.Log("Soy Log " + cont);
                            cont++;
                        }
                    }
                }
            }
        }

        return cont;
    }

    /*public int GetBombasAround(int x, int y)
    {
        int cont = 0;
        if (x > 0 && y < height - 1 && map[x - 1][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (y < height - 1 && map[x][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && y < height - 1 && map[x + 1][y + 1].GetComponent<Piece>().bomb)
            cont++;
        if (x > 0 && map[x - 1][y].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && map[x + 1][y].GetComponent<Piece>().bomb)
            cont++;
        if (x > 0 && y > 0 && map[x - 1][y - 1].GetComponent<Piece>().bomb)
            cont++;
        if (y > 0 && map[x][y - 1].GetComponent<Piece>().bomb)
            cont++;
        if (x < width - 1 && y > 0 && map[x + 1][y - 1].GetComponent<Piece>().bomb)
            cont++;

        return cont;
    }*/

    public void NoPulsable()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i][j].GetComponent<Piece>().pulsable = false;
            }
        }
    } 
}
