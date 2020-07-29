namespace UniEnumUtils
{
    interface IUnderlyingOperation<T>
    {
        bool TryParse(string text, out T result);
        bool IsDefined(T value);

        T GetMinValue();
        T GetMaxValue();
    }
}
