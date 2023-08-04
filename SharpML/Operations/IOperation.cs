namespace SharpML.Operations;

public interface IOperation<T>
{
    public IEnumerable<T> Forward(IEnumerable<T> input);
    public IEnumerable<T> Backward(IEnumerable<T> outputGrad);
}