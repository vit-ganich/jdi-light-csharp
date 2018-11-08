﻿using System.Reflection;
using JDI.Core.Attributes.Functions;

namespace JDI.Core.Interfaces.Base
{
    public interface IBaseElement
    {
        string Name { get; set; }
        void SetName(FieldInfo field);
        string TypeName { get; set; }
        string ParentTypeName { get; }
        void SetFunction(Functions function);
        IAvatar Avatar { get; set; }
        object Parent { set; get; }
    }
}
