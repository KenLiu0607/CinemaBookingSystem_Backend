namespace Backend.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuditLogAttribute : Attribute
    {
        public string Action { get; set; }

        //public AuditLogAttribute(string action)
        //{
        //    Action = action;
        //}
    }
}
