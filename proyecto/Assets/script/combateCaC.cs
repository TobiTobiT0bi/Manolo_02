using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combateCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Golpe();
        }
    }

    private void Golpe() {
        animator.SetTrigger("Golpe");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos) {
            if (colisionador.CompareTag("enemigo"))
            {
                colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
            }
            else {
                Debug.Log("hubo objetos, no entro en ninguno");
            }
        }
        Debug.Log("cantidad de objetos: " + objetos.Length);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
