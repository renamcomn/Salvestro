using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;

    [SerializeField] private ParticleSystem leafs;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onHit() {
        treeHealth--;

        anim.SetTrigger("isHit");
        leafs.Play();
        if(treeHealth <= 0) {
            //cria o toco e instancia os drops ( madeira )
            for(int i = 0; i < totalWood; i++) {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1.5f, 1.5f),Random.Range(-1.5f, 1.5f), 0f), transform.rotation);
            }
            anim.SetTrigger("cut");
    
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(treeHealth > 0) {
            if(other.CompareTag("Axe")) {
                onHit();
            }
        }
        
    }
}
