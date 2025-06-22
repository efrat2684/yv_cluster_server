public class ValueCodeItem
{
    public string Code { get; set; }
    public string Value { get; set; }
    public ValueCodeItem(string value, string code)
    {
        Value = value;
        Code = code;
    }
}