using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Pyronitia
{
    public void idle(int distance);
    public string attack(int distance);
    public void walk(int distance);
    public void run(int distance);
    public void jump(int distance);
}
