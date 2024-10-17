using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab do inimigo
    public float spawnInterval = 2f;  // Intervalo entre os spawns
    public float spawnY = 5.186543f;  // Posição Y fixa no topo da tela
    private float minX;  // Limite esquerdo da posição de spawn
    private float maxX;  // Limite direito da posição de spawn
    public float enemySpeed = 2f;  // Velocidade do inimigo

    void Start()
    {
        // Calcula a posição de spawn com base na largura da tela
        float cameraHeight = 2f * 5.186543f;
        float cameraWidth = cameraHeight * (16f / 9f); // Supondo uma proporção 16:9
        minX = -cameraWidth / 2;  // Bordas esquerda
        maxX = cameraWidth / 2;  // Bordas direita

        // Inicia o spawn dos inimigos repetidamente
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Gera uma posição aleatória dentro dos limites de X
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        // Instancia o inimigo com rotação padrão
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Adiciona movimento ao inimigo (de cima para baixo)
        newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -enemySpeed);  // Movimento de cima para baixo
    }
}
