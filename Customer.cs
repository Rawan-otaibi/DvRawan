using System;

public class Customer : BaseObject
{
    private string name;
    private string phone;
    private string status;

    public Customer(Session session) : base(session) { }

    [Size(40)]
    public string Name
    {
        get => name;
        set => SetPropertyValue(nameof(Name), ref name, value);
    }

    [RuleRequiredField]
    [RuleRegularExpression(@"^05\d{8}$", CustomMessageTemplate = "Phone must be in the format 05XXXXXXXX")]
    [ImmediatePostData]
    public string Phone
    {
        get => phone;
        set => SetPropertyValue(nameof(Phone), ref phone, value);
    }

    [RuleEnumField("ValidStatus", typeof(CustomerStatus))]
    public string Status
    {
        get => status;
        set => SetPropertyValue(nameof(Status), ref status, value);
    }
}

public enum CustomerStatus
{
    Active,
    Inactive,
    Banned
}