namespace Application.Common
{

    public class JqueryDatatableParam
    {
        public string SEcho { get; set; }
        public string SSearch { get; set; }
        public int IDisplayLength { get; set; }
        public int IDisplayStart { get; set; }
        public int IColumns { get; set; }
        public int ISortCol0 { get; set; }
        public string SSortDir_0 { get; set; }
        public int ISortingCols { get; set; }
        public string SColumns { get; set; }
        public Guid Type { get; set; }
    }
}


public class JqueryTrackDataTableParam
{
    public string SEcho { get; set; }
    public string SSearch { get; set; }
    public int IDisplayLength { get; set; }
    public int IDisplayStart { get; set; }
    public int IColumns { get; set; }
    public int ISortCol0 { get; set; }
    public string SSortDir_0 { get; set; }
    public int ISortingCols { get; set; }
    public string SColumns { get; set; }

    public string FromDate { get; set; }
    public string ToDate { get; set; }
    public string FromHours { get; set; }
    public string ToHours { get; set; }


}

