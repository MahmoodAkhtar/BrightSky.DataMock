﻿using System.Reflection;

namespace BrightSky.DataMock;

public class ListOfNullableByteParameterInfoHandler : IParameterInfoHandler
{
    public object? Handle(ParameterInfo parameterInfo)
        => parameterInfo.ParameterType == typeof(List<byte?>) ? Dm.ListsOf<byte?>() : null;
}