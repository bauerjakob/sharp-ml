using SharpML.Exceptions;

namespace SharpML.Operations;

public abstract class Operation<T> : IOperation<T>
{
    protected IEnumerable<T> _input;
    protected IEnumerable<T> _output; 

    public IEnumerable<T> Forward(IEnumerable<T> input)
    {
        _input = input; 
        CheckForward(input);
        _output = ForwardImpl(input);
        
        return _output;
    }

    public IEnumerable<T> Backward(IEnumerable<T> outputGrad)
    {
        CheckBackward(outputGrad);
        return BackwardImpl(outputGrad);
    }
    
    public virtual void CheckForward(IEnumerable<T> input)
    {
        
    }
    
    public virtual void CheckBackward(IEnumerable<T> outputGrad)
    {
        CheckSameShape(_input, outputGrad);
    }
    
    public abstract IEnumerable<T> ForwardImpl(IEnumerable<T> input);

    public abstract IEnumerable<T> BackwardImpl(IEnumerable<T> outputGrad);

    private void CheckSameShape(IEnumerable<T> a, IEnumerable<T> b)
    {
        if (a.Count() != b.Count())
        {
            throw new ShapeMismatchException();
        }
    }
}