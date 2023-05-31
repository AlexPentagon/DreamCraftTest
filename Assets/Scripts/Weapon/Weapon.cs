using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform projectilesHolder;
    public float SecondsCooldown { get => secondsCooldown; private set => SecondsCooldown = SecondsCooldown; }
    public float LastShotTime { get => lastShotTime; private set => LastShotTime = LastShotTime; }


    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;

    [Min(1)]
    [SerializeField] int projectilesPerShoot;

    [Range(1, 360)]
    [SerializeField] float projectilesSpread;

    [SerializeField] float secondsCooldown;


    private float lastShotTime;

    private List<GameObject> freeProjectilesPool = new List<GameObject>();
    private List<GameObject> projectilesList = new List<GameObject>();


    public void Shoot()
    {
        if (Time.time - lastShotTime < secondsCooldown)
            return;

        lastShotTime = Time.time;

        if (projectilesPerShoot == 1)
        {
            SpawnProjectile(0);
        }
        else
        {
            var startAngle = projectilesSpread / 2f * -1f;
            var angleStep = projectilesSpread / (projectilesPerShoot - 1);

            for (int i = 0; i < projectilesPerShoot; i++)
            {
                var currentAngle = startAngle + angleStep * i;
                SpawnProjectile(currentAngle);
            }
        }
    }

    private GameObject SpawnProjectile(float angle)
    {
        var projectileRotation = Quaternion.Euler(firePoint.rotation.eulerAngles + Vector3.forward * angle);

        if (freeProjectilesPool.Count == 0)
        {
            var projectileObj = Instantiate(projectilePrefab, firePoint.position, projectileRotation);
            projectileObj.transform.parent = projectilesHolder;
            projectilesList.Add(projectileObj);
            projectileObj.GetComponent<Projectile>().OnProjectileFinished += ProjectileFinished;
            return projectileObj;
        }
        else
        {
            var projectileObj = freeProjectilesPool[0];
            projectileObj.transform.position = firePoint.position;
            projectileObj.transform.rotation = projectileRotation;
            freeProjectilesPool.RemoveAt(0);
            projectileObj.SetActive(true);
            return projectileObj;
        }
    }

    private void ProjectileFinished(GameObject proj)
    {
        proj.SetActive(false);
        freeProjectilesPool.Add(proj);

    }
}
