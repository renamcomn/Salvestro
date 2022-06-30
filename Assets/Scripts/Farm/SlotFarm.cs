using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [SerializeField] private int digAmount; // quantidade de escavacao
    private int initialDigAmout;

    private void Start() {
        initialDigAmout = digAmount;
    }

    public void onDig() {
        digAmount--;

        if(digAmount <= initialDigAmout / 2) {
            spriteRenderer.sprite = hole;
        }

        // if(digAmount <= 0) {
        //     // plantar cenoura
        //     spriteRenderer.sprite = carrot;
        // }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Dig")) {
            onDig();
        }
    }
}
