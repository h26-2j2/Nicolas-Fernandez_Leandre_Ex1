using UnityEngine;

public class DeplacementMeteore : MonoBehaviour
{
    [Header("Vitesse du météore")]
    public float vitesseMin = 1f;
    public float vitesseMax = 6f;

    [Header("Limites de l'écran")]
    public float limiteHaut = 12f;
    public float limiteBas = -12f;

    [Header("Pulsation de taille")]
    public float tailleMin = 1f;
    public float tailleMax = 3f;
    public float vitessePulsation = 4f;

    // Vitesse aléatoire assignée au démarrage
    float vitesse;
    
    // Taille initiale du météore
    Vector3 tailleInitiale;
    
    // Position Y initiale (la rangée prédéterminée)
    float positionYInitiale;

    void Start()
    {
        // On assigne une vitesse aléatoire entre les bornes configurables
        vitesse = Random.Range(vitesseMin, vitesseMax);

        // On sauvegarde la taille initiale pour la pulsation
        tailleInitiale = transform.localScale;
        
        // On sauvegarde la position Y initiale (la rangée du météore)
        positionYInitiale = transform.position.y;

        // On place le météore hors écran en haut de l'écran
        transform.position = new Vector2(transform.position.x, limiteHaut);
    }

    void Update()
    {
        // On déplace le météore verticalement vers le bas
        transform.Translate(Vector2.down * vitesse * Time.deltaTime);

        // Vérification de la sortie d'écran pour la téléportation (warp)
        if (transform.position.y < limiteBas)
        {
            // Le météore sort par le bas, on le téléporte en haut
            transform.position = new Vector2(transform.position.x, limiteHaut);
        }

        // Pulsation de la taille du météore
        float pulsation = Mathf.Lerp(tailleMin, tailleMax, (Mathf.Sin(Time.time * vitessePulsation) + 1f) / 2f);
        transform.localScale = tailleInitiale * pulsation;
    }
}
