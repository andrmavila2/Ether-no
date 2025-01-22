using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCollitions : MonoBehaviour
{


    private PlayerData _data;
    private PlayerEscudo _escudo;


    private void Awake()
    {
        _data = GetComponent<PlayerData>();
        _escudo = GetComponent<PlayerEscudo>();
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag.Contains("pan"))
        {
            print("_data.salud antes " + _data.salud);

            _data.salud += 20f;

            if (_data.salud > 100f)
            {

                _data.salud = 100f;
            }

            _data.tieneEscudo = true;
            

            print("_data.salud despues " + _data.salud);

            Destroy(collision.gameObject);

        }
    }
}
