﻿using JDI.Light.Interfaces.Base;

namespace JDI.Light.Interfaces.Common
{
    public interface IDataList : IBaseUIElement, ISetValue<bool>
    {
        void Select(string value);
        void Select(int index);
        string GetSelected();
    }
}