using System;

using UnityEngine;

using Esuriru.Utility.Extensions;

namespace Esuriru.Utility
{
    /// <summary>
    /// Attribute for conditional fields in Unity Inspector
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ShowIfAttribute : PropertyAttribute
    {
        /// <summary>
        /// Type of disability for field
        /// </summary>
        public enum Type
        {
            Hide,
            ReadOnly
        }

        /// <summary>
        /// Name of field the attribute is on
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Value of field the attribute is on
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// Type of disable for this attribute
        /// </summary>
        public Type DisableType { get; private set; }

        /// <summary>
        /// ShowIfAttribute constructor  
        /// </summary>
        /// <param name="name">Name of the dependent field/property</param>
        /// <param name="value">Target value on dependent to show</param>
        /// <param name="property">Is attribute on property</param>
        /// <param name="disableType">Type of disable</param>
        public ShowIfAttribute(string name, object value,
            bool property = false, Type disableType = Type.Hide)
        {
            Name = property ? name.BackingField() : name;

            Value = value;
            DisableType = disableType;
        }
    }
}
