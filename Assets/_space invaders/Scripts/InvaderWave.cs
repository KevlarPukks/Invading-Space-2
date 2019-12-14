
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

using static UnityEngine.Camera;
[CreateAssetMenu(fileName = "InvaderWave")]
public class InvaderWave : Wave
{
    
    [SerializeField] private GameObject[] enemyObjOnEachRow;
    [SerializeField] private float startPosX = 1;
       [SerializeField] public float area = 0.5f;
    [SerializeField] public float startSpeed = 0.5f;

    [SerializeField, Range(0.1f, 100)] private float speedIncreasePercentPerSec;
    [SerializeField] private float moveDownTime;
    private float moveDownTimer = 0.5f;
    private bool moveDown;
    private bool moveLeft = true;
    [SerializeField] private float offScreenOffSet;
    [ShowInInspector] private float moveSpeed;
    private bool spawning = true;
    public override float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public override float StartSpeed { get; set; }

    public override void Start()
    {


    }
    public override IEnumerator _Init()
    {
        moveSpeed = startSpeed;
        foreach (var enemy in enemies)
        {

            EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
            enemy.transform.position = enemyBehaviour.startPos;
            enemyBehaviour.CapCollider.enabled = true;

            enemy.gameObject.SetActive(false);
        }
        yield return null;
    }

    public override void SpawnInvaders(GameObject enemyHolder)
    {
        StartSpeed = startSpeed;
        moveSpeed = startSpeed;
        enemies.Clear();
        enemyholder = enemyHolder;
       DrawGrid2();

    }
    
    public override IEnumerator  DrawGrid()
    {
        if (main == null) yield return null;
        spawning = true;
        var b = main.ViewportToWorldPoint(new Vector3(0, 1, 10f));
        var x = b.x + startPosX; // Define x.
        var y = b.y - area;
        for (int row = 0; row <enemyObjOnEachRow.Length; row++)
        {
            for (int col = 0; col < 15; col++)
            {
                var xObject = Instantiate(enemyObjOnEachRow[row], enemyholder.transform, true);
                xObject.transform.position = new Vector2(x, y);

                enemies.Add(xObject);
                xObject.GetComponent<EnemyBehaviour>().startPos = new Vector2(x, y);
                Debug.Log(x + "  " + y);
                yield return new WaitForSeconds(0.01f);
                x += area;
                if (x > main.ViewportToWorldPoint(new Vector3(1, 0, 10f)).x)
                {
                    yield return new WaitForSeconds(0.25f);
                    break;
                }
            }
            y -= area;
            x = b.x + startPosX;
        }
        spawning = false;
    }
    public   void DrawGrid2()
    {
        if (main == null) return;
        spawning = true;
        var b = main.ViewportToWorldPoint(new Vector3(0, 1, 10f));
        var x = b.x + startPosX; // Define x.
        var y = b.y - area;
        for (int row = 0; row < enemyObjOnEachRow.Length; row++)
        {
            for (int col = 0; col < 15; col++)
            {
                var xObject = Instantiate(enemyObjOnEachRow[row], enemyholder.transform, true);
                xObject.transform.position = new Vector2(x, y);
                xObject.GetComponent<EnemyBehaviour>().startPos = new Vector2(x, y);
                xObject.SetActive(false);
                enemies.Add(xObject);
               
                x += area;
                if (x > main.ViewportToWorldPoint(new Vector3(1, 0, 10f)).x)
                {
                   
                    break;
                }
            }
            y -= area;
            x = b.x + startPosX;
        }
        spawning = false;
    }
    public override void Update()
    {
        if (spawning) return;
        var speedIncrease = startSpeed * (speedIncreasePercentPerSec / 100);
        moveSpeed += speedIncrease * Time.deltaTime;
        if (moveDown)
        {
            MoveDown();
            return;
        }
        if (moveLeft)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }

    private void MoveRight()
    {
        foreach (var enemy in enemies)
        {
            if (enemy.gameObject.activeInHierarchy)
            {
                if (enemy.transform.position.x >
                    Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - offScreenOffSet)
                {
                    moveLeft = true;
                    moveDown = true;
                    break;
                }
            }
        }

        foreach (var enemy in enemies)
        {
            if (enemy.gameObject.activeInHierarchy)
            {
                enemy.transform.Translate(moveSpeed * Time.deltaTime * Vector3.right);
            }
        }
    }

    private void MoveLeft()
    {
        moveDownTimer = 0;
        foreach (var enemy in enemies)
        {
            if (enemy.gameObject.activeInHierarchy)
            {
                if (enemy.transform.position.x <
                    Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + offScreenOffSet)
                {
                    moveLeft = false;
                    moveDown = true;
                    break;
                }
            }
        }

        foreach (var enemy in enemies)
        {
            if (enemy.gameObject.activeInHierarchy)
            {
                enemy.transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);
            }
        }
    }

    private void MoveDown()
    {
        foreach (var enemy in enemies)
        {
            if (enemy.gameObject.activeInHierarchy)
            {
                enemy.transform.Translate(moveSpeed * Time.deltaTime * Vector3.down);
            }
        }

        moveDownTimer += Time.deltaTime * 1;

        if (moveDownTimer >= moveDownTime)
        {
            moveDownTimer = 0;
            moveDown = false;
        }
    }
}
