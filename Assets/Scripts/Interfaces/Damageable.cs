using System.Collections;
using System.Collections.Generic;

public interface Damageable
{ 
    void ReceiveDamage(DamageCommand command); //Anything that can take damage must have some way to take a damage value and apply it to itself.
    
    void Die(); //Anything that can take damage must have a process for dying/being destroyed.
    
}
