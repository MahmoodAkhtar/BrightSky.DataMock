namespace BrightSky.DataMock;

public interface IMockTypeParam<in T, out TMockType> where TMockType : IMockType<T>
{
    List<ParamValue> ParamValues { get; }
    TMockType Param<TParam>(string paramName, Func<IMockType<TParam>> func);
}