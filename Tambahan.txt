Muhammad Nasik Iqbal/463

Fitur yang saya tambah:

1. pengurangan spawnDelay enemy jika sudah mencapai jumlah 10 dan 3
Jadi, ketika jumlah total enemy tersisa 10 dan 3, maka kecepatan spawnnya akan bertambah

Pengubahan pada GameObject Level 1:
Spawn Delay awal: 8

Kode yang ditambah di script LevelManager:
//...
    public void SetTotalEnemy(int totalEnemy)
    {
        _enemyCounter = totalEnemy;
        _totalEnemyInfo.text = $"Total Enemy: {Mathf.Max(_enemyCounter, 0)}";

        if (totalEnemy == 10)			// mulai dari sini
        {
            _spawnDelay -= 2;
        }
        else if (totalEnemy == 3)
        {
            _spawnDelay -= 4;
        }					// sampai sini
    }
//...

2. Pemanggilan fungsi ReduceLives(1) supaya nyawa player berkurang 1 ketika enemy mencapai sisi lain, sehingga dapat menciptakan lose condition

Kode yang ditambah di script LevelManager:
//...
            if (Vector2.Distance(enemy.transform.position, enemy.TargetPosition) < 0.1f)
            {
                enemy.SetCurrentPathIndex(enemy.CurrentPathIndex + 1);
                if (enemy.CurrentPathIndex < _enemyPaths.Length)
                {
                    enemy.SetTargetPosition(_enemyPaths[enemy.CurrentPathIndex].position);
                }
                else
                {
                    ReduceLives(1);			// yang ditambah
                    enemy.gameObject.SetActive(false);
                }
            }
//...

3. Klik untuk mengulang permainan setelah menang atau kalah, Jadi ketika permainan selesai player tinggal menekan tombol mouse untuk mengulang lagi dari awal
 Yang ditambah:
-> GameObject Try yang berisi teks "Tap any button to try again"
-> Skript End yang berisi:

using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // reload screen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
Kemudian skript dimasukkan ke Inspector Panel

Sisanya sudah sesuai dengan tutorial pada DiLo Game Academy

