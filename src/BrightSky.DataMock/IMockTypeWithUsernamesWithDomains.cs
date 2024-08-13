namespace BrightSky.DataMock;

public interface IMockTypeWithUsernamesWithDomains<in T, out TMockType> where TMockType : IMockType<T>
{
    TMockType WithUsernames(MockTypeFormattedString formattedString);
    TMockType WithUsernames(IEnumerable<T> values);
    TMockType WithDomains(MockTypeFormattedString formattedString);
    TMockType WithDomains(IEnumerable<T> values);    
}