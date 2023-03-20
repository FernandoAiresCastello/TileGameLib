using System;
using System.Collections;
using System.Collections.Generic;

public struct Binary
{
    public string Bits => _value;
    public int Length => _value.Length;

    private string _value;

    public static implicit operator Binary(string value)
    {
        return new Binary { _value = value };
    }

    public static implicit operator string(Binary value)
    {
        return value._value;
    }
}
