
    using System.Collections.Generic;
    using Sirenix.OdinInspector;
    using UnityEngine;

    using static UnityEngine.Camera;
[CreateAssetMenu(fileName = "InvaderWave")]
    public class InvaderWave:Wave
    {
        [AssetList]
        [SerializeField] private GameObject enemyObj;
        [SerializeField]   private int amountX = 15;
        [ SerializeField]  private int amountY =10;
        
        [SerializeField] private float startPosX = 1;
        [SerializeField] private float startPosY = 6;
        [SerializeField] public float area=0.5f;
        [SerializeField] float startSpeed =0.5f;
        
        [SerializeField,Range(0.1f,100)] private float speedIncreasePercentPerSec;
        [SerializeField] private float moveDownTime;
        private float moveDownTimer =0.5f;
        private  bool moveDown;
        private  bool moveLeft=true;
     // public  List<GameObject> enemies = new List<GameObject>();
        [SerializeField] private float offScreenOffSet;
       [ShowInInspector] private float moveSpeed;
        public override void Start()
        {
          
            
        }

     
        public override void Init(GameObject enemyHolder)
        {
            moveSpeed = startSpeed;
          enemies.Clear(); 
          enemyholder = enemyHolder;
                    DrawGrid();
                
        }
         public override void DrawGrid()
            {
                if (main == null) return;
                var b =  main.ViewportToWorldPoint(new Vector3(0, 0, 10f));
                var x = b.x+startPosX; // Define x.
                var y = b.y+startPosY; // Define y.
                for (var row = 0; row <= amountX; row++)
                {
                    if (y > main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y- area)
                    {
                        break;
                    }
        
                    // The first for loop, loops through how many rows you want.
                    for (var col = 0; col <= amountY; col++)
                    {
                        // The second one loops through each column.
                       
                        var xObject = Instantiate(enemyObj, enemyholder.transform, true);
                        xObject.transform.position = new Vector2(x, y);
        
                      enemies.Add(xObject);
                      x += area; // Tell the next square to be drawn at the end of this one.
                        if (x > main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-area)
                        {
                           
                            var xObject2 = Instantiate(enemyObj, enemyholder.transform, true);
                            xObject2.transform.position = new Vector2(x, y);
                      enemies.Add(xObject2);
                      
                            break;
                        }
                    }
        
                    y += area; // Tell the next square to be drawn on the next row.
                    x = b.x+startPosX; // Woah! Almost forgot, make sure it starts at the beginning of the row.
                   
                }
            }
        public override void Update()
        {
          var  speedIncrease = startSpeed * (speedIncreasePercentPerSec / 100);
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
