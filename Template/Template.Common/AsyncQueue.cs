using System.Threading.Tasks.Dataflow;

namespace Template.Common;

public class AsyncQueue<T> : IAsyncEnumerable<T>
{
    private readonly SemaphoreSlim _enumerationSemaphore = new(1);
    private readonly BufferBlock<T> _bufferBlock = new();

    public void Enqueue(T item) => _bufferBlock.Post(item);

    public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken token = default)
    {
        await _enumerationSemaphore.WaitAsync(CancellationToken.None);
        try
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();
                yield return await _bufferBlock.ReceiveAsync(token);
            }
        }
        finally
        {
            _enumerationSemaphore.Release();
        }
    }
}