namespace QuickEditor.Attributes
{
    using UnityEngine;
    using System;

    [AttributeUsage(AttributeTargets.Field, Inherited = true)]
    public class ReadOnlyAttribute : PropertyAttribute
    {
    }
}