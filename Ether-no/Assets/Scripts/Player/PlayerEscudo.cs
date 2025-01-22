using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerEscudo : MonoBehaviour
{
    private PlayerData _data;
    public GameObject _body;

    public float tiempo;
    public int segundosEscudo;
    public TextMeshProUGUI textMeshPro;
    
    private void Awake()
    {
        _data = GetComponent<PlayerData>();
        
    }

    private void Start()
    {
        print("Tiempo Escudo: " + tiempo);
    }
    private void Cronometro() {

        print("Tiempo Escudo Cronometro: " + tiempo);

        tiempo = tiempo -  Time.deltaTime;
        segundosEscudo = Mathf.FloorToInt(tiempo % 60f);


        if (segundosEscudo == 0)       
        {

            _data.tieneEscudo = false;
            textMeshPro.text = "";
            tiempo = 30f;
        }
        else { 
        
            textMeshPro.text = segundosEscudo.ToString();
        }

    }


    private void Update()
    {
        if (_data.tieneEscudo)
        {

            _body.GetComponent<SpriteRenderer>().color = Color.blue;
            Cronometro();

        }
        else {

            _body.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

}
