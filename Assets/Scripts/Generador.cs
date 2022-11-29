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
        Camera.main.transform.position =
              new Vector3(((float)width / 2) - 0.5f, ((float)height / 2) - 0.5f, -10);


        map = new GameObject[width][];
        for (int i = 0; i < map.Length; i++)
        {
            map[i] = new GameObject[height];
        }


        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i][j] = Instantiate(piece, new Vector2(i, j), Quaternion.identity);
            }
        }

        /*for (int i = 0; i < bombsNumber; i++)
        {
            map[Random.Range(0, width)][Random.Range(0, height)].GetComponent<SpriteRenderer>().material.color = Color.red;
        }*/

        for (int i = 0; i < bombsNumber; i++)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            //Debug.Log("Map de " + map[x][y].GetComponent<Piece>().bomb);
            map[x][y].GetComponent<SpriteRenderer>().material.color = Color.red;
            if (map[x][y].GetComponent<Piece>().bomb == false)
            {
                map[x][y].GetComponent<Piece>().bomb = true;
            }
        }
        /*for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i][j].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = GetBombasAround(i, j).ToString();
            }
        }*/
        Debug.Log(GetBombasAround(1, 1));
    }

    // Update is called once per frame
    void Update()
    {

    }


    public int GetBombasAround(int x, int y)
    {
        int cont = 0;
        Debug.Log("Empiezo");
        for (int i = (x - 1); i <= (x + 1); i++)
        {
            for (int j = (y - 1); j <= (j + 1); j++)
            {
                if (i != x && j != y)
                {
                    if ((x>=0 && x<=width)&&(y>=0 && y <= height))
                    {
                        Debug.Log("Soy Log " + cont);
                        cont++;
                    }
                }
            }
        }

        return cont;
    }
}
