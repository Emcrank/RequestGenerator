using System.Reflection;
using System.Windows;
using RequestGenerator.Logic.Requests;
using RequestGenerator.WPFApp.Views;
using Expression = System.Linq.Expressions.Expression;

namespace RequestGenerator.WPFApp.Services;

public static class RequestEditWindowFactory
{
    private static readonly Dictionary<string, Func<Window>> windowBindings = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(x => x.GetTypes())
        .Where(x => typeof(Request).IsAssignableFrom(x) && !x.IsAbstract)
        .ToDictionary(
            k => k.Name,
            v =>
            {
                var mainWindowType = typeof(MainWindow);
                //Get page type
                string pageName = $"{mainWindowType.Namespace}.{v.Name}EditWindow";
                var pageType = Assembly.GetAssembly(mainWindowType)?.GetType(pageName) ??
                               throw new InvalidOperationException($"Unable to find page type '{pageName}'");

                //Create new expression
                var constructor = pageType.GetConstructor(Type.EmptyTypes) ??
                                  throw new InvalidOperationException($"Unable to find constructor with no parameters for type '{v.Name}'.");
                var instanceFactory = Expression.Lambda<Func<Window>>(Expression.New(constructor)).Compile();
                return instanceFactory;
            });

    public static IList<string> WindowNames { get; } = windowBindings.Keys.ToList();

    public static Window CreateWindow(string requestName) => windowBindings[requestName]();
}