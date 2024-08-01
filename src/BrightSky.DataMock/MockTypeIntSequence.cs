namespace BrightSky.DataMock;

public record MockTypeIntSequence : 
    IMockType<int>, 
    IMockTypeToList<int>, 
    IMockTypeRange<int, int, int, MockTypeIntSequence>, 
    IMockTypeIncrement<int, MockTypeIntSequence>,
    IMockTypeOrdering<int, MockTypeIntSequence>
{
    private int _minValue;
    private int _maxValue = 1000;
    private int _increment = 1;
    private bool _descending;
    private int _current;
    private int _previous;
    private bool _firstCall = true;
    
    public MockTypeIntSequence Range(int minValue, int maxValue)
    {
        if (maxValue < minValue) 
            throw new ArgumentOutOfRangeException(nameof(minValue), $"{nameof(minValue)} {minValue} cannot be less than {nameof(minValue)} {minValue}.");

        _minValue = minValue;
        _maxValue = maxValue;
        return this;
    }

    public MockTypeIntSequence Increment(int increment)
    {
        _increment = increment;
        return this;
    }

    public List<int> ToList()
    {
        var list = new List<int>();
        var loopFor = _maxValue - _minValue;
        for (var i = 0; i <= loopFor; i += _increment)
            list.Add(Get());

        return list;
    }

    public int Get()
    {
        _current = _descending 
            ? UncheckedDescending(_previous, _current, _increment, _minValue, _maxValue, _firstCall) 
            : UncheckedAscending(_previous, _current, _increment, _minValue, _maxValue, _firstCall);
        _previous = _current;
        _firstCall = false;
        
        return _current;
    }

    private static int UncheckedAscending(int previous, int current, int increment, int minValue, int maxValue, bool firstCall)
    {
        current = unchecked(current + increment);
        if (firstCall)
            current = minValue;
        if (previous > 0 && current < 0)
            current = int.MaxValue;
        if (current >= maxValue)
            current = maxValue;
        
        return current;
    }

    private static int UncheckedDescending(int previous, int current, int increment, int minValue, int maxValue, bool firstCall)
    {
        current = unchecked(current - increment);
        if (firstCall)
            current = maxValue;
        if (previous < 0 && current > 0)
            current = int.MinValue;
        if (current <= minValue)
            current = minValue;

        return current;
    }

    public MockTypeIntSequence Ascending()
    {
        _descending = false;
        return this;
    }
    
    public MockTypeIntSequence Descending()
    {
        _descending = true;
        return this;
    }
}