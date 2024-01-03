using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 public class Caminhada : MonoBehaviour
 {
    [SerializeField] private Transform[] NPCs;
    private int index = 0;
    public float velocidade;
    [SerializeField] private TMP_Dropdown drop;

     public void FixedUpdate()
     {
         Vector3 direcao = NPCs[index].position - transform.position;

         if (direcao.magnitude <= 0.1f)
         {
            index = ChangeIndex();
         }

         transform.position += direcao.normalized * velocidade * Time.fixedDeltaTime;
     }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            index = 0;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            index = 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            index = 2;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            index = 3;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            index = 4;
        }
    }

    int ChangeIndex()
    {
        switch (drop.value)
        {
            case 0:
                return (index + 1) % NPCs.Length;
            case 1:
                return Random.Range(0, 5);
            case 2:
                return (index + 1) % (NPCs.Length - 1);
            default:
                return (index + 1) % NPCs.Length;
        }
    }
}
