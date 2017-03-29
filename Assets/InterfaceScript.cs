using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void TakeDamage(float damage);
}

public interface IDamageDealer
{
    float DealDamage();
}

public interface IToggle
{
    void toggleActive();
}
