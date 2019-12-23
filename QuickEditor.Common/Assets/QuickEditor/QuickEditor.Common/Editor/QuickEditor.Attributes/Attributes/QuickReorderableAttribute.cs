using System;
using UnityEngine;

namespace QuickEditor.Attributes
{
    public class QuickReorderableAttribute : PropertyAttribute
    {
        public bool add;
        public bool remove;
        public bool draggable;
        public bool singleLine;
        public bool paginate;
        public bool sortable;
        public int pageSize;
        public string elementNameProperty;
        public string elementNameOverride;
        public string elementIconPath;
        public Type surrogateType;
        public string surrogateProperty;

        public QuickReorderableAttribute()
            : this(null)
        {
        }

        public QuickReorderableAttribute(string elementNameProperty)
            : this(true, true, true, elementNameProperty, null, null)
        {
        }

        public QuickReorderableAttribute(string elementNameProperty, string elementIconPath)
            : this(true, true, true, elementNameProperty, null, elementIconPath)
        {
        }

        public QuickReorderableAttribute(string elementNameProperty, string elementNameOverride, string elementIconPath)
            : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
        {
        }

        public QuickReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementIconPath = null)
            : this(add, remove, draggable, elementNameProperty, null, elementIconPath)
        {
        }

        public QuickReorderableAttribute(bool add, bool remove, bool draggable, string elementNameProperty = null, string elementNameOverride = null, string elementIconPath = null)
        {
            this.add = add;
            this.remove = remove;
            this.draggable = draggable;
            this.elementNameProperty = elementNameProperty;
            this.elementNameOverride = elementNameOverride;
            this.elementIconPath = elementIconPath;

            sortable = true;
        }
    }
}