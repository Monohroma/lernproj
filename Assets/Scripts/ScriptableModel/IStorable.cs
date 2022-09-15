using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStorable
{
    public bool Load();
    public bool Save();
}
