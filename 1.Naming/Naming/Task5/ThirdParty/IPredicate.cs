namespace Naming.Task5.ThirdParty
{
    public interface IPredicate<in T>
    {
        bool Test(T fileName);
    }
}
