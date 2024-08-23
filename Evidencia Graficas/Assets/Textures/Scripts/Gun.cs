using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public int bulletCount = 5;
    public float spreadAngle = 45f;
    public float bulletSpeed = 10f;
    public int bulletCountTotal = 0;
    public int bulletCountAlive = 0;
    private float nextTimeToFire = 1f;

    public TextMeshProUGUI bulletCountText;

    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate;
        }
    }

    void UpdateBulletCountText()
    {
        bulletCountText.text = "Bullets Alive: " + bulletCountAlive;
    }

    public void CountBullet()
    {
        bulletCountTotal++;
        bulletCountAlive++;
        UpdateBulletCountText();
    }

    private void SetBulletShooter(GameObject bullet)
    {
       
        if (bullet.CompareTag("Sphere1"))
        {
            return; 
        }
        bullet.GetComponent<Damage>().shooter = this.gameObject;
    }

    public void ShootOne()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.transform.forward = firePoint.forward * bulletSpeed;

        bulletCountAlive++;
        UpdateBulletCountText();

        bullet.GetComponent<BulletMovement>().OnDestroyAction = () =>
        {
            bulletCountAlive--;
            UpdateBulletCountText();
        };

        SetBulletShooter(bullet);
    }

    public void ShootPatternRight()
    {
        spreadAngle = 45f;
        for (int i = 0; i < bulletCount; i++)
        {
            float startAngle = spreadAngle / 2;
            float angleStep = spreadAngle / (bulletCount - 1);
            float angle = startAngle - i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            bullet.transform.forward = bullet.transform.rotation * Vector3.forward * bulletSpeed;

            CountBullet();
            bullet.GetComponent<BulletMovement>().OnDestroyAction = () =>
            {
                bulletCountAlive--;
                UpdateBulletCountText();
            };

            SetBulletShooter(bullet);
        }
    }

    public void ShootPatternLeft()
    {
        spreadAngle = 45f;
        for (int i = 0; i < bulletCount; i++)
        {
            float startAngle = -spreadAngle / 2;
            float angleStep = spreadAngle / (bulletCount - 1);
            float angle = startAngle + i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            bullet.transform.forward = bullet.transform.rotation * Vector3.forward * bulletSpeed;

            CountBullet();
            bullet.GetComponent<BulletMovement>().OnDestroyAction = () =>
            {
                bulletCountAlive--;
                UpdateBulletCountText();
            };

            SetBulletShooter(bullet);
        }
    }

    public void ShootPatternCircle()
    {
        spreadAngle = 360f;
        float angleStep = spreadAngle / bulletCount;
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            Quaternion rotation = Quaternion.Euler(0, angle, 0);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            bullet.transform.forward = bullet.transform.rotation * Vector3.forward * bulletSpeed;

            CountBullet();
            angle += angleStep;

            bullet.GetComponent<BulletMovement>().OnDestroyAction = () =>
            {
                bulletCountAlive--;
                UpdateBulletCountText();
            };

            SetBulletShooter(bullet);
        }
    }

    public void ShootPatternCircunference()
    {
        int bulletCount = 100;
        float radius = 1f;
        float angleStep = 2 * Mathf.PI / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            float t = i * angleStep;
            float x = 16 * Mathf.Pow(Mathf.Sin(t), 3);
            float y = 13 * Mathf.Cos(t) - 5 * Mathf.Cos(2 * t) - 2 * Mathf.Cos(3 * t) - Mathf.Cos(4 * t);

            Vector3 direction = new Vector3(x, 0, y).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            bullet.transform.forward = direction * bulletSpeed;

            CountBullet();
            bullet.GetComponent<BulletMovement>().OnDestroyAction = () =>
            {
                bulletCountAlive--;
                UpdateBulletCountText();
            };

            SetBulletShooter(bullet);
        }
    }

    public void ShootPatternStar()
    {
        int points = 8;
        int spikes = 2;
        float radius = 1f;

        for (int i = 0; i < points * spikes; i++)
        {
            float t = (float)i / (points * spikes) * Mathf.PI * 2;
            float angleDegrees = t * 180f / Mathf.PI;
            float r = Mathf.Sin(5 * (angleDegrees * Mathf.PI / 360)) * radius;

            float x = r * Mathf.Cos(t);
            float z = r * Mathf.Sin(t);

            Vector3 direction = new Vector3(x, 0, z).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            bullet.transform.forward = direction * bulletSpeed;

            CountBullet();
            bullet.GetComponent<BulletMovement>().OnDestroyAction = () =>
            {
                bulletCountAlive--;
                UpdateBulletCountText();
            };

            SetBulletShooter(bullet);
        }
    }

    public void ShootPatternEnd()
    {
        spreadAngle = 90f;
        for (int i = 0; i < bulletCount; i++)
        {
            float startAngle = -spreadAngle / 2;
            float angleStep = spreadAngle / (bulletCount - 1);
            float angle = startAngle + i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            bullet.transform.forward = bullet.transform.rotation * Vector3.forward * bulletSpeed;

            CountBullet();
            bullet.GetComponent<BulletMovement>().OnDestroyAction = () =>
            {
                bulletCountAlive--;
                UpdateBulletCountText();
            };

            SetBulletShooter(bullet);
        }
    }

    public void BombBurble()
    {
        Vector3 direction1 = Vector3.forward;
        Vector3 direction2 = Vector3.right;
        Vector3 direction3 = Vector3.back;
        Vector3 direction4 = Vector3.left;

        BurbleHelper(direction1);
        BurbleHelper(direction2);
        BurbleHelper(direction3);
        BurbleHelper(direction4);
    }

    public void BurbleHelper(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.transform.forward = direction * bulletSpeed;

        CountBullet();
        bullet.GetComponent<BulletMovement>().OnDestroyAction = () =>
        {
            bulletCountAlive--;
            UpdateBulletCountText();
        };

        SetBulletShooter(bullet);
    }
}
