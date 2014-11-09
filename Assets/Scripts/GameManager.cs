using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    private const int OPEN = 0;
    private const int CLOSED = 1;
    private const int OCCUPIED = 2;

	private int blockedFields;
	public int freeSlots;

	private const int height = 4;
	private const int width = 4;

    public int[,] occupationGrid = new int[width,height]; 
    public GameObject[,] bananaGrid = new GameObject[width,height];

	private int difficulty;
    private float startTime;

    //--------------------------------------------------------------------------
	void initField()
	{
        // initialize all fields as open
        for (int i=0; i<width; i++)
        {
            for(int j=0; j<height; j++)
            {
                occupationGrid[i,j] = OPEN;
            }
        }

        /*
        // block some fields in the beginning
        for (int i=0; i<blockedFields;)
        {
            int rand1 = Random.Range(0, width);
            int rand2 = Random.Range(0, height);

            if(occupationGrid[rand1,rand2] == OPEN)
            {
                occupationGrid[rand1,rand2] = CLOSED;
                i++;
            }

        }
        */
	}

    //--------------------------------------------------------------------------
    void createBananaGrid()
    {
        for (int i=0; i<width; i++)
        {
            for(int j=0; j<height; j++)
            {
                bananaGrid[i,j] = GameObject.Find("Banana"+(i+1).ToString()+"."+(j+1).ToString());
                bananaGrid[i,j].gameObject.GetComponent<BananaRise>().x = i;
                bananaGrid[i,j].gameObject.GetComponent<BananaRise>().y = j;
            }
        }
    }

    //--------------------------------------------------------------------------
    void openHole()
    {
        for (int i=0; i<width; i++)
        {
            for (int j=0; j<height; j++)
            {
                if(occupationGrid[i,j] == CLOSED)
                {
                    occupationGrid[i,j] = OPEN;
                    return;
                }
            }
        }
    }
	
    //--------------------------------------------------------------------------
	// Use this for initialization
	void Start () 
	{
		//blockedFields = 5;
		freeSlots = 5;
		difficulty = 0;

        initField();
        createBananaGrid();
        startTime = Time.time;
	}
	
    //--------------------------------------------------------------------------
	// Update is called once per frame
	void Update () 
	{
        // TODO: update bananas 
        Debug.Log(freeSlots);
        while (freeSlots > 0)
        {
            int rand1 = Random.Range(0, width);
            int rand2 = Random.Range(0, height);

            if(occupationGrid[rand1,rand2] == OPEN)
            {
                occupationGrid[rand1,rand2] = OCCUPIED;
                //rand1++;
                //rand2++;
                //GameObject.Find("Banana"+rand1.ToString()+"."+rand2.ToString()).gameObject.GetComponent<BananaRise>().canMove = true;
                bananaGrid[rand1, rand2].gameObject.GetComponent<BananaRise>().canMove = true;
                freeSlots--;
            }
        }
	
        // TODO: increase difficulty:
        if (Time.time - startTime > 30 && difficulty == 0)
        {
            difficulty++;
            openHole();
        }
    }
}
