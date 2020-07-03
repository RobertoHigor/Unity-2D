using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs; // Lista de Waves
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Fazendo o Start ser uma corrotina
    IEnumerator Start()
    {       
       do
       {
           yield return StartCoroutine(SpawnAllWaves());
       } while (looping);
    }

    // Spawn todas as waves da lista de waves
   private IEnumerator SpawnAllWaves()
   {
       for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
       {
          var currentWave = waveConfigs[waveIndex];  
          // Iniciar a corrotina de dar spawn nos inimigos, passando a waveConfig
          yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
       }
   }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig wave)
    {
        for (int i = 0; i < wave.GetNumberOfEnemies(); i++)
        {
            var newenemy = Instantiate(// Guardando os inimigos
            wave.GetEnemyPrefab(), // Pegar o inimigo da wave
            wave.GetWaypoints()[0].transform.position, // Pegar a posição do primeiro waypoint
            Quaternion.identity
            );

            // Passando a WaveConfig do método para o inimigo instanciado.
            newenemy.GetComponent<EnemyPathing>().SetWaveConfig(wave);

            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }       
    }
}
