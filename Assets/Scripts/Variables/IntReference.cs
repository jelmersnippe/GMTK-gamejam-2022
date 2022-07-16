using System;

[Serializable]
public class IntReference
{
    public bool UseConstant = true;
    public int ConstantValue;
    public IntVariable Variable;

    public IntReference()
    { }

    public IntReference(int value)
    {
        UseConstant = true;
        ConstantValue = value;
    }

    public int Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }

    public static implicit operator int(IntReference reference)
    {
        return reference.Value;
    }

    public void ApplyChange(int change)
    {
        if (UseConstant)
        {
            ConstantValue += change;
        }
        else
        {
            Variable.ApplyChange(change);
        }
    }

    public void SetValue(int value)
    {

        if (UseConstant)
        {
            ConstantValue = value;
        }
        else
        {
            Variable.SetValue(value);
        }
    }
}
