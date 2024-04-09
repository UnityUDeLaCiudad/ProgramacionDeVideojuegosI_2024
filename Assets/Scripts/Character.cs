using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    public int age;
    [SerializeField] private float health;
    [SerializeField] private float spinAngle;
    private double physicsAcceleration;
    [SerializeField] private string characterName;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float bulletDelay = 0.5f;
    private float currentBulletDelay;

    public int Sum(int number1, int number2)
    {
        int sum = number1 + number2;
        return sum;
    }

    public void FuncionTest()
    {
        var suma = 4 + 4;
        var resta = 4 - 4;
        var multiplicacion = 4 * 4;
        var division = 4 / 4;
        var sumaCompleja = 4 + 4 + 18;
        var operacionCompleja = (4 - 2 * 3) / 6;

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

        var modulo = 4 % 2;

        var esMenor = 6 < 8;
        var esMenorOIgual = 6 <= 8;
        var esMayor = 6 > 8;
        var esMayorOIgual = 6 >= 8;

        bool isNamePanchito = characterName == "Panchito";
        bool isNameNotPanchito = characterName != "Panchito";

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
    }

    private void Start()
    {
        print("Esto es el start");
        transform.position += offsetPosition;
    }

    private void Shoot()
    {
        currentBulletDelay = 0;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    private void Update()
    {
        //Si el personaje esta vivo, entonces lo muevo y lo roto
        // if (health > 0)
        // {
        //     transform.position += offsetPosition;
        //     // Rotate();
        // }
        // else
        // {
        //     print("Panchito esta muerto");
        // }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 rightAxis = horizontal * transform.right;
        Vector3 forwardAxis = vertical * transform.forward;
        Vector3 direction = rightAxis + forwardAxis;
        direction.y = 0;

        currentBulletDelay += Time.deltaTime;

        // //Chequear movimiento
        // if (Input.GetKey(KeyCode.W))
        // {
        //     //Mover hacia adelante
        //     print("Me muevo hacia adelante");
        //     Vector3 forward = transform.forward;
        //     direction += forward;
        //     // transform.position += forward * (speed * Time.deltaTime);
        // }
        //
        // if (Input.GetKey(KeyCode.S))
        // {
        //     //Mover hacia atras
        //     print("Me muevo hacia atras");
        //     Vector3 forward = transform.forward;
        //     direction -= forward;
        //     // transform.position -= forward * (speed * Time.deltaTime);
        // }
        //
        // if (Input.GetKey(KeyCode.A))
        // {
        //     //Mover hacia la izquierda
        //     print("Me muevo hacia la izquierda");
        //     Vector3 right = transform.right;
        //     direction -= right;
        //     // transform.position -= right * (speed * Time.deltaTime);
        // }
        //
        // if (Input.GetKey(KeyCode.D))
        // {
        //     //Mover hacia la derecha
        //     print("Me muevo hacia la derecha");
        //     Vector3 right = transform.right;
        //     direction += right;
        // }

        // if (Input.GetMouseButtonDown(0))
        // {
        //     Shoot();
        // }

        // CalculateRotation(horizontal);

        if (Input.GetButton("Fire1") && currentBulletDelay >= bulletDelay)
        {
            Shoot();
        }

        if (Input.GetButton("Rotate"))
        {
            Rotate();
        }

        direction = direction.normalized;

        transform.position += direction * (speed * Time.deltaTime);
    }

    // private void CalculateRotation(float horizontal)
    // {
    //     transform.Rotate(Vector3.up, spinAngle * horizontal * Time.deltaTime, Space.Self);
    // }

    private void Rotate()
    {
        Vector3 rotationX = Vector3.right * 10;
        Vector3 rotationZ = Vector3.forward * 35;
        Vector3 rotationAxis = (rotationX + rotationZ).normalized;
        transform.Rotate(rotationAxis, spinAngle, Space.World);
    }
}