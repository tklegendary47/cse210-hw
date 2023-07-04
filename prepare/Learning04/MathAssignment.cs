class MathAssignment : Assignment
{
    private String _textbookSection;
    private String _problems;

    public MathAssignment(string studentName, string topic, string _textbookSection, string _problems) : base(studentName, topic)
    {
        this._textbookSection = _textbookSection;
        this._problems = _problems;

    }

    public String GetHomeworkList(){
        return "Section " + _textbookSection + " Problems " + _problems;
    }
}