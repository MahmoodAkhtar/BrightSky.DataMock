namespace BrightSky.DataMock;

public interface IMockType<out T>
{
    T Get();
}