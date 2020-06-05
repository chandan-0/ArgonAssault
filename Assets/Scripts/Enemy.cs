using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject DeathFX;
    [Tooltip("1 baar me kitta damage hoga")][SerializeField] private int scorePerHit= 10; 
    
    /*
    [Tooltip("total health points")][SerializeField] private int healthPoint = 100;
    [Tooltip("Ek baar me kitta power jaayega")][SerializeField] private int healthPointPerHit = 10;
    */
    
    [Tooltip("kitte baar maarenge too marega")][SerializeField] private int maxHits = 10;
    
    private ScoreBord scoreBord;
    // Start is called before the first frame update
    void Start()
    {
        addNonTrigerBoxCollider();
        scoreBord = FindObjectOfType<ScoreBord>();
    }
    private void addNonTrigerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger=false;
    }
    // Update is called once per frame

    void OnParticleCollision(GameObject other)
    {
        HitProcess();
        if (maxHits <= 0)
        {
            print("You Kild Enemy & Remaning hits is -> "+maxHits);
            KillEnemy();
        }
        else
        {
            print("Abhi tak nahi mraa Enemy & total remaining hits-->"+maxHits);
        }
    }

    private void HitProcess()
    {
        scoreBord.scoreHit(scorePerHit);
        maxHits--;
    }

    private void KillEnemy()
    {
        GameObject ExplosianEnemy = Instantiate(DeathFX, transform.position, Quaternion.identity);
        ExplosianEnemy.transform.parent = parent;
        print("Partical Colided With Enemy -> "+gameObject.name);
        Destroy(gameObject);
    }
}
