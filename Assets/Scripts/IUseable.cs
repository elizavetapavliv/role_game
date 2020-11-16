using System;
using UnityEngine;

interface IUseable
{
    Sprite MyIcon { get; }
    void Use();
}