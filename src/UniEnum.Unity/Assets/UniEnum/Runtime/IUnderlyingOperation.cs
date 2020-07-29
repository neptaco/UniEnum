namespace UniEnumUtils
{
    interface IUnderlyingOperation<T>
    {
        bool TryParse(string text, out T result);
        bool IsDefined(T value);
        string GetName(T @enum);

        T GetMinValue();
        T GetMaxValue();
    }
}
