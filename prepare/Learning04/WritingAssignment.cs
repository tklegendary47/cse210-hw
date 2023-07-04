class WritingAssignment: Assignment{
    private String _title;

    public WritingAssignment(string studentName, string topic, String _title) : base(studentName, topic)
    {
        this._title = _title;
    }

    public String GetWritingInformation(){
        return _title;
    }
}