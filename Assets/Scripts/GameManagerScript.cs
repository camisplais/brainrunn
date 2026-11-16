using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    // ---------- CANVAS ----------
    public GameObject canvas_game;
    public GameObject canvas_menu;    // personajes
    public GameObject canvas_carro;
    public GameObject canvas_modo;    // Grand Prix / Trial / Battle

    // ---------- PERSONAJES ----------
    public Animator personajeGrande;
    public RuntimeAnimatorController[] animaciones;   // una por personaje
    public string[] nombres;
    public TextMeshProUGUI textoNombre;
    int actual = 0;

    // ---------- CARROS ----------
    public Animator carroGrande;
    public RuntimeAnimatorController[] animacionesCarros;  // una por carro
    public string[] nombresCarros;
    public TextMeshProUGUI textoNombreCarro;
    int carroActual = 0;

    // ---------- MODOS ----------
    public Image[] tarjetasModo;            // fondo de cada tarjeta (Grand Prix, Trial, Battle)
    public Sprite spriteNormal;             // panel_normal
    public Sprite spriteSeleccionado;       // panel_seleccionado
    public string[] escenasModo;            // nombre de la escena de cada modo
    int modoActual = 0;

    void Start()
    {
        Seleccionar(0);
        SeleccionarCarro(0);
        SeleccionarModo(0);
    }

    // ================= PERSONAJES =================
    public void Seleccionar(int i)
    {
        actual = i;
        personajeGrande.runtimeAnimatorController = animaciones[i];
        textoNombre.text = nombres[i];
    }
    public void Siguiente() { Seleccionar((actual + 1) % animaciones.Length); }
    public void Anterior()  { Seleccionar((actual - 1 + animaciones.Length) % animaciones.Length); }

    // ================= CARROS =================
    public void SeleccionarCarro(int i)
    {
        carroActual = i;
        carroGrande.runtimeAnimatorController = animacionesCarros[i];
        textoNombreCarro.text = nombresCarros[i];
    }
    public void SiguienteCarro() { SeleccionarCarro((carroActual + 1) % animacionesCarros.Length); }
    public void AnteriorCarro()  { SeleccionarCarro((carroActual - 1 + animacionesCarros.Length) % animacionesCarros.Length); }

    // ================= MODOS =================
    public void SeleccionarModo(int i)
    {
        modoActual = i;
        for (int k = 0; k < tarjetasModo.Length; k++)
            tarjetasModo[k].sprite = (k == i) ? spriteSeleccionado : spriteNormal;
    }
    public void SiguienteModo() { SeleccionarModo((modoActual + 1) % tarjetasModo.Length); }
    public void AnteriorModo()  { SeleccionarModo((modoActual - 1 + tarjetasModo.Length) % tarjetasModo.Length); }

    // ================= BOTONES DE FLUJO =================
    public void ButtonMenu()          // PLAY del título
    {
        canvas_game.SetActive(false);
        canvas_menu.SetActive(true);
    }

    public void ButtonElegirCarro()   // PLAY de personajes
    {
        PlayerPrefs.SetInt("personaje", actual);
        canvas_menu.SetActive(false);
        canvas_carro.SetActive(true);
        
    }

    public void ButtonElegirModo()    // PLAY de carros
    {
        //PlayerPrefs.SetInt("carro", carroActual);
        canvas_carro.SetActive(false);
        canvas_modo.SetActive(true);
    }

    public void ButtonJugar()         // PLAY de modos
    {
        PlayerPrefs.SetInt("modo", modoActual);
        SceneManager.LoadScene(escenasModo[modoActual]);
    }

    // ================= ATRÁS =================
    public void AtrasACarro()  { canvas_modo.SetActive(false);  canvas_carro.SetActive(true); }
    public void AtrasAMenu()   { canvas_carro.SetActive(false); canvas_menu.SetActive(true); }
}