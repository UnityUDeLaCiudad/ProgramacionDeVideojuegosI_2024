using Singleton;
using UnityEngine;
using System;
using UnityEngine.Events;
public class Player : MonoBehaviour
{
    public float speed;
    public int age;
    [SerializeField] private float maxHealth;
    private float health;
    [SerializeField] private float spinAngle;
    private double physicsAcceleration;
    [SerializeField] private string characterName;
    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float bulletDelay = 0.5f;
    [SerializeField] private Rigidbody myRigidbody;
    private float currentBulletDelay;
    private bool canShoot;

    public event Action<float> OnDeath;
    public UnityEvent<float> OnDeathUnity;

    public int Sum(int number1, int number2)
    {
        int sum = number1 + number2;
        return sum;
    }

    public void FuncionTest()
    {
        var suma = 4 + 4;
        var multiplicacion = 4 * 4;
        var division = 4 / 4;

        suma = suma + 1;
        suma += 1;
        suma++;

        suma = suma - 1;
        suma -= 1;
        suma--;

        multiplicacion = multiplicacion * 2;
        multiplicacion *= 2;

        division = division / 3;
        division /= 3;

        bool isNamePanchito = characterName == "Panchito";
        // isAlive = health > 0;
        // bool isDead = !isAlive;
        //
        // bool canMove = isAlive && speed > 0;
        bool canPlay = age >= 18 || isNamePanchito;
    }

    public void SayName()
    {
        print(characterName);
    }

    private void Awake()
    {
        //aca puedo poner el comentario que quiera
        /*
        un comentario
        multi linea
        que usa /*
         */
        SayName();
        print("Esto es el awake");
        health = maxHealth;
        ;
    }

    private void Start()
    {
        print("Esto es el start");
        transform.position += offsetPosition;

        GameManager.Instance.PlayerCreated(this);
        GameManager.Instance.LoadLevelAdditive("LevelUI");
    }

    private void Shoot()
    {
        currentBulletDelay = 0;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    private void Update()
    {
        currentBulletDelay += Time.deltaTime;

        if (Input.GetButton("Fire1") && canShoot && currentBulletDelay >= bulletDelay)
        {
            Shoot();
        }

        if (Input.GetButton("Rotate"))
        {
            Rotate();
        }

        // PhysicLessMovement();
        PhysicsMovement();
    }

    private void PhysicsMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 rightAxis = horizontal * transform.right;
        Vector3 forwardAxis = vertical * transform.forward;
        Vector3 direction = rightAxis + forwardAxis;
        direction.y = 0;
        direction = direction.normalized;
        Vector3 intendedSpeed = direction * speed;
        intendedSpeed.y = myRigidbody.velocity.y;
        myRigidbody.velocity = intendedSpeed;
    }

    private void PhysicLessMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 rightAxis = horizontal * transform.right;
        Vector3 forwardAxis = vertical * transform.forward;
        Vector3 direction = rightAxis + forwardAxis;
        direction.y = 0;
        direction = direction.normalized;

        transform.position += direction * (speed * Time.deltaTime);
    }


    private void Rotate()
    {
        Vector3 rotationX = Vector3.right * 10;
        Vector3 rotationZ = Vector3.forward * 35;
        Vector3 rotationAxis = (rotationX + rotationZ).normalized;
        transform.Rotate(rotationAxis, spinAngle, Space.World);
    }

    public void TakeDamage(float damage)
    {
        var previousHealth = health;
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            //TODO: Evento de muerte del jugador
            OnDeath?.Invoke(previousHealth); //? null propagation
            // ??= null coalescence
            OnDeathUnity?.Invoke(previousHealth);
        }
    }

    public void HealDamage(float healingAmount)
    {
        health += healingAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public enum Difficulty
    {
        Easy,
        EasyMedium,
        Medium,
        MediumAdvanced,
        Hard,
        DarkSouls
    }

    public void SetCanShoot(bool canShoot)
    {
        this.canShoot = canShoot;
    }

    private void SetEnemyAmount(int amount)
    {
    }

    private void SetEnemyDamageRange()
    {
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                // setear enemigos en dificultad facil
                break;
            case Difficulty.EasyMedium:
                //setear enemigos en dificultad easymedium
                break;
            case Difficulty.Medium:
                SetEnemyAmount(2);
                //Codigo que setea un valor en A
                break;
            case Difficulty.MediumAdvanced:
                SetEnemyAmount(2);
                SetEnemyDamageRange();
                break;
            case Difficulty.Hard:
                break;
            case Difficulty.DarkSouls:
                break;
            default:
                Debug.Log("el valor de difficulty no esta contemplado");
                break;
        }
    }

    public void Move()
    {
        Vector3 asdf = new Vector3(0, 0, 1);
        if (asdf != Vector3.zero)
        {
        }

        int initialNumber = 10;
        initialNumber += 4;
        initialNumber /= 3;
        print(initialNumber);
    }
}