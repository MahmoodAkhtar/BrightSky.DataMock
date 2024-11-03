﻿using System.Reflection;

namespace BrightSky.DataMock;

public class ListOfNullableCharParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(List<char?>) ? Dm.ListsOf<char?>() : null;
}