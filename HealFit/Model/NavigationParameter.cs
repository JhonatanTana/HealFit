namespace HealFit.Model;
public class NavigationParameter {
    public string Name { get; set; }
    public object Value { get; set; }

    public NavigationParameter(string name, object value) {
        Name = name;
        Value = value;
    }
}
