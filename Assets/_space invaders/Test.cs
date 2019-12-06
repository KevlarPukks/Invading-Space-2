using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Test : MonoBehaviour
{
    private void Start()
    {
     Person james = new Man();
       // Debug.Log(james.name);
    }
}
public abstract class Person
{
    private int myProperty;

    public virtual string name { get => throw new NotImplementedException(); set=>throw new NotImplementedException(name+"not implented yet"); }
    public virtual void ChangeName(string newname)
    {
        name = newname;
    }
     public int MyProperty { get => myProperty; private set => myProperty = value; }

}
public interface Idick
{
    float dickLength { get; set; }
}
public class Man : Person,Idick
{
    public Test test;
    
    private string thisname = "jim";
    public override string name { get; set ; }
    public float dickLength { get; set; }
   public Man()
    {
      //  Debug.Log(name);
        name = thisname;
    }

}