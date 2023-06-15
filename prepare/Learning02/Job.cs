public class Job{
    public string _company {get; set;}
    public string _jobTitle {get; set;}
    public int _startYear {get;set;}
    public int _endYear {get;set;}
    public void Display(){
        Console.WriteLine($"{this._jobTitle} ({this._company}) {this._startYear}-{this._endYear}");
    }
}