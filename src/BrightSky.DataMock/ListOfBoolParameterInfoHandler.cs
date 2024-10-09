﻿using System.Reflection;

namespace BrightSky.DataMock;

public class ListOfBoolParameterInfoHandler: IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(List<bool>) ? Dm.ListsOf<bool>() : null;
}