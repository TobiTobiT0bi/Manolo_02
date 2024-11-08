using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    public void TomarDaño(float daño) {
        vida -= daño;

        if (vida <= 0) {
            Muerte();
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        Invoke("Destruir", 1f);
    }

    private void Destruir() {
        Destroy(this.gameObject);
    }
}
