namespace SharpML.Operations;

public abstract class ParamOperation<T, TP> : Operation<T>
{
    protected readonly TP _parameter;
    
    public ParamOperation(TP parameter)
    {
        _parameter = parameter;
    }

    public TP Parameter => _parameter;


}