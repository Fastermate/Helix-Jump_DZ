using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public int points;
    public AudioSource PlatformDestroySound;
    

    

    private void OnTriggerEnter(Collider other)
    {
        
        GameObject Player = GameObject.FindGameObjectsWithTag("Player")[0];


        Player.SendMessage("PlayDestroySound", PlatformDestroySound);
        Player.SendMessage("addPoints", points);
        Destroy(gameObject);
        
    }
    

}
