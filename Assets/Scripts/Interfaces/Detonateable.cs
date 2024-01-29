using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Detonateable
{
    public void ImpactDetonate(Damageable target); //Triggered on impact with damageable target
    public void TimeOutDetonate();
    public void SecondaryFireDetonate();
}

public enum DetonateType //Save for trackable stats?
{
    Impact,
    Timeout,
    SecondaryFire
}
