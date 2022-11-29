namespace Cloud.DynamicExpress
{
    public class Filter
    {
        public Filter() { }

        public Filter(QueryFilter filter)
        {
            PropertyName = filter.PropertyName;
            Op = filter.Op;
            Value = filter.Val;
        }

        public string PropertyName { get; set; }
        public Operation Op { get; set; }
        public virtual object Value { get; set; }
    }

    public class QueryFilter : Filter
    {

        public string Val { get; set; }
    }
}
