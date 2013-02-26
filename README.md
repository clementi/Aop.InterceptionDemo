Aop.InterceptionDemo
====================

A simple demonstration of aspect-oriented programming with Unity dependency injection.

In this demonstration, we use Unity to resolve an `IStarship` and then tell it to go to various warp speeds:

```csharp
public static void Main(string[] args)
{
    IUnityContainer container = new UnityContainer();
    ConfigureContainer(container);

    var starship = container.Resolve<IStarship>(new ParameterOverride("name", "USS Enterprise"));

    starship.GoToWarp(7.5);
    starship.GoToWarp(10);
    starship.GoToWarp(1);
}
```

We tell the ship to go to warp 10, which is an impossible velocity. This throws an `ImpossibleVelocityException`,
but because we're using AOP interception with Unity, the exception is caught and logged&mdash;without us having 
to surround our calls to `GoToWarp` with a `try`/`catch`. Thus the cross-cutting concern of handling and logging
exceptions is handled in the AOP interceptor instead of in every place we call `GoToWarp`.
