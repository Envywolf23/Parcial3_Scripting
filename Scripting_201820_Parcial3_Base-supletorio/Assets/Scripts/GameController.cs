using UnityEngine;

public class GameController : MonoBehaviour
{

    private ActorController[] players;

    [SerializeField]
    private int numeroPlayers;

    public GameObject player;
    public GameObject AI;

    private void Start()
    {
        numeroPlayers = Mathf.Clamp(numeroPlayers, 2, 5);
        CrearPlayers();

        players = FindObjectsOfType<ActorController>();

    }



    private void Update()
    {
        int contador = 0;

        for(int i = 0; i < players.Length; i++)
        {
            if(players[i].isActiveAndEnabled == true)
            {
                contador += 1;
            }
        }

        if(contador == 1)
        {
            foreach(ActorController Ac in players)
            {
                CancelInvoke("MoveActor");
            }
        }

    }

    private void CrearPlayers()
    {
        Instantiate(player, new Vector3(Random.Range(-30F, 30F), 2, Random.Range(-31F, 30F)), Quaternion.identity);

        for (int i = 0; i < numeroPlayers; i++)
        {
            Instantiate(AI, new Vector3(Random.Range(-30F, 30F), 2, Random.Range(-31F, 30F)), Quaternion.identity);
        }
    }

}