using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public Transform memberPrefab;
    public Transform enemyPrefab;
    public Transform playerPrefab;
    public int numberOfMembers;
    public int numberOfEnemies;
    public int numberOfPlayers;
    public List<Member> members;
    public List<Enemy> enemies;
    public List<Player> players;
    public float bounds;
    public float spawnRadius;


    void Start()
    {
        members = new List<Member>();
        enemies = new List<Enemy>();
        players = new List<Player>();

        SpawnEntity(memberPrefab, numberOfMembers);
        SpawnEntity(enemyPrefab, numberOfEnemies);
        SpawnEntity(playerPrefab, numberOfPlayers);

        members.AddRange(FindObjectsOfType<Member>());
        enemies.AddRange(FindObjectsOfType<Enemy>());


    }

    void SpawnEntity(Transform prefab, int count)
    {
        for (int i = 0; i < count; i++){
            Instantiate(prefab, new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), 0), Quaternion.identity);
        }
    }

    public List<Member> GetNeighbors(Member member, float radius)
    {
        List<Member> neighborsFound = new List<Member>();

        foreach (var otherMember in members)
        {
            if (otherMember == member){
                continue;
            }

            if (Vector3.Distance(member.transform.position, otherMember.transform.position) <= radius){
                neighborsFound.Add(otherMember);
            }
        }   

        return neighborsFound;
    }

    public List<Enemy> GetEnemies(Member member, float radius)
    {
        List<Enemy> returnEnemies = new List<Enemy>();

        foreach(var enemy in returnEnemies)
        {
            if(Vector3.Distance(member.position, enemy.position) <= radius){
                returnEnemies.Add(enemy);
            }
        }

        return returnEnemies;
    }


}
