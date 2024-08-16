namespace BrightSky.DataMock;

public interface IMockTypeParam<in T, out TMockType> where TMockType : IMockType<T>
{
    List<MockParamValue> ParamValues { get; }
    TMockType Param<TParam>(string paramName, Func<IMockType<TParam>> typeFactory);
}